//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using IdoShamir_EyalCohen_Connect4.Repositories.Interfaces;
//using IdoShamir_EyalCohen_Connect4.Repositories;
//using IdoShamir_EyalCohen_Connect4.Models;
//using Models.Models.Extentions;
//using Models.Models;

using IdoShamir_EyalCohen_Connect4.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Models.Models.Dtos;
using Models.Models.Extentions;

namespace IdoShamir_EyalCohen_Connect4.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerRepository playerRepository;

        public PlayersController(IPlayerRepository playerRepository)
        {
            this.playerRepository = playerRepository;
        }

        // GET: api/Players
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerDTO>>> GetPlayers()
        {
            try
            {

                var players = await this.playerRepository.GetPlayers();


                if (players == null)
                {
                    return NotFound();
                }
                else
                {
                    var playerstoDtos = players.ConvertToDtos();

                    return Ok(playerstoDtos);
                }

            }
            catch (Exception ex)
            {
                if (this.playerRepository.GetContext().Player == null)
                    return Problem("DB not found. " + ex.Message, "PlayerDB", 500);
                return Problem("DB error retrieving from db " + ex.Message, "PlayerDB", 500);

            }
        }

        // GET: api/Players/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<PlayerDTO>> GetPlayer(int id)
        {
            try
            {
                var player = await this.playerRepository.GetPlayer(id);

                if (player == null)
                {
                    return NotFound("User not found. Please register on website");
                }
                else
                {

                    var playerDto = player.ToDto();

                    return Ok(playerDto);
                }

            }
            catch (Exception ex)
            {
                if (this.playerRepository.GetContext().Player == null)
                    return Problem("DB not found. " + ex.Message, "PlayerDB", 500);
                return Problem("DB error retrieving from db " + ex.Message, "PlayerDB", 500);
            }
        }


        // PUT: api/Players/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutPlayer(int id, [FromBody] PlayerDTO playerDTO)
        {
            //if (id != playerDTO.Id)
            //{
            //    return BadRequest();
            //}



            //try
            //{
            //    this.playerRepository.GetContext().Player.Entry(playerDTO.ToPlayer()).State = EntityState.Modified;
            //    await this.playerRepository.GetContext().SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!PlayerExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return NoContent();
            return Problem("Not implemented");
        }

        // POST: api/Players
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Player>> PostPlayer([FromBody] Player Player)
        {
            return Problem("Not implemented");
            //try
            //{
            //    if (this.playerRepository.GetContext().Player == null)
            //    {
            //        return Problem("Entity set 'ServerContext.Player'  is null.");
            //    }
            //    this.playerRepository.GetContext().Player.Add(player);
            //    await this.playerRepository.GetContext().SaveChangesAsync();
            //}
            //catch (Exception ex)
            //{
            //    if (this.playerRepository.GetContext().Player == null)
            //        return Problem("DB not found. " + ex.Message, "PlayerDB", 500);
            //    return Problem("DB error retrieving from db " + ex.Message, "PlayerDB", 500);
            //}

            //return CreatedAtAction("GetPlayer", new { id = player.Id }, player);
        }

        // DELETE: api/Players/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletePlayerDTO(int id)
        {
            //if (this.playerRepository.GetContext().PlayerDTO == null)
            //{
            //    return NotFound();
            //}
            //var playerDTO = await this.playerRepository.GetContext().Player.FindAsync(id);
            //if (playerDTO == null)
            //{
            //    return NotFound();
            //}

            //this.playerRepository.GetContext().Player.Remove(playerDTO);
            //await this.playerRepository.GetContext().SaveChangesAsync();

            //return NoContent();
            return Problem("Not implemented");
        }

     
    }
}
