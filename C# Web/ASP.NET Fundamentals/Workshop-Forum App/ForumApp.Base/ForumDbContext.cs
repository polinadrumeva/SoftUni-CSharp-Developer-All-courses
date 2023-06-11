using ForumApp.Base.Configurations;
using ForumApp.Base.Models;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Base
{
	public class ForumDbContext : DbContext
	{
        public ForumDbContext(DbContextOptions<ForumDbContext> options)
            :base(options) 
        {
            
        }

        public DbSet<Post> Posts { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new PostEntityConfiguration());

			base.OnModelCreating(modelBuilder);
		}
	}
}