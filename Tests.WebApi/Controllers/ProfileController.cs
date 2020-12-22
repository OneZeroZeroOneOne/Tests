using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tests.Bll.Services;
using Tests.Dal.Contexts;
using Tests.Dal.In;
using Tests.Dal.Models;
using Tests.Dal.Out;
using Tests.Security.Authorization;
using Tests.Utilities.Exceptions;
using Tests.Utilities.Validation;

namespace Tests.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly MainContext _context;
        private readonly IMapper _mapper;
        private readonly NotificationService _notificationService;

        public ProfileController(MainContext context, IMapper mapper, NotificationService notificationService)
        {
            _context = context;
            _mapper = mapper;
            _notificationService = notificationService;
        }

        [HttpPatch("Name")]
        [Authorize(Policy = "ClientAdmin")]
        public async Task<OutUserViewModel> UpdateCompanyName([FromBody]InUpdateCompanyNameViewModel updateCompanyName)
        {
            AuthorizedUserModel authorizedUserModel = (AuthorizedUserModel)HttpContext.User.Identity;

            if (string.IsNullOrEmpty(updateCompanyName.Name))
                throw ExceptionFactory.SoftException(ExceptionEnum.CompanyNameCantBeEmpty, "Company name can't be empty");

            var user = await _context.User.Include(x => x.Role).Include(x => x.UserSecurity).Include(x => x.Avatar)
                .FirstOrDefaultAsync(x => x.Id == authorizedUserModel.Id);

            user.Name = updateCompanyName.Name;

            await _context.SaveChangesAsync();

            return new OutUserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                RoleId = user.RoleId,
                Avatar = user.Avatar != null ? new OutAvatarViewModel
                {
                    Id = user.Avatar.Id,
                    Name = user.Avatar.Name,
                    Path = user.Avatar.Path
                } : null,
                Email = user.UserSecurity.Email,
                RoleName = user.Role.Title,
            };
        }

        [HttpPatch("Email")]
        [Authorize(Policy = "ClientAdmin")]
        public async Task<OutUserViewModel> UpdateEmail([FromBody] InUpdateEmailViewModel updateEmail)
        {
            AuthorizedUserModel authorizedUserModel = (AuthorizedUserModel)HttpContext.User.Identity;

            if (string.IsNullOrEmpty(updateEmail.Email))
                throw ExceptionFactory.SoftException(ExceptionEnum.EmailCantBeEmpty, "Email can't be empty");

            if (!EmailValidator.IsValidEmail(updateEmail.Email))
                throw ExceptionFactory.SoftException(ExceptionEnum.EmailCantBeEmpty, "Email not valid");

            var user = await _context.User.Include(x => x.Role).Include(x => x.UserSecurity).Include(x => x.Avatar)
                .FirstOrDefaultAsync(x => x.Id == authorizedUserModel.Id);

            user.UserSecurity.Email = updateEmail.Email;
            user.UserSecurity.Login = updateEmail.Email;

            await _context.SaveChangesAsync();

            return new OutUserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                RoleId = user.RoleId,
                Avatar = user.Avatar != null ? new OutAvatarViewModel
                {
                    Id = user.Avatar.Id,
                    Name = user.Avatar.Name,
                    Path = user.Avatar.Path
                } : null,
                Email = user.UserSecurity.Email,
                RoleName = user.Role.Title,
            };
        }

        [HttpPatch("Password")]
        [Authorize(Policy = "ClientAdmin")]
        public async Task<OutUserViewModel> UpdatePassword([FromBody] InUpdatePassword updatePassword)
        {
            AuthorizedUserModel authorizedUserModel = (AuthorizedUserModel)HttpContext.User.Identity;

            if (string.IsNullOrEmpty(updatePassword.Password))
                throw ExceptionFactory.SoftException(ExceptionEnum.PasswordCantBeEmpty, "Password can't be empty");

            var user = await _context.User.Include(x => x.Role).Include(x => x.UserSecurity).Include(x => x.Avatar)
                .FirstOrDefaultAsync(x => x.Id == authorizedUserModel.Id);

            user.UserSecurity.Password = updatePassword.Password;

            await _context.SaveChangesAsync();

            return new OutUserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                RoleId = user.RoleId,
                Avatar = user.Avatar != null ? new OutAvatarViewModel
                {
                    Id = user.Avatar.Id,
                    Name = user.Avatar.Name,
                    Path = user.Avatar.Path
                } : null,
                Email = user.UserSecurity.Email,
                RoleName = user.Role.Title,
            };
        }

        [HttpPatch("Notifications")]
        [Authorize(Policy = "ClientAdmin")]
        public async Task UpdateNotifications([FromBody] InUpdateNotifications updateNotifications)
        {
            AuthorizedUserModel authorizedUserModel = (AuthorizedUserModel)HttpContext.User.Identity;

            var settings = new List<UserNotificationSetting>();

            if (updateNotifications.Email != null)
            {
                settings.AddRange(_mapper.Map<List<UserNotificationSetting>>(updateNotifications.Email));
            }

            if (updateNotifications.Web != null)
            {
                settings.AddRange(_mapper.Map<List<UserNotificationSetting>>(updateNotifications.Web));
            }

            await _notificationService.UpdateNotificationSettings(authorizedUserModel.Id, settings);
        }
    }
}
