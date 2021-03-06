namespace Podemski.Musicorum.BusinessLogic.Exceptions
{
    public sealed class NotFoundException : MusicorumException
    {
        public NotFoundException(int id, string resource)
            : base($"{resource} with id {id} not found") { }
    }
}
