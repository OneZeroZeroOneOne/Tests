using System;
using System.Threading.Tasks;
using Tests.Dal.Contexts;
using Tests.Dal.Enums;
using Tests.Dal.Models;

namespace Tests.Bll.Services.NotificationSenderTarget
{
    public class NotificationWebTarget : INotificationTarget
    {
        private readonly MainContext _mainContext;

        public NotificationWebTarget(MainContext mainContext)
        {
            _mainContext = mainContext;
        }

        public async Task SendNotification(int userId, string content, NotificationTypeEnum notificationType, int fromUserId)
        {
            await _mainContext.Notification.AddAsync(new Notification
            {
                CreatedDateTime = DateTime.UtcNow,
                ArchivedDateTime = null,
                FromUserId = fromUserId,
                IsSeen = false,
                ModifiedDateTime = DateTime.UtcNow,
                NotificationContent = content,
                NotificationId = Guid.NewGuid(),
                NotificationTargetTypeId = (int) NotificationTargetTypeEnum.Web,
                NotificationTypeId = (int) notificationType,
                SeenDateTime = null,
                UserId = userId,
            });

            await _mainContext.SaveChangesAsync();
        }
    }
}
