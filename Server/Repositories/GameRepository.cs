using IdoShamir_EyalCohen_Connect4.Data;
using IdoShamir_EyalCohen_Connect4.Models;
using Models.Models;
using Models.Models.Dtos;
using Models.Models.Extentions;
using IdoShamir_EyalCohen_Connect4.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace IdoShamir_EyalCohen_Connect4.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly ServerContext _context;
        public GameRepository(ServerContext serverContext)
        {
            this._context = serverContext;

        }
        public async Task<Game?> AddGame(GameDTO gameToAddDto)
        {
            if (await GameExists(gameToAddDto.GameId))
            {
                return null;

            }
            var result = await this._context.Game.AddAsync(gameToAddDto.ToGame());
            await this._context.SaveChangesAsync();
            return result.Entity;

        }


        public ServerContext? GetContext()
        {
            return this._context;
        }

        public async Task<Game?> GetGame(int id)
        {
            var result = await this._context.Game.SingleOrDefaultAsync(g => g.GameId == id);
            return result;
        }

        public async Task<IEnumerable<Game>> GetGames()
        {
            var games = await this._context.Game.ToListAsync();

            return games;
        }

        public async Task<IEnumerable<Game>> GetGamesById(int id)
        {
            return await this._context.Game.Where(g => g.PlayerId == id).ToListAsync();

        }

        public async Task<Game?> PatchGame(int id, UpdateGameDTO gameToUpdateDto)
        {
            var game = await this._context.Game.FindAsync(id);

            if (game != null)
            {
                game.TimePlayed = gameToUpdateDto.TimePlayed;
                game.GameStatus = gameToUpdateDto.GameStatus;
                await this._context.SaveChangesAsync();
                return game;
            }

            return null;
        }



        private async Task<bool> GameExists(int gameId)
        {
            return await this._context.Game.AnyAsync(g => g.GameId == gameId);

        }
    }
}
