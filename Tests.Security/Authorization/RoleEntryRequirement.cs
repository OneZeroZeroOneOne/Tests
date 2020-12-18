using Microsoft.AspNetCore.Authorization;

namespace Tests.Security.Authorization
{
    public class RoleEntryRequirement : IAuthorizationRequirement
    {
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        public int RoleId { get; }

        public RoleEntryRequirement(int roleId)
        {
            RoleId = roleId;
        }
    }
}
