using System;
using System.Threading.Tasks;
using Mailjet.Client;
using Mailjet.Client.TransactionalEmails;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Tests.Bll.Services;
using Tests.Dal.In;
using Tests.Dal.Models;
using Tests.Dal.Out;
using Tests.Security.Authorization;
using Tests.Utilities;

namespace Tests.Authorization.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private RegisterService _registerService;
        private MailjetClient _emailclient;
        private SettingsService _settingsService;
        private NotificationService _notificationService;
        public RegisterController(RegisterService registerService, SettingsService settingsService, NotificationService notificationService, MailjetClient client)
        {
            _registerService = registerService;
            _settingsService = settingsService;
            _emailclient = client;
            _notificationService = notificationService;
        }

        [HttpPost]
        public async Task<OutAuthorizationViewModel> RegisterClientAdmin([FromBody] InRegisterModel inRegisterModel)
        {
            User newUser = await _registerService.RegisterClientAdmin(inRegisterModel.Login, inRegisterModel.Password, inRegisterModel.Email, inRegisterModel.Name);
            var identity = JwtService.GetUserIdentity(newUser.Id, newUser.Role.Id);
            var jwtToken = JwtService.GenerateToken(identity);
            return new OutAuthorizationViewModel { Id = newUser.Id, RoleName = newUser.Role.Title, Token = jwtToken };
        }

        [HttpPost]
        [Route("Auto")]
        public async Task<OutAuthorizationViewModel> AutoRegisterClientAdmin([FromBody] InRegisterModel inRegisterModel)
        {
            string password = StringExtensions.RandomString(10);
            User newUser = await _registerService.RegisterClientAdmin(inRegisterModel.Login, password, inRegisterModel.Email, inRegisterModel.Name);
            var identity = JwtService.GetUserIdentity(newUser.Id, newUser.Role.Id);
            var jwtToken = JwtService.GenerateToken(identity);
            MailjetRequest request = new MailjetRequest
            {
                Resource = Mailjet.Client.Resources.Send.Resource,
            };
            var email = new TransactionalEmailBuilder()
                .WithFrom(new SendContact("intheendreallife@gmail.com"))
                .WithSubject("Пестов Годзи")
                .WithHtmlPart($"Вы были успешно зарегистрированы в системе \"Пестов-Годзи\"<br>Войти в панель администратора можно по ссылке {await _settingsService.GetLoginUrl()}<br>Ваш пароль: {password}")
                .WithTo(new SendContact(inRegisterModel.Email))
                .Build();

            // invoke API to send email
            var response = await _emailclient.SendTransactionalEmailAsync(email);
            await _notificationService.AddPleaseChengePassNot(newUser.Id);
            return new OutAuthorizationViewModel { Id = newUser.Id, RoleName = newUser.Role.Title, Token = jwtToken };
        }
    }
}