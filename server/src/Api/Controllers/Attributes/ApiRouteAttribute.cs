using BGS.Api.Controllers.Constants;
using Microsoft.AspNetCore.Mvc;

namespace BGS.Api.Controllers.Attributes;

internal class ApiRouteAttribute : RouteAttribute
{
    public ApiRouteAttribute()
        : this("[controller]")
    {
    }

    public ApiRouteAttribute(string route)
        : base($"{Routes.Api}/{route}")
    {
    }
}