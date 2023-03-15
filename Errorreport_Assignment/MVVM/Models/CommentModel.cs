using Errorreport_Assignment.MVVM.Model.Entitites;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Errorreport_Assignment.MVVM.Models;

public class CommentModel
{
    [Key]
    public int Id { get; set; }
    public string? CommentString { get; set; }
    public DateTime Time { get; set; }
    public int ErrorReportId { get; set; }
    public virtual ErrorReportModel? ErrorReport { get; set; }

}

