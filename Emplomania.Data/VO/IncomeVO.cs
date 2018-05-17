using Emplomania.Infrastucture.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.Data.VO
{
    public class IncomeVO
    {
        public int Id { get; set; }
        public UserClientRole ClientType { get; set; }
        public ClientCategory ClientCategory { get; set; }
        public IncomeType IncomeType { get; set; }
        public DateTime IncomeDate { get; set; }
        public float? MoneyCountMemberchipCUC { get; set; }
        public float? MoneyCountAditionalServCUC { get; set; }
        public float? Return { get; set; }
        public Guid? User { get; set; }

        public Guid? MembershipFK { get; set; }
        public Guid? AditionalServiceFK { get; set; }
    }
}
