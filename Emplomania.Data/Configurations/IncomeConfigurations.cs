using Emplomania.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.Data.Configurations
{
    public class IncomeConfigurations: EntityTypeConfiguration<Income>
    {
        public IncomeConfigurations()
        {
            ToTable("Income");
            HasKey(i => i.Id);
        }
    }
}
