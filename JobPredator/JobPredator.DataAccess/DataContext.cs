

using JobPredator.Models;
using Microsoft.EntityFrameworkCore;

namespace JobPredator.DataAccess
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<Company> Companies { get; set; }


       





    }






}
