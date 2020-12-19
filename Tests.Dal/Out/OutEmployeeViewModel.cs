using System;
using System.Collections.Generic;

namespace Tests.Dal.Out
{
    public class OutEmployeeViewModel
    {
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
        public List<OutQuizViewModel> Quizzes {get; set;}
        public virtual OutAvatarViewModel Avatar { get; set; }
        public virtual OutPositionViewModel Position { get; set; }
        public virtual OutResumeViewModel Resume { get; set; }
        public virtual OutVacancyViewModel Vacancy { get; set; }
    }
}
