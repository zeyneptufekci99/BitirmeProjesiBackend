using MediatR;

namespace BitirmeProjesiBackend.Application.CQRS.Commands
{
    public class UpdateEventCommand:IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string ImageUrl { get; set; } = String.Empty;
        public string Explanation { get; set; } = String.Empty;
        public string Director { get; set; } = String.Empty;
        public string Type { get; set; } = String.Empty;
        public int Donated { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Point { get; set; }
        public int Quota { get; set; }
    
        public int Longitude { get; set; }
        public int Latitude { get; set; }
    }
}
