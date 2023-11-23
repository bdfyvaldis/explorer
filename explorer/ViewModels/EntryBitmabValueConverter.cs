using Avalonia.Data.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Media.Imaging;
using explorer.Models;
using System.Net.Http.Headers;
using Avalonia.Platform;
using Avalonia;
using System.Reflection;

namespace explorer.ViewModels
{
    public class EntryBitmabValueConverter : IValueConverter
    {
        public static EntryBitmabValueConverter Instance = new EntryBitmabValueConverter();
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null)
                return null;
            if (value is EntryType ent) 
            {
                string rawUri;
                switch (ent) 
                {
                    case EntryType.File:
                       rawUri = @"Assets/icons/File.png";
                        break;
                    case EntryType.Disk:
                        rawUri = @"Assets/icons/Disk.png";
                        break;
                    case EntryType.Folder:
                        rawUri = @"Assets/icons/Folder.png";
                        break;
                    default:
                        throw new ArgumentException("Unknown type of ExplorerEntry");
                }

                string assemblyName = Assembly.GetEntryAssembly().GetName().Name;
                Uri uri = new Uri($"avares://explorer/{rawUri}");

                var bitmap = new Bitmap(AssetLoader.Open(uri));
                return bitmap;
                

            }

            throw new NotImplementedException();
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
