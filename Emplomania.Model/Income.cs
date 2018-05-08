using Emplomania.Infrastucture.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.Model
{
    public class Income
    {
        public int Id { get; set; }
        public UserClientRole ClientType { get; set; }
        public ClientCategory ClientCategory { get; set; }
        public IncomeType IncomeType { get; set; }
        public DateTime? IncomeDate { get; set; }
        public int MoneyCountCUC { get; set; }
        public int Return { get; set; }

        public Guid? MembershipFK { get; set; }
        public Guid? AditionalServiceFK { get; set; }
    }
}
