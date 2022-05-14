﻿using MediatR;

namespace BitirmeProjesiBackend.Application.CQRS.Commands
{
    public class RemoveUserCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveUserCommand(int id)
        {
            Id = id;
        }
    }
}
