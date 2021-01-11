using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Dal.Out
{
    public class OutQuestionResultViewModel
    {
        public int QuestionId { get; set; }
        public bool IsRight { get; set; }
        public string AssessmentText { get;set;}
    }
}
