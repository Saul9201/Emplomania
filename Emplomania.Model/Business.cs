using System;
using System.Collections.Generic;

namespace Emplomania.Model
{
    public class Business
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string MovilPhoneNumber { get; set; }
        public string HomePhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public string Details { get; set; }
        public Guid EmployerFK { get; set; }
        public Guid? CategoryFK { get; set; }
        public Guid? MunicipalityFK { get; set; }
        public ICollection<BusinessWorkplace> Workplaces {get; set; }

    }
}