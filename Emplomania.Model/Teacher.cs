using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.Model
{
    public class Teacher
    {
        public Guid Id { get; set; }
        public string NoLicencia { get; set; }
        public string NoCarnet { get; set; }
        public string Address { get; set; }
        public string CoursesDetails { get; set; }
        public string WebSite { get; set; }

        public Guid UserFK { get; set; }
        public Guid? SchoolGradeFK { get; set; }
        public Guid? SpecialtyFK { get; set; }
    }
}
