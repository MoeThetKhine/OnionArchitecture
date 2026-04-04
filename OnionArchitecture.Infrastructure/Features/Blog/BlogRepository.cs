namespace OnionArchitecture.Infrastructure.Features.Blog;

public class BlogRepository : IBlogRepository
{
	private readonly AppDbContext _appDbContext;

	public BlogRepository(AppDbContext appDbContext)
	{
		_appDbContext = appDbContext;
	}

	#region GetBlogsAsync

	public async Task<Result<BlogListModelV1>> GetBlogsAsync(int pageNo, int pageSize, CancellationToken cancellationToken)
	{
		Result<BlogListModelV1> result;

		try
		{
			var query = _appDbContext.TblBlogs.OrderByDescending(x => x.BlogId);
			var lst = await query
				.Paginate(pageNo, pageSize)
				.ToListAsync(cancellationToken: cancellationToken);
			var totalCount = await query.CountAsync(cancellationToken: cancellationToken);
			var pageCount = totalCount / pageSize;
			if (totalCount % pageSize > 0)
			{
				pageCount++;
			}

			var pageSettingModel = new PageSettingModel(pageNo, pageSize, pageCount, totalCount);
			var model = new BlogListModelV1()
			{
				DataLst = lst.Select(x => new BlogModel()
				{
					BlogId = x.BlogId,
					BlogTitle = x.BlogTitle,
					BlogAuthor = x.BlogAuthor,
					BlogContent = x.BlogContent
				})
					.AsQueryable(),
				PageSetting = pageSettingModel
			};

			result = Result<BlogListModelV1>.Success(model);
		}

		catch (Exception ex)
		{
			result = Result<BlogListModelV1>.Failure(ex);
		}
		return result;
	}

	#endregion

	#region CreateBlogAsync

	public async Task<Result<BlogModel>> CreateBlogAsync(BlogRequestModel blogRequest, CancellationToken cancellationToken)
	{
		Result<BlogModel> result;

		try
		{
			await _appDbContext.TblBlogs.AddAsync(blogRequest.ToEntity(), cancellationToken);
			await _appDbContext.SaveChangesAsync(cancellationToken);

			result = Result<BlogModel>.SaveSuccess();
		}

		catch (Exception ex)
		{
			result = Result<BlogModel>.Failure(ex);
		}

		return result;
	}

	#endregion

	#region UpdateBlogAsync

	public async Task<Result<BlogModel>> UpdateBlogAsync(BlogRequestModel blogRequest, int id, CancellationToken cancellationToken)
	{
		Result<BlogModel> result;

		try
		{
			var blog = await _appDbContext.TblBlogs.FindAsync([id, cancellationToken], cancellationToken: cancellationToken);

			if (blog is null)
			{
				result = Result<BlogModel>.NotFound();
				goto result;
			}
			blog.BlogTitle = blogRequest.BlogTitle;
			blog.BlogAuthor = blogRequest.BlogAuthor;
			blog.BlogContent = blogRequest.BlogContent;

			_appDbContext.TblBlogs.Update(blog);
			await _appDbContext.SaveChangesAsync(cancellationToken);

			result = Result<BlogModel>.UpdateSuccess();
		}

		catch (Exception ex)
		{
			result = Result<BlogModel>.Failure(ex);
		}

	result:
		return result;
	}

	#endregion

	public async Task<Result<BlogModel>> DeleteBlogAsync(int id, CancellationToken cancellationToken)
	{
		Result<BlogModel> result;

		try
		{
			var blog = await _appDbContext.TblBlogs.FindAsync([id, cancellationToken], cancellationToken: cancellationToken);

			if (blog is null)
			{
				result = Result<BlogModel>.NotFound();
				goto result;
			}

			_appDbContext.TblBlogs.Remove(blog);
			await _appDbContext.SaveChangesAsync(cancellationToken);

			result = Result<BlogModel>.DeleteSuccess();
		}

		catch (Exception ex)
		{
			result = Result<BlogModel>.Failure(ex);
		}

	result:
		return result;
	}


}
