using Errorreport_Assignment.MVVM.ViewModels;
using System.Windows;

namespace Errorreport_Assignment;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        MainWindow = new MainWindow()
        {
            DataContext = new MainViewModel()
        };

        MainWindow.Show();
        base.OnStartup(e);
    }
}
