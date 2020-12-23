using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tests.Bll.Template
{
    public static class WordParser
    {
        public static List<Word> Parse(string htmlWordString)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(htmlWordString);
            List<Word> words = new List<Word>();
            foreach(var node in doc.DocumentNode.ChildNodes)
            {
                if(node.NodeType == HtmlNodeType.Element)
                {
                    Word word = new Word();
                    if (Enum.TryParse<WordTypeEnum>(node.Name, true, out var wordType))
                    {
                        word.WordType = wordType;
                        word.Id = int.Parse(node.Attributes.FirstOrDefault(x => x.Name == "id").Value);
                        word.StartPosition = node.LinePosition;
                        word.EndPosition = node.LinePosition + node.OuterHtml.Length;
                        switch (word.WordType)
                        {
                            case WordTypeEnum.Adjective:
                                word.Gender = node.Attributes.FirstOrDefault(x => x.Name == "gender").Value;
                                word.Amount = node.Attributes.FirstOrDefault(x => x.Name == "amount").Value;
                                word.Declension = node.Attributes.FirstOrDefault(x => x.Name == "declension").Value;
                                break;

                            case WordTypeEnum.Noun:
                                word.Amount = node.Attributes.FirstOrDefault(x => x.Name == "amount").Value;
                                word.Declension = node.Attributes.FirstOrDefault(x => x.Name == "declension").Value;
                                break;

                            case WordTypeEnum.Verb:
                                word.Time = node.Attributes.FirstOrDefault(x => x.Name == "time").Value;
                                word.Amount = node.Attributes.FirstOrDefault(x => x.Name == "amount").Value;
                                if (word.Time == "Past")
                                {
                                    if(word.Amount == "alone")
                                    {
                                        word.Gender = node.Attributes.FirstOrDefault(x => x.Name == "gender").Value;
                                    }
                                }
                                else
                                {
                                    word.Person = int.Parse(node.Attributes.FirstOrDefault(x => x.Name == "person").Value);
                                }
                                break;

                        }
                        words.Add(word);
                    }
                }
            }
            return words;
        }
    }
}
