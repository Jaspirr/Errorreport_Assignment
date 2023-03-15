
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

namespace Errorreport_Assignment.MVVM.ViewModels;

public partial class AddACaseViewModel : ObservableObject
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

    private void ClearForm()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        EmailAddress = string.Empty;
        PhoneNumber = string.Empty;
        EnteredDescription = string.Empty;
    }

    [RelayCommand]
    public async Task SaveAsync()
    {
        //Checking that the entered case is not empty
        if (EnteredDescription != "" && EmailAddress != "")
        {
            var newErrorReport = new ErrorReportModel
            {
                Description = EnteredDescription,
                CustomerFirstName = FirstName,
                CustomerLastName = LastName,
                CustomerEmailAdress = EmailAddress,
                CustomerPhoneNumber = PhoneNumber
            };

            await DatabaseService.SaveToDbAsync(newErrorReport);

            ClearForm();
        }
    }
}
//  [ObservableProperty]
// private string title = "Add a new report here";

//[ObservableProperty]
// private string firstName = string.Empty;

// [ObservableProperty]
// private string lastName = string.Empty;

// [ObservableProperty]
//private string emailAddress = string.Empty;

// [ObservableProperty]
//private string phoneNumber = string.Empty;

//[ObservableProperty]
//private string description = string.Empty;

//private void ClearForm()
//{   
//firstName = string.Empty;
//lastName = string.Empty;
//emailAddress= string.Empty;
//    phoneNumber = string.Empty;
//description = string.Empty;
//}

//[RelayCommand]
//public async Task SaveAsync()
//{
//var task = new ErrorReportModel
//{
//Description = description,
//CustomerFirstName = firstName,
//CustomerLastName = lastName,
//CustomerEmailAddress = emailAddress,
//CustomerPhoneNumber = phoneNumber
//};

//await DatabaseService.SaveToDbAsync(task);

//ClearForm();
//}
//}
