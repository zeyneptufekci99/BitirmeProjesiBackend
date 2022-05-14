using MediatR;
using Microsoft.EntityFrameworkCore;
using BitirmeProjesiBackend.Application.CQRS.Queries;
using BitirmeProjesiBackend.Application.Dtos;
using BitirmeProjesiBackend.Data.Context;
using BitirmeProjesiBackend.Data.Entities;

namespace BitirmeProjesiBackend.Application.CQRS.QueryHandlers
{
    public class GetTicketByIdQueryHandler : IRequestHandler<GetTicketByIdQuery,TicketDto?>
    {
        private readonly Context _context;

        public GetTicketByIdQueryHandler(Context context)
        {
            _context = context;
        }
        public async Task<TicketDto?> Handle(GetTicketByIdQuery request, CancellationToken cancellationToken)
        {
            var ticket = await _context.Tickets.AsNoTracking().OfType<Ticket>().Select(x => new TicketDto
            {
                Id = x.Id,
                Numara = x.Numara,
                EventId = x.EventId,
                UserId = x.UserId,

            }).SingleOrDefaultAsync(p => p.Id == request.Id);


            return ticket;
        }
    }
}
