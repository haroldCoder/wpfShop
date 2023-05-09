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

                prods.Add(prd);

                Grid grid;
                Grid[] subgrids = new Grid[prods.Count+1];

                int ite = 0;

                for(int i = 0; i<prods.Count+1; i++)
                {
                    prodata.RowDefinitions.Add(new RowDefinition());
                    grid = new Grid() { VerticalAlignment = System.Windows.VerticalAlignment.Top};
                    prodata.Children.Add(grid);
                    Grid.SetRow(grid, 1);
                    grid.ColumnDefinitions.Add(new ColumnDefinition());
                    subgrids[i] = new Grid() { Width=300, Background=Brushes.Gray};
                    grid.Children.Add(subgrids[i]);
                    Grid.SetColumn(subgrids[i], i);
                    for(int j = 0; j<3; j++)
                    {
                        subgrids[i].RowDefinitions.Add(new RowDefinition());
                    } 
                }

                foreach(var pr in prods)
                {
                    Console.WriteLine("nombres",pr.nombre);
                    BitmapImage bitmap = new BitmapImage();

                    // Establece la ruta de la imagen
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri("https://sgfm.elcorteingles.es/SGFM/dctm/MEDIA03/202104/05/00118630004077____2__600x600.jpg");
                    bitmap.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                    bitmap.EndInit();

                    
                    var img = new Image() { Source=bitmap};
                    var nombre = new Label(){ Content = pr.nombre, Foreground = Brushes.White};
                    var precio = new Label() { Content = pr.precio, Foreground = Brushes.White };

                    subgrids[ite].Children.Add(img);
                    Grid.SetRow(img, 0);


                    subgrids[ite].Children.Add(nombre);
                    Grid.SetRow(nombre, 1);

                    subgrids[ite].Children.Add(precio);
                    Grid.SetRow(precio, 2);
                    ite++;
                }
                

            }
        }
    }
}
