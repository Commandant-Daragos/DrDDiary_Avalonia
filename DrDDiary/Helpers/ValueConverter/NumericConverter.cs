using Avalonia;
using Avalonia.Data.Converters;
using Avalonia.Media;
using System;
using System.Globalization;

namespace DrDDiary.Helpers.ValueConverter
{ 
// Converter to convert TextBox value to SolidColorBrush
    public class NumericConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value?.ToString(); // Convert numeric value to string
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string strValue = value as string;
            if (string.IsNullOrWhiteSpace(strValue))
            {
                return null; // Handle empty string gracefully
            }

            if (int.TryParse(strValue, out int intValue))
            {
                return intValue; // Return integer value if conversion succeeds
            }
            else
            {
                return AvaloniaProperty.UnsetValue; // Indicate conversion error
            }
        }
    }
}
