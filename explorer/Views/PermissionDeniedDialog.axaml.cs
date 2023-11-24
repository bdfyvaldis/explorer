using Avalonia.Controls;
using Avalonia.Interactivity;

namespace explorer.Views
{
    public partial class PermissionDeniedDialog : Window
    {
        public PermissionDeniedDialog()
        {
            InitializeComponent();
        }
        void ButtonOKClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
