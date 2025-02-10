using UniSoft.Domain.Exceptions;
using UniSoft.Domain.ValueObjects;

namespace UniSoft.Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }
        public string Username { get; private set; }
        public Email Email { get; private set; }
        public PasswordHash PasswordHash { get; private set; }
        public string FullName { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public User(string username, Email email, PasswordHash passwordHash, string fullName)
        {
            if (string.IsNullOrWhiteSpace(username)) throw new DomainException("Le username est obligatoire.");
            if (string.IsNullOrWhiteSpace(fullName)) throw new DomainException("Le nom complet est obligatoire.");

            Username = username;
            Email = email;
            PasswordHash = passwordHash;
            FullName = fullName;
            CreatedAt = DateTime.UtcNow;
        }
    }
}