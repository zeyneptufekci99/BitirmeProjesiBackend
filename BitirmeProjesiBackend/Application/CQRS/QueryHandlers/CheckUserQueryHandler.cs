
using MediatR;
using Microsoft.EntityFrameworkCore;
using BitirmeProjesiBackend.Application.CQRS.Queries;
using BitirmeProjesiBackend.Application.Dtos;
using BitirmeProjesiBackend.Data.Context;

namespace BitirmeProjesiBackend.Application.CQRS.QueryHandlers
{
    public class CheckUserQueryHandler : IRequestHandler<CheckUserQuery, UserDto?>
    {
        private readonly Context _context;

        public CheckUserQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<UserDto?> Handle(CheckUserQuery request, CancellationToken cancellationToken)
        {
            // lazy, eagle, explicit
           var user = await _context.Users.Select(x=> new UserDto
           {
               Id = x.Id,
               Name = x.Name,
               Password= x.Password,
               Surname=x.Surname,
               Username=x.Username,
               Email = x.Email,
               RoleId = x.RoleId,

           }).AsNoTracking().SingleOrDefaultAsync(x=>x.Username == request.Username && x.Password == request.Password);

            return user;
        }
    }
}
