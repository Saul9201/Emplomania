﻿using Emplomania.Data;
using Emplomania.Data.ApiClient.Services;
using Emplomania.Data.Services;
using Emplomania.Data.VO;
using Emplomania.Model;
//using Emplomania.UI.Infrastucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Emplomania.UI.Infrastucture;
using Emplomania.Infrastucture.Enums;

namespace Emplomania.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            AutoMapper.Mapper.Initialize(cfg => MapConfiguration.Configure(cfg));
            ServiceLocator.Get<IIncomeService>().GetReport(null, null, ClientCategory.CommonCustomer);



            //var ms = ServiceLocator.Get<IMembershipService>();
            //var m = ms.GetAll().Where(x => x.UserType == UserClientRole.Empleador).ToList();
            //foreach (var item in m)
            //{
            //    ms.Add(new MembershipVO { Id = Guid.NewGuid(), Name = item.Name, Price = 0, UserType = UserClientRole.Profesor });
            //}

            //var l=ServiceLocator.Get<IWorkerService>().GetAll().ToList();

            //var ass = ServiceLocator.Get<IAditionalServiceService>();
            //ass.Add(new AditionalServiceVO() { Id = Guid.NewGuid(), Name = "Ofrezco/Necesito", Price = 0, UserType = UserClientRole.Empleador });
            //ass.Add(new AditionalServiceVO() { Id = Guid.NewGuid(), Name = "Ofrezco/Necesito", Price = 0, UserType = UserClientRole.Trabajador });
            //ass.Add(new AditionalServiceVO() { Id = Guid.NewGuid(), Name = "Ofrezco/Necesito", Price = 0, UserType = UserClientRole.Profesor });

            //ass.Add(new AditionalServiceVO() { Id = Guid.NewGuid(), Name = "Ficha Destacada", Price = 0, UserType = UserClientRole.Trabajador });
            //ass.Add(new AditionalServiceVO() { Id = Guid.NewGuid(), Name = "Asistencia Tecnica", Price = 0, UserType = UserClientRole.Empleador });
            //ass.Add(new AditionalServiceVO() { Id = Guid.NewGuid(), Name = "Confeccion de Matricula", Price = 0, UserType = UserClientRole.Profesor });

            //Guid[] l = new Guid[7];
            //l[2] = Guid.NewGuid();
            //Util Para generar userNameyPasswords
            //var g=Guid.NewGuid();
            //Console.WriteLine(g.ToString("N"));

            //string p = new PasswordHasher().HashPassword("olivera");
            //var v=new PasswordHasher().VerifyHashedPassword("AByZ1YE6UKPwfDUX3AE2IjlueeNRhiSPNBGBjmqT+Y1AIYD4lZt/OjqJQMhxApk9PQ==", "OLIVERA");
            //DataAdministrator.SincLocalDbWithWebSiteDb();
            //var serv = ServiceLocator.Get<IUtilsWebService>();
            //Console.WriteLine(serv.TestConnection());
            //EyeColorVO specificEyeColor = serv.GetAsync(new Guid("00000000-0000-0000-0000-000000000000")).GetAwaiter().GetResult();
            //EyeColorVO redEyeColor = serv.CreateAsync(new EyeColorVO() { Name = "Rojo", Id = Guid.NewGuid() }).GetAwaiter().GetResult();
            //bool updateRes = serv.UpdateAsync(new EyeColorVO() { Name = "Colorao", Id = redEyeColor.Id }).GetAwaiter().GetResult();
            //bool deleteRes = serv.DeleteAsync(redEyeColor.Id).GetAwaiter().GetResult();


            //var em = new EmplomaniaWebApiClient();
            //var t = em.GetDataAsync<List<TPP>>("trabajadores/GetTrabajadoresXPlazas");
            //Task.WaitAll(t);
            //var l = t.Result;



            //var cs = ServiceLocator.Get<IUserRoleService>();
            //cs.Add(new UserRoleVO() { Id = Guid.NewGuid(), Name = "Empleador" });
            //cs.Add(new UserRoleVO() { Id = Guid.NewGuid(), Name = "Trabajador" });
            //cs.Add(new UserRoleVO() { Id = Guid.NewGuid(), Name = "Profesor" });

            //EmplomaniaAdminDBContext writeDB = new EmplomaniaAdminDBContext();

            //var p=writeDB.Provinces.Add(new Province() { Name = "Prov1" , Id = Guid.NewGuid() });

            //writeDB.Municipalities.Add(new Municipality() { Name = "Algo",ProvinceFK = p.Id });

            //writeDB.SaveChanges();
        }
    }
}
