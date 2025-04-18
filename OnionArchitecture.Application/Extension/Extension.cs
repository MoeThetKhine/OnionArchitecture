using Microsoft.Extensions.DependencyInjection;

namespace OnionArchitecture.Application.Extension;

#region Extension

public static class Extension
{
	public static IServiceCollection AddMediatRService(this IServiceCollection services)
	{
		return services.AddMediatR(cf =>
		cf.RegisterServicesFromAssembly(typeof(Extension).Assembly));
	}
}

#endregion