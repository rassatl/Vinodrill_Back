using Microsoft.AspNetCore.Authorization;

namespace Vinodrill_Back.Models.Auth
{
    public class Policies
    {
        public const string Admin = "Admin";
        public const string Client = "Client";
        public static AuthorizationPolicy AdminPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(Admin).Build();
        }
        public static AuthorizationPolicy UserPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(Client).Build();
        }
    }
}
