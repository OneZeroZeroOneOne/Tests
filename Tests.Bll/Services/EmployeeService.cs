using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tests.Dal.Contexts;
using Tests.Dal.Models;
using Tests.Utilities.Exceptions;

namespace Tests.Bll.Services
{
    public class EmployeeService
    {
        private readonly MainContext _context;
        private readonly IMapper _mapper;

        public EmployeeService(MainContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Employee?> GetEmployee(int empId, int userId)
        {
            UserEmployee userEmployee = await _context.UserEmployee.FirstOrDefaultAsync(x => x.EmployeeId == empId && x.UserId == userId);
            if (userEmployee != null)
            {
                return await _context.Employee.Include(x => x.UserQuizzes).ThenInclude(x => x.Quiz)
                    .ThenInclude(x => x.Status).Include(x => x.UserQuizzes).ThenInclude(x => x.Quiz)
                    .ThenInclude(x => x.Questions).ThenInclude(x => x.UserAnswers)
                    .Include(x => x.Avatar)
                    .Include(x => x.Resume)
                    .Include(x => x.Vacancy)
                    .FirstOrDefaultAsync(x => x.Id == empId);
            }
            return null;
        }

        public async Task<List<Employee>> GetEmployees(int userId, int? quizStatusId, bool? isCandidate)
        {
            var userEmployees = _context.UserEmployee
                .Where(x => x.UserId == userId)
                .Include(x => x.Employee)
                .ThenInclude(x => x.UserQuizzes).ThenInclude(x => x.Quiz).ThenInclude(x => x.Status)
                .Include(x => x.Employee.Avatar)
                .Include(x => x.Employee.Resume)
                .Include(x => x.Employee.Vacancy)
                .Select(x => x.Employee);

            if (quizStatusId != null)
                userEmployees = userEmployees.Where(x => x.UserQuizzes.Any() && x.UserQuizzes.OrderByDescending(xx => xx.Id).FirstOrDefault().Quiz.StatusId == quizStatusId);

            if (isCandidate != null)
                userEmployees = userEmployees.Where(x => x.IsCandidate == isCandidate);

            return await userEmployees.ToListAsync();
        }

        public async Task<Employee> AddEmployee(Employee newEmp, int userId)
        {
            if (newEmp.AvatarId != null)
            {
                var avatar = await _context.Avatar.FirstOrDefaultAsync(x => x.Id == newEmp.AvatarId);

                if (avatar == null)
                    throw ExceptionFactory.SoftException(ExceptionEnum.AvatarRecordDoesntExist, "");

                newEmp.Avatar = avatar;
            }

            if (newEmp.ResumeId != null)
            {
                var resume = await _context.Resume.FirstOrDefaultAsync(x => x.Id == newEmp.ResumeId);

                if (resume == null)
                    throw ExceptionFactory.SoftException(ExceptionEnum.ResumeRecordDoesntExist, "");

                newEmp.Resume = resume;
            }

            await _context.Employee.AddAsync(newEmp);
            await _context.SaveChangesAsync();

            UserEmployee ue = new UserEmployee()
            {
                UserId = userId,
                EmployeeId = newEmp.Id,
            };

            await _context.UserEmployee.AddAsync(ue);
            await _context.SaveChangesAsync();


            return newEmp;
        }

        public async Task<Employee> EditEmployee(Employee editEmp, int empId, int userId)
        {
            UserEmployee userEmployee = await _context.UserEmployee.FirstOrDefaultAsync(x => x.EmployeeId == empId && x.UserId == userId);
            if (userEmployee == null)
                throw ExceptionFactory.SoftException(ExceptionEnum.EditedUserIsNotYours, "Edited user is not yours");

            if (editEmp.AvatarId != null)
            {
                var avatar = await _context.Avatar.FirstOrDefaultAsync(x => x.Id == editEmp.AvatarId);

                if (avatar == null)
                    throw ExceptionFactory.SoftException(ExceptionEnum.AvatarRecordDoesntExist, "");
            }

            if (editEmp.ResumeId != null)
            {
                var resume = await _context.Resume.FirstOrDefaultAsync(x => x.Id == editEmp.ResumeId);

                if (resume == null)
                    throw ExceptionFactory.SoftException(ExceptionEnum.ResumeRecordDoesntExist, "");
            }

            Employee emp = await _context.Employee
                .FirstOrDefaultAsync(x => x.Id == empId);

            _mapper.Map(editEmp, emp);

            emp.UserEmployees = new List<UserEmployee> { userEmployee };
            emp.Avatar = await _context.Avatar.FirstOrDefaultAsync(x => x.Id == editEmp.AvatarId);
            emp.Resume = await _context.Resume.FirstOrDefaultAsync(x => x.Id == editEmp.ResumeId);

            await _context.SaveChangesAsync();

            return await _context.Employee
                .Include(x => x.Avatar)
                .Include(x => x.Resume)
                .Include(x => x.Vacancy)
                .FirstOrDefaultAsync(x => x.Id == empId); 
        }
    }
}
