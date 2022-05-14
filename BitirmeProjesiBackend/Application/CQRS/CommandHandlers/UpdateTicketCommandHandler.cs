using MediatR;
using Microsoft.EntityFrameworkCore;
using BitirmeProjesiBackend.Application.CQRS.Commands;
using BitirmeProjesiBackend.Data.Context;

namespace BitirmeProjesiBackend.Application.CQRS.CommandHandlers
{
    public class UpdateTicketCommandHandler : IRequestHandler<UpdateTicketCommand>
    {
        private readonly Context _context;

        public UpdateTicketCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
        {
            var updatedTicket = await _context.Tickets.SingleOrDefaultAsync(x => x.Id == request.Id);
            if (updatedTicket != null)
            {
                updatedTicket.Numara = request.Numara;
                updatedTicket.EventId = request.EventId;
                updatedTicket.UserId = request.UserId;


                await _context.SaveChangesAsync();
            }

            return Unit.Value;
        }
    }
}
