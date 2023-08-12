using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdoShamir_EyalCohen_Connect4.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Models.Models.Queries_Models;

namespace IdoShamir_EyalCohen_Connect4.Pages.Queries
{
    public class Q6Model : PageModel
    {
        private readonly ServerContext _context;

        public Q6Model(ServerContext context)
        {
            _context = context;
        }

        public IList<Q6> Players { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Player != null && _context.Game != null)
            {
                var PlayersPlayed = _context.Player.Select(p => p.Id); //select all players
                // count all games played by each player
                Players = await _context.Player
                    .Select(p => new Q6
                    {
                        PlayerId = p.Id,
                        PlayerName = p.Name,
                        GamesCount = _context.Game
                            .Where(gp => gp.PlayerId == p.Id)
                            .Count()
                    })
                    .ToListAsync();
            }
        }
    }
}
