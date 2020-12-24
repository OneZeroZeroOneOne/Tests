using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tests.Bll.Services.NotificationSenderTarget;
using Tests.Dal.Contexts;
using Tests.Dal.Enums;

namespace Tests.Bll.Services
{
    public class NotificationSenderService
    {
        private readonly MainContext _mainContext;
        private readonly IServiceProvider _serviceProvider;
        private readonly Dictionary<int, Type> _senders;

        public NotificationSenderService(MainContext mainContext, IServiceProvider serviceProvider)
        {
            _mainContext = mainContext;
            _serviceProvider = serviceProvider;
            _senders = new Dictionary<int, Type>
            {
                {(int)NotificationTargetTypeEnum.Web, typeof(NotificationWebTarget)},
            };
        }

        public async Task CreateSystemNotification(int userId, string content, NotificationTypeEnum notificationType)
        { 
            await CreateNotificationForUser(userId, content, notificationType, 0);
        }

        public async Task CreateNotificationForUser(int userId, string content, NotificationTypeEnum notificationType, int fromUserId)
        {
            var settings = await
                _mainContext.UserNotificationSetting.Where(
                    x => x.UserId == userId && x.NotificationTypeId == (int)notificationType).ToListAsync();

            foreach (var typeId in settings.Select(x => x.NotificationTypeId))
            {
                if (_senders.TryGetValue(typeId, out var senderType))
                {
                    var sender = (INotificationTarget) ActivatorUtilities.CreateInstance(_serviceProvider, senderType);
                    await sender.SendNotification(userId, content, notificationType, fromUserId);
                }
                else throw new Exception($"Can't find sender for {typeId}");
            }
        }
    }
}
