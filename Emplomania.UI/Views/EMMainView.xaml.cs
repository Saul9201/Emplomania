using Emplomania.UI.ViewModels;
using Emplomania.UI.ViewModels.StartViewModels;
using Emplomania.UI.Views.UtilsTemplatesViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Emplomania.UI.Views
{
    /// <summary>
    /// Lógica de interacción para EMMainView.xaml
    /// </summary>
    public partial class EMMainView : UserControl
    {
        public EMMainView()
        {
            InitializeComponent();

            foreach (Type viewModelType in Assembly.GetAssembly(typeof(ViewModels.UserViewMoldels.AlterClientViewModel)).GetTypes())
            {
                if (viewModelType.BaseType?.Name == "EMViewModelBase")
                {
                    string aqName = viewModelType.AssemblyQualifiedName;
                    aqName= aqName.Replace("Model", "");
                    aqName = aqName.Replace("Moldel", "");

                    var viewType = Type.GetType(aqName);
                    if (viewType!=null)
                    {
                        DataTemplate dt = new DataTemplate()
                        {
                            DataType = viewModelType
                        };
                        FrameworkElementFactory fef = new FrameworkElementFactory(viewType);
                        dt.VisualTree = fef;
                        DataTemplateKey dtKey = new DataTemplateKey(viewModelType);
                        this.Resources.Add(dtKey, dt);
                    }
                }
            }
            
        }
    }
}
