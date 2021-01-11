using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Dal.Models
{
    public class EmployeeAnswerAssessment
    {
        public int AssessmentId { get; set; }
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
        public virtual Assessment Assessment { get; set; }

        public DateTime CreateDateTime { get; set; }


    }
}
