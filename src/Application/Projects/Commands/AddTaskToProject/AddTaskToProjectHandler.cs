﻿using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Projects.Commands.AddTaskToProject
{
    public class AddTaskToProjectHandler : IRequestHandler<AddTaskToProjectCommand>
    {
        private readonly IApplicationDbContext _context;

        public AddTaskToProjectHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(AddTaskToProjectCommand request, CancellationToken cancellationToken)
        {
            var project = _context.Projects.FirstOrDefault(p => p.Id == request.ProjectId);

            if (project == null)
            {
                return Unit.Value;
            }

            var task = new TaskItem
            {
                ProjectId = request.ProjectId,
                Name = request.Name,
                Status = "TODO"
            };

            project.Tasks.Add(task);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
