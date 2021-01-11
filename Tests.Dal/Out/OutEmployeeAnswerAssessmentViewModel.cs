using System;
using System.Collections.Generic;
using System.Text;
using Tests.Dal.Models;

namespace Tests.Dal.Out
{
    public class OutEmployeeAnswerAssessmentViewModel
    {
        public int AssessmentId { get; set; }
        public int QuiestionId { get; set; }

        public OutQuestionViewModel Question { get; set; }
        public OutAssessmentViewModel Assessment { get; set; }
    }
}
