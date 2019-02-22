using System;
using System.Collections.Generic;
using System.Globalization;
using MvvmCross.Converters;
using Xamarin.Forms;

namespace MvvmQuiz.Forms.UI.ValueConverters
{
    public class BoolToColorValueConverter : MvxValueConverter<bool, Color>
    {
        protected override Color Convert(bool value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter is Color[] colorArray)
            {
                if (colorArray.Length >= 2)
                {
                    return value ? colorArray[0] : colorArray[1];
                }

                if (colorArray.Length == 1 && value)
                {
                    return colorArray[0];
                }
            }
            else if (value)
            {
                if (parameter is Color color)
                {
                    return color;
                }

                if (!string.IsNullOrEmpty(parameter.ToString()))
                {
                    return Color.FromHex(parameter.ToString());
                }
            }

            return Color.Transparent;
        }
    }
}