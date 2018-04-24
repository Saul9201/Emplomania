using Emplomania.Data;
using Emplomania.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Emplomania.UI.Infrastucture;

namespace Emplomania.UI.Views
{
    /// <summary>
    /// Lógica de interacción para MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            AutoMapper.Mapper.Initialize(cfg => MapConfiguration.Configure(cfg));

            var v = WebNomenclatorsCache.Instance;
            InitializeComponent();
        }
    }
}
