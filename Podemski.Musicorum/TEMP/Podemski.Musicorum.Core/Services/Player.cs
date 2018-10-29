using Podemski.Musicorum.Core.Models;

namespace Podemski.Musicorum.Core.Services
{
    public interface IPlayer
    {
        void Play(Track track);

        void Pause();

        void Resume();
    }
}