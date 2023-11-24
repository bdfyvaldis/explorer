using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using explorer.ViewModels;


namespace explorer.Views
{
    public partial class PropertiesWindow : Window
    {
        private PropertiesWindow()
        {
            InitializeComponent();
        }

        public PropertiesWindow(string path):this()
        {
            this.DataContext = new PropertiesWindowViewModel(path);
        }

        void ButtonOKClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
