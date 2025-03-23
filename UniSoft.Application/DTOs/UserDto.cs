namespace UniSoft.Application.DTOs
{
    public class UserDto
    {
        public int Id { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public string FullName { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}