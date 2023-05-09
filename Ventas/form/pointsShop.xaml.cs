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
    /// Lógica de interacción para pointsShop.xaml
    /// </summary>
    public partial class pointsShop : UserControl
    {
        public pointsShop()
        {
            InitializeComponent();
            System.Net.ServicePointManager.SecurityProtocol |= System.Net.SecurityProtocolType.Tls11 | System.Net.SecurityProtocolType.Tls12;


            string address = "1600 Amphitheatre Parkway, Mountain View, CA";
            string mapQuery = "https://www.google.com/maps/embed/v1/place?q=" + address + "&key=AIzaSyCeWe2ZcnvNrVOclRtSyaHyKCgkEf8XCuA";

            MyWebBrowser.Source = new Uri(mapQuery);
        }
    }
}
