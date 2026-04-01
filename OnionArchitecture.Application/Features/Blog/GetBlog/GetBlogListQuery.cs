using OnionArchitecture.DTOs.Features.Blog;
using OnionArchitecture.Utils;

namespace OnionArchitecture.Application.Features.Blog.GetBlog;

public class GetBlogListQuery : IRequest<Result<BlogListModelV1>>
{
	public int PageNo { get; set; }
	public int PageSize { get; set; }

	public GetBlogListQuery(int pageNo, int pageSize)
	{
		PageNo = pageNo;
		PageSize = pageSize;
	}
}
