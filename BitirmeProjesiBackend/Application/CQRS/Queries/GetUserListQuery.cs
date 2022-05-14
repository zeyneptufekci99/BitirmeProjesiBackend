
using MediatR;
using BitirmeProjesiBackend.Application.Dtos;

namespace BitirmeProjesiBackend.Application.CQRS.Queries
{
    public class GetUserListQuery : IRequest<List<UserDto>>
    {
    }
}
