using AutoMapper;
using AutoMapper.QueryableExtensions;
using Emplomania.Data.Services.Base;
using Emplomania.Data.VO;
using Emplomania.Infrastucture.Enums;
using Emplomania.Model;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.Data.Services
{
    internal class AdminUserService : ServiceBase<AdminUserVO, AdminUser>, IAdminUserService
    {
        public AdminUserService(EmplomaniaAdminDBContext db) : base(db)
        {
        }

        public bool Create(UserAdminRole userRole, string userName, string pass)
        {
            var readDB = new EmplomaniaAdminDBContext();
            var users = (from u in readDB.AdminUsers
                         where u.Role == userRole && u.Name == userName
                         select u).ToList();
            if (users.Count != 0 && users.Any(x => x.Name == userName))
                return false;
            db.AdminUsers.Add(new AdminUser() { Id = Guid.NewGuid(), Name = userName, PasswordHash = new PasswordHasher().HashPassword(pass), Role = userRole });
            db.SaveChanges();
            return true;
        }

        public AdminUserVO Authentic(UserAdminRole role, string adminUserName, string pass)
        {
            var readDB = new EmplomaniaAdminDBContext();
            var users = (from u in readDB.AdminUsers
                         where u.Role == role && u.Name == adminUserName
                         select u).ToList();

            //Esto es porque el where de Linq no distingue entre mayusculas y minusculas
            var us = users.Where(x => x.Name == adminUserName).FirstOrDefault();
            if (new PasswordHasher().VerifyHashedPassword(us?.PasswordHash, pass) != PasswordVerificationResult.Success)
                return null;
            else
                return Mapper.Map<AdminUserVO>(us);
        }
    }

    public interface IAdminUserService : IServiceBase<AdminUserVO, AdminUser>
    {
        bool Create(UserAdminRole userRole, string userName, string pass);
        AdminUserVO Authentic(UserAdminRole role, string adminUserName, string pass);
    }
}
