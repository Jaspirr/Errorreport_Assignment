using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Errorreport_Assignment.MVVM.Models;


namespace Errorreport_Assignment.MVVM.Model.Entitites;

public  class CommentEntity
{
    [Key]
    public int Id { get; set; }

    [MaxLength]
    public string Comment { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime EntryTime { get; set; }


    [Required]
    public int ErrorReportId { get; set; }

    public ErrorReportEntity ErrorReport { get; set; } = null!;

    [Required]
    public int WorkerId { get; set; }

    public WorkerEntity Worker { get; set; } = null!;


    #region implicit operators

    public static implicit operator CommentEntity(CommentModel comment)
    {
        return new CommentEntity
        {
            Comment = comment.CommentString,
            EntryTime = comment.EntryTime,
            WorkerId = comment.SigningWorker.Id
        };
    }

    public static implicit operator CommentModel(CommentEntity commentEntity)
    {
        return new CommentModel
        {
            Id = commentEntity.Id,
            CommentString = commentEntity.Comment,
            EntryTime = commentEntity.EntryTime,
            SigningWorker = commentEntity.Worker
        };
    }

    #endregion
}

