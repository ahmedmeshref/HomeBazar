using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Otthonbazar.Data;

namespace Otthonbazar.Pages.Advertisement
{
    public class DeleteModel : PageModel
    {
        private readonly Otthonbazar.Data.ApplicationDbContext _context;

        public DeleteModel(Otthonbazar.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Otthonbazar.Data.Advertisement Advertisement { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Advertisement = await _context.Advertisement.FirstOrDefaultAsync(m => m.Id == id);

            if (Advertisement == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Advertisement = await _context.Advertisement.FindAsync(id);

            if (Advertisement != null)
            {
                _context.Advertisement.Remove(Advertisement);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
