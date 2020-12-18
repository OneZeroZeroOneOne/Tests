using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Tests.Dal.Contexts;
using Tests.Dal.Models;

namespace Tests.Bll.Services
{
    public class UserService
    {
        private MainContext _context;
        public UserService(MainContext maincontext)
        {
            _context = maincontext;
        }

        public async Task<User> GetUser(int id)
        {
            
            return await _context.User.Include(x => x.Role).Include(x => x.UserSecurity).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
