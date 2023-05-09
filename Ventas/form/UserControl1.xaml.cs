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
    /// Lógica de interacción para UserControl1.xaml
    /// </summary>

    public class User
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public string Phone { get; set; }
        public bool Access { get; set; }
    }
    public partial class UserControl1 : UserControl
    {
        Frame frame;
        SqlConnection connection;
        public UserControl1(Frame frame)
        {
            InitializeComponent();
            this.frame = frame;
            string connectionString = ConfigurationManager.ConnectionStrings["usuarios"].ConnectionString;
            List<User> users = new List<User>();

            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM users", connection);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    User user = new User();
                    user.ID = (int)reader["ID"];
                    user.Nombre = (string)reader["Nombre"];
                    user.Apellido = (string)reader["Apellido"];
                    user.Direccion = (string)reader["Direccion"];
                    user.Correo = (string)reader["Correo"];
                    user.Phone = (string)reader["Phone"];
                    user.Access = (bool)reader["Access"];
                    users.Add(user);
                    int row = 0;

                    Grid[] tabla = new Grid[users.Count + 1];
                    for (int i = 0; i < users.Count + 1; i++)
                    {
                        data.RowDefinitions.Add(new RowDefinition { Height = new GridLength(30), Cursor = System.Windows.Input.Cursors.Help });
                        tabla[row] = new Grid();
                        data.Children.Add(tabla[row]);
                        Grid.SetRow(tabla[row], row + 1);
                        for (int j = 0; j < 7; j++)
                        {
                            tabla[row].ColumnDefinitions.Add(new ColumnDefinition());
                        }
                        row++;
                    }

                    // Definir las columnas


                    // Agregar los labels a la Grid
                    int count = 1;
                    foreach (User use in users)
                    {
                        var idLabel = new Label() { Content = use.ID, Foreground = Brushes.White, VerticalAlignment = VerticalAlignment.Top, VerticalContentAlignment = VerticalAlignment.Bottom };
                        var nombreLabel = new Label() { Content = use.Nombre, Foreground = Brushes.White };
                        var apellidoLabel = new Label() { Content = use.Apellido, Foreground = Brushes.White, VerticalAlignment = VerticalAlignment.Top, VerticalContentAlignment = VerticalAlignment.Bottom };
                        var direccionLabel = new Label() { Content = use.Direccion, Foreground = Brushes.White, VerticalAlignment = VerticalAlignment.Top, VerticalContentAlignment = VerticalAlignment.Bottom };
                        var correoLabel = new Label() { Content = use.Correo, Foreground = Brushes.White, VerticalAlignment = VerticalAlignment.Top, VerticalContentAlignment = VerticalAlignment.Bottom };
                        var phoneLabel = new Label() { Content = use.Phone, Foreground = Brushes.White, VerticalAlignment = VerticalAlignment.Top, VerticalContentAlignment = VerticalAlignment.Bottom };
                        var accessLabel = new Label() { Content = use.Access, Foreground = Brushes.White, VerticalAlignment = VerticalAlignment.Top, VerticalContentAlignment = VerticalAlignment.Bottom };

                        tabla[count].Children.Add(idLabel);
                        tabla[count].Children.Add(nombreLabel);
                        tabla[count].Children.Add(apellidoLabel);
                        tabla[count].Children.Add(direccionLabel);
                        tabla[count].Children.Add(correoLabel);
                        tabla[count].Children.Add(phoneLabel);
                        tabla[count].Children.Add(accessLabel);

                        Grid.SetRow(idLabel, count + 1);
                        Grid.SetColumn(idLabel, 0);

                        Grid.SetRow(nombreLabel, count + 1);
                        Grid.SetColumn(nombreLabel, 1);

                        Grid.SetRow(apellidoLabel, count + 1);
                        Grid.SetColumn(apellidoLabel, 2);

                        Grid.SetRow(direccionLabel, count + 1);
                        Grid.SetColumn(direccionLabel, 3);

                        Grid.SetRow(correoLabel, count + 1);
                        Grid.SetColumn(correoLabel, 4);

                        Grid.SetRow(phoneLabel, count + 1);
                        Grid.SetColumn(phoneLabel, 5);

                        Grid.SetRow(accessLabel, count + 1);
                        Grid.SetColumn(accessLabel, 6);

                        count++;

                    }
                }
            }
        }

        private void view_addUser(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new AddUser());
        }
    }
}
