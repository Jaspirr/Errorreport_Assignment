using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Errorreport_Assignment.MVVM.Models;


namespace Errorreport_Assignment.MVVM.Model.Entitites;

public  class CommentEntity
{
    [Key]
    public int CommentId { get; set; }

    [MaxLength]
    public string Text { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }


    [Required]
    public int ErrorReportId { get; set; }

    public ErrorReportEntity ErrorReport { get; set; } = null!;

    [Required]
    public int WorkerId { get; set; }

    public WorkerEntity Worker { get; set; } = null!;


    #region implicit operators

    public static implicit operator CommentEntity(CommentModel text)
    {
        return new CommentEntity
        {
            Text = text.Text,
            CreatedDate = text.CreatedDate,
            WorkerId = text.CommentId
        };
    }

    public static implicit operator CommentModel(CommentEntity textEntity)
    {
        return new CommentModel
        {
            CommentId = textEntity.CommentId,
            Text = textEntity.Text,
            CreatedDate = textEntity.CreatedDate,
            WorkerId = textEntity.Worker
        };
    }

    #endregion
}

