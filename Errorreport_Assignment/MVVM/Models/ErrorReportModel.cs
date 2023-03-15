using Errorreport_Assignment.MVVM.Model.Entitites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Errorreport_Assignment.MVVM.Models;

public class ErrorReportModel
{
    [Key]
    public int Id { get; set; }
    public string Description { get; set; } = null!;
    public DateTime EntryTime { get; set; } = DateTime.Now;
    public ErrorReportStatus Status { get; set; } = ErrorReportStatus.NotStarted;
    public string CustomerFirstName { get; set; } = null!;
    public string CustomerLastName { get; set; } = null!;
    public string CustomerEmailAddress { get; set; } = null!;
    public string? CustomerPhoneNumber { get; set; }

}