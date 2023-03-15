
using Errorreport_Assignment.MVVM.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Errorreport_Assignment.Services;
using System.Threading.Tasks;
using System;
using Errorreport_Assignment.MVVM.Model.Entitites;
using System.ComponentModel;
using Errorreport_Assignment.Contexts;
using System.Collections.ObjectModel;

namespace Errorreport_Assignment.MVVM.ViewModels;

public partial class AddCommentViewModel : ObservableObject
{
    [ObservableProperty]
    private int? id;

    [ObservableProperty]
    private string description = string.Empty;

    [ObservableProperty]
    private string? entryTime;

    [ObservableProperty]
    private string status;

    [ObservableProperty]
    private string firstName = string.Empty;

    [ObservableProperty]
    private string lastName = string.Empty;

    [ObservableProperty]
    private string emailAdress = string.Empty;

    [ObservableProperty]
    private string? phoneNumber = string.Empty;

    [ObservableProperty]
    private string enteredComment = string.Empty;

    [ObservableProperty]
    private string selectedStatus = "Välj en ny status:";

    [ObservableProperty]
    private WorkerModel selectedWorker = null!;

    [ObservableProperty]
    private ErrorReportModel _currentErrorReport = null!;

    [ObservableProperty]
    private ObservableCollection<WorkerModel> workersList = null!;

    [ObservableProperty]
    private ObservableCollection<CommentModel> commentsList = null!;

    public AddCommentViewModel()
    {
        Task.Run(async () => await populateWorkersList());
    }

    public async Task populateLists(ErrorReportModel currentErrorReport)
    {
        WorkersList = await DatabaseService.GetAllWorkersAsync();
        CommentsList = await DatabaseService.GetSpecificCommentsFromDbAsync(currentErrorReport);
    }

    public async Task populateWorkersList()
    {
        WorkersList = await DatabaseService.GetAllEmployeesAsync();
    }

    public AddCommentViewModel(ErrorReportModel currentErrorReport)
    {
        Task.Run(async () => await populateLists(_currentErrorReport));

        _currentErrorReport = currentErrorReport;

        Id = _currentErrorReport.Id;
        Description = _currentErrorReport.Description;
        EntryTime = _currentErrorReport.EntryTime.ToString("dd/MM/yyyy HH:mm");

        //Convert the enum to a string, in swedish:
        if (_currentErrorReport.Status == ErrorReportStatus.NotStarted)
            Status = "Ej påbörjad";
        else if (_currentErrorReport.Status == ErrorReportStatus.InProgress)
            Status = "Pågående";
        else if (_currentErrorReport.Status == ErrorReportStatus.Completed)
            Status = "Avslutad";

        FirstName = _currentErrorReport.CustomerFirstName;
        LastName = _currentErrorReport.CustomerLastName;
        EmailAdress = _currentErrorReport.CustomerEmailAdress;

        //Checks if there is a phonenumber in the db and if there isn't any,
        //sets it to a string-message for the frontend:
        if (_currentErrorReport.CustomerPhoneNumber == "             ")
            PhoneNumber = "Inget telefonnummer angivet.";
        else
            PhoneNumber = _currentErrorReport.CustomerPhoneNumber;
    }

    [RelayCommand]
    public async Task UpdateStatusAsync()
    {
        if (SelectedStatus == "Ej påbörjad")
            _currentErrorReport.Status = ErrorReportStatus.NotStarted;
        else if (SelectedStatus == "Pågående")
            _currentErrorReport.Status = ErrorReportStatus.InProgress;
        else if (SelectedStatus == "Avslutad")
            _currentErrorReport.Status = ErrorReportStatus.Completed;


        if (SelectedStatus != "Välj en ny status:")
        {
            await DatabaseService.ChangeStatusAsync(_currentErrorReport);

            //This updates the frontend's current status to the new status
            Status = SelectedStatus;
        }
        else
            SelectedStatus = "Välj en ny status:";
    }

    [RelayCommand]
    public async Task AddCommentAsync()
    {
        CommentModel _comment = new CommentModel
        {
            CommentString = EnteredComment,
            SigningEmployee = SelectedWorker
        };

        await DatabaseService.SaveCommentToDbAsync(_comment, _currentErrorReport.Id);

        //Resetting and updating frontend
        CommentsList.Add(_comment);
        EnteredComment = "";
        SelectedWorker = WorkersList[0];
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