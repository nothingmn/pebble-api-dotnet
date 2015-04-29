using Newtonsoft.Json;
using pebble_api_dotnet.Helpers;
using pebble_api_dotnet.Layouts;

namespace pebble_api_dotnet.Layouts
{

    public enum GameStates
    {
        InGame,
        PreGame,
        //PostGame   //not supported
    }

    public class SportsLayout : GenericLayout
    {
        public SportsLayout()
        {
            Type = LayoutTypes.sportsPin;
        }

        /// <summary>
        /// rankAway	String (~2 characters)	The rank of the away team.
        /// </summary>
        public string RankAway { get; set; }

        /// <summary>
        /// rankHome	String (~2 characters)	The rank of the home team.
        /// </summary>
        public string RankHome { get; set; }

        /// <summary>
        /// nameAway	String (Max 4 characters)	Short name of the away team.
        /// </summary>
        public string NameAway { get; set; }

        /// <summary>
        /// nameHome	String (Max 4 characters)	Short name of the home team.
        /// </summary>
        public string NameHome { get; set; }

        /// <summary>
        /// recordAway	String (~5 characters)	Record of the away team (wins-losses).
        /// </summary>
        public string RecordAway { get; set; }

        /// <summary>
        /// recordHome	String (~5 characters)	Record of the home team (wins-losses).
        /// </summary>
        public string RecordHome { get; set; }

        /// <summary>
        /// scoreAway	String (~2 characters)	Score of the away team.
        /// </summary>
        public string ScoreAway { get; set; }

        /// <summary>
        /// scoreHome	String (~2 characters)	Score of the home team.
        /// </summary>
        public string ScoreHome { get; set; }

        /// <summary>
        /// sportsGameState	String	in-game for in game or post game, pre-game for pre game.
        /// </summary>
        [JsonConverter(typeof(PebbleGameStateConverter))]
        public GameStates SportsGameState { get; set; }
    }
}