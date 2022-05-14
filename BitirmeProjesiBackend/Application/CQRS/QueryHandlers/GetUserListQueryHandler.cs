
using MediatR;
using Microsoft.EntityFrameworkCore;
using BitirmeProjesiBackend.Application.CQRS.Queries;
using BitirmeProjesiBackend.Application.Dtos;
using BitirmeProjesiBackend.Data.Context;
using BitirmeProjesiBackend.Data.Entities;

namespace BitirmeProjesiBackend.Application.CQRS.QueryHandlers
{
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, List<UserDto>>
    {
        private readonly Context _context;

        public GetUserListQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<List<UserDto>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var userList = await _context.Users.OfType<User>().Select(x => new UserDto
            {
                Id = x.Id,
                Name = x.Name,
                Password = x.Password,
                Surname = x.Surname,
                Username = x.Username,
                Email = x.Email,
                RoleId = x.RoleId,
            }).AsNoTracking().ToListAsync();

            return userList;
        }
    }
}
