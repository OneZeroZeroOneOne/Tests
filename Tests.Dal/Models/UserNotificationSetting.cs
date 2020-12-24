using System;
using System.Collections.Generic;

#nullable disable

namespace Tests.Dal.Models
{
    public partial class UserNotificationSetting
    {
        public int UserId { get; set; }
        public int NotificationTargetTypeId { get; set; }
        public int NotificationTypeId { get; set; }
        public bool IsEnabled { get; set; }

        public virtual NotificationTargetType NotificationTargetType { get; set; }
        public virtual NotificationType NotificationType { get; set; }
        public virtual User User { get; set; }
    }
}
