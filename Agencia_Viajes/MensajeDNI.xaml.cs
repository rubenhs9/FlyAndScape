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
using System.Windows.Shapes;

namespace Proyecto_Troncal.Rubén_De_Las_Heras_Silveira
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class MensajeDNI : Window
    {
        public MensajeDNI(string mensaje, string tipo)
        {
            InitializeComponent();
            MensajeTexto.Text = mensaje;

            // Cambiar el icono según el tipo
            switch (tipo.ToLower())
            {
                case "error":
                    Icono.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri("pack://application:,,,/img/error.png"));
                    break;
                case "warning":
                    Icono.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri("pack://application:,,,/img/warning.png"));
                    break;
                case "success":
                    Icono.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri("pack://application:,,,/img/success.png"));
                    break;
                default:
                    Icono.Source = null;
                    break;
            }


        }

        private void Aceptar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
