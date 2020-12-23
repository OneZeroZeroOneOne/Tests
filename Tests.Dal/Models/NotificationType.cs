using System;
using System.Collections.Generic;

#nullable disable

namespace Tests.Dal.Models
{
    public partial class NotificationType
    {
        public NotificationType()
        {
            Notifications = new HashSet<Notification>();
            UserNotificationSettings = new HashSet<UserNotificationSetting>();
        }

        public int NotificationTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<UserNotificationSetting> UserNotificationSettings { get; set; }
    }
}
