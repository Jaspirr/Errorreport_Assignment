using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Errorreport_Assignment.MVVM.Models;


namespace Errorreport_Assignment.MVVM.Model.Entitites;

public  class CommentEntity
{
    [Key]
    public int CommentId { get; set; }
    public string Comment { get; set; } = string.Empty;
    public DateTime EntryTime { get; set; }
    public int ErrorReportId { get; set; }
    public ErrorReportModel? ErrorReport { get; set; }

}


