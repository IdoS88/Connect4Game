
using Client.Models;
using Client.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Services.Interfaces
{
    public interface IGameService
    {
        Task<IEnumerable<Game>> GetGames();
        Task<IEnumerable<Game>> GetGames(int userId);
        Task<Game> GetGame(int id);
        Task<Uri> AddGame(GameDTO gameToAddDto);

        Task<int> GetComputerMove();

    }
}
