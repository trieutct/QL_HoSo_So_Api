using CommonHelper;
using Microsoft.AspNetCore.Authorization;

namespace Web_QLHoSo_So.Api.PolicyBaseAuthProvider
{
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public PermissionRequirement(string permission)
        {
            Permission = permission;
        }
        public string Permission { get; }
    }
}
