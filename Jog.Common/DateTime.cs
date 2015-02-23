using System;
using Newtonsoft.Json.Converters;

namespace Jog.Common
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow { get; }
    }

    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow
        {
            get { return DateTime.UtcNow;  }
        }
    }

    public class ShortDateTimeConverter : IsoDateTimeConverter
    {
        public ShortDateTimeConverter()
        {
            base.DateTimeFormat = "yyyy-MM-dd";
        }
    }
}
