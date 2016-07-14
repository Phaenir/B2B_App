using System;
using System.Diagnostics;
using Windows.UI.Xaml.Data;

namespace B2B_App.Models.APA
{
    class DateTimeConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            try
            {
                DateTime date = (DateTime)value;
                return new DateTimeOffset(date);
            }
            catch (Exception ex)
            {
                Debug.Assert(true,ex.Message);
                return DateTimeOffset.MinValue;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            try
            {
                DateTimeOffset dto = (DateTimeOffset)value;
                return dto.DateTime;
            }
            catch (Exception ex)
            {
                Debug.Assert(true, ex.Message);
                return DateTime.MinValue;
            }
        }
    }
}
