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
using System.Windows;
using System.Windows.Input;
using Telerik.Windows.Controls;

namespace Emplomania.UI.ViewModels.StartViewModels
{
    public class CreateUserViewModel : EMViewModelBase
    {
        public CreateUserViewModel(EMMainViewModel emMainViewModel) : base(emMainViewModel)
        {
            Subtitle = "Crear usuario administrativo";
            CreateCommand = new RelayCommand(this.OnCreateCommandExecute, p =>
            {
                if (!string.IsNullOrEmpty(UserName))
                    return true;
                else return false;
            });
        }

        //Propiedades Bindeadas
        public UserAdminRole SelectedUserRole { get; set; }
        public string UserName { get; set; }
        public ICommand CreateCommand { get; set; }

        private void OnCreateCommandExecute(object obj)
        {
            RadPasswordBox passwordBox = (RadPasswordBox)obj;
            var adminUserService = ServiceLocator.Get<IAdminUserService>();
            
            if (adminUserService.Create( SelectedUserRole, UserName, passwordBox.Password))
                CentralEMMain.CurrentViewModel = new BasicViewModel(CentralEMMain);
            else
                MessageBox.Show("El usuario que decea insertar ya exciste");
        }
    }
}
