using System.Windows;

namespace Proyecto_Troncal
{
    public partial class CustomMessageBox : Window
    {
        public bool IsClientRegistered { get; private set; } = false;

        public CustomMessageBox()
        {
            InitializeComponent();
        }

        private void Si_Click(object sender, RoutedEventArgs e)
        {
            IsClientRegistered = true;
            this.DialogResult = true; // Indica que se cerró correctamente
        }

        private void No_Click(object sender, RoutedEventArgs e)
        {
            IsClientRegistered = false;
            this.DialogResult = false; // Indica que se cerró con "No"
        }

    }
}
