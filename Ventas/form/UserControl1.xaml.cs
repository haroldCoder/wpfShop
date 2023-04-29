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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ventas.form
{
    /// <summary>
    /// Lógica de interacción para UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        Frame frame;
        public UserControl1(Frame frame)
        {
            InitializeComponent();
            this.frame = frame;
        }

        private void view_addUser(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new AddUser());
        }
    }
}
