using CommonHelper;
using Microsoft.AspNetCore.Authorization;

namespace Web_QLHoSo_So.Api.PolicyBaseAuthProvider
{
    public sealed class HasPermisionAttribute:AuthorizeAttribute
    {
        public HasPermisionAttribute(string permission):base(policy:Convert.ToString(permission))
        {

        }
    }
}
