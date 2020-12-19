using System;
using System.Collections.Generic;

#nullable disable

namespace Tests.Dal.Models
{
    public partial class AvatarUser
    {
        public int AvatarId { get; set; }
        public int UserId { get; set; }

        public virtual Avatar Avatar { get; set; }
        public virtual User User { get; set; }
    }
}
