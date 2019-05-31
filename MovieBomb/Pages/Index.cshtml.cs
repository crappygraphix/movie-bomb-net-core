using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MovieBomb.Data;
using MovieBomb.Models;

namespace MovieBomb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly MovieBomb.Data.MovieBombContext _context;

        public IndexModel(MovieBomb.Data.MovieBombContext context)
        {
            _context = context;
        }

        public IList<MovieBomb.Models.Game> Game { get;set; }
        public async Task OnGetAsync()
        {
            Game = await _context.Game.ToListAsync();
        }

        [BindProperty]
        public String GameCode { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            return RedirectToPage("./Index");
        }
    }
}
