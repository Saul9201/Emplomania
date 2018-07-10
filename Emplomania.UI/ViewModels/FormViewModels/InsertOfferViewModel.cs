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
    public class InsertOfferViewModel : EMViewModelBase
    {
        private UserVO currentUser;
        private ObservableCollection<UserVO> usersSearchResult;

        public string UserNameToSearch { get; set; }
        public string FullNameToSearch { get; set; }
        public UserClientRole SelectedClientType { get; set; }
        public OfferNeedVO Offer { get; set; }

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

        public ICommand InsertOfferCommand => new RelayCommand(param =>
        {
            if (CurrentUser == null)
            {
                MessageBox.Show("Debe seleccionar algun usuario");
                return;
            }
            Offer.UserFK = CurrentUser.Id;
            var o=ServiceLocator.Get<IOfferNeedService>().Add(Offer);
            if (o != null)
                MessageBox.Show("La Oferta se inserto correctamente en la base de datos local.");
            else 
                MessageBox.Show("La Oferta no se inserto correctamente.");
        });

        public InsertOfferViewModel(EMMainViewModel centralEMMain) : base(centralEMMain)
        {
            Offer = new OfferNeedVO() { Id = Guid.NewGuid(), Discriminator=OfferNeedType.Ofrezco };
        }


    }
}
