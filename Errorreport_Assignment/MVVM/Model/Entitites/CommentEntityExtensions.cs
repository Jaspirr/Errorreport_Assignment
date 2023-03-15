using Errorreport_Assignment.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Errorreport_Assignment.MVVM.Model.Entitites
{
    public static class CommentEntityExtensions
    {
        public static CommentEntity ToEntity(this CommentModel commentModel)
        {
            return new CommentEntity
            {
                CommentId = commentModel.CommentId,
                Comment = commentModel.Comment,
                EntryTime = commentModel.EntryTime
            };
        }
    }
}
