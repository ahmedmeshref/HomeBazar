using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Otthonbazar.Data.EntityTypeConfigurations;


namespace Otthonbazar.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<City> City { get; set; }
        public DbSet<Advertisement> Advertisement { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Add data 
            builder.ApplyConfiguration(new CitySeedConfig());
            builder.ApplyConfiguration(new AdvertisementSeedConfig());
        }
    }

    

    public enum AdvertisementType
    {
        Flat,
        House,
        HolidayHouse,
        BuildingPlot
    }

    public class Advertisement
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public AdvertisementType AdvertisementType { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        [Required]
        public int Size { get; set; }
        [Required]
        public int Room { get; set; }
        [Required]
        public int HalfRoom { get; set; }
        [Required]
        public int BuildDate { get; set; }
        [Required]
        public string Description { get; set; }
    }

    public class City
    {
        public int Id { get; set; }
        [Required, StringLength(4, MinimumLength = 4)]
        public string Zip { get; set; }
        [Required]
        public string Name { get; set; }
        
        [ForeignKey("CityId")]
        public ICollection<Advertisement> Advertisements { get; set; }
    }

}
