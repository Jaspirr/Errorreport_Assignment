using Errorreport_Assignment.MVVM.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Errorreport_Assignment.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Errorreport_Assignment.MVVM.ViewModels;

public partial class MainViewModel : ObservableObject
{
    public static ObservableObject CurrentViewModel = null!;

    public MainViewModel()
    {
        CurrentViewModel = new FirstViewModel();
    }

    //Navigation commands
    [RelayCommand]
    public void GoToAllErrorReportList()
    {
        CurrentViewModel = new AllErrorReportListViewModel();
    }

    [RelayCommand]
    public void GoToAddErrorReport()
    {
        CurrentViewModel = new AddErrorReportViewModel();
    }

    [RelayCommand]
    public void GoToAddComment()
    {
        ErrorReportModel _currentErrorReport = AllErrorReportListViewModel.clickedErrorReport;

        if (_currentErrorReport != null)
            CurrentViewModel = new AddCommentViewModel(_currentErrorReport);
        else
            CurrentViewModel = new ErrorReportDetailsViewModel();
    }
}
