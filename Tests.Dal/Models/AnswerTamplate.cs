using System;
using System.Collections.Generic;

#nullable disable

namespace Tests.Dal.Models
{
    public partial class AnswerTamplate
    {
        public int Id { get; set; }
        public int? QuestionTamplateId { get; set; }
        public string Text { get; set; }

        public virtual QuestionTemplate QuestionTamplate { get; set; }
    }
}
