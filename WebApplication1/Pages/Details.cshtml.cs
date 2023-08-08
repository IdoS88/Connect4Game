using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;

namespace Server.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly Server.Data.ServerContext _context;

        public DetailsModel(Server.Data.ServerContext context)
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
