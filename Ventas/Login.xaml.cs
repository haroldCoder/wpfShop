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
using Ventas;
using static System.Net.Mime.MediaTypeNames;
using Application = System.Windows.Application;

namespace Crud_Wpf.View
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        readonly SqlConnection _connection; //Declaración de SqlConnection

        //CONSTRUCTOR
        public Login()
        {
            InitializeComponent();
            _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["usuarios"].ConnectionString);
        }


        //MINIMIZAR VENTANA
        private void BtnMinimizar_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        //CERRAR APLICACION
        private void BtnCerrar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        //MOVER VENTANA CON CLICK-SOSTENIDO
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        //LOGIN (INGRESO)
        private void BtnIngresar_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(tblUsuario.Text) || string.IsNullOrEmpty(tblUsuario.Text))//Valida que los campos no esten vacios
            {
                tblMensaje.Text = "Los campos no pueden estar vacios";
            }
            else//Sin no estan vacios :
            {
                _connection.Open();

                SqlCommand cmValidateUser = new SqlCommand("Select Count(*) from users Where Nombre =@Usuario", _connection);//Valida si existe el usuario
                cmValidateUser.Parameters.AddWithValue("@Usuario", tblUsuario.Text);
                int count = (int)cmValidateUser.ExecuteScalar();

                if( count > 0)
                {
                        MainWindow inicio = new MainWindow();
                        this.Close();
                        inicio.Show();  
                }
                else//No se existe el usuario ingresado
                {
                    tblMensaje.Text = "Usuario incorrecto";
                }
                _connection.Close();
            }
        }
    }
}

