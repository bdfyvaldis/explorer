using DynamicData.Binding;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace explorer.Models
{
    public class Explorer : AbstractNotifyPropertyChanged
    {
        private string currentDirName;
        public ObservableCollection<ExplorerEntry> entries;
        public string CurrentDirName
        {
            get { return currentDirName; }
            set
            { 
                if (Path.Exists(value) || value == "")
                {
                    currentDirName = value;
                    if (entries != null)
                    {
                        Fill();
                    }
                }
            }
        }
        public ObservableCollection<ExplorerEntry> Entries
        {
            get => entries;
            set
            {
                SetAndRaise(ref entries, value);
            }
        }

        private void Fill()
        {
            if (CurrentDirName == "")
            {
                Entries.Clear();
                foreach (var drive in DriveInfo.GetDrives())
                {
                    Entries.Add(new ExplorerEntry(drive.Name, EntryType.Disk));
                }
            }
            
            if (Path.Exists(CurrentDirName))
            {
                DirectoryInfo current_dir = new DirectoryInfo(CurrentDirName);
                Entries.Clear();
                try
                {
                    foreach (var dir in current_dir.GetDirectories())
                    {
                        Entries.Add(new ExplorerEntry(dir.Name, EntryType.Folder));
                    }
                    foreach (var file in current_dir.GetFiles())
                    {
                        Entries.Add(new ExplorerEntry(file.Name, EntryType.File));
                    }
                }
                catch (UnauthorizedAccessException e)
                {
                    Up();
                }

            }
        }

        public void Up()
        {
            if (CurrentDirName == "") return;
            if (CurrentDirName.Count(ch => ch == '\\') == 1)
            {
                CurrentDirName = "";
                Fill();
                return; 
            }
            var path = CurrentDirName.Split('\\');
            currentDirName = string.Join('\\', path, 0, path.Length - 2) + '\\';
            Fill();
        }

        public void Home()
        {
            CurrentDirName = "";
            Fill();
        }

        public void ChangeDirectory(string dirname)
        {
            if (CurrentDirName == "")
            {
                CurrentDirName = dirname;
            }
            else
            {
                CurrentDirName += dirname + '\\';
            }
        }

        public Explorer()
        {
            var drives = DriveInfo.GetDrives();
            CurrentDirName = drives[0].Name;
            Entries = new ObservableCollection<ExplorerEntry>();
            Fill();

        }
    }
}
