using System;
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
    public class Q2Model : PageModel
    {
        private readonly ServerContext _context;

        public Q2Model(ServerContext context)
        {
            _context = context;
        }
        [BindProperty]
        public string QueryName { get; set; } = string.Empty;
        [BindProperty]
        public IList<Q2> Q2List { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Player != null && _context.Game != null)
            {
                var caseSensitiveComparer = new CaseSensitiveComparer();

                QueryName = "List of All Players names and last game date";

                //Q2List = await _context.Game
                //    .Join(_context.Player, g => g.PlayerId, p => p.Id, (g, p) => new Q2
                //    {
                //        PlayerId = p.Id,
                //        PlayerName = p.Name,
                //        DateInit = g.DateInit
                //    }).OrderByDescending(pn => pn.PlayerName)
                //    .ThenBy(gm => gm.DateInit).GroupBy(group => group.PlayerId)
                //    .Select(gr => new Q2 { PlayerId = gr.Key, PlayerName = gr.First().PlayerName, DateInit = gr.First().DateInit }).ToListAsync();
                Q2List = (await _context.Player
            .OrderByDescending(p => p.Name) // Order player names in descending order (case-sensitive)
            .Select(p => new Q2
            {
                PlayerId = p.Id,
                PlayerName = p.Name,
                DateInit = _context.Game
                    .Where(g => g.PlayerId == p.Id)
                    .OrderByDescending(g => g.DateInit)
                    .Select(g => g.DateInit.ToString("dd/MM/yyyy HH:mm:ss"))
                    .FirstOrDefault() // Get the most recent DateInit for each player
            }).ToListAsync());

             Q2List = Q2List.OrderByDescending(Q2item => Q2item.PlayerName, caseSensitiveComparer).ToList(); // Order player names in descending order (case-sensitive   

              
            }

        }
    }
}
