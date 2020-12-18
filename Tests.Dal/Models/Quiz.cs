using System;
using System.Collections.Generic;

#nullable disable

namespace Tests.Dal.Models
{
    public partial class Quiz
    {
        public Quiz()
        {
            Questions = new HashSet<Question>();
            UserAnswers = new HashSet<UserAnswer>();
            UserQuizzes = new HashSet<UserQuiz>();
        }

        public int Id { get; set; }
        public DateTime CreateDateTime { get; set; }
        public int StatusId { get; set; }
        public string AddressKey { get; set; }

        public virtual Status Status { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<UserAnswer> UserAnswers { get; set; }
        public virtual ICollection<UserQuiz> UserQuizzes { get; set; }
    }
}
