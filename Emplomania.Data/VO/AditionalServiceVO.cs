using Emplomania.Data.VO.Base;
using Emplomania.Infrastucture.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.Data.VO
{
    public class AditionalServiceVO: NomenclatorVO
    {
        public UserClientRole UserType { get; set; }
        public int Price { get; set; }
    }
}
