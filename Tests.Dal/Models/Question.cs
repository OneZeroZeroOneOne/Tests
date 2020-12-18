using System;
using System.Collections.Generic;

#nullable disable

namespace Tests.Dal.Models
{
    public partial class Question
    {
        public Question()
        {
            Answers = new HashSet<Answer>();
            UserAnswers = new HashSet<UserAnswer>();
        }

        public int Id { get; set; }
        public int? QuizId { get; set; }
        public int? QuestionTypeId { get; set; }
        public string Text { get; set; }
        public DateTime? CreateDateTime { get; set; }

        public virtual QuestionType QuestionType { get; set; }
        public virtual Quiz Quiz { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<UserAnswer> UserAnswers { get; set; }
    }
}
