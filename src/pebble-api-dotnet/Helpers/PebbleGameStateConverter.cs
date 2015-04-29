using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using pebble_api_dotnet.Layouts;

namespace pebble_api_dotnet.Helpers
{
    public class PebbleGameStateConverter : StringEnumConverter
    {

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            object newValue = GameStates.InGame;
            var value = ((string) existingValue).ToLower();
            if (value == "pre-game")
            {
                newValue = GameStates.PreGame;
            }
//            else if (value == "post-game")
//            {
//                newValue = GameStates.PostGame;
//            }
            return base.ReadJson(reader, objectType, newValue, serializer);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var e = ((GameStates) value);
            if (e == GameStates.InGame)
            {
                writer.WriteValue("in-game");

            }
//            else if (e == GameStates.PostGame)
//            {
//                writer.WriteValue("post-game");
//            }
            else
            {
                writer.WriteValue("pre-game");
            }

        }
    }
}