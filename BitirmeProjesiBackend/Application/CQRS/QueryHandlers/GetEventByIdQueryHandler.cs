using MediatR;
using Microsoft.EntityFrameworkCore;
using BitirmeProjesiBackend.Application.CQRS.Queries;
using BitirmeProjesiBackend.Application.Dtos;
using BitirmeProjesiBackend.Data.Context;

namespace BitirmeProjesiBackend.Application.CQRS.QueryHandlers
{
    public class GetEventByIdQueryHandler : IRequestHandler<GetEventByIdQuery, EventDto?>
    {
        private readonly Context _context;

        public GetEventByIdQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<EventDto?> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Events.AsNoTracking().Select(x => new EventDto
            {
                Id = x.Id,
                Name = x.Name,
                ImageUrl=x.ImageUrl,
                Explanation = x.Explanation,
                Director=x.Director,
                Point=x.Point,
                Type = x.Type,
                StartDate = x.StartDate,
                Quota = x.Quota,
                Longitude = x.Longitude,
                Latitude = x.Latitude,

            }).SingleOrDefaultAsync(x => x.Id == request.Id);

            return result;
        }
    }
}
