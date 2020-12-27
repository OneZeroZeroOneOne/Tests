using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Tests.Dal.Contexts;
using Tests.Dal.Models;
using Tests.Utilities;

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
            List<UserEmployee> fakeEmployees = new List<UserEmployee>()
            {
                new UserEmployee
                {
                    Employee = new Employee
                                {
                                    DateOfBirth = DateTime.Now.Subtract(TimeSpan.FromDays(365 * 26)),
                                    Email = "steffanygretzinger@gmail.com",
                                    FirstName = "Steffany",
                                    SurName = "Gretzinger",
                                    PositionId = 1,
                                    AvatarId = 1,
                                    SotialNetworks = "@steffanygretzinger",
                                    Phone = "+380732014451",
                                    FakeEmployee = new FakeEmployee(),
                                    IsCandidate = true,
                                },
                },

                new UserEmployee
                {
                    Employee = new Employee
                                {
                                    DateOfBirth = DateTime.Now.Subtract(TimeSpan.FromDays(365 * 21)),
                                    Email = "kevinmitnick@gmail.com",
                                    FirstName = "Kevin",
                                    SurName = "Mitnick",
                                    PositionId = 1,
                                    AvatarId = 1,
                                    SotialNetworks = "@kevinmitnick",
                                    Phone = "+380632013221",
                                    FakeEmployee = new FakeEmployee(),
                                    IsCandidate = false,
                                }
                }
            };
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
