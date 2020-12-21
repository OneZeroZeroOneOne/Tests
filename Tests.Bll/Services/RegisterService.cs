using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Tests.Dal.Contexts;
using Tests.Dal.Models;

namespace Tests.Bll.Services
{
    public class RegisterService
    {
        private MainContext _context;
        public RegisterService(MainContext maincontext)
        {
            _context = maincontext;
        }

        public async Task<User> RegisterClientAdmin(string login, string password, string email, string name)
        {
            Role role = await _context.Role.FirstOrDefaultAsync(x => x.Title == "ClientAdmin");
            User newUser = new User() { RoleId = role.Id, Name = name, CreateDateTime = DateTime.Now, AvatarId = 1};
            await _context.User.AddAsync(newUser);
            await _context.SaveChangesAsync();
            UserSecurity userSecurity = new UserSecurity()
            {
                Login = login,
                Password = password,
                UserId = newUser.Id,
                Email = email,
            };
            await _context.UserSecurity.AddAsync(userSecurity);
            await _context.SaveChangesAsync();
            return newUser;

        }

    }
}
