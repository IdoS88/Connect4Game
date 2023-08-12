using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdoShamir_EyalCohen_Connect4.Data;
using IdoShamir_EyalCohen_Connect4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Models.Models;

namespace IdoShamir_EyalCohen_Connect4.Pages.Queries
{
    public class Q1Model : PageModel
    {
        private readonly ServerContext _context;

        public Q1Model(ServerContext context)
        {
            _context = context;
        }
        [BindProperty]
        public string QueryName { get; set; } = string.Empty;
        [BindProperty]
        public IList<Player> PlayerList { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Player != null)
            {
                QueryName = "List of All Players with details";
                PlayerList = await _context.Player.ToListAsync();
            }
        }
    }
}
