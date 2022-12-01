using CommunityToolkit.Maui.Converters;
using System.Globalization;

namespace HomelyzerUI.Common
{
    internal sealed class IncludesBillsConverter : BaseConverter<bool, String>
    {
        public override string DefaultConvertReturnValue { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override bool DefaultConvertBackReturnValue { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override bool ConvertBackTo(string value, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override string ConvertFrom(bool value, CultureInfo culture)
        {
            return value ? "Bills included" : "Bills NOT included";
        }
    }
}
