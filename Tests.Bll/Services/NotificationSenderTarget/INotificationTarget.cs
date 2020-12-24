using System.Threading.Tasks;
using Tests.Dal.Enums;

namespace Tests.Bll.Services.NotificationSenderTarget
{
    public interface INotificationTarget
    {
        Task SendNotification(int userId, string content, NotificationTypeEnum notificationType, int fromUserId);
    }
}
