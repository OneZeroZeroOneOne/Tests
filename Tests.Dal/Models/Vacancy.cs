using System;
using System.Collections.Generic;

#nullable disable

namespace Tests.Dal.Models
{
    public partial class Vacancy
    {
        public Vacancy()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
