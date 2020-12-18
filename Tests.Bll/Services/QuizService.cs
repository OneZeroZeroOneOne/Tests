using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tests.Dal.Contexts;
using Tests.Dal.Models;
using Tests.Utilities.Exceptions;

namespace Tests.Bll.Services
{
    public class QuizService
    {
        private readonly MainContext _context;
        public QuizService(MainContext context)
        {
            _context = context;
        }

        public async Task<Quiz> CreateNewQuiz(int empId, int userId)
        {
            UserEmployee userEmployee = await _context.UserEmployee.FirstOrDefaultAsync(x => x.EmployeeId == empId && x.UserId == userId);
            if (userEmployee == null)
                throw ExceptionFactory.SoftException(ExceptionEnum.EmployeeIsNotYours, "Employee is not yours");
            
            DateTime currentTime = DateTime.Now;
            Subscription subscription = await _context.Subscription.Include(x => x.Type).FirstOrDefaultAsync(x =>
                x.BeginDateTime <= currentTime && x.EndDateTime >= currentTime && x.UserId == userId);

            if (subscription == null)
                throw ExceptionFactory.SoftException(ExceptionEnum.SubscriptionNotFound, "Subscription not found");

            int quizzesFromThisSubscriptionCount = await _context.UserQuiz.Include(x => x.Quiz)
                .Where(x => x.UserId == userId).Select(x => x.Quiz).Where(x =>
                    x.CreateDateTime >= subscription.BeginDateTime && x.CreateDateTime <= subscription.EndDateTime)
                .CountAsync();

            if (quizzesFromThisSubscriptionCount >= subscription.Type.AvailableTestAmount)
                throw ExceptionFactory.SoftException(ExceptionEnum.ExceededMaximumTests,
                    $"Exceeded the maximum number of tests for the current subscription, SubscriptionId={subscription.Id}");

            string quizId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10);

            Quiz newQuiz = new Quiz {StatusId = 1, CreateDateTime = currentTime, AddressKey = quizId };
            await _context.Quiz.AddAsync(newQuiz);
            await _context.SaveChangesAsync();
            await _context.UserQuiz.AddAsync(new UserQuiz
            {
                QuizId = newQuiz.Id,
                UserId = userId,
                EmployeeId = empId,
            });
            await _context.SaveChangesAsync();
            return await _context.Quiz.Include(x => x.Status).FirstOrDefaultAsync(x => x.Id == newQuiz.Id);
        }

        public async Task<List<Quiz>> GetEmployeeQuizzes(int empId, int userId)
        {
            return await _context.UserQuiz.Include(x => x.Quiz).ThenInclude(x => x.Status).Where(x => x.UserId == userId && x.EmployeeId == empId).Select(x => x.Quiz).ToListAsync();
        }
    }
}
