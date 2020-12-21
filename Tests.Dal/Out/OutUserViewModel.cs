namespace Tests.Dal.Out
{
    public class OutUserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Email { get; set; }
        public OutAvatarViewModel Avatar { get; set; }
    }
}
