using System;
using System.Collections.Generic;
using System.Data;
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
using System.Data.SqlClient;

namespace EventosCorporativos
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();

            labelRegistrarse.Visibility = Visibility.Hidden;
            textboxUsuarioC.Visibility = Visibility.Hidden;
            passwordBoxContraseñaC.Visibility = Visibility.Hidden;
            textboxNombreC.Visibility = Visibility.Hidden;
            textboxCorreoC.Visibility = Visibility.Hidden;
            buttonRegistrarse.Visibility = Visibility.Hidden;
            buttonIniciarSesionC.Visibility = Visibility.Hidden;
        }

        private void buttonSolicitarUsuario_Click(object sender, RoutedEventArgs e)
        {
            labelIniciarSesion.Visibility = Visibility.Hidden; 
            textboxUsuario.Visibility = Visibility.Hidden;
            passwordBoxContraseña.Visibility = Visibility.Hidden;
            buttonIniciarSesion.Visibility = Visibility.Hidden;
            buttonSolicitarUsuario.Visibility = Visibility.Hidden;

            labelRegistrarse.Visibility = Visibility.Visible;
            textboxUsuarioC.Visibility = Visibility.Visible;
            passwordBoxContraseñaC.Visibility = Visibility.Visible;
            textboxNombreC.Visibility = Visibility.Visible;
            textboxCorreoC.Visibility = Visibility.Visible;
            buttonRegistrarse.Visibility = Visibility.Visible;
            buttonIniciarSesionC.Visibility = Visibility.Visible;
        }
        private void buttonIniciarSesionC_Click(object sender, RoutedEventArgs e)
        {
            labelIniciarSesion.Visibility = Visibility.Visible;
            textboxUsuario.Visibility = Visibility.Visible;
            passwordBoxContraseña.Visibility = Visibility.Visible;
            buttonIniciarSesion.Visibility = Visibility.Visible;
            buttonSolicitarUsuario.Visibility = Visibility.Visible;

            labelRegistrarse.Visibility = Visibility.Hidden;
            textboxUsuarioC.Visibility = Visibility.Hidden;
            passwordBoxContraseñaC.Visibility = Visibility.Hidden;
            textboxNombreC.Visibility = Visibility.Hidden;
            textboxCorreoC.Visibility = Visibility.Hidden;
            buttonRegistrarse.Visibility = Visibility.Hidden;
            buttonIniciarSesionC.Visibility = Visibility.Hidden;
        }

        private void buttonIniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=TOMMY-ROG;Initial Catalog=EVENTOS;Integrated Security=True");
                con.Open();
                string select_user = "SELECT * FROM Usuarios WHERE Usuario = @Usuario AND Contrasenia = @Contrasenia";
                SqlCommand cmd = new SqlCommand(select_user, con);

                cmd.Parameters.AddWithValue("@Usuario", textboxUsuario.Text);
                cmd.Parameters.AddWithValue("@Contrasenia", passwordBoxContraseña.Password);
                cmd.ExecuteNonQuery();
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                con.Close();

                if(count > 0)
                {
                    MessageBox.Show("Se inició sesión correctamente.");
                    textboxUsuario.Text = "Usuario";
                    passwordBoxContraseñaC.Password = "";
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonRegistrarse_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=TOMMY-ROG;Initial Catalog=EVENTOS;Integrated Security=True");
                SqlDataAdapter adapter = new SqlDataAdapter("PR_EVENTOS_NUEVO_USUARIO", con);
                con.Open();
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = textboxUsuarioC.Text;
                adapter.SelectCommand.Parameters.Add("@Contrasenia", SqlDbType.VarChar).Value = passwordBoxContraseñaC.Password;
                adapter.SelectCommand.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = textboxNombreC.Text;
                adapter.SelectCommand.Parameters.Add("@Correo", SqlDbType.VarChar).Value = textboxCorreoC.Text;
                adapter.SelectCommand.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Se creó usuario correctamente.");
                textboxUsuarioC.Text = "Usuario";
                passwordBoxContraseñaC.Password = "";
                textboxNombreC.Text = "Nombre";
                textboxCorreoC.Text = "Correo";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
