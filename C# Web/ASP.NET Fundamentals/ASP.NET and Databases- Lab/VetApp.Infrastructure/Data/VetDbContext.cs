using Microsoft.EntityFrameworkCore;
using VetApp.Infrastructure.Models;

namespace VetApp.Infrastructure.Data
{
	public class VetDbContext : DbContext
	{
        public VetDbContext(DbContextOptions<VetDbContext> options)
            : base(options)
        {
                
        }

        public DbSet<Dog> Dogs { get; set; }
		public DbSet<Cat> Cats { get; set; }
		public DbSet<Owner> Owners { get; set; }
	}
}
