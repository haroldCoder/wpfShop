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
    public class Product { 
        public int ID { get; set; }
        public string nombre { get; set; }
        public double precio { get; set; }
        public string img { get; set; }

        public Product(string nombre, double price, string img)
        {
            this.nombre = nombre;
            this.precio = precio;
            this.img = img;
        }
    }
    public partial class products : UserControl
    {
        Frame fr;

        public products(Frame fr)
        {
            InitializeComponent();

            // Obtener los productos de la base de datos y almacenarlos en la lista
            Products = GetProductsFromDatabase();

            // Vincular la lista de productos a la vista
            DataContext = this;
            this.fr = fr;
        }

        public List<Product> Products { get; set; }

        private List<Product> GetProductsFromDatabase()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["usuarios"].ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT nombre, precio, img FROM prod", connection);
                SqlDataReader reader = command.ExecuteReader();

                List<Product> productList = new List<Product>();

                while (reader.Read())
                {
                    string name = (string)reader["nombre"];
                    double price = (double)reader["precio"];
                    string imageUrl = (string)reader["img"];

                    Product product = new Product(name, price, imageUrl);
                    productList.Add(product);
                }

                reader.Close();
                connection.Close();

                return productList;
                throw new NotImplementedException();
            }
        }

        private void Addp(object sender, RoutedEventArgs e)
        {
            fr.NavigationService.Navigate(new AddProduct());
        }
    }
}
