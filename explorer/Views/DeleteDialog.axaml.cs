using Avalonia.Controls;
using Avalonia.Interactivity;
using explorer.Models;
using explorer.ViewModels;

namespace explorer.Views
{
    public partial class DeleteDialog : Window
    {
        public DeleteDialog()
        {
            InitializeComponent();
        }

        public DeleteDialog(string path) : this()
        {
            DataContext = new DeleteDialogViewModel(path);
        }

        private void ButtonYesClick(object sender, RoutedEventArgs e)
        {
            Close(DialogResult.Yes);
        }

        private void ButtonNoClick(object sender, RoutedEventArgs e)
        {
            Close(DialogResult.No);
        }

    }
}
