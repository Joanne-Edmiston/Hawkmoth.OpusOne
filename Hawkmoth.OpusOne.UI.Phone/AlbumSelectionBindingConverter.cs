using Hawmoth.OpusOne.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Hawkmoth.OpusOne.UI.Phone
{
    public class AlbumSelectionBindingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var album = value as Album;
            return $"{album.Name} ({album.Artist})";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return true;
        }
    }
}
