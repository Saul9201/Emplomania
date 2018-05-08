using Emplomania.Infrastucture.Enums;
using Emplomania.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.Model
{
    public class AditionalService : Nomenclator
    {
        public UserClientRole UserType { get; set; }
        public int Price { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Income> Income { get; set; }
    }
}
