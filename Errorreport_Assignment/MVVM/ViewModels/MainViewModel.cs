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

    }

    //Navigation commands:
    [RelayCommand]
    public void GoToAllErrorReport()
    {
        currentViewModel = new AllErrorReportViewModel();
    }

    [RelayCommand]
    public void GoToAddErrorReport()
    {
        currentViewModel = new AddErrorReportViewModel();
    }

    [RelayCommand]
    public void GoToAddComment()
    {
        ErrorReportModel _currentErrorReport = AllErrorReportView.clickedErrorReport;

        if (_currentErrorReport != null)
            currentViewModel = new AddCommentViewModel(_currentErrorReport);
        else
            currentViewModel = new ErrorReportDetailsViewModel();
    }
}