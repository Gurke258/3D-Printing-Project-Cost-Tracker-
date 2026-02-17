using PrintTracker.Core;
using PrintTracker.Infrastructure;
using PrintTracker.Wpf.ViewModels;
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

            var viewModel = new MainViewModel(storage);

            var window = new MainWindow();

            window.DataContext = viewModel;

            window.Show();
        }
    }
}
