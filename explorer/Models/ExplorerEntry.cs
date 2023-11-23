using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace explorer.Models
{
    public enum EntryType { Folder, File, Disk }
    public class ExplorerEntry
    {
        public string Name { get; set; }
        public EntryType EntryType { get; set; }

        public ExplorerEntry(string Name, EntryType EntryType)
        {
            this.Name = Name;
            this.EntryType = EntryType;
        }


    }
}
