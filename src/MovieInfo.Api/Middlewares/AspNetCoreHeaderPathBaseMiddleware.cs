using Microsoft.AspNetCore.Http;

namespace MovieInfo.Api.Middlewares;

internal sealed class AspNetCoreHeaderPathBaseMiddleware
{
    private readonly RequestDelegate _next;

    public AspNetCoreHeaderPathBaseMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Headers.ContainsKey("ASPNETCORE-PATH-BASE"))
        {
            context.Request.PathBase = new PathString(context.Request.Headers["ASPNETCORE-PATH-BASE"].First());
        }

        await _next(context);
    }
}
