﻿
using MediatR;
using BitirmeProjesiBackend.Application.CQRS.Commands;
using BitirmeProjesiBackend.Data.Context;
using BitirmeProjesiBackend.Data.Entities;

namespace BitirmeProjesiBackend.Application.CQRS.CommandHandlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly Context _context;

        public CreateUserCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var createdUser = new User();
            createdUser.Surname = request.Surname;
            createdUser.Username = request.Username;
            createdUser.Name = request.Name;
            createdUser.Password = request.Password;
            createdUser.RoleId = request.RoleId;
            createdUser.Email = request.Email;
            createdUser.Point = request.Point;
            await _context.Users.AddAsync(createdUser);
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
