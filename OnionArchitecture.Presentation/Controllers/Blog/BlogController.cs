using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnionArchitecture.Application.Features.Blog.CreateBlog;
using OnionArchitecture.Application.Features.Blog.GetBlog;
using OnionArchitecture.DTOs.Features.Blog;

namespace OnionArchitecture.Presentation.Controllers.Blog;

[Route("api/[controller]")]
[ApiController]
public class BlogController : BaseController
{
	private readonly IMediator _mediator;

	public BlogController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[HttpGet]
	public async Task<IActionResult> GetBlogsAsync(int pageNo, int pageSize, CancellationToken cancellationToken)
	{
		var query = new GetBlogListQuery(pageNo, pageSize);
		var result = await _mediator.Send(query, cancellationToken);

		return Content(result);
	}

	[HttpPost]
	public async Task<IActionResult> CreateBlogAsync([FromBody] BlogRequestModel requestModel, CancellationToken cancellationToken)
	{
		var command = new CreateBlogCommand(requestModel); ;
		var result = await _mediator.Send(command, cancellationToken);

		return Content(result);
	}
}
