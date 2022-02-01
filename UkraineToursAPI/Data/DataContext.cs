using Microsoft.EntityFrameworkCore;
using UkraineToursAPI.Models;

namespace UkraineToursAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<City> Cities { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Tour> Tours { get; set; }

        public DbSet<TourType> TourTypes { get; set; }

        public DbSet<SupportType> SupportTypes { get; set; }

    }
}