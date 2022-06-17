
using MediatR;
using BitirmeProjesiBackend.Application.CQRS.Commands;
using BitirmeProjesiBackend.Data.Context;

namespace BitirmeProjesiBackend.Application.CQRS.CommandHandlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly Context _context;

        public UpdateUserCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var updatedUser = await _context.Users.FindAsync(request.Id);
            if (updatedUser != null)
            {
                updatedUser.Surname = request.Surname;
                updatedUser.Username = request.Username;
                updatedUser.Name = request.Name;
                updatedUser.Email = request.Email;
                updatedUser.Password = request.Password;
                updatedUser.RoleId = request.RoleId;
                updatedUser.Point = request.Point;
                _context.SaveChanges();
            }

            return Unit.Value;
        }
    }
}
