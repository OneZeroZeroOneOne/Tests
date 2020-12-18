using System;
using System.Collections.Generic;

#nullable disable

namespace Tests.Dal.Models
{
    public partial class Status
    {
        public Status()
        {
            Quizzes = new HashSet<Quiz>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Quiz> Quizzes { get; set; }
    }
}
