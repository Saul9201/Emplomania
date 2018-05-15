using Emplomania.Data.VO;
using Emplomania.Data.VO.Base;
using Emplomania.Infrastucture;
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
        public InsertClientModel()
        {
            UserVO = new UserVO()
            {
                Id = Guid.NewGuid(),
                UserName = Guid.NewGuid().ToString("N"),
                PasswordHash = Guid.NewGuid().ToString("N"),
                HowKnowEmplomania = WebNomenclatorsCache.Instance.HowKnowEM.FirstOrDefault(),
            };
        }
        public AuthenticationTypes AuthenticationTypes
        {
            get { return UserVO == null ? AuthenticationTypes.NaturalAuthRB : UserVO.AuthenticationType; }
            set
            {
                if (UserVO != null)
                    UserVO.AuthenticationType = value;
                OnPropertyChanged();
            }
        }
        public UserClientRole UserClientRole { get; set; }
        public UserVO UserVO { get; set; }

        private ProvinceVO province;
        private List<MunicipalityVO> municipalities;

        public ProvinceVO Province
        {
            get { return province; }
            set
            {
                province = value;
                if (value != null)
                    Municipalities = WebNomenclatorsCache.Instance.Municipalities.Where(x => x.ProvinciaId == value.Id).ToList();
                else
                    Municipalities = new List<MunicipalityVO>();
            }
        }
        public List<MunicipalityVO> Municipalities
        {
            get { return municipalities; }
            set
            {
                SetProperty(ref municipalities, value);
            }
        }
    }
}
