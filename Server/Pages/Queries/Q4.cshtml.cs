using IdoShamir_EyalCohen_Connect4.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using System.Collections.Generic;

namespace IdoShamir_EyalCohen_Connect4.Pages.Queries
{
    public class Q4Model : PageModel
    {
        private readonly ServerContext _context;

        public Q4Model(ServerContext context)
        {
            _context = context;
        }
        public IList<Game> Games { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Game != null && _context.Player != null)
            {
                var gamesFromDatabase = await _context.Game
                    .Where(game => game != null && game.PlayerId != null)
                    .OrderByDescending(game => game.GameStatus)
                    .ThenBy(game => game.TimePlayed)
                    .ToListAsync();
                Games = gamesFromDatabase
    .DistinctBy(game => game.PlayerId).ToList();
            }
        }
    }
    public class PlayerIdComparer: IEqualityComparer<Game>
    {
          public bool Equals(Game x, Game y)
        {
            return x.PlayerId == y.PlayerId;
        }

        public int GetHashCode(Game obj)
        {
            return obj.PlayerId.GetHashCode();
        }   
    }
}
