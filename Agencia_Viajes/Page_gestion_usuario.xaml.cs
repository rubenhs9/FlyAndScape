using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Navigation;

namespace Proyecto_Troncal.Rubén_De_Las_Heras_Silveira
{
    public partial class Page_gestion_usuario : Page
    {
        public Page_gestion_usuario()
        {
            InitializeComponent();
        }

        private void RegistrarCliente_Click(object sender, RoutedEventArgs e)
        {
            // Capturar los datos del formulario
            string nombre = TextBoxNombre.Text;
            string apellidos = TextBoxApellidos.Text;
            string dni = TextBoxDNI.Text;
            string correo = TextBoxCorreo.Text;

            // Validar que todos los campos están llenos
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellidos) ||
                string.IsNullOrWhiteSpace(dni) || string.IsNullOrWhiteSpace(correo))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Validar el DNI
            if (!EsDNIValido(dni))
            {
                MessageBox.Show("El DNI introducido no es válido. Por favor, verifique y vuelva a intentarlo.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Lógica para registrar al cliente (puede ser guardar en una base de datos, etc.)
            MessageBox.Show($"Cliente {nombre} {apellidos} registrado correctamente.\nDNI: {dni}", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);

            // Limpiar los campos del formulario (sin recargar la página ni navegar)
            TextBoxNombre.Clear();
            TextBoxApellidos.Clear();
            TextBoxDNI.Clear();
            TextBoxCorreo.Clear();
        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // Buscar la animación en los recursos
            Storyboard storyboard = (Storyboard)this.Resources["animacionFondo"];
            if (storyboard != null)
            {
                storyboard.Begin();
            }
        }

        private void VolverMenu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.GoBack();
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
