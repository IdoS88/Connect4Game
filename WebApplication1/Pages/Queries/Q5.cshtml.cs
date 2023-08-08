using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models.Games;
using Server.Models;

namespace Server.Pages.Queries
{
    public class Q5Model : PageModel
    {
        private readonly Server.Data.ServerContext _context;

        public Q5Model(Server.Data.ServerContext context)
        {
            _context = context;
        }
      
        public IList<Game>? Game { get; set; } = new List<Game>();
        public IList<string> PlayerTable { get; set; } = default!;
        [BindProperty]
        public string SelectedPlayerName { get; set; }
        public string QueryName { get; set; } = "List of all player games with details";


        public async Task OnGetAsync()
        {
            if (_context.Player != null)
            {
                PlayerTable = await _context.Player
                               .OrderBy(p => p.Name).Select(pl =>pl.Name).ToListAsync();
                  
            }

        }
        public async Task OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                PlayerTable = await _context.Player
                               .OrderBy(p => p.Name).Select(pl => pl.Name).ToListAsync();
                return;
            }

            if (SelectedPlayerName != null && _context.Game != null)
            {
                var player = await _context.Player
                    .FirstOrDefaultAsync(p => p.Name == SelectedPlayerName);

                if (player != null)
                {
                    Game = await _context.Game
                        .Where(g => g.PlayerId == player.Id)
                        .ToListAsync();
                }
            }
            // Repopulate the drop-down list
            PlayerTable = await _context.Player
                               .OrderBy(p => p.Name).Select(pl => pl.Name).ToListAsync();
        }
    }
}
