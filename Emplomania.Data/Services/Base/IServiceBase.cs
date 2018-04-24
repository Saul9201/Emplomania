using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.Data.Services.Base
{
    public interface IServiceBase<VOT, ENT> where ENT : class
    {
        IQueryable<VOT> GetAll();

        VOT Get(Expression<Func<VOT, bool>> where);
    }
}
