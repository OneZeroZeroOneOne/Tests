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
            UserAnswers = new HashSet<EmployeeAnswer>();
        }

        public int Id { get; set; }
        public int QuizId { get; set; }
        public int QuestionTypeId { get; set; }
        public string Text { get; set; }
        public DateTime CreateDateTime { get; set; }

        public virtual QuestionType QuestionType { get; set; }
        public virtual Quiz Quiz { get; set; }
        public virtual EmployeeAnswerAssessment EmployeeAnswerAssessment { get; set; }
        public virtual AllegedEmployeeError AllegedEmployeeError { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<EmployeeAnswer> UserAnswers { get; set; }
        public virtual int? AboutQuestionId { get; set; } 
        public virtual Question AboutQuestion { get; set; }
    }
}
