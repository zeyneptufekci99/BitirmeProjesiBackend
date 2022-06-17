using MediatR;
using Microsoft.EntityFrameworkCore;
using BitirmeProjesiBackend.Application.CQRS.Queries;
using BitirmeProjesiBackend.Application.Dtos;
using BitirmeProjesiBackend.Data.Context;
using BitirmeProjesiBackend.Data.Entities;

namespace BitirmeProjesiBackend.Application.CQRS.QueryHandlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery,UserDto?>
    {
        private readonly Context _context;

        public GetUserByIdQueryHandler(Context context)
        {
            _context = context;
        }
        public async Task<UserDto?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.AsNoTracking().OfType<User>().Select(x => new UserDto
            {
                Id = x.Id,
                Name = x.Name,
                Password = x.Password,
                Surname = x.Surname,
                Username = x.Username,
                Email = x.Email,
                RoleId = x.RoleId,
                Point = x.Point,
            }).SingleOrDefaultAsync(p => p.Id == request.Id);


            return user;
        }
    }
}
