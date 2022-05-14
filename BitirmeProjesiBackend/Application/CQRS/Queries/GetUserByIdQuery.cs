
using MediatR;
using BitirmeProjesiBackend.Application.Dtos;

namespace BitirmeProjesiBackend.Application.CQRS.Queries
{
    public class GetUserByIdQuery : IRequest<UserDto?>
    {
        public int Id { get; set; }

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
