using System;
using System.Collections.Generic;

#nullable disable

namespace Tests.Dal.Models
{
    public partial class NotificationTargetType
    {
        public NotificationTargetType()
        {
            Notifications = new HashSet<Notification>();
            UserNotificationSettings = new HashSet<UserNotificationSetting>();
        }

        public int NotificationTargetTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<UserNotificationSetting> UserNotificationSettings { get; set; }
    }
}
