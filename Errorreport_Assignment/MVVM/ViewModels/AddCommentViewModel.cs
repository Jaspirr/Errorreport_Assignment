
using Errorreport_Assignment.MVVM.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Errorreport_Assignment.Services;
using System.Threading.Tasks;
using System;
using Errorreport_Assignment.MVVM.Model.Entitites;
using System.ComponentModel;
using Errorreport_Assignment.Contexts;

namespace Errorreport_Assignment.MVVM.ViewModels;

public partial class AddCommentViewModel : ObservableObject
{
    private readonly DataContext? _dbDataContext;


    public event PropertyChangedEventHandler? PropertyChanged;

    private string? _commentText;

    public string? CommentText
    {
        get { return _commentText; }
        set
        {
            if (_commentText != value)
            {
                _commentText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CommentText)));
            }
        }
    }

    public void AddComment(ErrorReportModel errorReport, CommentModel comment)
    {
        var commentEntity = comment.ToEntity();
        _dbDataContext.Comments.Add(commentEntity);
        _dbDataContext.SaveChanges();

        errorReport.Comments.Add(comment);
    }
}
//private readonly ErrorReportModel currentTask = null!;

//[ObservableProperty]
//public int id;

//[ObservableProperty]
//private string? content = string.Empty;

//[ObservableProperty]
//public DateTime entryTime;

//[ObservableProperty]
//public int errorReportId;

//[ObservableProperty]
//public string? selectedStatus = "Välj en uppdaterad status:";

//[ObservableProperty]
//public string? status = string.Empty;

// Properties for Customer
//[ObservableProperty]
//private string? firstName = string.Empty;

//[ObservableProperty]
//public string? lastName = string.Empty;

//public string? emailAddress = string.Empty;

//[ObservableProperty]
//public string? phoneNumber = string.Empty;

//public string? CommentContent { get; set; }

//public AddCommentViewModel()
//{
//
//public AddCommentViewModel(ErrorReportModel currentReport)
//{
//currentTask = currentReport;

// id = currentTask.Id;
//entryTime = currentTask.EntryTime;

//if (currentTask.Status == ErrorReportStatus.NotStarted)
//status = "Ej påbörjad";
//else if (currentTask.Status == ErrorReportStatus.InProgress)
//status = "Pågående";
//else if (currentTask.Status == ErrorReportStatus.Completed)
//status = "Avslutad";

//firstName = currentTask.CustomerFirstName;
//lastName = currentTask.CustomerLastName;
//emailAddress = currentTask.CustomerEmailAddress;

// if (currentTask.CustomerPhoneNumber == "             ")
//phoneNumber = "Inget telefonnummer angivet.";
//else
//phoneNumber = currentTask.CustomerPhoneNumber;
//}

//[RelayCommand]
//public async Task UpdateStatusAsync()
//{
//if (SelectedStatus != "Välj en uppdaterad status:")
//{
//if (SelectedStatus == "Ej påbörjad")
//currentTask.Status = ErrorReportStatus.NotStarted;
//else if (SelectedStatus == "Pågående")
//currentTask.Status = ErrorReportStatus.InProgress;
//else if (SelectedStatus == "Avslutad")
//currentTask.Status = ErrorReportStatus.Completed;

//await DatabaseService.ChangeStatusAsync(currentTask);

//FRONTEND!
//Status = SelectedStatus;
//}
//}
//}