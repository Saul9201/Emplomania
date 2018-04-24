using Emplomania.Data.Services;
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
    public class LoginViewModel : Base.ViewModelBase
    {
        public LoginViewModel(MainViewModel centralMain):base(centralMain)
        {
            CentralMain.Title = "login";
            SignInCommand = new RelayCommand(this.OnSignInCommandExecute, p=> 
            {
                if (!string.IsNullOrEmpty(UserName))
                    return true;
                else return false;
            });
        }


        //Propiedades Bindeadas
        public UserAdminRole SelectedUserRole { get; set; }
        public string UserName { get; set; }
        public ICommand SignInCommand { get; set; }

        private void OnSignInCommandExecute(object obj)
        {
            RadPasswordBox passwordBox = (RadPasswordBox)obj;
            var adminUserService = ServiceLocator.Get<IAdminUserService>();
            var us = adminUserService.Authentic(SelectedUserRole, UserName, passwordBox.Password);
            if (us != null)
                CentralMain.CurrentViewModel = new EMMainViewModel(CentralMain, SelectedUserRole);
            else
                MessageBox.Show("Revise el usuario y la contraseña.");
        }
    }
}
