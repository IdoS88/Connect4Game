using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using IdoShamir_EyalCohen_Connect4.Data;
using IdoShamir_EyalCohen_Connect4.UI;
using Models.Models;
namespace IdoShamir_EyalCohen_Connect4.Pages
{
    [ValidateAntiForgeryToken]
    public class CreateModel : PageModel
    {
        private readonly ServerContext _context;

        [BindProperty]
        public NewPlayerRegister? NewPlayerRegister { get; set; }

        public List<Country> Names { get; set; } = Enum.GetValues(typeof(Country))
                                       .OfType<Country>()
                                       .ToList();

        public IList<Player>? PlayersTable { get; set; } = default!;
        public CreateModel(ServerContext context)
        {
            _context = context;
            PlayersTable = _context.Player.ToList();
        }

        public IActionResult OnGet()
        {
            if (_context.Player != null)
            {
                PlayersTable = _context.Player.ToList();
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid || _context.Player == null || NewPlayerRegister == null)
            {
                return Page();
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var entry = _context.Add(new Player());
            entry.CurrentValues.SetValues(NewPlayerRegister);
            await _context.SaveChangesAsync();
            return RedirectToPage("/Details", new { id = NewPlayerRegister.Id });
        }
    }
}


