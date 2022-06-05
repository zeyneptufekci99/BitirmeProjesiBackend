using MediatR;
using BitirmeProjesiBackend.Application.CQRS.Commands;
using BitirmeProjesiBackend.Data.Context;
using BitirmeProjesiBackend.Data.Entities;

namespace BitirmeProjesiBackend.Application.CQRS.CommandHandlers
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand>
    {
        private readonly Context _context;

        public CreateEventCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var createdMovie=new Event();
            createdMovie.Name=request.Name;
            createdMovie.ImageUrl=request.ImageUrl;
            createdMovie.Explanation = request.Explanation;
            createdMovie.Director=request.Director;
            createdMovie.Point=request.Point;
            createdMovie.StartDate = request.StartDate;
            createdMovie.EndDate = request.EndDate;
            createdMovie.Quota = request.Quota;
            createdMovie.Longitude = request.Longitude;
            createdMovie.Latitude = request.Latitude;
            createdMovie.Type = request.Type;
            createdMovie.Donated = request.Donated;
     

            await _context.Events.AddAsync(createdMovie);
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
