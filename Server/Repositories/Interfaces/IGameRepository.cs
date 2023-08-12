

using IdoShamir_EyalCohen_Connect4.Data;
using Models.Models;
using Models.Models.Dtos;

namespace IdoShamir_EyalCohen_Connect4.Repositories.Interfaces
{
    public interface IGameRepository
    {

        Task<IEnumerable<Game>> GetGames();
        Task<Game?> GetGame(int id);
        Task<IEnumerable<Game>> GetGamesById(int id);
        Task<Game?> AddGame(GameDTO game);

        Task<Game?> PatchGame(int id, UpdateGameDTO gameToUpdateDto);
        public ServerContext? GetContext();
    }
}
