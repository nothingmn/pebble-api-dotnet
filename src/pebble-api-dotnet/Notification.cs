using System;
using Newtonsoft.Json;
using pebble_api_dotnet.Helpers;
using pebble_api_dotnet.Layouts;

namespace pebble_api_dotnet
{
    public class Notification
    {
        /// <summary>
        /// layout	Layout object	The layout that will be used to display this notification.
        /// </summary>
        public GenericLayout Layout { get; set; }

        /// <summary>
        /// time	String (ISO date-time)	The new time of the pin update.
        /// </summary>
        [JsonConverter(typeof(PebbleDateTimeConverter))]
        public DateTimeOffset Time { get; set; }
    }
}