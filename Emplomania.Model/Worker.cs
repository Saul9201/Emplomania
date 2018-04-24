using System;
using System.Collections.Generic;

namespace Emplomania.Model
{
    public class Worker
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

        public ICollection<WorkReference> WorkReferences { get; set; }
        public ICollection<WorkerDriverLicense> DriverLicenses { get; set; }
        public ICollection<WorkerVehicle> Vehicles { get; set; }
        public ICollection<WorkerLanguage> Languages { get; set; }
        public ICollection<WorkerCourse> Courses { get; set; }
        public ICollection<WorkAspiration> WorkAspirations { get; set; }
    }
}