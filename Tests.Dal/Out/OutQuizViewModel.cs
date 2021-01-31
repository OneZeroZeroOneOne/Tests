using System;
using System.Collections.Generic;

namespace Tests.Dal.Out
{
    public class OutQuizViewModel
    {
        public int Id { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string AddressKey { get; set; }
        public OutStatusViewModel Status { get; set; }
        public bool IsAdmin { get; set; }

        public List<int> AllegedErrors { get; set; }

        public List<int> AnsweredQuestionIds { get; set; }
        public List<OutQuestionViewModel> Questions { get; set; }
    }
}
