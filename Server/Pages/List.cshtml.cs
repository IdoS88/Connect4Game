using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdoShamir_EyalCohen_Connect4.Data;
using Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace IdoShamir_EyalCohen_Connect4.Pages
{
    public class ListModel : PageModel
    {
        private readonly ServerContext _context;

        public ListModel(ServerContext context)
        {
            _context = context;
        }

        public IList<Player> Player { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Player != null)
            {
                Player = await _context.Player.ToListAsync();
            }
        }
    }
}
