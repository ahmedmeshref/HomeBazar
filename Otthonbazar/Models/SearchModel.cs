using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Otthonbazar.Models
{
    public class SearchModel
    {
        public int CityId { get; set; }
        [Display(Name = "City Name")]
        public string CityName { get; set; }
        [Display(Name = "Max Price")]
        public Nullable<decimal> PriceMax { get; set; }
        [Display(Name = "Min Price")]
        public Nullable<decimal> PriceMin { get; set; }
        [Display(Name = "Max Rooms")]
        public Nullable<int> RoomMax { get; set; }
        [Display(Name = "Min Rooms")]
        public Nullable<int> RoomMin { get; set; }
        [Display(Name = "Max Size")]
        public Nullable<int> SizeMax { get; set; }
        [Display(Name = "Min Size")]
        public Nullable<int> SizeMin { get; set; }
    }
}
