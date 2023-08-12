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
using IdoShamir_EyalCohen_Connect4.UI;

namespace IdoShamir_EyalCohen_Connect4.Pages.Queries
{
    public class Q8Model : PageModel
    {
        private readonly ServerContext _context;

        public Q8Model(ServerContext context)
        {
            _context = context;
        }

        public int MaxCountries = Enum.GetValues(typeof(Country)).Length;
        [BindProperty]
        public IList<string> CountryNames { get; set; } = Enum.GetNames(typeof(Country)).ToList();
        public IList<Player>[] PlayersByCountry { get; set; } = new List<Player>[1];

        public async Task OnGetAsync()
        {
            if (_context.Player != null)
            {
                PlayersByCountry = new List<Player>[MaxCountries];

                for (int i = 0; i < PlayersByCountry.Length; i++)
                {
                    PlayersByCountry[i] = await _context.Player.Where(p => p.CountrySelection == Enum.GetName((Country)i)).ToListAsync();
                    if (PlayersByCountry[i].Count == 0)
                        PlayersByCountry[i] = new List<Player>();
                }
            }
            else
            {
                await Response.WriteAsync("No Players Found or db missing");
            }

        }
    }
}
