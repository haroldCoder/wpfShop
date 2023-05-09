using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
    /// Lógica de interacción para AddProduct.xaml
    /// </summary>
    public partial class AddProduct : UserControl
    {
        public AddProduct()
        {
            InitializeComponent();
        }

        private void AddProducts(object sender, RoutedEventArgs e)
        {
            string nombre = txtNombre.Text;
            decimal precio = decimal.Parse(txtPrecio.Text);
            string img = txtUrlImagen.Text;


            // Creamos la conexión
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["usuarios"].ConnectionString);

            // Creamos el comando SQL
            SqlCommand command = new SqlCommand("INSERT INTO prod (nombre, precio, img) VALUES (@nombre, @precio, @img)", connection);

            // Añadimos los parámetros
            command.Parameters.AddWithValue("@nombre", nombre);
            command.Parameters.AddWithValue("@precio", precio);
            command.Parameters.AddWithValue("@img", img);

            try
            {
                // Abrimos la conexión
                connection.Open();

                // Ejecutamos el comando SQL
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error al insertar el producto: " + ex.Message);
            }
            finally
            {
                // Cerramos la conexión
                connection.Close();

                // Limpiamos los campos del formulario
                txtNombre.Text = "";
                txtPrecio.Text = "";
                txtUrlImagen.Text = "";
            }
        }
    }
}
