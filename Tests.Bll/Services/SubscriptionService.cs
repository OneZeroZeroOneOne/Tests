using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Dal.Contexts;
using Tests.Dal.Models;

namespace Tests.Bll.Services
{
    public class SubscriptionService
    {
        private readonly MainContext _context;

        public SubscriptionService(MainContext context)
        {
            _context = context;
        }

        public async Task<Subscription> GetCurrent(int userId)
        {
            DateTime currTime = DateTime.Now;
            return await _context.Subscription.Include(x => x.Type).ThenInclude(x => x.LongevityType).FirstOrDefaultAsync(x => x.UserId == userId && x.BeginDateTime <= currTime && x.EndDateTime >= currTime);
        }


        public async Task<List<Subscription>> GetAllSubscriptions(int userId)
        {
            DateTime currTime = DateTime.Now;
            return await _context.Subscription.Include(x => x.Type).ThenInclude(x => x.LongevityType).Where(x => x.UserId == userId && x.BeginDateTime <= currTime && x.EndDateTime >= currTime).ToListAsync();
        }

        public async Task<List<SubscriptionType>> GetSubscriptionTypes()
        {
            return await _context.SubscriptionType.Include(x => x.LongevityType).ToListAsync();
        }
    }
    
}
