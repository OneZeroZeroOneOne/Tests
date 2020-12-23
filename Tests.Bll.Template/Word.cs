using System;

namespace Tests.Bll.Template
{
    public class Word
    {
        public WordTypeEnum WordType { get;set; }
        public int Id { get; set; }
        public string Amount {get;set;}
        public int StartPosition { get; set; }
        public int EndPosition { get; set; }
        public int? Person { get; set; }
        public string Declension { get; set; }
        public string Gender { get; set; }
        public string Time { get; set; }
    }

}
