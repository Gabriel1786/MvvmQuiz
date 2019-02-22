using System;
using System.Globalization;
using MvvmCross.Converters;

namespace MvvmQuiz.Forms.UI.ValueConverters
{
    public class StringToBoolConverter : MvxValueConverter<string, bool>
    {
        protected override bool Convert(string value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.IsNullOrEmpty(value);
        }
    }
}
