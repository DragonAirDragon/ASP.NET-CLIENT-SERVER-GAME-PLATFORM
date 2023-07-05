using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication10.Data;
using WebApplication10.Models;

namespace WebApplication10.Pages.Presets
{
    public class EditModel : PageModel
    {
        private readonly WebApplication10.Data.Game _context;

        public EditModel(WebApplication10.Data.Game context)
        {
            _context = context;
        }

        [BindProperty]
        public Preset Preset { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Presets == null)
            {
                return NotFound();
            }

            var preset =  await _context.Presets.FirstOrDefaultAsync(m => m.PresetID == id);
            if (preset == null)
            {
                return NotFound();
            }
            Preset = preset;
           ViewData["HealthplayerID"] = new SelectList(_context.Set<Healthplayer>(), "ID", "ID");
           ViewData["SpeedplayerID"] = new SelectList(_context.Set<Speedplayer>(), "SpeedplayerID", "SpeedplayerID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Preset).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PresetExists(Preset.PresetID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PresetExists(int id)
        {
          return _context.Presets.Any(e => e.PresetID == id);
        }
    }
}
