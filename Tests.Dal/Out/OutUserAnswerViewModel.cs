using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Dal.Out
{
    public class OutUserAnswerViewModel
    {
        public int? EmployeeId { get; set; }
        public int? QuizId { get; set; }
        public int? QuestionId { get; set; }
        public int? AnswerId { get; set; }
        public DateTime? CreateDateTime { get; set; }
    }
}
