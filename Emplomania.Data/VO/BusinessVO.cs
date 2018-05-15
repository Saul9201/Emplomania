using System;
using System.Collections.Generic;

namespace Emplomania.Data.VO
{
    public class BusinessVO
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
        public List<WorkplaceVO> Workplaces { get; set; }

        private MunicipalityVO municipality;
        private CategoryVO category;

        public MunicipalityVO Municipality
        {
            get { return municipality; }
            set
            {
                municipality = value;
                if (municipality != null)
                    MunicipalityFK = municipality.Id;
            }
        }
        public CategoryVO Category
        {
            get { return category; }
            set
            {
                category = value;
                if (category != null)
                    CategoryFK = category.Id;
            }
        }
    }
}