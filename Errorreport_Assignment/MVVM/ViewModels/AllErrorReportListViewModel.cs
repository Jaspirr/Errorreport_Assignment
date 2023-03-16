using Errorreport_Assignment.MVVM.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using Errorreport_Assignment.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.ComponentModel;
using Errorreport_Assignment.Contexts;
using System.Linq;

namespace Errorreport_Assignment.MVVM.ViewModels;

public partial class AllErrorReportListViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<ErrorReportModel> errorReportList = null!;

    public async Task populateErrorReportList()
    {
        errorReportList = await DatabaseService.GetAllFromDbAsync();
    }

    public AllErrorReportListViewModel()
    {
        Task.Run(async () => await populateErrorReportList());
    }
}


