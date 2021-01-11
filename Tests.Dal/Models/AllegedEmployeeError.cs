using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Dal.Models
{
    public class AllegedEmployeeError
    {
        public int QuestionId {get;set;}
        public int EmployeeId { get; set; }

        public Question Question { get; set; }
        public Employee Employee { get; set; }
    }
}
