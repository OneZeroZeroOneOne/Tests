using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tests.Dal.Contexts;
using Tests.Dal.Enums;
using Tests.Dal.Models;
using Tests.Dal.Out;

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

        public IQueryable<OutNotificationViewModel> GetUserNotification(int userId, int targetTypeId, bool? isSeen)
        {
            var notificationQuery = (
                from notification in _mainContext.Notification
                join user in _mainContext.Employee on notification.FromUserId equals user.Id into un
                from subUser in un.DefaultIfEmpty()
                join avatar in _mainContext.Avatar on subUser.AvatarId equals avatar.Id into au
                from subAvatar in au.DefaultIfEmpty()
                where notification.NotificationTargetTypeId == targetTypeId && notification.UserId == userId
                select new
                {
                    Notification = notification,
                    FromUser = subUser,
                    Avatar = subAvatar,
                });

            if (isSeen != null)
                notificationQuery = notificationQuery.Where(x => x.Notification.IsSeen == isSeen);

            return notificationQuery.OrderByDescending(x => x.Notification.CreatedDateTime)
                .Select(x => new OutNotificationViewModel
                {
                    ArchivedDateTime = x.Notification.ArchivedDateTime,
                    CreatedDateTime = x.Notification.CreatedDateTime,
                    FromUser = x.FromUser != null ? new OutEmployeeViewModel
                    {
                        FirstName = x.FromUser.FirstName,
                        MiddleName = x.FromUser.MiddleName,
                        SurName = x.FromUser.SurName,
                        Avatar = x.Avatar != null ? new OutAvatarViewModel
                        {
                            Id = x.Avatar.Id,
                            Name = x.Avatar.Name,
                            Path = x.Avatar.Path
                        } : null,
                        Email = x.FromUser.Email,
                        DateOfBirth = x.FromUser.DateOfBirth,
                        IsCandidate = x.FromUser.IsCandidate,
                        
                    } : null,
                    IsSeen = x.Notification.IsSeen,
                    ModifiedDateTime = x.Notification.ModifiedDateTime,
                    NotificationContent = x.Notification.NotificationContent,
                    NotificationTargetTypeId = x.Notification.NotificationTargetTypeId,
                    NotificationId = x.Notification.NotificationId,
                    NotificationTypeId = x.Notification.NotificationTypeId,
                    SeenDateTime = x.Notification.SeenDateTime,
                    UserId = x.Notification.UserId,
                });
        }

        public async Task<OutNotificationViewModel> MarkAsSeen(int id, Guid notificationId)
        {
            var notification = await 
                _mainContext.Notification.FirstOrDefaultAsync(x =>
                    x.NotificationId == notificationId && x.UserId == id);

            if (notification != null)
                notification.IsSeen = true;

            await _mainContext.SaveChangesAsync();
            return await GetUserNotification(id, notification.NotificationTargetTypeId, null).FirstOrDefaultAsync(x => x.NotificationId == notificationId);
        }
    }
}
