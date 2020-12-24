using System;
using System.Collections.Generic;

namespace Tests.Bll.Template
{
    public class Word
    {
        public string Id { get; set; }
        public int WordNumber { get; set; }
        public int StartPosition { get; set; }
        public int EndPosition => StartPosition + TagLength;
        public int TagLength { get; set; }
        public int? Person { get; set; }
        public WordTypeEnum WordType { get; set; }
        public AmountEnum Amount {get;set;}
        public DeclensionEnum Declension { get; set; }
        public GenderEnum Gender { get; set; }
        public TimeEnum Time { get; set; }
    }

    public class WordComparer : EqualityComparer<Word>
    {
        public override bool Equals(Word x, Word y)
        {
            if (object.ReferenceEquals(x, y)) return true;

            if (object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null))
                return false;

            return x.WordNumber == y.WordNumber;
        }

        public override int GetHashCode(Word? obj)
        {
            if (object.ReferenceEquals(obj, null)) return 0;

            return obj.WordNumber == null ? 0 : obj.WordNumber.GetHashCode();
        }
    }
}
