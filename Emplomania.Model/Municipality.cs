using Emplomania.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.Model
{
    public class Municipality : Nomenclator
    {
        public Guid ProvinceFK { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
