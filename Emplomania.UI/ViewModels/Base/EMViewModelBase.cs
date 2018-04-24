using Emplomania.Data.VO.Base;
using Emplomania.UI.Infrastucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.UI.ViewModels.Base
{
    //Clase de la que heredan todos los view model que van dentro de la ventana que no contiene el menu 
    public class EMViewModelBase : BindableBase
    {
        public EMMainViewModel CentralEMMain { get; set; }// View Model de la ventana que me contiene
        public EMViewModelBase(EMMainViewModel centralEMMain)
        {
            CentralEMMain = centralEMMain;
        }
        
    }
}
