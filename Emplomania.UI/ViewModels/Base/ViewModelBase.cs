using Emplomania.Data.VO.Base;
using Emplomania.UI.Infrastucture;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.UI.ViewModels.Base
{
    //Clase base de la cual heredan las ventanas mas generales(Login y EMMain)
    public abstract class ViewModelBase : BindableBase
    {
        public MainViewModel CentralMain { get; set; }//Ventana que me contiene
        public ViewModelBase(MainViewModel centralMain)
        {
            CentralMain = centralMain;
        }
        
    }
}
