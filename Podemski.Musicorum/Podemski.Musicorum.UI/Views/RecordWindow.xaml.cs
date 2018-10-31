using Podemski.Musicorum.Interfaces.Entities;
using Podemski.Musicorum.UI.Factories;

namespace Podemski.Musicorum.UI.Views
{
    public partial class RecordWindow 
    {
        public RecordWindow(IEntity entity)
        {
            DataContext = this;

            InitializeComponent();

            Navigate(entity);
        }

        public void Navigate(IEntity entity)
        {
            Page.Navigate(RecordPageFactory.Create(entity));

            Title = entity.ToString();
        }
    }
}