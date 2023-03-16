
using Errorreport_Assignment.MVVM.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Errorreport_Assignment.Services;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Errorreport_Assignment.Contexts;
using System;
using Microsoft.EntityFrameworkCore;
using Errorreport_Assignment.MVVM.Model.Entitites;
using System.Collections.Generic;

namespace Errorreport_Assignment.MVVM.ViewModels;

public partial class AddErrorReportViewModel : ObservableObject
{
    [ObservableProperty]
    private string firstName = string.Empty;

    [ObservableProperty]
    private string lastName = string.Empty;

    [ObservableProperty]
    private string emailAddress = string.Empty;

    [ObservableProperty]
    private string phoneNumber = string.Empty;

    [ObservableProperty]
    private string enteredDescription = string.Empty;
    public List<ErrorReportStatus> StatusList { get; set; } = new List<ErrorReportStatus> { ErrorReportStatus.Open, ErrorReportStatus.InProgress, ErrorReportStatus.Closed };


    private void ClearForm()
    {
        firstName = string.Empty;
        lastName = string.Empty;
        emailAddress = string.Empty;
        phoneNumber = string.Empty;
        enteredDescription = string.Empty;
    }

    [RelayCommand]
    public async Task SaveAsync()
    {
        //Checking that the entered case is not empty
        if (enteredDescription != "" && emailAddress != "")
        {
            var newErrorReport = new ErrorReportModel
            {
                Description = enteredDescription,
                CustomerFirstName = firstName,
                CustomerLastName = lastName,
                CustomerEmailAddress = emailAddress,
                CustomerPhoneNumber = phoneNumber
            };

            await DatabaseService.SaveToDbAsync(newErrorReport);

            ClearForm();
        }
    }
}

