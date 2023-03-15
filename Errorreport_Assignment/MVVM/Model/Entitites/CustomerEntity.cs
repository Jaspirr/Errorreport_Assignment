using Errorreport_Assignment.MVVM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Errorreport_Assignment.MVVM.Model.Entitites;

[Index(nameof(EmailAddress), IsUnique = true)]
public class CustomerEntity
{
    [Key]
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty; 
    public string EmailAddress { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public ICollection<ErrorReportModel>? ErrorReports { get; set; }


    //Takes a Customer and makes a CustomerEntity
    public static implicit operator CustomerEntity(CustomerModel customer)
    {
        return new CustomerEntity
        {
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            EmailAddress = customer.EmailAddress,
            PhoneNumber = customer.PhoneNumber
        };
    }

    //Takes a CustomerEntity and makes a Customer
    public static implicit operator CustomerModel(CustomerEntity customerEntity)
    {
        return new CustomerModel
        {
            Id = customerEntity.Id,
            FirstName = customerEntity.FirstName,
            LastName = customerEntity.LastName,
            EmailAddress = customerEntity.EmailAddress,
            PhoneNumber = customerEntity.PhoneNumber
        };
    }

    //Takes a Case and makes a CustomerEntity
    public static explicit operator CustomerEntity(ErrorReportModel errorReport)
    {
        return new CustomerEntity
        {
            FirstName = errorReport.CustomerFirstName,
            LastName = errorReport.CustomerLastName,
            EmailAddress = errorReport.CustomerEmailAddress,
            PhoneNumber = errorReport.CustomerPhoneNumber
        };
    }
}