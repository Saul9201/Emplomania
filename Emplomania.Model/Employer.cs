using System;
using System.Collections.Generic;

namespace Emplomania.Model
{
    public class Employer
    {
        public Guid Id { get; set; }
        public string NoLicencia { get; set; }
        public Guid UserFK { get; set; }

        //Relations
        public ICollection<Business> Business { get; set; }

    }
}