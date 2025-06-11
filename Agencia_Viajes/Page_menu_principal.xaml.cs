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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Proyecto_Troncal.Rubén_De_Las_Heras_Silveira
{
    /// <summary>
    /// Lógica de interacción para Page_menu_principal.xaml
    /// </summary>
    public partial class Page_menu_principal : Page
    {
        public Page_menu_principal()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // Busca la animación en los recursos
            Storyboard storyboard = (Storyboard)this.Resources["animacionFondo"];
            if (storyboard != null)
            {
                storyboard.Begin();
            }

        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Page_inicio_sesion());
        }

        private void Consultas_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Page_consultas());
        }

        
        private void Gestion_Click(object sender, RoutedEventArgs e)
        {
            // Mostrar el MessageBox personalizado
            CustomMessageBox messageBox = new CustomMessageBox();
            bool? result = messageBox.ShowDialog();

            if (result == true && messageBox.IsClientRegistered)
            {
                this.NavigationService.Navigate(new Page_gestion_viaje());
            }
            else
            {
                this.NavigationService.Navigate(new Page_gestion_usuario());
            }
        }


    }
}
