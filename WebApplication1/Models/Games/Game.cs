using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models.Games
{
    public class Game
    {
        [ForeignKey("PlayerId")]
        public int PlayerId { get; set; }
        [Key]
        public int GameId { get; set; }

        public DateTime DateInit { get; set; }

        public int TimePlayed { get; set; }

        public string GameStatus { get; set; } = "In Progress";
        // Player, Computer, Draw, In Progress

    }
}
