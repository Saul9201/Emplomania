namespace Emplomania.Data.Migrations
{
    using Emplomania.Model;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Emplomania.Data.EmplomaniaAdminDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Emplomania.Data.EmplomaniaAdminDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            if (context.AdminUsers.Count() == 0)
                context.AdminUsers.Add(new AdminUser() { Id = Guid.NewGuid(), Name = "saul", PasswordHash = new PasswordHasher().HashPassword("1234"), Role = Infrastucture.Enums.UserAdminRole.Administrador });
        }
    }
}
