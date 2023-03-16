using Errorreport_Assignment.MVVM.Model.Entitites;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Errorreport_Assignment.MVVM.Models;

public class CommentModel
{
    [Key]
    public int CommentId { get; set; }
    public string Text { get; set; } = null!;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public WorkerModel WorkerId { get; set; } = null!;

}

