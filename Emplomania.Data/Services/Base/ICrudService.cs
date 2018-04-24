using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.Data.Services.Base
{
    public interface ICrudService<VOT, ENT> : IServiceBase<VOT, ENT> where ENT : class
    {
        VOT Add(VOT vo, bool saveChanges = true);
        void Delete(VOT vo);
        void Update(VOT vo);
        bool Exist(VOT vo);
        void Commit();
        void UndoChanges();
    }
}
