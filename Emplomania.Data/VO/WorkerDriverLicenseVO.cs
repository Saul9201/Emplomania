﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.Data.VO
{
    public class WorkerDriverLicenseVO
    {
        public int Id { get; set; }
        public Guid WorkerFK { get; set; }
        public Guid DriverLicenseFK { get; set; }
    }
}
