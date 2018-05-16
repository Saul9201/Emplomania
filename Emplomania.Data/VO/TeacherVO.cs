using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.Data.VO
{
    public class TeacherVO
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

        private SchoolGradeVO schoolGrade;
        public SchoolGradeVO SchoolGrade
        {
            get { return schoolGrade; }
            set
            {
                schoolGrade = value;
                if (schoolGrade != null)
                    SchoolGradeFK = schoolGrade.Id;
            }
        }
        private SpecialtyVO specialty;
        public SpecialtyVO Specialty
        {
            get { return specialty; }
            set
            {
                specialty = value;
                if (specialty != null)
                    SpecialtyFK = specialty.Id;
            }
        }
    }
}
