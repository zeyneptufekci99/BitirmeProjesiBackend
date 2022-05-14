using MediatR;
using BitirmeProjesiBackend.Application.Dtos;

namespace BitirmeProjesiBackend.Application.CQRS.Queries
{
    public class GetTicketByIdQuery:IRequest<TicketDto?>
    {
        public int Id { get; set; }

        public GetTicketByIdQuery(int id)
        {
            Id = id;
        }
    }
}
