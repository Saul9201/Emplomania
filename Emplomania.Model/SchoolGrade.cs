using Emplomania.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.Model
{
    public class SchoolGrade : Nomenclator
    {
        public ICollection<Worker> Workers { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
    }
}
