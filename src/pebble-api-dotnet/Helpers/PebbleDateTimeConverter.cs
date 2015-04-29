using Newtonsoft.Json.Converters;

namespace pebble_api_dotnet.Helpers
{
    public class PebbleDateTimeConverter : IsoDateTimeConverter
    {
        public PebbleDateTimeConverter()
        {
            base.DateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ssK";
        }
    }
}