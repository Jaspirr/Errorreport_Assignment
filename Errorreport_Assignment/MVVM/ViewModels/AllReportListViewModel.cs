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
    private readonly DataContext _dbDataContext;

    public AllReportListViewModel(ObservableCollection<ErrorReportModel> errorReportList)
      {
        _dbDataContext = new DataContext();
        ErrorReports = new ObservableCollection<ErrorReportModel>(_dbDataContext.ErrorReports
            .Select(er => new ErrorReportModel
            {
                ErrorReportId = er.ErrorReportId,
                Description = er.Description,
                Status = er.Status,
                EntryTime = er.EntryTime,
                Customer = new CustomerModel
                {
                    Id = er.Customer.Id,
                    FirstName = er.Customer.FirstName,
                    LastName = er.Customer.LastName,
                    EmailAddress = er.Customer.EmailAddress,
                    PhoneNumber = er.Customer.PhoneNumber
                }
            })
        );
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private ObservableCollection<ErrorReportModel> _errorReports;

    public ObservableCollection<ErrorReportModel> ErrorReports
    {
        get { return _errorReports; }
        set
        {
            if (_errorReports != value)
            {
                _errorReports = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ErrorReports)));
            }
        }
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


