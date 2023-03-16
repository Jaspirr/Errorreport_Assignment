using Errorreport_Assignment.MVVM.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using Errorreport_Assignment.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.ComponentModel;
using Errorreport_Assignment.Contexts;
using System.Linq;
using CommunityToolkit.Mvvm.Input;
using Errorreport_Assignment.MVVM.Model.Entitites;
using System.Runtime.CompilerServices;

namespace Errorreport_Assignment.MVVM.ViewModels;

public class AllErrorReportViewModel : INotifyPropertyChanged
{
    public ObservableCollection<ErrorReportEntity> ErrorReports { get; set; }

    private ErrorReportEntity _selectedErrorReport;
    public ErrorReportEntity SelectedErrorReport
    {
        get { return _selectedErrorReport; }
        set
        {
            _selectedErrorReport = value;
            OnPropertyChanged();
        }
    }

    private RelayCommand _clickErrorReportCommand;
    public RelayCommand ClickErrorReportCommand
    {
        get
        {
            return _clickErrorReportCommand ?? (_clickErrorReportCommand = new RelayCommand(
                () =>
                {
                    clickedErrorReport(SelectedErrorReport);
                }
                ));
        }
    }

    public delegate void ClickedErrorReportDelegate(ErrorReportEntity errorReport);
    public ClickedErrorReportDelegate clickedErrorReport;

    public AllErrorReportViewModel(ObservableCollection<ErrorReportEntity> errorReports)
    {
        ErrorReports = errorReports;
    }


    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}



