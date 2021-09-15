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
    public class IndexModel : PageModel
    {
        private readonly Otthonbazar.Data.ApplicationDbContext _context;

        public IndexModel(Otthonbazar.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Otthonbazar.Data.Advertisement> Advertisement { get;set; }

        public async Task OnGetAsync()
        {
            Advertisement = await _context.Advertisement.ToListAsync();
        }
    }
}
