using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Hawkmoth.OpusOne.UI.Phone
{
    public class MenuItemBindingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var menuItem = value as MenuItem;
            return (MainPage.Current.MenuItems.IndexOf(menuItem) + 1) + ") " + menuItem.Title;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return true;
        }
    }
}
