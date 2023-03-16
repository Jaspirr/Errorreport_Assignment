using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Errorreport_Assignment.MVVM.Models;

namespace Errorreport_Assignment.MVVM.Model.Entitites;

public class ErrorReportEntity
{
    [Key]
    public int ErrorReportId { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime EntryTime { get; set; }
    public string Status { get; set; }  = string.Empty;   
    public Guid CustomerId { get; set; }
    public CustomerModel? Customer { get; set; }
    public ICollection<CommentModel>? Comments { get; set; }

    public const string Open = "Open";

    private CustomerEntity ConvertToCustomerEntity(ErrorReportModel errorReportModel)
    {
        CustomerEntity customerEntity = new CustomerEntity();
        customerEntity.FirstName = errorReportModel.CustomerFirstName;
        customerEntity.LastName = errorReportModel.CustomerLastName;
        customerEntity.EmailAddress = errorReportModel.CustomerEmailAddress;
        
        return customerEntity;
    }

    public static implicit operator ErrorReportEntity(ErrorReportModel task)
    {
        return new ErrorReportEntity
        {
            Description = task.Description,
            EntryTime = task.EntryTime,
            Status = task.Status
        };
    }

    public static implicit operator ErrorReportModel(ErrorReportEntity errorReportEntity)
    {
        return new ErrorReportModel
        {
            ErrorReportId = errorReportEntity.ErrorReportId,
            Description = errorReportEntity.Description,
            EntryTime = errorReportEntity.EntryTime,
            Status = errorReportEntity.Status
        };
    }
}



public enum ErrorReportStatus
{   Open,
    InProgress,
    Closed
}
