using System;
using System.Collections.Generic;

#nullable disable

namespace Tests.Dal.Models
{
    public partial class Employee
    {
        public Employee()
        {
            UserAnswers = new HashSet<UserAnswer>();
            UserEmployees = new HashSet<UserEmployee>();
            UserQuizzes = new HashSet<UserQuiz>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }
        public string SurName { get; set; }
        public string Phone { get; set; }
        public int? Salary { get; set; }
        public string SotialNetworks { get; set; }
        public string Adress { get; set; }
        public bool? IsCandidate { get; set; }
        public int? AvatarId { get; set; }
        public int? ResumeId { get; set; }
        public int? PositionId { get; set; }
        public int? VacancyId { get; set; }

        public virtual Avatar Avatar { get; set; }
        public virtual Position Position { get; set; }
        public virtual Resume Resume { get; set; }
        public virtual Vacancy Vacancy { get; set; }
        public virtual ICollection<UserAnswer> UserAnswers { get; set; }
        public virtual ICollection<UserEmployee> UserEmployees { get; set; }
        public virtual ICollection<UserQuiz> UserQuizzes { get; set; }
    }
}
