using Emplomania.Infrastucture.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.Model
{
    public class User
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
        public float Balance { get; set; }
        public byte[] ProfileImageRaw { get; set; }
        public AuthenticationTypes AuthenticationType { get; set; }
        public string HowKnowEmplomania { get; set; }
        public string InvitationConfirmCode { get; set; }

        public Guid? MunicipalityFK { get; set; }
        public Guid? MembershipFK { get; set; }
        public Guid? AditionalServiceFK { get; set; }
        
        public ICollection<Employer> Employers { get; set; }
        public ICollection<Worker> Workers { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
    }
}
