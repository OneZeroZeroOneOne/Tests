using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Dal.Out
{
    public class OutQuestionViewModel
    {
        public int Id { get; set; }
        public int QuizId { get; set; }
        public int QuestionTypeId { get; set; }
        public string Text { get; set; }
        public DateTime CreateDateTime { get; set; }
        public List<OutAnswerViewModel> Answers { get; set; }
    }
}
