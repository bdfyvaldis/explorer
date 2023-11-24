using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.VisualTree;
using explorer.Models;
using explorer.ViewModels;
using System.Diagnostics;
using System.Linq;

namespace explorer.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        DataContext = new MainViewModel();
        InitializeComponent();
    }


    private void RectDoubleTapped(object? sender, TappedEventArgs e)
    {
        var rect = sender as Rectangle;
        Grid grid = rect.Parent as Grid;
        (this.DataContext as MainViewModel).Explorer.ChangeDirectory(grid.GetVisualChildren().OfType<TextBlock>().First().Text);
        //Debug.WriteLine(grid.GetVisualChildren().OfType<TextBlock>().First().Text);
    }

    private void PropertiesClick(object sender, RoutedEventArgs e)
    {
        var lb = this.GetVisualDescendants().OfType<ListBox>().First() as ListBox;
        var entryname = (lb.SelectedItem as ExplorerEntry).Name;

        try
        {
            (new PropertiesWindow((this.DataContext as MainViewModel).Explorer.CurrentDirName + entryname)).Show(this);
        }
        catch (System.UnauthorizedAccessException)
        {
            (new PermissionDeniedDialog()).Show(this);
        }
    }

    private async void DeleteClick(object sender, RoutedEventArgs e)
    {
        var lb = this.GetVisualDescendants().OfType<ListBox>().First() as ListBox;
        var entry = (lb.SelectedItem as ExplorerEntry);
        var path = (this.DataContext as MainViewModel).Explorer.CurrentDirName + entry.Name;

        DialogResult result = await (new DeleteDialog(path).ShowDialog<DialogResult>(this));

        try
        {
            if (result == DialogResult.Yes)
            {
                (DataContext as MainViewModel).Explorer.Delete(entry);
            }
        }
        catch (System.UnauthorizedAccessException)
        {
           await (new PermissionDeniedDialog()).ShowDialog(this);
        }
    }

}
