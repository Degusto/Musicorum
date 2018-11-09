using Podemski.Musicorum.Interfaces.Entities;

namespace Podemski.Musicorum.Interfaces.Services
{
    public interface IViewService
    {
        void ShowView(IEntity entity);

        void CloseEntityView();
    }
}
