using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.Data.VO.Base
{
    public abstract class NomenclatorVO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public interface INomenclatorVO
    {
        Guid Id { get; set; }
        string Name { get; set; }
    }


}
