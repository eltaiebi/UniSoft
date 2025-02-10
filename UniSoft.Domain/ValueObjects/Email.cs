using UniSoft.Domain.Exceptions;

namespace UniSoft.Domain.ValueObjects
{
    public class Email
    {
        public string Value { get; private set; }

        public Email(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || !value.Contains("@"))
                throw new DomainException("Email invalide.");

            Value = value;
        }

        public override bool Equals(object obj)
        {
            return obj is Email email && Value == email.Value;
        }

        public override int GetHashCode() => Value.GetHashCode();

        public override string ToString() => Value;
    }
}