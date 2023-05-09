using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;
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
    /// Lógica de interacción para products.xaml
    /// </summary>
    /// 
    public class Prod { 
        public int ID { get; set; }
        public string nombre { get; set; }
        public double precio { get; set; }
        public string img { get; set; }
    }
    public partial class products : UserControl
    {
        List<Prod> prods = new List<Prod>();

        public products()
        {
            InitializeComponent();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["usuarios"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM prod",con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Prod prd = new Prod();
                prd.ID = (int)reader["ID"];
                prd.nombre = (string)reader["nombre"];
                prd.precio = (double)reader["precio"];
                prd.img = (string)reader["img"];
                

                var grid = new Grid() { VerticalAlignment=System.Windows.VerticalAlignment.Top,};
                Grid[] subgrids = new Grid[prods.Count+1];
                for(int i = 0; i<prods.Count+1; i++)
                {
                    prodata.RowDefinitions.Add(new RowDefinition());
                    prodata.Children.Add(grid);
                    Grid.SetRow(grid, 1);
                    grid.ColumnDefinitions.Add(new ColumnDefinition());

                    subgrids = new Grid[prods.Count + 1];
                    subgrids[i] = new Grid(){ Background = System.Windows.Media.Brushes.Aqua };
                    grid.Children.Add(subgrids[i]);
                    Grid.SetColumn(subgrids[i], i);
                    for(int j = 0; j<5; j++)
                    {
                        subgrids[i].RowDefinitions.Add(new RowDefinition());
                    } 
                }

                var img = new Image();
                var nombre = new Label(){ Content = prd.nombre, Foreground = Brushes.White};
                var precio = new Label() { Content = prd.precio, Foreground = Brushes.White };

                subgrids[0].Children.Add(nombre);

            }
        }
    }
}
