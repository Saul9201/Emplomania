using Emplomania.Data.Services;
using Emplomania.Data.VO;
using Emplomania.Infrastucture.Enums;
using Emplomania.UI.Infrastucture;
using Emplomania.UI.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.UI.ViewModels.PaymentGatewayViewModels
{
    public class PaymentGatewayViewModel : EMViewModelBase
    {
        public bool UserClientIdetityKnow { get; set; } = false;
        //private UserVO currentUser;
        //public UserVO CurrentUser
        //{
        //    get {
        //        return currentUser;
        //    }
        //    set
        //    {
        //        currentUser = value;
        //        if(value!=null)
        //            SelectedClientType=
        //    }
        //}
        public UserVO CurrentUser { get; set; }
        public PaymentGatewayViewModel(EMMainViewModel centralEMMain) : base(centralEMMain)
        {
            CentralEMMain.Subitle = "Pasarela de pago";
            SelectedClientType = UserClientRole.Trabajador;
        }
        private UserClientRole selectedClientType;
        public UserClientRole SelectedClientType
        {
            get { return selectedClientType; }
            set
            {
                selectedClientType = value;
                Memberships = ServiceLocator.Get<IMembershipService>().GetMembershipsByUserType(value).ToList();
                AditionalServices = ServiceLocator.Get<IAditionalServiceService>().GetAditionalServicesByUserType(value).ToList();
            }
        }

        private List<MembershipVO> memberships;
        public List<MembershipVO> Memberships
        {
            get { return memberships; }
            set
            {
                SetProperty(ref memberships, value);
            }
        }

        private List<AditionalServiceVO> aditionalServices;
        public List<AditionalServiceVO> AditionalServices
        {
            get { return aditionalServices; }
            set
            {
                SetProperty(ref aditionalServices, value);
            }
        }
    }
}
