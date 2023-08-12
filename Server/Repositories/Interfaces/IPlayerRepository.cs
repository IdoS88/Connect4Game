using IdoShamir_EyalCohen_Connect4.Data;
using IdoShamir_EyalCohen_Connect4.Models;
using Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace IdoShamir_EyalCohen_Connect4.Repositories.Interfaces
{
    public interface IPlayerRepository
    {
        Task<IEnumerable<Player>> GetPlayers();
        Task<Player?> GetPlayer(int id);
        Task<bool> PlayerExists(int playerId);
        public ServerContext? GetContext();
    }
}
