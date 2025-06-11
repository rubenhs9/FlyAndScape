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
    /// Lógica de interacción para Page_consultas.xaml
    /// </summary>
    public partial class Page_consultas : Page
    {
        public Page_consultas()
        {
            InitializeComponent();
            CargarDatosGestionesPendientes();
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
        private void CargarDatosGestionesPendientes()
        {
            var datos = ObtenerDatosDePrueba("Gestiones Pendientes");
            dataGridConsultas.ItemsSource = datos;
        }

        private void CargarDatosViajesCerrados()
        {
            var datos = ObtenerDatosDePrueba("Viajes Cerrados");
            dataGridConsultas.ItemsSource = datos;
        }

        private void CargarDatosViajesCancelados()
        {
            var datos = ObtenerDatosDePrueba("Viajes Cancelados");
            dataGridConsultas.ItemsSource = datos;
        }

        private List<dynamic> ObtenerDatosDePrueba(string tipo)
        {
            if (tipo == "Gestiones Pendientes")
            {
                return new List<dynamic>
        {
                new { Nombre = "Juan", Apellidos = "Pérez", DNI = "12345678A", CorreoElectronico = "juan@mail.com", Origen = "Roma", Destino = "París" },
                new { Nombre = "Ana", Apellidos = "García", DNI = "87654321B", CorreoElectronico = "ana@mail.com", Origen = "Madrid", Destino = "Barcelona" },
                new { Nombre = "Luis", Apellidos = "Martínez", DNI = "56781234C", CorreoElectronico = "luis@mail.com", Origen = "Sevilla", Destino = "Nueva York" },
                new { Nombre = "Sofía", Apellidos = "López", DNI = "34567891D", CorreoElectronico = "sofia@mail.com", Origen = "París", Destino = "Madrid" },
                new { Nombre = "Carlos", Apellidos = "Fernández", DNI = "23456789E", CorreoElectronico = "carlos@mail.com", Origen = "Barcelona", Destino = "Roma" },
                new { Nombre = "María", Apellidos = "Hernández", DNI = "45678912F", CorreoElectronico = "maria@mail.com", Origen = "Nueva York", Destino = "Sevilla" },
                new { Nombre = "Javier", Apellidos = "Ruiz", DNI = "56789123G", CorreoElectronico = "javier@mail.com", Origen = "Madrid", Destino = "Barcelona" },
                new { Nombre = "Lucía", Apellidos = "Gómez", DNI = "67891234H", CorreoElectronico = "lucia@mail.com", Origen = "París", Destino = "Roma" },
                new { Nombre = "David", Apellidos = "Sánchez", DNI = "78912345I", CorreoElectronico = "david@mail.com", Origen = "Roma", Destino = "Nueva York" },

        };
            }
            else if (tipo == "Viajes Cerrados")
            {
                return new List<dynamic>
        {
                new { Nombre = "Paula", Apellidos = "Morales", DNI = "89123456J", CorreoElectronico = "paula@mail.com", Origen = "Sevilla", Destino = "París" },
                new { Nombre = "Alejandro", Apellidos = "Ortega", DNI = "91234567K", CorreoElectronico = "alejandro@mail.com", Origen = "Barcelona", Destino = "Madrid" },
                new { Nombre = "Elena", Apellidos = "Pérez", DNI = "12345679L", CorreoElectronico = "elena@mail.com", Origen = "Nueva York", Destino = "Sevilla" },
                new { Nombre = "Andrés", Apellidos = "Vega", DNI = "34567892M", CorreoElectronico = "andres@mail.com", Origen = "París", Destino = "Barcelona" },
                new { Nombre = "Carmen", Apellidos = "Blanco", DNI = "23456780N", CorreoElectronico = "carmen@mail.com", Origen = "Madrid", Destino = "Roma" },
                new { Nombre = "Raúl", Apellidos = "Romero", DNI = "45678913O", CorreoElectronico = "raul@mail.com", Origen = "Barcelona", Destino = "Nueva York" },
                new { Nombre = "Isabel", Apellidos = "Molina", DNI = "56789124P", CorreoElectronico = "isabel@mail.com", Origen = "Sevilla", Destino = "París" },
                new { Nombre = "Pedro", Apellidos = "Díaz", DNI = "67891235Q", CorreoElectronico = "pedro@mail.com", Origen = "Roma", Destino = "Madrid" },
                new { Nombre = "Clara", Apellidos = "Navarro", DNI = "78912346R", CorreoElectronico = "clara@mail.com", Origen = "Nueva York", Destino = "Barcelona" },
                new { Nombre = "Miguel", Apellidos = "Crespo", DNI = "89123457S", CorreoElectronico = "miguel@mail.com", Origen = "París", Destino = "Sevilla" },

        };
            }
            else if (tipo == "Viajes Cancelados")
            {
                return new List<dynamic>
        {
                new { Nombre = "Eva", Apellidos = "Delgado", DNI = "91234568T", CorreoElectronico = "eva@mail.com", Origen = "Madrid", Destino = "Roma" },
                new { Nombre = "Daniel", Apellidos = "Martín", DNI = "12345680U", CorreoElectronico = "daniel@mail.com", Origen = "Barcelona", Destino = "Nueva York" },
                new { Nombre = "Sara", Apellidos = "Castro", DNI = "34567893V", CorreoElectronico = "sara@mail.com", Origen = "Sevilla", Destino = "París" },
                new { Nombre = "Tomás", Apellidos = "Torres", DNI = "23456781W", CorreoElectronico = "tomas@mail.com", Origen = "Roma", Destino = "Barcelona" },
                new { Nombre = "Patricia", Apellidos = "Campos", DNI = "45678914X", CorreoElectronico = "patricia@mail.com", Origen = "Nueva York", Destino = "Madrid" },
                new { Nombre = "Hugo", Apellidos = "Prieto", DNI = "56789125Y", CorreoElectronico = "hugo@mail.com", Origen = "París", Destino = "Sevilla" },
                new { Nombre = "Alicia", Apellidos = "Reyes", DNI = "67891236Z", CorreoElectronico = "alicia@mail.com", Origen = "Barcelona", Destino = "Roma" }
        };
            }
            return new List<dynamic>();
        }

       

        private void BtnGestionesPendientes_Click(object sender, RoutedEventArgs e)
        {
            CargarDatosGestionesPendientes();
        }

        private void BtnViajesCerrados_Click(object sender, RoutedEventArgs e)
        {
            CargarDatosViajesCerrados();
        }

        private void BtnViajesCancelados_Click(object sender, RoutedEventArgs e)
        {
            CargarDatosViajesCancelados();
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            // Navegar al menú principal (MainPage)
            this.NavigationService.Navigate(new Page_menu_principal());
        }
    }
}
