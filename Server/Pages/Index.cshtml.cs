using IdoShamir_EyalCohen_Connect4.Data;
using Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace IdoShamir_EyalCohen_Connect4.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ServerContext _context;
        [BindProperty]
        public Player PlayerLogin { get; set; } = default!;
        public IndexModel(ServerContext context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            if (_context.Player == null)
            {
                return NotFound();
            }
            return Page();

        }

        public IActionResult OnPost()
        {

            if (ModelState.IsValid)
            {
                var player = _context.Player.FirstOrDefault(p => p.Id == PlayerLogin.Id);
                if (player != null)
                {
                    // Redirect to the user details page with the valid user ID
                    return RedirectToPage("/Details", new { id = player.Id });
                }
                else
                {
                    ModelState.AddModelError("PlayerLogin.Id", "Invalid User ID. Please try again.");
                }
            }

            // If the ModelState is invalid or the user ID is invalid, redisplay the login form
            return Page();
        }
    }
}

