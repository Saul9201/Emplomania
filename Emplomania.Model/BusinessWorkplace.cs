﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.Model
{
    public class BusinessWorkplace
    {
        public int Id { get; set; }
        public Guid BusinessFK { get; set; }
        public Guid WorkplaceFK { get; set; }
    }
}
