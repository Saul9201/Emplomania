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
        #endregion

        #region Commands
        public ICommand SearchButtonCommand => new RelayCommand(param =>
        {
            UsersSearchResult = new ObservableCollection<UserVO>(DataAdministrator.GetUserByUserNameOrFullName(SelectedClientType, UserNameToSearch, FullNameToSearch));
        });

        public ICommand AlterButtonCommand => new RelayCommand(param =>
        {
            if (CurrentUser == null)
            {
                MessageBox.Show("Debe seleccionar algun usuario");
                return;
            }
            switch (SelectedClientType)
            {
                case UserClientRole.Trabajador:
                    var workModel = new InsertWorkerModel(CurrentUser.Id);
                    CentralEMMain.DisplayInsertClientWorkerView.Execute(workModel);
                    break;
                case UserClientRole.Empleador:
                    var emplModel = new InsertEmployerModel(currentUser);
                    CentralEMMain.DisplayInsertClientEmployerView.Execute(emplModel);
                    break;
                case UserClientRole.Profesor:
                    var teachModel = new InsertTeacherModel(currentUser);
                    CentralEMMain.DisplayInsertClientTeacherView.Execute(teachModel);
                    break;
                default:
                    break;
            }
        });
        #endregion
    }
}
