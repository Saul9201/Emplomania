using Emplomania.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.Data.Configurations
{
    internal class OfferNeedConfigurations: EntityTypeConfiguration<OfferNeed>
    {
        public OfferNeedConfigurations()
        {
            ToTable("OffersNeeds");
            HasKey(x => x.Id);
            
        }
    }
}
