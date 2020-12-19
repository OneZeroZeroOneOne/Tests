using System;
using System.Collections.Generic;

#nullable disable

namespace Tests.Dal.Models
{
    public partial class Resume
    {
        public Resume()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
