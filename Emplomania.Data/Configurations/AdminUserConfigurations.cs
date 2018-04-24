using Emplomania.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.Data.Configurations
{
    public class AdminUserConfigurations : EntityTypeConfiguration<AdminUser>
    {
        public AdminUserConfigurations()
        {
            ToTable("AdminUsers");
            HasKey(x => x.Id);
        }
    }
}
