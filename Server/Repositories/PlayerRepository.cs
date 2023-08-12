using IdoShamir_EyalCohen_Connect4.Data;
using IdoShamir_EyalCohen_Connect4.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Models;
namespace IdoShamir_EyalCohen_Connect4.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly ServerContext playerDbContext;

        public PlayerRepository(ServerContext playerDbContext)
        {
            this.playerDbContext = playerDbContext;
        }
        public async Task<Player?> GetPlayer(int id)
        {
            var player = await playerDbContext.Player.SingleOrDefaultAsync(p => p.Id == id);
            return player;
        }

        public async Task<IEnumerable<Player>> GetPlayers()
        {
            var players = await this.playerDbContext.Player.ToListAsync();

            return players;
        }
        public async Task<bool> PlayerExists(int playerId)
        {
            return await this.playerDbContext.Player.AnyAsync(g => g.Id == playerId);

        }

        public ServerContext? GetContext()
        {
            return this.playerDbContext;
        }

    }

}
