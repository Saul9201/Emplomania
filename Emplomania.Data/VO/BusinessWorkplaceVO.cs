using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.Data.VO
{
    public class BusinessWorkplaceVO
    {
        public int Id { get; set; }
        public Guid BusinessFK { get; set; }
        public Guid WorkplaceFK { get; set; }
    }
}
