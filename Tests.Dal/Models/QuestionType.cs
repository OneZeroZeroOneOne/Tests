using System;
using System.Collections.Generic;

#nullable disable

namespace Tests.Dal.Models
{
    public partial class QuestionType
    {
        public QuestionType()
        {
            QuestionTemplates = new HashSet<QuestionTemplate>();
            Questions = new HashSet<Question>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<QuestionTemplate> QuestionTemplates { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
