using System.Collections.Generic;

#nullable disable

namespace Tests.Dal.Models
{
    public partial class Avatar
    {
        public Avatar()
        {
            Employees = new HashSet<Employee>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
