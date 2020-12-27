using System;
using System.ComponentModel.DataAnnotations;

namespace Tests.Dal.In
{
    public class InEmployeeViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [Required]
        public int PositionId { get; set; }
        public string? Email { get; set; }
        public string SurName { get; set; }
        public string? Phone { get; set; }
        public int? Salary { get; set; }
        public string? SotialNetworks { get; set; }
        public int? AvatarId { get; set; }
        public string? Adress { get; set; }
        public int? ResumeId { get; set; }
        [Required]
        public bool IsCandidate { get; set; }
    }
}
