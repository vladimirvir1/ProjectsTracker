﻿using MediatR;

namespace Application.Projects.Commands.DeleteProject
{
    public class DeleteProjectCommand : IRequest
    {
        public int Id { get; set; }
    }
}
