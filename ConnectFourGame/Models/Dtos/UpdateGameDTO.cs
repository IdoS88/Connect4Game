
using System.ComponentModel.DataAnnotations;

namespace Client.Models.Dtos
{
    public class UpdateGameDTO : Models.Dtos.Interfaces.IGameDTO
    {
        // might be unnecessary
        public int PlayerId { get; set; }
        [Key]
        public int GameId { get; set; }
        public int TimePlayed { get; set; }
        public string GameStatus { get; set; }
    }
}
