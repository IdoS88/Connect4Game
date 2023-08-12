
using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Services.Interfaces
{
    internal interface IPlayerService
    {
        Task<IEnumerable<Player>> GetPlayers();
        Task<Player> GetPlayer(int id);
    }
}
