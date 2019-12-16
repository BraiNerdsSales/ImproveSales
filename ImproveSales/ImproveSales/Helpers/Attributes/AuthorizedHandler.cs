namespace ImproveSales.Helpers.Attributes
{
    using ImproveSales.Services.Policies;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using System.Threading.Tasks;

    public class AuthorizedHandler : AuthorizationHandler<AuthorizationRequirement>
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public AuthorizedHandler(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AuthorizationRequirement requirement)
        {
            if (!context.User.Identity.IsAuthenticated)
            {
                _contextAccessor.HttpContext.Response.Redirect(requirement.RedirectUrl);
                context.Succeed(requirement);

                return Task.CompletedTask;
            }

            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}
