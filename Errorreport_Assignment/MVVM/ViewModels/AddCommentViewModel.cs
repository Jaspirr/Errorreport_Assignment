
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
        workersList = await DatabaseService.GetAllWorkersAsync();
        commentsList = await DatabaseService.GetSpecificCommentsFromDbAsync(currentErrorReport);
    }

    public async Task populateWorkersList()
    {
        workersList = await DatabaseService.GetAllWorkersAsync();
    }

    public AddCommentViewModel(ErrorReportModel currentErrorReport)
    {
        Task.Run(async () => await populateLists(_currentErrorReport));

        _currentErrorReport = currentErrorReport;

        id = _currentErrorReport.Id;
        description = _currentErrorReport.Description;
        entryTime = _currentErrorReport.EntryTime.ToString("dd/MM/yyyy HH:mm");

        //Convert the enum to a string, in swedish:
        if (_currentErrorReport.Status == ErrorReportStatus.NotStarted)
            status = "Ej påbörjad";
        else if (_currentErrorReport.Status == ErrorReportStatus.InProgress)
            status = "Pågående";
        else if (_currentErrorReport.Status == ErrorReportStatus.Completed)
            status = "Avslutad";

        firstName = _currentErrorReport.CustomerFirstName;
        lastName = _currentErrorReport.CustomerLastName;
        emailAdress = _currentErrorReport.CustomerEmailAdress;

        //Checks if there is a phonenumber in the db and if there isn't any,
        //sets it to a string-message for the frontend:
        if (_currentErrorReport.CustomerPhoneNumber == "             ")
            phoneNumber = "Inget telefonnummer angivet.";
        else
            phoneNumber = _currentErrorReport.CustomerPhoneNumber;
    }

    [RelayCommand]
    public async Task UpdateStatusAsync()
    {
        if (selectedStatus == "Ej påbörjad")
            _currentErrorReport.Status = ErrorReportStatus.NotStarted;
        else if (selectedStatus == "Pågående")
            _currentErrorReport.Status = ErrorReportStatus.InProgress;
        else if (selectedStatus == "Avslutad")
            _currentErrorReport.Status = ErrorReportStatus.Completed;


        if (selectedStatus != "Välj en ny status:")
        {
            await DatabaseService.ChangeStatusAsync(_currentErrorReport);

            //This updates the frontend's current status to the new status
            status = selectedStatus;
        }
        else
            selectedStatus = "Välj en ny status:";
    }

    [RelayCommand]
    public async Task AddCommentAsync()
    {
        CommentModel _comment = new CommentModel
        {
            CommentString = enteredComment,
            SigningWorker = selectedWorker
        };

        await DatabaseService.SaveCommentToDbAsync(_comment, _currentErrorReport.Id);

        //Resetting and updating frontend
        commentsList.Add(_comment);
        enteredComment = "";
        selectedWorker = workersList[0];
    }
}
