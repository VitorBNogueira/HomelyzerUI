using CommunityToolkit.Maui.Converters;
using System.Globalization;

namespace HomelyzerUI.Common.Converters
{
    internal sealed class MeetingTimeConverter : BaseConverter<DateTime, TimeSpan>
    {
        public override TimeSpan DefaultConvertReturnValue { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override DateTime DefaultConvertBackReturnValue { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override DateTime ConvertBackTo(TimeSpan value, CultureInfo culture)
        {
            return DateTime.Today.Add(value);
        }

        public override TimeSpan ConvertFrom(DateTime value, CultureInfo culture)
        {
            return value.TimeOfDay;
        }
    }
}
