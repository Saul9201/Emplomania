using Emplomania.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.Model
{
    public class Course : Nomenclator
    {
        public ICollection<WorkerCourse> Workers { get; set; }
    }
}
