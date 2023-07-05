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
    public class IndexModel : PageModel
    {
        private readonly WebApplication10.Data.Game _context;

        public IndexModel(WebApplication10.Data.Game context)
        {
            _context = context;
        }

        public IList<Preset> Preset { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Presets != null)
            {
                Preset = await _context.Presets
                .Include(p => p.Healthplayer)
                .Include(p => p.Speedplayer).ToListAsync();
            }
        }
    }
}
