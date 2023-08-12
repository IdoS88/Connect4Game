using ClientModels.Dtos.Interfaces;
using Newtonsoft.Json;

namespace ClientModels.Dtos
{
    public class GameDTO : IGameDTO
    {
        [JsonProperty("GameId")]
        public int GameId { get; set; }

        [JsonProperty("DateInit")]
        public System.DateTime DateInit { get; set; }

        [JsonProperty("GameStatus")]
        public string GameStatus { get; set; }

        [JsonProperty("PlayerId")]
        public int PlayerId { get; set; }

        [JsonProperty("TimePlayed")]
        public int TimePlayed { get; set; }


    }
}
