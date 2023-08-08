using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;

namespace Server.Pages
{
    public class EditModel : PageModel
    {
        private readonly Server.Data.ServerContext _context;

        public List<Country> Names { get; set; } = Enum.GetValues(typeof(Country))
                                       .OfType<Country>()
                                       .ToList();

        public EditModel(Server.Data.ServerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UpdateUser? UpdateUserInstance { get; set; }

        public Player? GamePlayer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {

            if (id == null || _context.Player == null || !_context.Player.Any(p => p.Id == id))
            {
                return NotFound();
            }

            GamePlayer = await _context.Player.FindAsync(id);
            if (GamePlayer == null)
            {
                return NotFound();
            }
            return Page();

        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (_context.Player == null || !_context.Player.Any(p => p.Id == id) || UpdateUserInstance == null)
            {
                return NotFound();
            }
            var playerToUpdate = await _context.Player.FindAsync(id);
            if (playerToUpdate == null)
            {
                return NotFound();
            }


            foreach (var modelStateEntry in ModelState.Values)
            {
                foreach (var error in modelStateEntry.Errors)
                {
                    // Log or handle the error, e.g., display error message in the console.
                    Console.WriteLine($"Validation Error: {error.ErrorMessage}");
                }
            }
            if (ModelState.IsValid)
            {
                if (await TryUpdateModelAsync<Player>(
    playerToUpdate,
    "UpdateUserInstance",
    p => p.Name, p => p.Phone, p => p.CountrySelection))
                {
                    try
                    {
                        await _context.SaveChangesAsync();
                        return RedirectToPage("/Details", new { id = playerToUpdate.Id });
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!NewPlayerRegisterExists(playerToUpdate.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    
                }
            }
            return Page();

        }

        private bool NewPlayerRegisterExists(int id)
        {
            return (_context.Player?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}




