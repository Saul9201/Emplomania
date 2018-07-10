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
    internal class OfferNeedService : CrudService<OfferNeedVO, OfferNeed>, IOfferNeedService
    {
        public OfferNeedService(EmplomaniaAdminDBContext db) : base(db)
        {
        }
    }

    public interface IOfferNeedService : ICrudService<OfferNeedVO, OfferNeed>
    {
    }
}
