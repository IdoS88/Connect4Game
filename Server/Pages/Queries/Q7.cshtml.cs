using IdoShamir_EyalCohen_Connect4.Data;
using IdoShamir_EyalCohen_Connect4.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Models.Models;

namespace IdoShamir_EyalCohen_Connect4.Pages.Queries
{
    public class Q7Model : PageModel
    {
        private readonly ServerContext _context;

        public Q7Model(ServerContext context)
        {
            _context = context;
        }
        public int MaxGameCountForPlayer { get; set; } = 0;
        public IList<Player>[] Players { get; set; } = new List<Player>[1];

        public async Task OnGetAsync()
        {
            Players[0] = new List<Player>();
            if (_context.Game != null)
            {
                Q6Model q6 = new Q6Model(_context);
                await q6.OnGetAsync();
                MaxGameCountForPlayer = await _context.Game.MaxAsync(x => x.PlayerId);
                if (MaxGameCountForPlayer > 0)
                    Players = new List<Player>[MaxGameCountForPlayer + 1];
                for (int i = 0; i < Players.Length; i++)
                {
                    var PlayerListForGameCount = q6.Players.Where(x => x.GamesCount == i).Select(p => p.PlayerId).ToList();
                    Players[i] = await _context.Player.Where(p => PlayerListForGameCount.Contains(p.Id)).ToListAsync();
                    if (Players[i].Count == 0)
                        Players[i] = new List<Player>();
                }
            }

        }
    }
}
