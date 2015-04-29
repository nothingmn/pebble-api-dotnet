namespace pebble_api_dotnet
{
    public class Action
    {
        public Action()
        {
            Type = "openWatchApp";
        }

        /// <summary>
        /// title	String	The name of the action that appears on the watch.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// type	String	The type of action this will execute. See Pin Actions for a list of available actions.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The launchCode field of this action object will be passed to the watchapp and can be obtained with launch_get_args().
        /// </summary>
        public int LaunchCode { get; set; }
    }
}