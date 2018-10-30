using System;

namespace Podemski.Musicorum.BusinessLogic.Exceptions
{
    public abstract class MusicorumException : Exception
    {
        protected MusicorumException()
            : base() { }

        protected MusicorumException(string message)
            : base(message) { }
    }
}
