using OnionArchitecture.DbService.AppDbContextModels;

namespace OnionArchitecture.Infrastructure.Features.Blog;

public class BlogRepository : IBlogRepository
{
	private readonly AppDbContext _appDbContext;

	public BlogRepository(AppDbContext appDbContext)
	{
		_appDbContext = appDbContext;
	}
}
