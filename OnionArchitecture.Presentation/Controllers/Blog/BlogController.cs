using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnionArchitecture.Application.Features.Blog.CreateBlog;
using OnionArchitecture.Application.Features.Blog.DeleteBlog;
using OnionArchitecture.Application.Features.Blog.GetBlog;
using OnionArchitecture.Application.Features.Blog.UpdateBlog;
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

	#region GetBlogsAsync

	[HttpGet]
	public async Task<IActionResult> GetBlogsAsync(int pageNo, int pageSize, CancellationToken cancellationToken)
	{
		var query = new GetBlogListQuery(pageNo, pageSize);
		var result = await _mediator.Send(query, cancellationToken);

		return Content(result);
	}

	#endregion

	#region CreateBlogAsync

	[HttpPost]
	public async Task<IActionResult> CreateBlogAsync([FromBody] BlogRequestModel requestModel, CancellationToken cancellationToken)
	{
		var command = new CreateBlogCommand(requestModel); ;
		var result = await _mediator.Send(command, cancellationToken);

		return Content(result);
	}

	#endregion

	#region UpdateBlogAsync

	[HttpPut("{id}")]
	public async Task<IActionResult> UpdateBlogAsync([FromBody] BlogRequestModel requestModel, int id, CancellationToken cancellationToken)
	{
		var command = new UpdateBlogCommand(requestModel, id);
		var result = await _mediator.Send(command, cancellationToken);

		return Content(result);
	}

	#endregion

	#region DeleteBlogAsync

	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteBlog(int id, CancellationToken cancellationToken)
	{
		var command = new DeleteBlogCommand(id);
		var result = await _mediator.Send(command, cancellationToken);
		return Content(result);
	}

	#endregion
}
