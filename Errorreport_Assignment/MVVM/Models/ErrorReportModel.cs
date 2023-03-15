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
    public string Description { get; set; }
    public DateTimeOffset EntryTime { get; set; }
    public int Status { get; set; }
    public Guid CustomerId { get; set; }
    public virtual CustomerModel Customer { get; set; }
    public virtual ICollection<CommentModel> CommentString { get; set; }

}