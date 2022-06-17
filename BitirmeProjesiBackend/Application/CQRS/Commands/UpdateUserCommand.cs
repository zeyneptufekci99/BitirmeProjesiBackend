using MediatR;

namespace BitirmeProjesiBackend.Application.CQRS.Commands
{
    public class UpdateUserCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Surname { get; set; } = String.Empty;
        public string Username { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public int? RoleId { get; set; }
        public float Point { get; set; }
    }
}
