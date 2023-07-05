using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication10.Data;
using WebApplication10.Models;

namespace WebApplication10.Pages.Presets
{
    public class DetailsModel : PageModel
    {
        private readonly WebApplication10.Data.Game _context;

        public DetailsModel(WebApplication10.Data.Game context)
        {
            _context = context;
        }

      public Preset Preset { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Presets == null)
            {
                return NotFound();
            }

            var preset = await _context.Presets.FirstOrDefaultAsync(m => m.PresetID == id);
            if (preset == null)
            {
                return NotFound();
            }
            else 
            {
                Preset = preset;
            }
            return Page();
        }
    }
}
