namespace BitirmeProjesiBackend.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Surname { get; set; } = String.Empty;
        public string Username { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public float Point { get; set; }
        public List<Comment>? Comments { get; set; } = new List<Comment>();
        public List<Ticket>? Tickets { get; set; } = new List<Ticket>();

        public int? RoleId { get; set; }
        public Role? Role { get; set; }


       
    }
}
