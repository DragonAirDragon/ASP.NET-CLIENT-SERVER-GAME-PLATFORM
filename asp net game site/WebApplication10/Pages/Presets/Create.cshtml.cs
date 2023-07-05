using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication10.Data;
using WebApplication10.Models;

namespace WebApplication10.Pages.Presets
{
    public class CreateModel : PageModel
    {
        private readonly WebApplication10.Data.Game _context;

        public CreateModel(WebApplication10.Data.Game context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["HealthplayerID"] = new SelectList(_context.Set<Healthplayer>(), "ID", "ID");
        ViewData["SpeedplayerID"] = new SelectList(_context.Set<Speedplayer>(), "SpeedplayerID", "SpeedplayerID");
            return Page();
        }

        [BindProperty]
        public Preset Preset { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Presets.Add(Preset);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
