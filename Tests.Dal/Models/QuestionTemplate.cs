using System;
using System.Collections.Generic;

#nullable disable

namespace Tests.Dal.Models
{
    public partial class QuestionTemplate
    {
        public QuestionTemplate()
        {
            AnswerTamplates = new HashSet<AnswerTamplate>();
        }

        public int Id { get; set; }
        public string Text { get; set; }
        public int QuestionTypeId { get; set; }

        public virtual QuestionType QuestionType { get; set; }
        public virtual ICollection<AnswerTamplate> AnswerTamplates { get; set; }
    }
}
