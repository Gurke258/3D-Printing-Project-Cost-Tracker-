using PrintTracker.Core;
using PrintTracker.Infrastructure;
using PrintTracker.Wpf.ViewModels;
using PrintTracker.Wpf.Views;
using System.Configuration;
using System.Data;
using System.Windows;

namespace PrintTracker.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IStorageService storage = new FileStorageService();
            IDialogService dialogService = new DialogService();

            var viewModel = new MainViewModel(storage, dialogService);

            var window = new MainWindow();

            window.DataContext = viewModel;

            window.Show();
        }
    }
}
