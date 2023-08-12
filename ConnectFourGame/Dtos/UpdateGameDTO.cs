
using System.ComponentModel.DataAnnotations;
using ClientModels.Dtos.Interfaces; 
namespace ClientModels.Dtos
{
    public class UpdateGameDTO : IGameDTO
    {
        // might be unnecessary
        public int PlayerId { get; set; }
        [Key]
        public int GameId { get; set; }
        public int TimePlayed { get; set; }
        public string GameStatus { get; set; }
    }
}
