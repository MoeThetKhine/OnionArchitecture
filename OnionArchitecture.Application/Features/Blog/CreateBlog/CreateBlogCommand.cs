using MediatR;
using OnionArchitecture.DTOs.Features.Blog;
using OnionArchitecture.Utils;

namespace OnionArchitecture.Application.Features.Blog.CreateBlog;

public class CreateBlogCommand : IRequest<Result<BlogModel>>
{
	public BlogRequestModel requestModel;

	public CreateBlogCommand(BlogRequestModel requestModel)
	{
		this.requestModel = requestModel;
	}

}
