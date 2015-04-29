namespace pebble_api_dotnet.Layouts
{
    public class WeatherLayout : GenericLayout
    {
        public string LocationName { get; set; }

        public WeatherLayout()
        {
            Type = LayoutTypes.weatherPin;
        }

//        public string HighLowTemperatures
//        {
//            get { return base.Subtitle; }
//            set { base.Subtitle = value; }
//        }
//
//        public string ShortCast
//        {
//            get { return base.Body; }
//            set { base.Body = value; }
//        }
    }
}