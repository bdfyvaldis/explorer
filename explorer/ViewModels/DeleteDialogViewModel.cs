using explorer.Models;
using System.IO;


namespace explorer.ViewModels
{
    internal class DeleteDialogViewModel : ViewModelBase
    {
        ExplorerEntry Entry { get; set; }


        public DeleteDialogViewModel(string path)
        {
            if (File.Exists(path))
            {
                Entry = new ExplorerEntry(Path.GetFileName(path), EntryType.File);
            }
            else
           if (Directory.Exists(path))
            {
                Entry = new ExplorerEntry(Path.GetFileName(path), EntryType.Folder);
            }
        }



    }
}
