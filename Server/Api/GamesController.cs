
using IdoShamir_EyalCohen_Connect4.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Dtos;
using Models.Models;
using Models.Models.Dtos;
using Models.Models.Extentions;

namespace IdoShamir_EyalCohen_Connect4.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameRepository gameRepository;

        public GamesController(IGameRepository gameRepository)
        {
            this.gameRepository = gameRepository;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameDTO>>> GetallGames()
        {
            try
            {
                var games = await this.gameRepository.GetGames();

                if (games == null)
                {
                    return NoContent();
                }

                var gamesDto = games.ConvertToDtos();

                return Ok(gamesDto);

            }
            catch (Exception ex)
            {
                if (this.gameRepository.GetContext().Game == null)
                    return Problem("DB not found. " + ex.Message, "PlayerDB", 500);
                return Problem("DB error retrieving from db " + ex.Message, "PlayerDB", 500);
            }
        }
        [HttpGet("GetGamesByUserId/{id:int}")]
        public async Task<ActionResult<IEnumerable<GameDTO>>> GetPlayerGames(int id)
        {
            try
            {
                var games = await this.gameRepository.GetGamesById(id);

                if (games == null)
                {
                    return NoContent();
                }

                var gamesDto = games.ConvertToDtos();

                return Ok(gamesDto);

            }
            catch (Exception ex)
            {
                if (this.gameRepository.GetContext().Game == null)
                    return Problem("DB not found. " + ex.Message, "PlayerDB", 500);
                return Problem("DB error retrieving from db " + ex.Message, "PlayerDB", 500);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GameDTO>> GetGame(int id)
        {
            try
            {
                var game = await this.gameRepository.GetGame(id);
                if (game == null)
                {
                    return NotFound();
                }

                var gameDto = game.ToDto();

                return Ok(gameDto);
            }
            catch (Exception ex)
            {
                if (this.gameRepository.GetContext().Game == null)
                    return Problem("DB not found. " + ex.Message, "PlayerDB", 500);
                return Problem("DB error retrieving from db " + ex.Message, "PlayerDB", 500);
            }
        }

        [HttpGet("GetComputerTurn")]
        public ActionResult<int> GetComputerTurn()
        {
            try
            {
                Random random = new Random();
                int col = random.Next(7);
                return Ok(col);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<GameDTO>> PostGame([FromBody] GameDTO gameToAddDto)
        {
            try
            {

                var newGame = await this.gameRepository.AddGame(gameToAddDto);

                if (newGame == null)
                {
                    return NoContent();
                }

                var gameDto = newGame.ToDto();

                return CreatedAtAction(nameof(GetGame), new { id = gameDto.GameId }, gameDto);


            }
            catch (Exception ex)
            {
                if (this.gameRepository.GetContext().Game == null)
                    return Problem("DB not found. " + ex.Message, "PlayerDB", 500);
                return Problem("DB error retrieving from db " + ex.Message, "PlayerDB", 500);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<GameDTO>> DeleteGame(int id)
        {
            return Problem("not implemented");
        }

        [HttpPatch("{id:int}")]
        public async Task<ActionResult> PatchGameStatusDetails(int id, [FromBody] UpdateGameDTO gameUpdateDto)
        {
            try
            {
                var updatedGame = await this.gameRepository.PatchGame(id, gameUpdateDto);
                if (updatedGame == null)
                {
                    return NotFound();
                }

                var gameDto = updatedGame.ToPatchDto();

                return Ok();

            }
            catch (Exception ex)
            {
                if (this.gameRepository.GetContext().Game == null)
                    return Problem("DB not found. " + ex.Message, "PlayerDB", 500);
                return Problem("DB error retrieving from db " + ex.Message, "PlayerDB", 500);
            }

        }
    }


}
