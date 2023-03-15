using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Errorreport_Assignment.MVVM.Models
{
    internal class WorkerModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string NameInitials { get; set; } = null!;
    }
}
