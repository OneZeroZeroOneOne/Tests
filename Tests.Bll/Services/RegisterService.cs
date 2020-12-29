using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Tests.Dal.Contexts;
using Tests.Dal.Models;
using Tests.Utilities;
using Tests.Utilities.Exceptions;

namespace Tests.Bll.Services
{
    public class RegisterService
    {
        private readonly MainContext _context;
        private readonly NotificationService _notificationService;

        public RegisterService(MainContext mainContext, NotificationService notificationService)
        {
            _context = mainContext;
            _notificationService = notificationService;
        }


        public async Task<User> RegisterClientAdmin(string login, string password, string email, string name)
        {
            int testSubscriptionTypeId = 1;
            int defAvatarId = 1;
            GlobalSetting gl = await _context.GlobalSetting.FirstOrDefaultAsync(x => x.Key == "RegistrationPolitics");
            JObject json = JObject.Parse(gl.StringValue);
            if (login.Length < int.Parse(json["login"].ToString()))
            {
                throw ExceptionFactory.SoftException(ExceptionEnum.ShortLogin, "Short login");
            } 
            if(password.Length < int.Parse(json["password"].ToString()))
            {
                throw ExceptionFactory.SoftException(ExceptionEnum.ShortPassword, "Short password");
            }
            if (!EmailValidator.IsValidEmail(email))
            {
                throw ExceptionFactory.SoftException(ExceptionEnum.InvalidEmailFormat, "Invalid email format");
            }
            Role role = await _context.Role.FirstOrDefaultAsync(x => x.Title == "ClientAdmin");
            User newUser = new User() { RoleId = role.Id, Name = name, CreateDateTime = DateTime.Now, AvatarId = defAvatarId };
            SubscriptionType subscriptionType = await _context.SubscriptionType.Include(x => x.LongevityType).FirstOrDefaultAsync(x => x.Id == testSubscriptionTypeId);
            Subscription testSubscription = new Subscription
            {
                TypeId = testSubscriptionTypeId,
                CreatedDateTime = DateTime.Now,
                BeginDateTime = DateTime.Now,
                EndDateTime = TimeAdder.AddTimeSegment(DateTime.Now, subscriptionType.LongevityType.LongevityMeasureName, subscriptionType.LongevityType.LongevityValue),
            };
            newUser.Subscriptions.Add(testSubscription);
            UserSecurity userSecurity = new UserSecurity()
            {
                Login = login,
                Password = password,
                Email = email,
            };
            int positionCount = await _context.Position.CountAsync();
            Random r = new Random();
            List<Position> positions = await _context.Position.Skip(positionCount < 5 ? 0 : r.Next(0, positionCount-5)).Take(5).ToListAsync();
            List<UserEmployee> fakeEmployees = new List<UserEmployee>();
            for(int i = 0; i < 5; i++)
            {
                UserEmployee  userEmployee = new UserEmployee
                {
                    Employee = FakeUserGenerator.GetFakeUser(positions)
                };
                userEmployee.Employee.FakeEmployee = new FakeEmployee();
                fakeEmployees.Add(userEmployee);
            }
            newUser.UserSecurity = userSecurity;
            newUser.UserEmployees = fakeEmployees;
            await _context.User.AddAsync(newUser);
            await _context.SaveChangesAsync();
            await _notificationService.AddDefaultNotificationSetting(newUser.Id);
            await _context.SaveChangesAsync();
            return newUser;

        }

    }
}
