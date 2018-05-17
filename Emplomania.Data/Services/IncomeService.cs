using Emplomania.Data.Model;
using Emplomania.Data.Services.Base;
using Emplomania.Data.VO;
using Emplomania.Infrastucture.Enums;
using Emplomania.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.Data.Services
{
    internal class IncomeService : CrudService<IncomeVO, Income>, IIncomeService
    {
        public IncomeService(EmplomaniaAdminDBContext db) : base(db)
        {
        }

        public AccountingReportModel GetReport(DateTime? init, DateTime? end, ClientCategory cc)
        {
            var res = new AccountingReportModel();
            IQueryable<Income> timeInterval = from i in db.Incomes
                                              where i.ClientCategory == cc
                                              select i;
            if (init != null)
                timeInterval = timeInterval.Where(x => x.IncomeDate > init);
            if (end != null)
                timeInterval = timeInterval.Where(x => x.IncomeDate < end);
            var q = (from i in timeInterval
                     join m in db.Memberships on i.MembershipFK equals m.Id
                     where i.ClientType == UserClientRole.Empleador
                     group new { i.MoneyCountMemberchipCUC } by m.Name into iGroup
                     select iGroup).ToList();
            res.EmployerEsmeralda = q.Where(x => x.Key == "Esmeralda").FirstOrDefault()?.Sum(x => x.MoneyCountMemberchipCUC) ?? 0;
            res.EmployerRubi = q.Where(x => x.Key == "Rubi").FirstOrDefault()?.Sum(x => x.MoneyCountMemberchipCUC) ?? 0;
            res.EmployerTurquesa = q.Where(x => x.Key == "Turquesa").FirstOrDefault()?.Sum(x => x.MoneyCountMemberchipCUC) ?? 0;
            res.EmployerZafiro = q.Where(x => x.Key == "Zafiro").FirstOrDefault()?.Sum(x => x.MoneyCountMemberchipCUC) ?? 0;
            res.EmployerDiamante = q.Where(x => x.Key == "Diamante").FirstOrDefault()?.Sum(x => x.MoneyCountMemberchipCUC) ?? 0;
            var q2 = (from i in timeInterval
                      join ads in db.AditionalServices on i.AditionalServiceFK equals ads.Id
                      where i.ClientType == UserClientRole.Empleador
                      group new { i.MoneyCountAditionalServCUC } by ads.Name into iGroup
                      select iGroup).ToList();
            res.EmployerAsistenciaTecnica = q2.Where(x => x.Key == "Asistencia Tecnica").FirstOrDefault()?.Sum(x => x.MoneyCountAditionalServCUC) ?? 0;
            res.EmployerOfrezcoNecesito = q2.Where(x => x.Key == "Ofrezco/Necesito").FirstOrDefault()?.Sum(x => x.MoneyCountAditionalServCUC) ?? 0;
            

            var q3 = (from i in timeInterval
                     join m in db.Memberships on i.MembershipFK equals m.Id
                     where i.ClientType == UserClientRole.Trabajador
                     group new { i.MoneyCountMemberchipCUC } by m.Name into iGroup
                     select iGroup).ToList();
            res.WorkerEsmeralda = q3.Where(x => x.Key == "Esmeralda").FirstOrDefault()?.Sum(x => x.MoneyCountMemberchipCUC) ?? 0;
            res.WorkerRubi = q3.Where(x => x.Key == "Rubi").FirstOrDefault()?.Sum(x => x.MoneyCountMemberchipCUC) ?? 0;
            res.WorkerTurquesa = q3.Where(x => x.Key == "Turquesa").FirstOrDefault()?.Sum(x => x.MoneyCountMemberchipCUC) ?? 0;
            res.WorkerZafiro = q3.Where(x => x.Key == "Zafiro").FirstOrDefault()?.Sum(x => x.MoneyCountMemberchipCUC) ?? 0;
            res.WorkerDiamante = q3.Where(x => x.Key == "Diamante").FirstOrDefault()?.Sum(x => x.MoneyCountMemberchipCUC) ?? 0;
            var q4 = (from i in timeInterval
                      join ads in db.AditionalServices on i.AditionalServiceFK equals ads.Id
                      where i.ClientType == UserClientRole.Trabajador
                      group new { i.MoneyCountAditionalServCUC } by ads.Name into iGroup
                      select iGroup).ToList();
            res.WorkerFichaDestacada = q4.Where(x => x.Key == "Ficha Destacada").FirstOrDefault()?.Sum(x => x.MoneyCountAditionalServCUC) ?? 0;
            res.WorkerOfrezcoNecesito = q4.Where(x => x.Key == "Ofrezco/Necesito").FirstOrDefault()?.Sum(x => x.MoneyCountAditionalServCUC) ?? 0;


            var q5 = (from i in timeInterval
                      join m in db.Memberships on i.MembershipFK equals m.Id
                      where i.ClientType == UserClientRole.Profesor
                      group new { i.MoneyCountMemberchipCUC } by m.Name into iGroup
                      select iGroup).ToList();
            res.TeacherEsmeralda = q5.Where(x => x.Key == "Esmeralda").FirstOrDefault()?.Sum(x => x.MoneyCountMemberchipCUC) ?? 0;
            res.TeacherRubi = q5.Where(x => x.Key == "Rubi").FirstOrDefault()?.Sum(x => x.MoneyCountMemberchipCUC) ?? 0;
            res.TeacherTurquesa = q5.Where(x => x.Key == "Turquesa").FirstOrDefault()?.Sum(x => x.MoneyCountMemberchipCUC) ?? 0;
            res.TeacherZafiro = q5.Where(x => x.Key == "Zafiro").FirstOrDefault()?.Sum(x => x.MoneyCountMemberchipCUC) ?? 0;
            res.TeacherDiamante = q5.Where(x => x.Key == "Diamante").FirstOrDefault()?.Sum(x => x.MoneyCountMemberchipCUC) ?? 0;
            var q6 = (from i in timeInterval
                      join ads in db.AditionalServices on i.AditionalServiceFK equals ads.Id
                      where i.ClientType == UserClientRole.Profesor
                      group new { i.MoneyCountAditionalServCUC } by ads.Name into iGroup
                      select iGroup).ToList();
            res.TeacherConfeccionMatricula = q6.Where(x => x.Key == "Confeccion de Matricula").FirstOrDefault()?.Sum(x => x.MoneyCountAditionalServCUC) ?? 0;
            res.TeacherOfrezcoNecesito = q6.Where(x => x.Key == "Ofrezco/Necesito").FirstOrDefault()?.Sum(x => x.MoneyCountAditionalServCUC) ?? 0;

            var q7 = (from i in timeInterval
                      where i.IncomeType == IncomeType.BankDeposit
                      select i).ToList();
            var q8 = (from i in timeInterval
                      where i.IncomeType == IncomeType.CommercialOffice
                      select i).ToList();
            var q9 = (from i in timeInterval
                      where i.IncomeType == IncomeType.CouponSale
                      select i).ToList();

            res.TotalDepositoBancario = q7.Sum(i => i.MoneyCountMemberchipCUC) + q7.Sum(i => i.MoneyCountAditionalServCUC) ?? 0;
            res.TotalOficinaComercial = q8.Sum(i => i.MoneyCountMemberchipCUC) + q8.Sum(i => i.MoneyCountAditionalServCUC) ?? 0;
            res.TotalVentaCupon = q9.Sum(i => i.MoneyCountMemberchipCUC) + q9.Sum(i => i.MoneyCountAditionalServCUC) ?? 0;
            return res;

        }
    }

    public interface IIncomeService : ICrudService<IncomeVO, Income>
    {
        AccountingReportModel GetReport(DateTime? init, DateTime? end, ClientCategory cc);
    }
}
