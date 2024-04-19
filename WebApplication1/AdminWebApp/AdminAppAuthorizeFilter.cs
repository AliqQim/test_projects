using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace aliksoft.AdminWebApp;

public class AdminAppAuthorizeFilter : AuthorizeFilter
{
    public AdminAppAuthorizeFilter() : base(
        new AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser()
            .RequireRole(Roles.Admin)
            .Build())
    {
    }

    public override async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        var path = context.HttpContext.Request.Path;
        if (path.StartsWithSegments(new PathString("/Identity"), StringComparison.OrdinalIgnoreCase))
        {
            return;
        }

        await base.OnAuthorizationAsync(context);
    }
}