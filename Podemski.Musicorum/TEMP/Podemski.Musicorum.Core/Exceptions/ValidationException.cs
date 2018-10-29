namespace Podemski.Musicorum.Core.Exceptions
{
    public sealed class ValidationException : MusicorumException
    {
        public ValidationException(string message)
            : base(message) { }
    }
}
