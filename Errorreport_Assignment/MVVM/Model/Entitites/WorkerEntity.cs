using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Errorreport_Assignment.MVVM.Models;

namespace Errorreport_Assignment.MVVM.Model.Entitites
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [Column(TypeName = "nvarchar(20)")]
    public string NameInitials { get; set; } = null!;


    public ICollection<CommentEntity> CommentModel = new HashSet<CommentEntity>();

    public static implicit operator WorkerEntity(WorkerModel worker)
    {
        return new WorkerEntity
        {
            FirstName = worker.FirstName,
            LastName = worker.LastName,
            NameInitials = worker.NameInitials
        };
    }

    public static implicit operator WorkerModel(WorkerEntity workerEntity)
    {
        return new WorkerModel
        {
            Id = workerEntity.Id,
            FirstName = workerEntity.FirstName,
            LastName = workerEntity.LastName,
            NameInitials = workerEntity.NameInitials
        };
    }
}

