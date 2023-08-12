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
    public class DetailsModel : PageModel
    {
        private readonly ServerContext _context;

        public DetailsModel(ServerContext context)
        {
            _context = context;
        }

        public Player GamePlayer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Player == null)
            {
                return NotFound();
            }


            GamePlayer = await _context.Player
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (GamePlayer == null)
            {
                return NotFound();
            }
            return Page();

        }
    }
}
