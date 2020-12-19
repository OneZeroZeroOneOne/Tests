using System;

namespace Tests.Dal.In
{
    public class InEmployeeViewModel
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Position { get; set; }
        public string? Email { get; set; }
        public string SurName { get; set; }
        public string? Phone { get; set; }
        public int Salary { get; set; }
        public string? SotialNetworks { get; set; }
        public int? AvatarId { get; set; }
        public string? Adress { get; set; }
        public int? ResumeId { get; set; }
        public bool IsCandidate { get; set; }
    }
}
