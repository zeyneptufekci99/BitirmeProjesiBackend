
using MediatR;
using Microsoft.EntityFrameworkCore;
using BitirmeProjesiBackend.Application.CQRS.Queries;
using BitirmeProjesiBackend.Application.Dtos;
using BitirmeProjesiBackend.Data.Context;
using BitirmeProjesiBackend.Data.Entities;

namespace BitirmeProjesiBackend.Application.CQRS.QueryHandlers
{
    public class GetTicketListQueryHandler : IRequestHandler<GetTicketListQuery, List<TicketDto>>
    {
        private readonly Context _context;

        public GetTicketListQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<List<TicketDto>> Handle(GetTicketListQuery request, CancellationToken cancellationToken)
        {
            var ticketList = await _context.Tickets.OfType<Ticket>().Select(x => new TicketDto
            {
                Id = x.Id,
                Numara = x.Numara,
                EventId = x.EventId,
                UserId = x.UserId,
            }).AsNoTracking().ToListAsync();

            return ticketList;
        }
    }
}
