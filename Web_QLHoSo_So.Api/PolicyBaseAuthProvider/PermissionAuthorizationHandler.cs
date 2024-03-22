using CommonHelper;
using Microsoft.AspNetCore.Authorization;

namespace Web_QLHoSo_So.Api.PolicyBaseAuthProvider
{
    public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            var permision=context.User.Claims.Where(x=>x.Type== ClaimsConstant.PERMISSION).Select(x=>x.Value).ToList();
            if(permision.Contains(requirement.Permission))
            {
                context.Succeed(requirement);
            }    
            return Task.CompletedTask;
        }
    }
}
