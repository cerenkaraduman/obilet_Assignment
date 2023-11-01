using Newtonsoft.Json.Converters;

namespace obilet_Assignment.Applicaiton.Common.Convertor
{
    public class DateTimeConvertor : IsoDateTimeConverter
    {
        public DateTimeConvertor()
        {
            DateTimeFormat = "yyyy-MM-ddTHH:mm:ss";
        }
    }
}
