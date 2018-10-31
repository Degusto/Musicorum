using System.Linq;
using System.Windows;

using Podemski.Musicorum.Interfaces.Entities;
using Podemski.Musicorum.Interfaces.Services;
using Podemski.Musicorum.UI.Views;

namespace Podemski.Musicorum.UI.Services
{
    public sealed class ViewService : IViewService
    {
        public void ShowView(IEntity entity)
        {
            var window = GetRecordWindow();

            if (window != null)
            {
                window.Navigate(entity);
            }
            else
            {
                window = new RecordWindow(entity);

                window.ShowDialog();
            }

            RecordWindow GetRecordWindow() => Application.Current.Windows.OfType<RecordWindow>().SingleOrDefault();
        }
    }
}