
using Errorreport_Assignment.MVVM.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Errorreport_Assignment.Services;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Errorreport_Assignment.Contexts;
using System.Linq;
using System;
using GalaSoft.MvvmLight;
using Microsoft.EntityFrameworkCore;

namespace Errorreport_Assignment.MVVM.ViewModels;

public class AddReportViewModel : ViewModelBase
{
    private readonly DataContext _context;

    public AddReportViewModel(DataContext context)
    {
        _context = context;
        AddCustomerCommand = new RelayCommand(AddCustomer, CanAddCustomer);
    }

    // Properties for data bindings
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }
    public string Description { get; set; }

    // Command for adding a new customer
    public RelayCommand AddCustomerCommand { get; set; }

    private bool CanAddCustomer()
    {
        // Check that required fields are not empty
        return !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName)
            && !string.IsNullOrEmpty(EmailAddress) && !string.IsNullOrEmpty(PhoneNumber);
    }

    private void AddCustomer()
    {
        // Create a new Customer object with data from properties
        var customer = new CustomerModel
        {
            CustomerId = Guid.NewGuid(),
            FirstName = FirstName,
            LastName = LastName,
            EmailAddress = EmailAddress,
            PhoneNumber = PhoneNumber
        };

        // Create a new ErrorReport object with data from properties
        var errorReport = new ErrorReportModel
        {
            Description = Description,
            EntryTime = DateTimeOffset.Now,
            Status = 0,
            Customer = customer
        };

        // Add the new ErrorReport to the DbContext and save changes
        _context.ErrorReports.Add(errorReport);
        _context.SaveChanges();

        // Reset properties
        FirstName = "";
        LastName = "";
        EmailAddress = "";
        PhoneNumber = "";
        Description = "";

       
    }
    // Update ErrorReports collection to refresh the view
    public void UpdateErrorReports()
    {
        ErrorReports = new ObservableCollection<ErrorReportModel>(_context.ErrorReports.Include(er => er.Customer).ToList());
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
