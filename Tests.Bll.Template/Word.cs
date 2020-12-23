namespace Tests.Bll.Template
{
    public class Word
    {
        public WordTypeEnum WordType { get;set; }
        public int Id { get; set; }
        public AmountEnum Amount {get;set;}
        public int StartPosition { get; set; }
        public int EndPosition { get; set; }
        public int? Person { get; set; }
        public DeclensionEnum Declension { get; set; }
        public GenderEnum Gender { get; set; }
        public TimeEnum Time { get; set; }
    }

}
