namespace pebble_api_dotnet.Layouts
{
    public class ReminderLayout : GenericLayout
    {
        public ReminderLayout()
        {
            Type = LayoutTypes.genericReminder;
        }

        public string LocationName { get; set; }
    }
}