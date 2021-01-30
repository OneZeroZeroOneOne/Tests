using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Dal.Out
{
    public class OutAnswerViewModel
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public DateTime CreateDateTime { get; set; }
        public bool IsPicked { get; set; }
        public bool IsRight { get; set; }
    }
}
