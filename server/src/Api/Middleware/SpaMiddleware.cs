using BGS.Api.Constants;
using Microsoft.Net.Http.Headers;

namespace BGS.Api.Middleware;

internal class SpaMiddleware
{
    private const string SpaDefaultPage = "/index.html";
    private const string AcceptHeaderName = "Accept";

    private readonly RequestDelegate _next;

    public SpaMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public Task Invoke(HttpContext context)
    {
        if (context.GetEndpoint() != null)
        {
            return _next(context);
        }


        if (IsHtmlPageRequest(context.Request) && !IsSwaggerRequest(context.Request))
        {
            context.Request.Path = SpaDefaultPage;
            context.Response.Headers.Add(HeaderNames.XFrameOptions, "DENY");
            context.Response.Headers.Add(HeaderNames.CacheControl, "max-age=0, no-cache, no-store, must-revalidate");
            context.Response.Headers.Add(HeaderNames.Pragma, "no-cache");
            context.Response.Headers.Add(HeaderNames.Expires, "Wed, 12 Jan 1980 05:00:00 GMT");
        }

        return _next(context);
    }

    private static bool IsHtmlPageRequest(HttpRequest request) =>
        request.Method == HttpMethods.Get &&
        request.Headers[AcceptHeaderName].Any(ContainHtmlMimeType);

    private static bool ContainHtmlMimeType(string header) =>
        header.Contains(MimeTypes.Html, StringComparison.InvariantCulture);

    private static bool IsSwaggerRequest(HttpRequest request) =>
        request.Path.StartsWithSegments("/swagger", StringComparison.InvariantCultureIgnoreCase);
}