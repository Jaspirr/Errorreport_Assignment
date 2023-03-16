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
using Errorreport_Assignment.MVVM.Views;

namespace Errorreport_Assignment.MVVM.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    public static ObservableObject currentViewModel = null!;

    public MainViewModel()
    {
        CurrentViewModel = new FirstViewModel();
    }

    //Navigation commands:
    [RelayCommand]
    public void GoToAllErrorReportList()
    {
        CurrentViewModel = new AllErrorReportViewModel();
    }

    [RelayCommand]
    public void GoToAddErrorReport()
    {
        CurrentViewModel = new AddErrorReportViewModel();
    }

    [RelayCommand]
    public void GoToAddComment()
    {
        ErrorReportModel _currentErrorReport = AllErrorReportView.clickedErrorReport;

        if (_currentErrorReport != null)
            CurrentViewModel = new AddCommentViewModel(_currentErrorReport);
        else
            CurrentViewModel = new ErrorReportDetailsViewModel();
    }
}