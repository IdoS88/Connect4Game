namespace Client.Models.Dtos.Interfaces
{
    public interface IGameDTO
    {
        int PlayerId { get; set; }
        int GameId { get; set; }

        int TimePlayed { get; set; }

        string GameStatus { get; set; }
        // Player, Computer, Draw, In Progress
    }
}
