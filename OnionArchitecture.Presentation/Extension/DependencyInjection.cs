using Microsoft.EntityFrameworkCore;
using OnionArchitecture.Domain.Features.Blog;
using OnionArchitecture.Infrastructure.Features.Blog;

namespace OnionArchitecture.Presentation.Extension;

public static class DependencyInjection
{

	private static IServiceCollection AddDbContextService(this IServiceCollection services, WebApplicationBuilder builder)
	{
		builder.Services.AddDbContext<BlogDbContext>(
			opt =>
			{
				opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
				opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
			},
			ServiceLifetime.Transient,
			ServiceLifetime.Transient
		);

		return services;
	}

	private static IServiceCollection AddRepositoryService(this IServiceCollection services)
	{
		return services.AddScoped<IBlogRepository, BlogRepository>();
	}


}
