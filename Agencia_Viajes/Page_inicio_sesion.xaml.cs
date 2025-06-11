using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Proyecto_Troncal.Rubén_De_Las_Heras_Silveira
{
    public partial class Page_inicio_sesion : Page
    {
        // Lista de DNIs permitidos
        private readonly string[] dnIsPermitidos = { "12345678Z", "87654321X", "11223344A" };

        public Page_inicio_sesion()
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

        private void AccederButton_Click(object sender, RoutedEventArgs e)
        {
            string dni = DniTextBox.Text.Trim().ToUpper();

            // Validar que el formato del DNI sea correcto y calcular la letra
            if (!EsDNIValido(dni))
            {
                // Mostrar mensaje de error por DNI incorrecto
                new MensajeDNI("El DNI ingresado no es válido.\nPor favor, revisa el formato.", "error").ShowDialog();
                return;
            }

            // Validar si el DNI está registrado
            if (!dnIsPermitidos.Contains(dni))
            {
                // Mostrar mensaje de advertencia por DNI no registrado
                new MensajeDNI("El DNI ingresado es válido, pero no está registrado.\nAcceso denegado.", "warning").ShowDialog();
                return;
            }

            // Si el DNI es válido y está registrado, permitir acceso
            new MensajeDNI("Acceso concedido. Bienvenido.", "success").ShowDialog();
            this.NavigationService.Navigate(new Page_menu_principal());
        }

        private bool EsDNIValido(string dni)
        {
            // Verificar longitud y estructura general
            if (dni.Length != 9 || !char.IsLetter(dni.Last()) || !int.TryParse(dni.Substring(0, 8), out int numero))
            {
                return false;
            }

            // Calcular letra esperada
            string letrasDni = "TRWAGMYFPDXBNJZSQVHLCKE";
            char letraEsperada = letrasDni[numero % 23];

            // Comparar letra introducida con la calculada
            char letraIntroducida = char.ToUpper(dni.Last());
            return letraIntroducida == letraEsperada;
        }
    }
}
