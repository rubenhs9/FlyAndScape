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
    /// Lógica de interacción para Page_gestion_usuario.xaml
    /// </summary>
    public partial class Page_gestion_viaje : Page
    {
        public Page_gestion_viaje()
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

        private void VolverMenu_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Page_menu_principal());
        }

        private void ButtonAgregar_Click(object sender, RoutedEventArgs e)
        {
            // Capturar los datos
            string origen = (ComboBoxOrigen.SelectedItem as ComboBoxItem)?.Content.ToString();
            string destino = (ComboBoxDestino.SelectedItem as ComboBoxItem)?.Content.ToString();
            DateTime? fechaIda = DatePickerIda.SelectedDate;
            DateTime? fechaVuelta = DatePickerVuelta.SelectedDate;
            string alojamiento = (ComboBoxAlojamiento.SelectedItem as ComboBoxItem)?.Content.ToString();
            string transporte = (ComboBoxTransporte.SelectedItem as ComboBoxItem)?.Content.ToString();
            string dniCliente = TextBoxDNI.Text;

            // Validar campos
            StringBuilder errores = new StringBuilder();

            if (string.IsNullOrEmpty(origen))
                errores.AppendLine("El campo 'Origen' es obligatorio.");
            if (string.IsNullOrEmpty(destino))
                errores.AppendLine("El campo 'Destino' es obligatorio.");
            if (!fechaIda.HasValue)
                errores.AppendLine("El campo 'Fecha de Ida' es obligatorio.");
            if (!fechaVuelta.HasValue)
                errores.AppendLine("El campo 'Fecha de Vuelta' es obligatorio.");
            if (string.IsNullOrEmpty(alojamiento))
                errores.AppendLine("El campo 'Alojamiento' es obligatorio.");
            if (string.IsNullOrEmpty(transporte))
                errores.AppendLine("El campo 'Transporte' es obligatorio.");
            if (string.IsNullOrEmpty(dniCliente))
                errores.AppendLine("El campo 'DNI Cliente' es obligatorio.");
            else if (!EsDNIValido(dniCliente))
                errores.AppendLine("El DNI introducido no es válido.");

            // Validar que la fecha de vuelta no sea anterior a la fecha de ida
            if (fechaIda.HasValue && fechaVuelta.HasValue && fechaVuelta < fechaIda)
                errores.AppendLine("La 'Fecha de Vuelta' no puede ser anterior a la 'Fecha de Ida'.");

            if (errores.Length > 0)
            {
                // Mostrar mensaje de error si hay campos faltantes, fechas incorrectas o DNI inválido
                MessageBox.Show($"Por favor, corrige los siguientes errores:\n{errores.ToString()}", "Error en los datos", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Si todos los campos están completos y correctos, proceder
            var viaje = new
            {
                Origen = origen,
                Destino = destino,
                FechaIda = fechaIda,
                FechaVuelta = fechaVuelta,
                Alojamiento = alojamiento,
                Transporte = transporte,
                DNICliente = dniCliente
            };

            // Mostrar los datos en un MessageBox
            MessageBox.Show($"Viaje agregado:\nOrigen: {origen}\nDestino: {destino}\nFecha Ida: {fechaIda}\nFecha Vuelta: {fechaVuelta}\nAlojamiento: {alojamiento}\nTransporte: {transporte}\nDNI Cliente: {dniCliente}");
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
