using Emplomania.Data.VO.Base;
using Emplomania.Infrastucture.Enums;
using Emplomania.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.Data.VO
{
    public class UserVO : BindableBase
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string MovilPhoneNumber { get; set; }
        public string HomePhoneNumber { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string LastName2 { get; set; }
        public string PrivateAddress { get; set; }
        public bool Verified { get; set; }
        public float Balance { get; set; }//saldo
        public byte[] ProfileImageRaw { get; set; }
        private Image profileImage;
        public Image ProfileImage
        {
            get
            {
                if (profileImage == null)
                    profileImage = Image.FromStream(new MemoryStream(ProfileImageRaw));
                return profileImage;
            }
            set
            {
                SetProperty(ref profileImage, value);
                if (value != null)
                    using (var ms = new MemoryStream())
                    {
                        value.Save(ms, value.RawFormat);
                        ProfileImageRaw = ms.ToArray();
                    }
            }
        }
        public Guid MunicipalityFK { get; set; }

        #region Old
        //public Guid Id { get; set; }
        //public string UserName { get; set; }
        //public string PasswordHash { get; set; }
        //public string MovilPhoneNumber { get; set; }
        //public string Email { get; set; }
        //public bool ProfileCreated { get; set; }
        //public string Name { get; set; }
        //public string LastName { get; set; }
        //public string LastName2 { get; set; }
        //public string PrivateAddress { get; set; }
        //public string HomePhoneNumber { get; set; }
        ////public int Ticket { get; set; }
        //public bool Verified { get; set; }
        //public bool Actived { get; set; }
        //public float Balance { get; set; }
        //private Image profileImage;
        //public Image ProfileImage
        //{
        //    get { return profileImage; }
        //    set { SetProperty(ref profileImage, value); }
        //}
        //public DateTime BornDate { get; set; }
        //public string Barriada { get; set; }
        //public string Abilities { get; set; }
        //public string Salary { get; set; }
        //public string Experience { get; set; }
        //public string NoLicencia { get; set; }
        //public Guid MembershipFK { get; set; }

        //private MembershipVO membership;
        //public MembershipVO Membership
        //{
        //    get { return membership; }
        //    set
        //    {
        //        membership = value;
        //        MembershipFK = membership.Id;
        //    }
        //}

        //public Guid MunicipalityFK { get; set; }
        //private MunicipalityVO municipality;

        //public MunicipalityVO Municipality
        //{
        //    get { return municipality; }
        //    set
        //    {
        //        municipality = value;
        //        MunicipalityFK = municipality.Id;
        //    }
        //}
        //public ProvinceVO Province { get; set; }

        //public UserClientRole Role { get; set; }
        //public Gender Gender { get; set; }
        //public float Stature { get; set; }
        //public bool Childrens { get; set; }
        //public Guid EyeColorFK { get; set; }
        //private EyeColorVO eyeColor;

        //public EyeColorVO EyeColor
        //{
        //    get { return eyeColor; }
        //    set
        //    {
        //        eyeColor = value;
        //        EyeColorFK = eyeColor.Id;
        //    }
        //}

        //public Guid SkinColorFK { get; set; }
        //private SkinColorVO skinColor;

        //public SkinColorVO SkinColor
        //{
        //    get { return skinColor; }
        //    set
        //    {
        //        skinColor = value;
        //        SkinColorFK = skinColor.Id;
        //    }
        //}

        //public Guid ComplexionFK { get; set; }
        //private ComplexionVO complexion;

        //public ComplexionVO Complexion
        //{
        //    get { return complexion; }
        //    set
        //    {
        //        complexion = value;
        //        ComplexionFK = complexion.Id;
        //    }
        //}

        //public Guid CivilStatusFK { get; set; }
        //private CivilStatusVO civilStatus;

        //public CivilStatusVO CivilStatus
        //{
        //    get { return civilStatus; }
        //    set
        //    {
        //        civilStatus = value;
        //        CivilStatusFK = civilStatus.Id;
        //    }
        //}

        //public Guid ScheduleFK { get; set; }
        //private ScheduleVO schedule;

        //public ScheduleVO Schedule
        //{
        //    get { return schedule; }
        //    set
        //    {
        //        schedule = value;
        //        ScheduleFK = schedule.Id;
        //    }
        //}


        ////Propiedades que no son propias del usuario
        //private AuthenticationTypes authenticationType;
        //public AuthenticationTypes AuthenticationType
        //{
        //    get { return authenticationType; }
        //    set { SetProperty(ref authenticationType, value); }
        //}
        //public string InvitationCode { get; set; }


        ////Propiedades de un Empleador
        //public string LicenseNumber { get; set; }
        //public Guid MunicipalityNegFK { get; set; }
        //private MunicipalityVO municipalityNeg;
        //public MunicipalityVO MunicipalityNeg
        //{
        //    get { return municipalityNeg; }
        //    set
        //    {
        //        municipalityNeg = value;
        //        MunicipalityNegFK = municipalityNeg.Id;
        //    }
        //}
        //public ProvinceVO ProvinceNeg { get; set; }

        //public string NameNeg { get; set; }
        //public string AddressNeg { get; set; }
        //public string MovilPhoneNumberNeg { get; set; }
        //public string EmailNeg { get; set; }
        //public string DetailNeg { get; set; }
        //public Guid CategoryNegFK { get; set; }
        //private CategoryVO categoryNeg;
        //public CategoryVO CategoryNeg
        //{
        //    get { return categoryNeg; }
        //    set
        //    {
        //        categoryNeg = value;
        //        CategoryNegFK = categoryNeg.Id;
        //    }
        //}
        //public string HomePhoneNumberNeg { get; set; }
        //public string WebSiteNeg { get; set; }


        #endregion
    }
}
