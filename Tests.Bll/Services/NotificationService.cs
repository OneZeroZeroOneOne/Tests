using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tests.Dal.Contexts;
using Tests.Dal.Enums;
using Tests.Dal.Models;

namespace Tests.Bll.Services
{
    public class NotificationService
    {
        private readonly MainContext _mainContext;

        public NotificationService(MainContext mainContext)
        {
            _mainContext = mainContext;
        }

        public async Task AddDefaultNotificationSetting(int userId)
        {
            await _mainContext.UserNotificationSetting.AddRangeAsync(new List<UserNotificationSetting>()
            {
                new UserNotificationSetting
                {
                    NotificationTargetTypeId = (int) NotificationTargetTypeEnum.Email,
                    IsEnabled = true,
                    NotificationTypeId = (int) NotificationTypeEnum.OrderStatusChange,
                    UserId = userId,
                },
                new UserNotificationSetting
                {
                    NotificationTargetTypeId = (int) NotificationTargetTypeEnum.Email,
                    IsEnabled = true,
                    NotificationTypeId = (int) NotificationTypeEnum.UserEndTest,
                    UserId = userId,
                },
                new UserNotificationSetting
                {
                    NotificationTargetTypeId = (int) NotificationTargetTypeEnum.Email,
                    IsEnabled = true,
                    NotificationTypeId = (int) NotificationTypeEnum.UserStartTest,
                    UserId = userId,
                },
                new UserNotificationSetting
                {
                    NotificationTargetTypeId = (int) NotificationTargetTypeEnum.Web,
                    IsEnabled = true,
                    NotificationTypeId = (int) NotificationTypeEnum.OrderStatusChange,
                    UserId = userId,
                },
                new UserNotificationSetting
                {
                    NotificationTargetTypeId = (int) NotificationTargetTypeEnum.Web,
                    IsEnabled = true,
                    NotificationTypeId = (int) NotificationTypeEnum.UserEndTest,
                    UserId = userId,
                },
                new UserNotificationSetting
                {
                    NotificationTargetTypeId = (int) NotificationTargetTypeEnum.Web,
                    IsEnabled = true,
                    NotificationTypeId = (int) NotificationTypeEnum.UserStartTest,
                    UserId = userId,
                },
            });

            await _mainContext.SaveChangesAsync();
        }

        public async Task UpdateNotificationSettings(int userId, List<UserNotificationSetting> settings)
        {
            settings.ForEach(x => x.UserId = userId);

            _mainContext.UpdateRange(settings);
            await _mainContext.SaveChangesAsync();
        }

        public async Task<List<UserNotificationSetting>> GetUserNotificationSettings(int userId)
        {
            return await _mainContext.UserNotificationSetting.Include(x => x.NotificationType)
                .Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<List<Notification>> GetUserNotification(int userId, int targetTypeId, bool? isSeen)
        {
            var notificationQuery = _mainContext.Notification
                .Where(x => x.NotificationTargetTypeId == targetTypeId && x.UserId == userId);

            if (isSeen != null)
                notificationQuery = notificationQuery.Where(x => x.IsSeen == isSeen);

            return await notificationQuery.OrderByDescending(x => x.CreatedDateTime).ToListAsync();
        }

        public async Task<Notification> MarkAsSeen(int id, Guid notificationId)
        {
            var notification = await 
                _mainContext.Notification.FirstOrDefaultAsync(x =>
                    x.NotificationId == notificationId && x.UserId == id);

            if (notification != null)
                notification.IsSeen = true;

            await _mainContext.SaveChangesAsync();
            return notification;
        }
    }
}
