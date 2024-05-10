using Avalonia;
using Avalonia.Data.Converters;
using Avalonia.Media;
using System;
using System.Globalization;

namespace DrDDiary.Helpers.ValueConverter
{ 
// Converter to convert TextBox value to SolidColorBrush
    public class ValueToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return Brushes.Gray;
            }
            if (value is int intValue)
            {
                // Check if the value is 0
                if (intValue == 0)
                {
                    // Return gray color
                    return Brushes.Gray;
                }
            }
            // Return default color
            return Brushes.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
