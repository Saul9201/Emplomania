using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Emplomania.UI.Views.UtilsTemplatesViews
{
    /// <summary>
    /// Interaction logic for CircularProgressBar.xaml
    /// </summary>
    public partial class CircularProgressBar : UserControl, INotifyPropertyChanged, IDisposable
    {
        public CircularProgressBar()
        {
            InitializeComponent();
            this.BallColor = new SolidColorBrush(Color.FromRgb(40, 80, 187));

        }
        public static readonly DependencyProperty BallColorProperty = DependencyProperty.Register("BallColor", typeof(SolidColorBrush), typeof(CircularProgressBar), new UIPropertyMetadata(new SolidColorBrush(Color.FromRgb(40, 80, 187))));
        public SolidColorBrush BallColor
        {
            get { return (SolidColorBrush)this.GetValue(BallColorProperty); }
            set { this.SetValue(BallColorProperty, value); }
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropChanged(string name)
        {
            var eh = this.PropertyChanged;
            if (eh != null)
            {
                eh(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion

        #region INotifyPropertyChanged Members
        public void Dispose()
        {
            this.OnDispose();
        }

        protected virtual void OnDispose()
        {
        }

        #endregion
    }
}
