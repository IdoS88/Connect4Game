using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Server.Data;
using Server.Models;
using Server.Models.Games;
using Server.Models.Queries_Models;

namespace Server.Pages.Queries
{
    public class QueriesModel : PageModel
    {
        private readonly Server.Data.ServerContext _context;
        public int QueryId { get; set; }
        public string QueryName { get; set; } = string.Empty;
        public QueriesModel(Server.Data.ServerContext context)
        {
            _context = context;
        }
        public IList<Player> QueryPlayerList { get; set; } = new List<Player>();
        public IList<Q2> QueryQ2List { get; set; } = new List<Q2>();

        //public IList<Q3> QueryQ3List { get; set; } = new List<Q3>();
        //public IList<Q4> QueryQ4List { get; set; } = new List<Q4>();

        public async Task OnGetAsync()
        {
            if (_context.Game == null || _context.Player == null)
            {
                string res = string.Join("No Data Found! ", "<br /><a href=\"/Index\">Back to Login Page</a>");

                await Response.WriteAsync("<p>" + res + "</p>");

            }
            Page();
        }
        public IActionResult OnPostQ1()
        {
            return RedirectToPage("./Q1");
        }

        public IActionResult OnPostQ2()
        {
            return RedirectToPage("./Q2");
            
        }

        public IActionResult OnPostQ3()
        {
            return RedirectToPage("./Q3");

        }

        public IActionResult OnPostQ4()
        {
            return RedirectToPage("./Q4");

        }

        public IActionResult OnPostQ5()
        {
            return RedirectToPage("./Q5");

        }

        public IActionResult OnPostQ6()
        {
            return RedirectToPage("./Q6");

        }

        public IActionResult OnPostQ7()
        {
            return RedirectToPage("./Q7");

        }
        public IActionResult OnPostQ8()
        {
            return RedirectToPage("./Q8");

        }
    }
}
