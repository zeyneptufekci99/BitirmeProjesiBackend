using MediatR;
using BitirmeProjesiBackend.Application.Dtos;

namespace BitirmeProjesiBackend.Application.CQRS.Queries
{
    public class GetTicketListQuery : IRequest<List<TicketDto>>
    {
    }
}
