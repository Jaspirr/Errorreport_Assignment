using Errorreport_Assignment.MVVM.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Errorreport_Assignment.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Errorreport_Assignment.MVVM.ViewModels;

public partial class MainViewModel : INotifyPropertyChanged
{
    private readonly AddReportViewModel _errorReportViewModel;
    private readonly AddCommentViewModel _commentViewModel;

    public MainViewModel()
    {
        _errorReportViewModel = new AddReportViewModel();
        _commentViewModel = new AddCommentViewModel();
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public AddReportViewModel ErrorReportViewModel => _errorReportViewModel;

    public AddCommentViewModel CommentViewModel => _commentViewModel;
}
