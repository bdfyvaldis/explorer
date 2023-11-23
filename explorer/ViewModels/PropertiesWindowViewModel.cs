using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using explorer.Models;

namespace explorer.ViewModels
{
    public class Pair
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public Pair(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
    public class PropertiesWindowViewModel : ViewModelBase
    {
        EntryType EType { get; }
        public ObservableCollection<Pair> Properties { get; }


        public PropertiesWindowViewModel(string path)
        {
            Properties = new ObservableCollection<Pair>();
            if (File.Exists(path))
            {
                EType = EntryType.File;
                FileInfo info = new FileInfo(path);
                Properties.Add(new Pair("Name: ", info.Name));
                Properties.Add(new Pair("CreationTime: ", info.CreationTime.ToString()));
                Properties.Add(new Pair("Size: ", (info.Length / 1024).ToString() + " Kb"));
            }
            else
           if (Directory.Exists(path))
            {
                EType = EntryType.Folder;
                DirectoryInfo info = new DirectoryInfo(path);
                Properties.Add(new Pair("Name: ", info.Name));
                Properties.Add(new Pair("CreationTime: ", info.CreationTime.ToString()));
                Properties.Add(new Pair("LastWriteTime: ", info.LastWriteTime.ToString()));
                Properties.Add(new Pair("Subdirectories: ", Directory.GetDirectories(path).Length.ToString()));
                Properties.Add(new Pair("Files: ", Directory.GetFiles(path).Length.ToString()));
            }
        }
    }
}
