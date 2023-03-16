using Errorreport_Assignment.MVVM.Model.Entitites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Errorreport_Assignment.MVVM.Models
{
    public class CustomerModel

    {
        [Key]
        public Guid CustomerId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string EmailAddress { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public ICollection<ErrorReportEntity> ErrorReports { get; set; } = new HashSet<ErrorReportEntity>();

    }

}
