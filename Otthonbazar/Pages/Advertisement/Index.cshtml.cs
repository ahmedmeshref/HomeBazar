using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Otthonbazar.Data;
using Otthonbazar.Models;

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

        /*
        public async Task OnGetAsync()
        {
            Advertisement = await _context.Advertisement.ToListAsync();
        }*/

        public async Task OnGetAsync()
        {

            IQueryable<Otthonbazar.Data.Advertisement> advertisements = _context.Advertisement;

            if (Search.PriceMin != null)
                advertisements = advertisements.Where(a => a.Price >= Search.PriceMin.Value);
            if (Search.PriceMax != null)
                advertisements = advertisements.Where(a => a.Price <= Search.PriceMax.Value);
            if (Search.RoomMin != null)
                advertisements = advertisements.Where(a => a.Room >= Search.RoomMin.Value);
            if (Search.RoomMax != null)
                advertisements = advertisements.Where(a => a.Room <= Search.RoomMax.Value);
            if (Search.SizeMax != null)
                advertisements = advertisements.Where(a => a.Price <= Search.SizeMax.Value);
            if (Search.SizeMin != null)
                advertisements = advertisements.Where(a => a.Price >= Search.SizeMin.Value);
            Advertisement = await advertisements.ToListAsync();
        }


        [BindProperty(SupportsGet = true)]
        public SearchModel Search { get; set; }
    }
}
