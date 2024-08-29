using Microsoft.EntityFrameworkCore;
using FilmGalary.Core.Entity;
using FilmGalary.Core.Data;
using FilmGalary.Core.Service;

namespace FilmGallaryAPI
{
    public class DataContext : DbContext    
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {

        }

        public DbSet<Film2> Films { get; set; }

    }
}
