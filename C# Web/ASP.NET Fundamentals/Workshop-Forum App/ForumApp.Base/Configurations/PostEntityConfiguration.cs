using ForumApp.Base.Models;
using ForumApp.Base.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApp.Base.Configurations
{
	public class PostEntityConfiguration : IEntityTypeConfiguration<Post>
	{
		private readonly PostSeeder postSeeder;

        public PostEntityConfiguration()
        {
			this.postSeeder = new PostSeeder();
        }
        public void Configure(EntityTypeBuilder<Post> builder)
		{
			builder.HasData(this.postSeeder.GeneratePost());
		}
	}
}
