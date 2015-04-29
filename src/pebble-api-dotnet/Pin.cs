using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using pebble_api_dotnet.Helpers;
using pebble_api_dotnet.Layouts;

namespace pebble_api_dotnet
{
    public class Pin
    {
        public Pin()
        {
            Time = DateTime.UtcNow;
            Layout = new GenericLayout();
        }

        /// <summary>
        /// createNotification	Notification object	The notification shown when the event is first created.
        /// </summary>
        public GenericLayout CreateNotification { get; set; }

        /// <summary>
        /// updateNotification	Notification object	The notification shown when the event is updated but already exists.
        /// </summary>
        public GenericLayout UpdateNotification { get; set; }

        /// <summary>
        /// duration	Integer number	The duration of the event the pin represents, in minutes.
        /// </summary>
        [JsonConverter(typeof(PebbleDurationTimeConverter))]
        public TimeSpan? Duration { get; set; }

        /// <summary>
        /// time	String (ISO date-time)	The start time of the event the pin represents, such as the beginning of a meeting.
        /// </summary>
        [JsonConverter(typeof(PebbleDateTimeConverter))]
        public DateTime Time { get; set; }

        /// <summary>
        /// id	String (max. 64 chars)	Developer-implemented identifier for this pin event. Can not be re-used.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// reminders	Reminder object array (Max. 3)	Collection of event reminders to display before an event starts.
        /// </summary>
        public List<Reminder> Reminders { get; set; }

        /// <summary>
        /// actions	Action object array	Collection of event actions that can be executed by the user.
        /// </summary>
        public List<Action> Actions { get; set; }

        /// <summary>
        /// layout	Layout object	Description of the values to populate the layout when the user views the pin.
        /// </summary>
        public GenericLayout Layout { get; set; }
    }
}