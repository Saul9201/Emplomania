using Emplomania.Data.VO.Base;
using Emplomania.UI.Infrastucture;
using Emplomania.UI.ViewModels.Base;
using Emplomania.UI.ViewModels.StartViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Emplomania.UI.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private ViewModelBase currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                SetProperty(ref currentViewModel, value);
            }
        }
        
        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                SetProperty(ref title, value.ToUpper());
            }
        }
        
        public MainViewModel()
        {
            this.Title = "Emplomania";
            this.currentViewModel = new LoginViewModel(this);
        }

        #region Commands
        public ICommand CloseWindowsCommand
        {
            get
            {
                return new RelayCommand(action => Environment.Exit(0));
            }
        }

        private bool isTracking = false;
        public bool IsTracking
        {
            get { return isTracking; }
            set { SetProperty(ref isTracking, value); }
        }

        #endregion
    }
}
