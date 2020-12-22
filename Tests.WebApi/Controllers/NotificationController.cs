using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        public NotificationController(NotificationService notificationService)
        {
            _notificationService = notificationService;
        }


        [HttpGet]
        [Authorize(Policy = "ClientAdmin")]
        public async Task<OutNotificationViewModel> GetUserNotificationSettings()
        {
            AuthorizedUserModel authorizedUserModel = (AuthorizedUserModel)HttpContext.User.Identity;
            var settings = await _notificationService.GetUserNotificationSettings(authorizedUserModel.Id);

            return new OutNotificationViewModel
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
    }
}
