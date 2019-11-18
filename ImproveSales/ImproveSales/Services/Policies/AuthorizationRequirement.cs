namespace ImproveSales.Services.Policies
{
    using Microsoft.AspNetCore.Authorization;

    public class AuthorizationRequirement : IAuthorizationRequirement
    {
        public AuthorizationRequirement(string redirectUrl)
        {
            RedirectUrl = redirectUrl;
        }

        public string RedirectUrl { get; }
    }
}
