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
    public Guid CustomerId { get; set; } = Guid.NewGuid();

    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [StringLength(100)]
    public string EmailAddress { get; set; } = null!;

    [Column(TypeName = "char(13)")]
    public string? PhoneNumber { get; set; }


    public ICollection<ErrorReportEntity> ErrorReports = new HashSet<ErrorReportEntity>();


    //Takes a Customer and makes a CustomerEntity
    public static implicit operator CustomerEntity(Customer customer)
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
    public static implicit operator Customer(CustomerEntity customerEntity)
    {
        return new Customer
        {
            CustomerId = customerEntity.CustomerId,
            FirstName = customerEntity.FirstName,
            LastName = customerEntity.LastName,
            EmailAddress = customerEntity.EmailAddress,
            PhoneNumber = customerEntity.PhoneNumber
        };
    }

    //Takes a Case and makes a CustomerEntity
    public static implicit operator CustomerEntity(ErrorReportModel task)
    {
        return new CustomerEntity
        {
            FirstName = task.CustomerFirstName,
            LastName = task.CustomerLastName,
            EmailAddress = task.CustomerEmailAdress,
            PhoneNumber = task.CustomerPhoneNumber
        };
    }
}
