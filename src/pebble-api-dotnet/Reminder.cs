using System;
using Newtonsoft.Json;
using pebble_api_dotnet.Helpers;
using pebble_api_dotnet.Layouts;

namespace pebble_api_dotnet
{
    public class Reminder
    {
        public Reminder()
        {
            Time = DateTimeOffset.UtcNow;
            Layout = new GenericLayout();
        }

        /// <summary>
        /// time	String (ISO date-time)	The time the reminder is scheduled to be shown.
        /// </summary>
        [JsonConverter(typeof(PebbleDateTimeConverter))]
        public DateTimeOffset Time { get; set; }

        /// <summary>
        /// layout	Layout object	The layout of the reminder.
        /// </summary>
        public GenericLayout Layout { get; set; }
    }
}