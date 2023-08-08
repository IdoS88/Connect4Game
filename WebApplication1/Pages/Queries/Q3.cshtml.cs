using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models.Games;

namespace Server.Pages.Queries
{
    public class Q3Model : PageModel
    {
        private readonly ServerContext _context;

        public Q3Model(ServerContext context)
        {
            _context = context;
        }
        public string QueryName { get; set; } = string.Empty;
        public IList<Game> Game { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Game != null)
            {
                QueryName = "List of All Games with details";
                Game = await _context.Game.ToListAsync();
            }
        }
    }
}
