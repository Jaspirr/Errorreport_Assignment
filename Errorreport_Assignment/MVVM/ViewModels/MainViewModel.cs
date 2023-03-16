using Errorreport_Assignment.MVVM.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Errorreport_Assignment.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.ComponentModel;
using Errorreport_Assignment.Contexts;
using Errorreport_Assignment.MVVM.Model.Entitites;
using System.Windows.Input;

namespace Errorreport_Assignment.MVVM.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    private ObservableCollection<ErrorReportEntity> _errorReports;

    public ObservableCollection<ErrorReportEntity> ErrorReports
    {
        get { return _errorReports; }
        set
        {
            _errorReports = value;
            OnPropertyChanged(nameof(ErrorReports));
        }
    }

    public AllErrorReportListViewModel AllErrorReportListViewModel { get; set; }

    public MainViewModel()
    {
        ErrorReports = new ObservableCollection<ErrorReportEntity>();
        AllErrorReportListViewModel = new AllErrorReportListViewModel(ErrorReports);
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string name)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}

