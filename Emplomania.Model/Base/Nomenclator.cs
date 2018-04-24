using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.Model.Base
{
    public abstract class Nomenclator
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
