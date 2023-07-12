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

namespace EventosCorporativos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AppWindow : Window
    {
        public AppWindow()
        {
            InitializeComponent();
            Main.Content = new Inicio();
        }

        private void buttonInicio_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Inicio();
        }

        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Login();
        }

        private void buttonParticipantes_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Participantes();
        }

        private void buttonSalas_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Salas();
        }

        private void buttonRecursos_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Recursos();
        }

        private void buttonIngresos_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Ingresos();
        }

        private void buttonEgresos_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Egresos();
        }

        private void buttonFacturacion_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Facturacion();
        }

        private void buttonInformes_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Informes();
        }
    }
}