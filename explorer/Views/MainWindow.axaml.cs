using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.VisualTree;
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

}
