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

namespace Emplomania.UI.ViewModels.FormViewModels
{
    public class InsertNeedViewModel : EMViewModelBase
    {
        private UserVO currentUser;
        private ObservableCollection<UserVO> usersSearchResult;

        public string UserNameToSearch { get; set; }
        public string FullNameToSearch { get; set; }
        public UserClientRole SelectedClientType { get; set; }
        public OfferNeedVO Need { get; set; }

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
        public ICommand SearchButtonCommand => new RelayCommand(param =>
        {
            UsersSearchResult = new ObservableCollection<UserVO>(DataAdministrator.GetUserByUserNameOrFullName(SelectedClientType, UserNameToSearch, FullNameToSearch));
        });

        public ICommand InsertNeedCommand => new RelayCommand(param =>
        {
            if (CurrentUser == null)
            {
                MessageBox.Show("Debe seleccionar algun usuario");
                return;
            }
            if (Need.WorkplaceFK == null)
            {
                MessageBox.Show("Debe seleccionar una categoria.");
                return;
            }
            Need.UserFK = CurrentUser.Id;
            //TODO: Chequear antes de insertar que no excista un necesito con el mismo user y workplacefk, de ser true preguntar al usuario si se desea continuar con la insercion
            var o = ServiceLocator.Get<IOfferNeedService>().Add(Need);
            if (o != null)
                MessageBox.Show("El Necesito se inserto correctamente en la base de datos local.");
            else
                MessageBox.Show("El Necesito no se inserto correctamente.");
        });

        public InsertNeedViewModel(EMMainViewModel centralEMMain) : base(centralEMMain)
        {
            Subtitle = "insertar necesito";
            Need = new OfferNeedVO() { Id = Guid.NewGuid(), Discriminator = OfferNeedType.Necesito };
        }
    }
}
