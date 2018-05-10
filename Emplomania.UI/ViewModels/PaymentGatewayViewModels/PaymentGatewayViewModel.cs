using Emplomania.Data.Services;
using Emplomania.Data.VO;
using Emplomania.Infrastucture.Enums;
using Emplomania.UI.Infrastucture;
using Emplomania.UI.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Telerik.Windows.Controls;

namespace Emplomania.UI.ViewModels.PaymentGatewayViewModels
{
    public class PaymentGatewayViewModel : EMViewModelBase
    {
        public string UserNameToSearch { get; set; }
        public string FullNameToSearch { get; set; }
        public bool UserClientIdetityKnow { get; set; } = false;
        //private UserVO currentUser;
        //public UserVO CurrentUser
        //{
        //    get
        //    {
        //        return currentUser;
        //    }
        //    set
        //    {
        //        SetProperty(ref currentUser, value);
        //    }
        //}
        private UserVO currentUser;
        public UserVO CurrentUser
        {
            get { return currentUser; }
            set { SetProperty(ref currentUser, value); }
        }
        public IncomeVO IncomeVO { get; set; }
        public PaymentGatewayViewModel(EMMainViewModel centralEMMain) : base(centralEMMain)
        {
            CentralEMMain.Subitle = "Pasarela de pago";
            SelectedClientType = UserClientRole.Trabajador;
            IncomeVO = new IncomeVO();
            MembershipMoney = 0;
            AditionSerMoney = 0;
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


        public float? MembershipMoney { get; set; }
        public MoneyType MembershipMoneyType { get; set; }

        public float? AditionSerMoney { get; set; }
        public MoneyType AditionSerMoneyType { get; set; }

        public float? ReturnMoney { get; set; }

        private MembershipVO selectedMembership;
        public MembershipVO SelectedMembership
        {
            get { return selectedMembership; }
            set
            {
                selectedMembership = value;
            }
        }

        private AditionalServiceVO selectedAditServ;
        public AditionalServiceVO SelectedAditServ
        {
            get { return selectedAditServ; }
            set
            {
                selectedAditServ = value;
            }
        }

        private ObservableCollection<UserVO> usersSearchResult;
        public ObservableCollection<UserVO> UsersSearchResult
        {
            get { return usersSearchResult; }
            set { SetProperty(ref usersSearchResult, value); }
        }

        public ICommand CobrarButtonCommand => new RelayCommand(param =>
        {
            IncomeVO.ClientType = SelectedClientType;
            IncomeVO.IncomeDate = DateTime.Now;
            IncomeVO.User = CurrentUser.Id;
            if (ValidM)
            {
                if ((MembershipMoneyType == MoneyType.CUC && MembershipMoney >= SelectedMembership.Price)
                || (MembershipMoneyType == MoneyType.CUP && MembershipMoney / 25 >= SelectedMembership.Price))
                {
                    IncomeVO.MembershipFK = SelectedMembership.Id;
                    IncomeVO.MoneyCountMemberchipCUC = MembershipMoneyType == MoneyType.CUC ? MembershipMoney : MembershipMoney / 25;
                }
                else
                {
                    MessageBox.Show($"{MembershipMoney} {MembershipMoneyType} no es suficiente para pagar {SelectedMembership.Name}.");
                    return;
                }
            }
            if (ValidAS)
            {
                if ((AditionSerMoneyType == MoneyType.CUC && AditionSerMoney >= SelectedAditServ.Price)
                || (AditionSerMoneyType == MoneyType.CUP && AditionSerMoney / 25 >= SelectedAditServ.Price))
                {
                    IncomeVO.AditionalServiceFK = SelectedAditServ.Id;
                    IncomeVO.MoneyCountAditionalServCUC = AditionSerMoneyType == MoneyType.CUC ? AditionSerMoney : AditionSerMoney / 25;
                }
                else
                {
                    MessageBox.Show($"{AditionSerMoney} {AditionSerMoneyType} no es suficiente para pagar {SelectedAditServ.Name}.");
                    return;
                }
            }
            if (ServiceLocator.Get<IIncomeService>().Add(IncomeVO) != null)
            {
                MessageBox.Show("El cobro fue efectuado correctamente.\nRecuerde sincronizar cuando se conecte a internet.");
                //RadWindow.Alert(new DialogParameters
                //{
                //    Content = "El cobro fue efectuado correctamente.\nRecuerde sincronizar cuando se conecte a internet.",
                //    Owner = Application.Current.MainWindow,
                //});
                if (UserClientIdetityKnow)
                    //TODO: Pensar si no es mejor aqui virar para donde estaba
                    CentralEMMain.DisplayBasicView.Execute(null);
            }
            else
            {
                MessageBox.Show("Error interno al insertar a la db local.");
            }

        },
            param => CanExecuteCobrarButton());
        public ICommand SearchButtonCommand => new RelayCommand(param =>
        {
            UsersSearchResult = new ObservableCollection<UserVO>(DataAdministrator.GetUserByUserNameOrFullName(SelectedClientType, UserNameToSearch, FullNameToSearch));
        });

        public bool ValidM
        {
            get
            {
                return CurrentUser != null && SelectedMembership != null && MembershipMoney != null;
            }
        }
        private bool ValidAS
        {
            get
            {
                return CurrentUser != null && SelectedAditServ != null && AditionSerMoney != null;
            }
        }
        private bool CanExecuteCobrarButton()
        {
            return ValidM || ValidAS;
        }
    }
}
