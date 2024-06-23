using agrisynth_backend.IAM.Infrastructure.Pipeline.Middleware.Components;

namespace agrisynth_backend.IAM.Infrastructure.Pipeline.Middleware.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseRequestAuthorization(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RequestAuthorizationMiddleware>();
    }
}