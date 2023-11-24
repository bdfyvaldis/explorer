using explorer.Models;
using ReactiveUI;
using System.Diagnostics;
using System.Reactive;

namespace explorer.ViewModels;

public class MainViewModel : ViewModelBase
{
    public Explorer Explorer { get; set; }
    public ReactiveCommand<Unit, Unit> UpCommand { get; }
    public ReactiveCommand<ExplorerEntry, Unit> OpenCommand { get; }
    public ReactiveCommand<Unit,Unit> HomeCommand { get; }
    public MainViewModel()
    {
        Explorer = new Explorer();
        UpCommand = ReactiveCommand.Create(() => Explorer.Up());
        OpenCommand = ReactiveCommand.Create<ExplorerEntry>((entry) => Explorer.ChangeDirectory(entry.Name));
        HomeCommand = ReactiveCommand.Create(() => Explorer.Home());
    }

}
