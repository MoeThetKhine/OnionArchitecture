namespace OnionArchitecture.Domain.Features.Blog;

#region IBlogRepository

public interface IBlogRepository
{
	Task<Result<BlogListModelV1>> GetBlogsAsync(int pageNo, int pageSize, CancellationToken cancellationToken);
	Task<Result<BlogModel>> GetBlogByIdAsync(int id, CancellationToken cancellationToken);

	Task<Result<BlogModel>> CreateBlogAsync(BlogRequestModel blogRequest, CancellationToken cancellationToken);
	Task<Result<BlogModel>> UpdateBlogAsync(BlogRequestModel blogRequest, int id, CancellationToken cancellationToken);
	Task<Result<BlogModel>> PatchBlogAsync(BlogRequestModel blogRequest, int id, CancellationToken cancellationToken);
	Task<Result<BlogModel>> DeleteBlogAsync(int id, CancellationToken cancellationToken);
}

#endregion