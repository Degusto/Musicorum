using System;
using System.Windows;

using Ninject;

using Podemski.Musicorum.Interfaces.Services;
using Podemski.Musicorum.UI.Bootstrap;

namespace Podemski.Musicorum.UI
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            AppDomain.CurrentDomain.UnhandledException += HandleException;

            base.OnStartup(e);
        }

        private void HandleException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception exception)
            {
                Kernel.Instance.Get<IDialogService>().ShowError(exception.Message);
            }
            else
            {
                Kernel.Instance.Get<IDialogService>().ShowError(e.ExceptionObject?.ToString() ?? string.Empty);
            }
        }
    }
}