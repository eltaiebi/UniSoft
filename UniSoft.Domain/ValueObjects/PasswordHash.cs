using UniSoft.Domain.Exceptions;

namespace UniSoft.Domain.ValueObjects
{
    public class PasswordHash
    {
        public string Value { get; private set; }

        public PasswordHash(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 60)
                throw new DomainException("Mot de passe hashé invalide.");

            Value = value;
        }

        public override bool Equals(object obj)
        {
            return obj is PasswordHash hash && Value == hash.Value;
        }

        public override int GetHashCode() => Value.GetHashCode();

        public override string ToString() => "********"; // Ne jamais afficher le hash en clair.
    }
}