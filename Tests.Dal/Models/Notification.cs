using System;
using System.Collections.Generic;

#nullable disable

namespace Tests.Dal.Models
{
    public partial class Notification
    {
        public int UserId { get; set; }
        public Guid NotificationId { get; set; }
        public string NotificationContent { get; set; }
        public int? NotificationTypeId { get; set; }
        public int NotificationTargetTypeId { get; set; }
        public bool IsSeen { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public DateTime? ArchivedDateTime { get; set; }
        public DateTime? SeenDateTime { get; set; }
        public int? FromUserId { get; set; }

        public virtual NotificationTargetType NotificationTargetType { get; set; }
        public virtual NotificationType NotificationType { get; set; }
        public virtual User User { get; set; }
    }
}
