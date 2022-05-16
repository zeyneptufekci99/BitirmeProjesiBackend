﻿namespace BitirmeProjesiBackend.Data.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }=String.Empty;
        public string ImageUrl { get; set; }=String.Empty;
        public string Explanation { get; set; }=String.Empty;
        public string Director { get; set; }=String.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Point { get; set; }
        public string Type { get; set; } = String.Empty;
        public int Quota { get; set; }
        public List<Comment>? Comments { get; set; } = new List<Comment>();
        public int Longitude { get; set; }
        public int Latitude { get; set; }
        public List<Ticket>? Tickets { get; set; }
    }
}
