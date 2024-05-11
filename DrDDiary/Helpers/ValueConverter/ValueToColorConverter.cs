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

        /// <summary>
        /// Method must be present due to interface, but is not implemented.
        /// Method does not have purpose for this class.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
