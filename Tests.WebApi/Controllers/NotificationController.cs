using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tests.Bll.Services;
using Tests.Dal.Enums;
using Tests.Dal.Out;
using Tests.Security.Authorization;

namespace Tests.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly NotificationService _notificationService;
        private readonly IMapper _mapper;

        public NotificationController(NotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }


        [HttpGet("Settings")]
        [Authorize(Policy = "ClientAdmin")]
        public async Task<OutNotificationSettingAllViewModel> GetUserNotificationSettings()
        {
            AuthorizedUserModel authorizedUserModel = (AuthorizedUserModel)HttpContext.User.Identity;
            var settings = await _notificationService.GetUserNotificationSettings(authorizedUserModel.Id);

            return new OutNotificationSettingAllViewModel
            {
                Email = settings.Where(x => x.NotificationTargetTypeId == (int)NotificationTargetTypeEnum.Email).Select(x => new OutNotificationSettingViewModel
                {
                    IsEnabled = x.IsEnabled,
                    TypeId = x.NotificationType.NotificationTypeId,
                    TypeName = x.NotificationType.Name,
                    TargetTypeId = (int)NotificationTargetTypeEnum.Email,
                    TargetTypeName = NotificationTargetTypeEnum.Email.ToString(),
                }).ToList(),
                Web = settings.Where(x => x.NotificationTargetTypeId == (int)NotificationTargetTypeEnum.Web).Select(x => new OutNotificationSettingViewModel
                {
                    IsEnabled = x.IsEnabled,
                    TypeId = x.NotificationType.NotificationTypeId,
                    TypeName = x.NotificationType.Name,
                    TargetTypeId = (int)NotificationTargetTypeEnum.Web,
                    TargetTypeName = NotificationTargetTypeEnum.Web.ToString(),
                }).ToList(),
            };
        }

        [HttpGet("{targetTypeId}")]
        [Authorize(Policy = "ClientAdmin")]
        public async Task<List<OutNotificationViewModel>> GetUserNotifications([FromRoute]int targetTypeId, [FromQuery] bool? isSeen = null)
        {
            AuthorizedUserModel authorizedUserModel = (AuthorizedUserModel)HttpContext.User.Identity;
            var notifications = await _notificationService.GetUserNotification(authorizedUserModel.Id, targetTypeId, isSeen);

            return notifications.ToList();
        }

        [HttpPost("{notificationId}")]
        [Authorize(Policy = "ClientAdmin")]
        public async Task<OutNotificationViewModel> MarkAsSeen([FromRoute] Guid notificationId)
        {
            AuthorizedUserModel authorizedUserModel = (AuthorizedUserModel)HttpContext.User.Identity;
            var notification = await _notificationService.MarkAsSeen(authorizedUserModel.Id, notificationId);

            return _mapper.Map<OutNotificationViewModel>(notification);
        }
    }
}
