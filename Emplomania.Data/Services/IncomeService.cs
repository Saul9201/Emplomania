using Emplomania.Data.Services.Base;
using Emplomania.Data.VO;
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
    }

    public interface IIncomeService : ICrudService<IncomeVO, Income>
    {
    }
}
