using System.Security.Principal;

namespace Tests.Security.Authorization
{
    public class AuthorizedUserModel : IIdentity
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string? AuthenticationType { get; }
        public bool IsAuthenticated { get; }
        public string? Name { get; }
    }
}
