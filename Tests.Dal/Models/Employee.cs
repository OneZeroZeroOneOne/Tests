using System;
using System.Collections.Generic;

#nullable disable

namespace Tests.Dal.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Quizzes = new HashSet<Quiz>();
            UserAnswers = new HashSet<EmployeeAnswer>();
            UserEmployees = new HashSet<UserEmployee>();
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
        public virtual FakeEmployee FakeEmployee { get; set; }
        public virtual ICollection<Quiz> Quizzes { get; set; }
        public virtual ICollection<EmployeeAnswer> UserAnswers { get; set; }
        public virtual ICollection<UserEmployee> UserEmployees { get; set; }
        public virtual ICollection<AllegedEmployeeError> AllegedEmployeeError { get; set; }
    }
}
