using Emplomania.Data.Services;
using Emplomania.Data.VO;
using Emplomania.UI.Infrastucture;
using Emplomania.UI.Model;
using Emplomania.UI.ViewModels.Base;
using Emplomania.UI.ViewModels.UserViewMoldels.InsertClientViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Emplomania.UI.ViewModels.UserViewMoldels
{

    public class InsertClientViewModel : EMViewModelBase
    {
        public InsertClientModel InsertClientModel { get; set; }

        public InsertClientViewModel(EMMainViewModel emMainViewModel) : base(emMainViewModel)
        {
            Subtitle = "Insertar Cliente";
            InsertClientModel = new InsertClientModel();
        }
    

    }
}
