using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Dal.Models
{
    public class Assessment
    {
        public Assessment()
        {
            EmployeeAnswerAssessments = new HashSet<EmployeeAnswerAssessment>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<EmployeeAnswerAssessment> EmployeeAnswerAssessments { get; set; }
    }
}
