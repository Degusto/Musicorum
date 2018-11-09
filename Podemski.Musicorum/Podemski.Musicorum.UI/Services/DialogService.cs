using System.Windows;

using Podemski.Musicorum.Interfaces.Services;

namespace Podemski.Musicorum.UI.Services
{
    internal sealed class DialogService : IDialogService
    {
        public void ShowInfo(string message) => MessageBox.Show(message, "Komunikat", MessageBoxButton.OK, MessageBoxImage.Information);

        public void ShowError(string message) => MessageBox.Show(message, "Wystąpił błąd", MessageBoxButton.OK, MessageBoxImage.Error);

        public bool ShowQuestion(string message) => MessageBox.Show(message, "Potwierdzenie", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes;
    }
}
