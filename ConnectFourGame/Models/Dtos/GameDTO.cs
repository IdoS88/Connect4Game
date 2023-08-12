using Client.Models.Dtos.Interfaces;
using Newtonsoft.Json;
using System;

namespace Client.Models.Dtos
{
    public class GameDTO : IGameDTO
    {
        [JsonProperty("GameId")]
        public int GameId { get; set; }

        [JsonProperty("DateInit")]
        public DateTime DateInit { get; set; }

        [JsonProperty("GameStatus")]
        public string GameStatus { get; set; }

        [JsonProperty("PlayerId")]
        public int PlayerId { get; set; }

        [JsonProperty("TimePlayed")]
        public int TimePlayed { get; set; }


    }
}
