using System;

namespace Tests.Dal.Out
{
    public class OutNotificationViewModel
    {
        public int UserId { get; set; }
        public Guid NotificationId { get; set; }
        public string NotificationContent { get; set; }
        public int? NotificationTypeId { get; set; }
        public int? NotificationTargetTypeId { get; set; }
        public bool IsSeen { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public DateTime? ArchivedDateTime { get; set; }
        public DateTime? SeenDateTime { get; set; }

        public OutEmployeeViewModel FromUser { get; set; }
    }
}
