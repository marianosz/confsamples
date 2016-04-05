using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Data;

namespace ContosoCookbookUniversal.Common
{
    class UppercaseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return ((string)value).ToUpper();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
