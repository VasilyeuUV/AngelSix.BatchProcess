﻿using System;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media;

namespace AngelSix.BatchProcess.ValueConverters;

public class BooleanToBoldFontConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        => value is bool and true ? FontWeight.Bold : FontWeight.Normal;

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotImplementedException();
}
