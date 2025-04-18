using Microsoft.EntityFrameworkCore;
using OnionArchitecture.Domain.Features.Blog;

namespace OnionArchitecture.Infrastructure.Features.Blog;

public class BlogDbContext : DbContext
{
	public BlogDbContext(DbContextOptions options) : base(options) { }

	public DbSet<Tbl_Blog> Tbl_Blogs { get; set; }

}
