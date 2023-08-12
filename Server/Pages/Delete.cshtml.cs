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
    public class DeleteModel : PageModel
    {
        private readonly ServerContext _context;
        private readonly ILogger<DeleteModel> _logger;

        public DeleteModel(ServerContext context, ILogger<DeleteModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Player GamePlayer { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
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
            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = string.Format("Delete {ID} failed. Try again", id);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Player == null)
            {
                return NotFound();
            }
            var player = await _context.Player.FindAsync(id);

            if (player == null)
            {
                return NotFound();
            }

            try
            {
                _context.Player.Remove(player);
                await _context.SaveChangesAsync();
                string res = string.Join("You successfuly Deleted The User! ", new List<string> { player.Name, player.Id.ToString() });

                await Response.WriteAsync("<p>" + res + "</p>" + "<br /><a href=\"/Index\">Back to Login Page</a>");

            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, ErrorMessage);

                return RedirectToAction("./Delete",
                                     new { id, saveChangesError = true });
            }
            return Page();
        }
    }
}
