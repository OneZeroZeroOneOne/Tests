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
    public class VacancyService
    {
        public MainContext _context;
        public VacancyService(MainContext context)
        {
            _context = context;
        }

        public async Task<Vacancy> AddVacancy(Vacancy newVacancy)
        {
            await _context.Vacancy.AddAsync(newVacancy);
            await _context.SaveChangesAsync();
            return newVacancy;
        }

        public async Task<List<Vacancy>> GetUserVacancies(int userId)
        {
            return await _context.Vacancy.Where(x => x.UserId == userId).ToListAsync();
        }
    }
}
