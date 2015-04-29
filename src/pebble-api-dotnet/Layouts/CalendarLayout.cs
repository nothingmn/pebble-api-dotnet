namespace pebble_api_dotnet.Layouts
{
    public class CalendarLayout : GenericLayout
    {
        public CalendarLayout()
        {
            Type = LayoutTypes.calendarPin;
        }

        public string LocationName { get; set; }
    }
}