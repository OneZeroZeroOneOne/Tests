using System.Threading.Tasks;
using Tests.Dal.Contexts;
using Tests.Dal.Models;

namespace Tests.Bll.Services
{
    public class ResumeService
    {
        private readonly MainContext _context;
        public ResumeService(MainContext context)
        {
            _context = context;
        }

        public async Task<Resume> AddResume(Resume newResume)
        {
            await _context.Resume.AddAsync(newResume);
            await _context.SaveChangesAsync();
            return newResume;
        }
    }
}
