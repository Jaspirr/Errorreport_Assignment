using Errorreport_Assignment.MVVM.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using Errorreport_Assignment.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.ComponentModel;
using Errorreport_Assignment.Contexts;
using System.Linq;

namespace Errorreport_Assignment.MVVM.ViewModels;

public partial class AllReportListViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<ErrorReportModel> errorReportList = null!;

    public async Task populateErrorReportList()
    {
        errorReportList = await DatabaseService.GetAllFromDbAsync();
    }

    public AllReportListViewModel()
    {
        Task.Run(async () => await populateErrorReportList());
    }
}

// private ErrorReportModel? _clickedErrorReport;
// public static AllReportListViewModel Instance { get; } = new AllReportListViewModel();


//private ObservableCollection<ErrorReportModel> _errorReportList = null!;
//public ObservableCollection<ErrorReportModel>? ErrorReportList { get; set; }

//public AllReportListViewModel()
//{
//}

//public AllReportListViewModel(ObservableCollection<ErrorReportModel> errorReportList)
//{
//ErrorReportList = errorReportList;
//Task.Run(async () => await PopulateReportList());
//}//


//public async Task PopulateReportList()
//{
//ErrorReportList = await DatabaseService.GetAllFromDbAsync();
//}


//public ErrorReportModel ClickedErrorReport
//{
//get => _clickedErrorReport!;
//set { _clickedErrorReport = value; }
//}
//}


