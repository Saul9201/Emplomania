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

namespace Emplomania.UI.Views.UtilsTemplatesViews
{
    /// <summary>
    /// Lógica de interacción para ClientContactWindowsView.xaml
    /// </summary>
    public partial class ClientContactWindowsView : Window
    {
        public ClientContactWindowsView()
        {
            InitializeComponent();
        }
        
        private void TitleBarMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Close_Button(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
