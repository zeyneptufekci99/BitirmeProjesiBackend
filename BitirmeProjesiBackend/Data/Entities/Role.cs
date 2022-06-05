namespace BitirmeProjesiBackend.Data.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Definition { get; set; } = string.Empty;
        public List<User>? Users { get; set; }
    }
}
