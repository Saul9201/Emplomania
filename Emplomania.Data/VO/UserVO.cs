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
        public bool Verified { get; set; }
        public float Balance { get; set; }//saldo
        public byte[] ProfileImageRaw { get; set; }
        public AuthenticationTypes AuthenticationType { get; set; }
        public string HowKnowEmplomania { get; set; }
        public string InvitationConfirmCode { get; set; }

        public Guid? MunicipalityFK { get; set; }
        public Guid? MembershipFK { get; set; }
        public Guid? AditionalServiceFK { get; set; }


        private Image profileImage;
        private MunicipalityVO municipality;
        private MembershipVO membership;
        private AditionalServiceVO aditionalService;
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
        public MembershipVO Membership
        {
            get { return membership; }
            set
            {
                membership = value;
                if (membership != null)
                    MembershipFK = membership.Id;
            }
        }
        public AditionalServiceVO AditionalService
        {
            get { return aditionalService; }
            set
            {
                aditionalService = value;
                if (aditionalService != null)
                    AditionalServiceFK = aditionalService.Id;
            }
        }

    }
}
