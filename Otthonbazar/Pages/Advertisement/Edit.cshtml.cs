using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Otthonbazar.Data;

namespace Otthonbazar.Pages.Advertisement
{
    public class EditModel : PageModel
    {
        private readonly Otthonbazar.Data.ApplicationDbContext _context;

        public EditModel(Otthonbazar.Data.ApplicationDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Advertisement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdvertisementExists(Advertisement.Id))
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

        private bool AdvertisementExists(int id)
        {
            return _context.Advertisement.Any(e => e.Id == id);
        }
    }
}
