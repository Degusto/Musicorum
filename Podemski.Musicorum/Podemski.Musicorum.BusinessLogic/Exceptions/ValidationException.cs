namespace Podemski.Musicorum.BusinessLogic.Exceptions
{
    public sealed class ValidationException : MusicorumException
    {
        public ValidationException(string message)
            : base(message) { }
    }
}
