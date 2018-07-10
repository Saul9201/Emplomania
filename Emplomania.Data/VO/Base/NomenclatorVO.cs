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

        public override bool Equals(object obj)
        {
            var o = obj as NomenclatorVO;
            if (o == null)
                return false;

            return o.Id==this.Id && o.Name==this.Name;
        }

        public override int GetHashCode()
        {
            int hash = 13;
            hash = (hash * 7) + this.Id.GetHashCode();
            hash = (hash * 7) + (this.Name != null ? this.Name.GetHashCode() : 0);
            return hash;
        }
    }

    public interface INomenclatorVO
    {
        Guid Id { get; set; }
        string Name { get; set; }
    }


}
