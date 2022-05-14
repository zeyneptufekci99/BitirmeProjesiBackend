using MediatR;
using Microsoft.EntityFrameworkCore;
using BitirmeProjesiBackend.Application.CQRS.Commands;
using BitirmeProjesiBackend.Data.Context;

namespace BitirmeProjesiBackend.Application.CQRS.CommandHandlers
{
    public class RemoveTicketCommandHandler : IRequestHandler<RemoveTicketCommand>
    {
        private readonly Context _context;

        public RemoveTicketCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(RemoveTicketCommand request, CancellationToken cancellationToken)
        {
            var removedTicket = await _context.Tickets.SingleOrDefaultAsync(x => x.Id == request.Id);
            if (removedTicket != null)
            {
                _context.Tickets.Remove(removedTicket);
                await _context.SaveChangesAsync();

            }
            return Unit.Value;
        }
    }
}
