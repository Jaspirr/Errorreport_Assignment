using Errorreport_Assignment.MVVM.Model.Entitites;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Errorreport_Assignment.MVVM.Models;

public class CommentModel
{
    [Key]
    public int Id { get; set; }
    public string CommentString { get; set; } = null!;
    public DateTime EntryTime { get; set; } = DateTime.Now;
    public WorkerModel SigningWorker { get; set; } = null!;

}

