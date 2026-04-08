namespace OnionArchitecture.Application.Features.Blog.PatchBlog;

#region PatchBlogCommandHandler

public class PatchBlogCommandHandler : IRequestHandler<PatchBlogCommand, Result<BlogModel>>
{
	private readonly IBlogRepository repository;

	public PatchBlogCommandHandler(IBlogRepository repository)
	{
		this.repository = repository;
	}

	public async Task<Result<BlogModel>> Handle(PatchBlogCommand request, CancellationToken cancellationToken)
	{
		Result<BlogModel> result;

		if (request.BlogId <= 0)
		{
			result = Result<BlogModel>.Fail(MessageResource.InvalidId);
			goto result;
		}

		result = await _blogRepository.PatchBlogAsync(request.BlogRequestModel, request.BlogId, cancellationToken);

	result:
		return result;
	}

}

#endregion
