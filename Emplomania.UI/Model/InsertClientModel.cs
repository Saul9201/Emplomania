using Emplomania.Data.VO;
using Emplomania.Data.VO.Base;
using Emplomania.Infrastucture.Enums;
using Emplomania.UI.Infrastucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.UI.Model
{
    public class InsertClientModel : BindableBase
    {
        private AuthenticationTypes authenticationTypes;
        public AuthenticationTypes AuthenticationTypes
        {
            get { return authenticationTypes; }
            set
            {
                SetProperty(ref authenticationTypes, value);
            }
        }
        public string InvitationCode { get; set; }
        public UserClientRole UserClientRole { get; set; }
        
        public UserVO UserVO { get; set; }
    }
}
