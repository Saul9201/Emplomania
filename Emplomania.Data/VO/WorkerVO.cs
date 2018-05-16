using Emplomania.Data.VO.Base;
using Emplomania.Infrastucture.Enums;
using System;
using System.Collections.Generic;

namespace Emplomania.Data.VO
{
    public class WorkerVO:BindableBase
    {
        public Guid Id { get; set; }
        public DateTime? BornDate { get; set; }
        public float Stature { get; set; }
        private bool childrens;
        public bool Childrens
        {
            get {
                return childrens;
            }
            set {
                SetProperty(ref childrens, value);
            }
        }
        public string Barriada { get; set; }
        public string Abilities { get; set; }
        public string Salary { get; set; }
        public string Experience { get; set; }
        public string OtherCourses { get; set; }
        public string OtherHomePhoneNumber { get; set; }
        public string OtherMovilPhoneNumber { get; set; }
        public string OtherEmail { get; set; }

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
        private EyeColorVO eyeColor;
        private SkinColorVO skinColor;
        private ComplexionVO complexion;
        private GenderVO gender;
        private CivilStatusVO civilStatus;
        private SchoolGradeVO schoolGrade;
        private SpecialtyVO specialty;
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
        public EyeColorVO EyeColor
        {
            get { return eyeColor; }
            set
            {
                eyeColor = value;
                if (eyeColor != null)
                    EyeColorFK = eyeColor.Id;
            }
        }
        public SkinColorVO SkinColor
        {
            get { return skinColor; }
            set
            {
                skinColor = value;
                if (skinColor != null)
                    SkinColorFK = skinColor.Id;
            }
        }
        public ComplexionVO Complexion
        {
            get { return complexion; }
            set
            {
                complexion = value;
                if (complexion != null)
                    ComplexionFK = complexion.Id;
            }
        }
        public GenderVO Gender
        {
            get { return gender; }
            set
            {
                gender = value;
                if (gender != null)
                    GenderFK = gender.Id;
            }
        }
        public CivilStatusVO CivilStatus
        {
            get { return civilStatus; }
            set
            {
                civilStatus = value;
                if (civilStatus != null)
                    CivilStatusFK = civilStatus.Id;
            }
        }
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