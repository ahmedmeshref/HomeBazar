using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Otthonbazar.Data;

namespace Otthonbazar.Pages.Advertisement
{
    public class CreateModel : PageModel
    {
        private readonly Otthonbazar.Data.ApplicationDbContext _context;

        public CreateModel(Otthonbazar.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }
        public ActionResult OnGetZip(int zip) => new JsonResult(_context.City.FirstOrDefault(c => c.Zip == zip.ToString()));

        [BindProperty]
        public Otthonbazar.Data.Advertisement Advertisement { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Advertisement.Add(Advertisement);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
