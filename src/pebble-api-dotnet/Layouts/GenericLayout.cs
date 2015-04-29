using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using pebble_api_dotnet.Helpers;

namespace pebble_api_dotnet.Layouts
{
    public enum LayoutTypes
    {
        genericPin,
        calendarPin,
        genericReminder,
        genericNotification,
        commNotification,
        weatherPin,
        sportsPin,
    }

    public class GenericLayout
    {
        public GenericLayout()
        {
            Type = LayoutTypes.genericPin;
        }

        /// <summary>
        /// type	String	The type of layout the pin will use. See Pin Layouts for a list of available types.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public LayoutTypes Type { get; set; }

        /// <summary>
        /// title	String	The title of the pin when viewed.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// shortTitle	String	The title of the pin in a compressed view.
        /// </summary>
        public string ShortTitle { get; set; }

        /// <summary>
        /// tinyIcon	String	URI of the pin's tiny icon.
        /// </summary>
        public string TinyIcon { get; set; }

        /// <summary>
        /// subtitle	String	Shorter subtitle for details.
        /// </summary>
        public string Subtitle { get; set; }

        /// <summary>
        /// body	String	The body text of the pin.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// smallIcon	String	URI of the pin's small icon.
        /// </summary>
        public string SmallIcon { get; set; }

        /// <summary>
        /// largeIcon	String	URI of the pin's large icon.
        /// </summary>
        public string LargeIcon { get; set; }

        /// <summary>
        /// foregroundColor	String	Six-digit color hexadecimal string describing the foreground text color, or case-insensitive SDK constant name such as "mintgreen".
        /// </summary>
        public string ForegroundColor { get; set; }

        /// <summary>
        /// backgroundColor	String	Same as foregroundColor, except applies to the background color.
        /// </summary>
        public string BackgroundColor { get; set; }

        /// <summary>
        /// headings	Array of Strings	List of section headings in this layout.
        /// </summary>
        public List<string> Headings { get; set; }

        /// <summary>
        /// paragraphs	Array of Strings	List of paragraphs in this layout. Must equal the number of headings.
        /// </summary>
        public List<string> Paragraphs { get; set; }

        /// <summary>
        /// lastUpdated	ISO date-time	Timestamp of when the pin’s data (e.g: weather forecast or sports score) was last updated.
        /// </summary>
        [JsonConverter(typeof(PebbleDateTimeConverter))]
        public DateTime? LastUpdated { get; set; }

        public string Sender { get; set; }

        public string Broadcaster { get; set; }
    }
}