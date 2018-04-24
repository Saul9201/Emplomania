using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.Data.Services.Base
{
    public class ServiceBase<VOT, ENT> : IServiceBase<VOT, ENT> where ENT : class
    {
        protected EmplomaniaAdminDBContext db;
        public ServiceBase(EmplomaniaAdminDBContext db)
        {
            this.db = db;
        }

        public virtual IQueryable<VOT> GetAll()
        {
            //projecto es un metodo extensor de automapper
            return db.Set<ENT>().AsNoTracking().ProjectTo<VOT>();
        }

        public virtual VOT Get(Expression<Func<VOT, bool>> where)
        {
            //convierte la expression where de vo a ent y el resultado lo convierte a vo de nuevo
            return GetAll().FirstOrDefault(where);
        }

    }
}
