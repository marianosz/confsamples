using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Data;

namespace ContosoCookbookUniversal.Common
{
    class ListConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return String.Join("\r\n", (IEnumerable<string>)value);
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
