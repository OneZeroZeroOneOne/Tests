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
        public string? Position { get; set; }
        public string? Email { get; set; }
        public string SurName { get; set; }
        public string Phone { get; set; }
        public int Salary { get; set; }
        public string SotialNetworks { get; set; }
        public int? AvatarId { get; set; }
        public string? AvatarPath { get; set; }
        public string? Address { get; set; }
        public int? ResumeId { get; set; }
        public string? ResumePath { get; set; }
        public string? ResumeName { get; set; }
        public List<OutQuizViewModel> Quizzes {get; set;}
    }
}
