using Emplomania.Data.Services;
using Emplomania.Data.VO;
using Emplomania.Infrastucture.Enums;
using Emplomania.UI.Infrastucture;
using Emplomania.UI.Model;
using Emplomania.UI.ViewModels.Base;
using Emplomania.UI.Views.UserViews;
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
    public class AlterClientViewModel : EMViewModelBase
    {
        public AlterClientViewModel(EMMainViewModel emMainViewModel) : base(emMainViewModel)
        {
            CentralEMMain.Subitle = "MODIFICAR CLIENTE";
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
        #endregion

        #region Commands
        public ICommand SearchButtonCommand => new RelayCommand(param =>
        {
            UsersSearchResult = new ObservableCollection<UserVO>(DataAdministrator.GetUserByUserNameOrFullName(SelectedClientType, UserNameToSearch, FullNameToSearch));
        });

        public ICommand AlterButtonCommand => new RelayCommand(param =>
        {
            //TODO: Crear un InsertClientModel con los datos que tengo en el viewmodel(si estos son validos) y llamar al
            //command dedicado a mostrar la vista correspondiente.
            switch (SelectedClientType)
            {
                case UserClientRole.Trabajador:
                    WorkerVO worker = ServiceLocator.Get<IWorkerService>().Get(x => x.UserFK == CurrentUser.Id);
                    if (worker == null)
                    {
                        MessageBox.Show("Error interno.");
                        return;
                    }
                    var iwm = new InsertWorkerModel()
                    {
                        UserVO=CurrentUser,
                        WorkerVO=worker,
                        AuthenticationTypes=CurrentUser.AuthenticationType,
                        Childrens = worker.Childrens?YesNotAnswer.Yes:YesNotAnswer.No,

                        //TODO++: Antes de hacer esto arreglar lo de los modelos de insercion
                        //TODO: Agregar AuthenticationTypes a UserVO y User para guardarlo en base de datos y aqui hacer: AuthenticationTypes=CurrentUser.AuthenticationType
                        
                    };
                    break;
                case UserClientRole.Empleador:
                    break;
                case UserClientRole.Profesor:
                    break;
                default:
                    break;
            }
        });
        #endregion
    }
}
