﻿using Emplomania.Data.VO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.Data.VO
{
    public class MunicipalityVO : NomenclatorVO
    {
        public Guid ProvinciaId { get; set; }
    }
}
