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
        public Guid? CategoryFK { get; set; }
        public string Details { get; set; }
        public string Duration { get; set; }
        public string Frequency { get; set; }
        public string Cost { get; set; }
        public string TimeToRegister { get; set; }
        public string Contact { get; set; }

        public ICollection<WorkerCourse> Workers { get; set; }
    }
}
