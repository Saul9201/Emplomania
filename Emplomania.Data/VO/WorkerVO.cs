using System;
using System.Collections.Generic;

namespace Emplomania.Data.VO
{
    public class WorkerVO
    {
        public Guid Id { get; set; }
        public DateTime? BornDate { get; set; }
        public float Stature { get; set; }
        public bool Childrens { get; set; }
        public string Barriada { get; set; }
        public string Abilities { get; set; }
        public string Salary { get; set; }
        public string Experience { get; set; }
        public string OtherCourses { get; set; }

        public Guid UserFK { get; set; }
        public Guid? EyeColorFK { get; set; }
        public Guid? SkinColorFK { get; set; }
        public Guid? ComplexionFK { get; set; }
        public Guid? GenderFK { get; set; }
        public Guid? CivilStatusFK { get; set; }
        public Guid? SchoolGradeFK { get; set; }
        public Guid? SpecialtyFK { get; set; }

        public List<WorkReferenceVO> WorkReferences { get; set; }
        public List<DriverLicenseVO> DriverLicenses { get; set; }
        public List<VehicleVO> Vehicles { get; set; }
        public List<WorkerLanguageVO> Languages { get; set; }
        public List<CourseVO> Courses { get; set; }
        public List<WorkAspirationVO> WorkAspirations { get; set; }

        private UserVO user;
        public UserVO User
        {
            get { return user; }
            set
            {
                user = value;
                if (user != null)
                    UserFK = user.Id;
            }
        }

    }
}