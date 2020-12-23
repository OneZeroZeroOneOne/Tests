using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Dal.Contexts;
using Tests.Dal.Models;
using Tests.Dal.Models.Views;

namespace Tests.Bll.Services
{
    public class PositionService
    {
        private readonly MainContext _context;
        public PositionService(MainContext context)
        {
            _context = context;
        }

        public async Task<Position> AddPosition(Position newPosition)
        {
            await _context.Position.AddAsync(newPosition);
            await _context.SaveChangesAsync();
            return newPosition;
        }

        public async Task<List<Position>> GetUserPositions(int userId)
        {
            return await _context.Position.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<List<PositionsWithCount>> GetUserPositionsWithCount(int adminId)
        {
            return await _context.PositionsWithCount.Where(x => x.UserId == adminId).ToListAsync();
        }
    }
}
