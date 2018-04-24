using Emplomania.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.Model
{
    public class Workplace : Nomenclator
    {
        public ICollection<BusinessWorkplace> Business { get; set; }
        public ICollection<WorkAspiration> WorkAspirations { get; set; }
    }
}
