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
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Emplomania.UI.ViewModels.UserViewMoldels
{
    public class SaleCredCuponViewModel : EMViewModelBase
    {
        public SaleCredCuponViewModel(EMMainViewModel emMainViewModel) : base(emMainViewModel)
        {
            Subtitle = "VENTA DE CUPÓN DE CRÉDITO";
            CentralEMMain.ResetScrollContent();
        }

        #region Campos
        private UserVO currentUser;
        private ObservableCollection<UserVO> usersSearchResult;
        #endregion

        #region Propiedades
        public UserClientRole SelectedClientType { get; set; }
        public UserVO CurrentUser
        {
            get { return currentUser; }
            set { SetProperty(ref currentUser, value); }
        }
        public ObservableCollection<UserVO> UsersSearchResult
        {
            get { return usersSearchResult; }
            set { SetProperty(ref usersSearchResult, value); }
        }
        public string UserNameToSearch { get; set; }
        public string FullNameToSearch { get; set; }
        public MoneyType MoneyType { get; set; }
        public float MoneyCount { get; set; }
        #endregion

        #region Commands
        public ICommand SearchButtonCommand => new RelayCommand(param =>
        {
            UsersSearchResult = new ObservableCollection<UserVO>(DataAdministrator.GetUserByUserNameOrFullName(SelectedClientType, UserNameToSearch, FullNameToSearch));
        });

        public ICommand AddCredCuponButtonCommand => new RelayCommand(param =>
        {
            if (CurrentUser != null && MoneyCount > 0)
            {
                float moneyCountCUC = MoneyType == MoneyType.CUP ? MoneyCount / 25 : MoneyCount;
                //TODO: Poner otro campo bool en la tabla Income que diga si la fila correspondiente ya fue
                //sincronizada con el sitio web. Chequear si existe en la db algun ingreso con el mismo usuario que el ingreso que se
                //decea insertar, de ser asi notificar o preguntar a yoanna que hacer. Resordar cambiar esto en la pasarela de pago.
                var i = ServiceLocator.Get<IIncomeService>().Add(new IncomeVO
                {
                    ClientType = SelectedClientType,
                    IncomeDate = DateTime.Now,
                    User = CurrentUser.Id,
                    IncomeType = IncomeType.CouponSale,
                    ClientCategory = ClientCategory.CommonCustomer,
                    MoneyCountCredCupponCUC = moneyCountCUC,
                });
                if(i!=null)
                    MessageBox.Show("Cupon insertado correctamente.");
                else
                    MessageBox.Show("Error interno al insertar a la db local.");

            }
            else
                MessageBox.Show("Usuario no seleccionado o Cantidad de dinero = 0.");
        });
        #endregion
    }
}
