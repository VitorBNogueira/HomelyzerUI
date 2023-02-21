using CommunityToolkit.Maui.Converters;
using HomelyzerUI.Models.Enums;
using System.Globalization;

namespace HomelyzerUI.Common.Converters;

internal sealed class TypeConverter : BaseConverter<object, int>
{
    public override int DefaultConvertReturnValue { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public override object DefaultConvertBackReturnValue { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public override object ConvertBackTo(int value, CultureInfo culture)
    {
        return Enum.ToObject(typeof(EAdvertType), value);
    }

    public override int ConvertFrom(object value, CultureInfo culture)
    {
        return (int)value;
    }
}
