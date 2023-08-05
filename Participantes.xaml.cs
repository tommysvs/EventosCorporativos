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
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Data;

namespace EventosCorporativos
{
    /// <summary>
    /// Interaction logic for Participantes.xaml
    /// </summary>
    public partial class Participantes : Page
    {
        public Participantes()
        {
            InitializeComponent();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void buttonGuardarParticipante_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=TOMMY-ROG;Initial Catalog=EVENTOS;Integrated Security=True");
                SqlDataAdapter adapter = new SqlDataAdapter("PR_EVENTOS_INSERTAR_PARTICIPANTE", con);
                con.Open();
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = textBoxNombre.Text;
                adapter.SelectCommand.Parameters.Add("@Empresa", SqlDbType.VarChar).Value = textBoxEmpresa.Text;
                adapter.SelectCommand.Parameters.Add("@Cargo", SqlDbType.VarChar).Value = textBoxCargo.Text;
                adapter.SelectCommand.Parameters.Add("@Correo", SqlDbType.VarChar).Value = textBoxCorreo.Text;
                adapter.SelectCommand.Parameters.Add("@Estado", SqlDbType.VarChar).Value = comboBoxEstado.SelectedItem;
                adapter.SelectCommand.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Se creó usuario correctamente.");
                textBoxNombre.Text = "";
                textBoxEmpresa.Text = "";
                textBoxCargo.Text = "";
                textBoxCorreo.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
