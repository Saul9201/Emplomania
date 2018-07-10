using Emplomania.Infrastucture.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.Data.VO
{
    public class OfferNeedVO
    {
        public Guid Id { get; set; }
        public Guid? WorkplaceFK { get; set; }
        public Guid? UserFK { get; set; }
        public string Others { get; set; }
        public string Details { get; set; }
        public OfferNeedType Discriminator { get; set; }
    }
}
