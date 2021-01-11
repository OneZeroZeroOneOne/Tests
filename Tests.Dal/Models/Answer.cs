using System;
using System.Collections.Generic;

#nullable disable

namespace Tests.Dal.Models
{
    public partial class Answer
    {
        public Answer()
        {
            EmployeeAnswers = new HashSet<EmployeeAnswer>();
        }

        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public DateTime CreateDateTime { get; set; }
        public bool IsRight { get; set; }

        public virtual Question Question { get; set; }
        public virtual ICollection<EmployeeAnswer> EmployeeAnswers { get; set; }
    }
}
