using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tests.Dal.Contexts;
using Tests.Dal.Models;

namespace Tests.Bll.Services
{
    public class AvatarService
    {
        private readonly MainContext _context;
        public AvatarService(MainContext context)
        {
            _context = context;
        }

        public async Task<Avatar> AddAvatar(Avatar newAvatar)
        {
            await _context.Avatar.AddAsync(newAvatar);
            await _context.SaveChangesAsync();
            return newAvatar;
        }
    }
}
