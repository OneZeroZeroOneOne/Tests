using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests.Bll.Template
{
    public class WordParser
    {
        private readonly string _template;
        private List<Word> _words;
        public string parsedTemplate;
        public Dictionary<string, Word> templateDataObjects;

        public WordParser(string template)
        {
            _template = template;
            Parse();
        }

        private void Parse()
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(_template);
            _words = new List<Word>();

            foreach (var node in doc.DocumentNode.ChildNodes.Where(x => x.NodeType == HtmlNodeType.Element).ToList())
            {
                if (!Enum.TryParse<WordTypeEnum>(node.Name, true, out var wordType)) continue;

                var word = new Word
                {
                    WordType = wordType,
                    Id = Guid.NewGuid().ToString().Substring(0, 5),
                    WordNumber = int.Parse(node.Attributes.FirstOrDefault(x => x.Name == "wordnumber")?.Value ?? string.Empty),
                    StartPosition = node.LinePosition,
                    TagLength = node.OuterHtml.Length
                };

                switch (word.WordType)
                {
                    case WordTypeEnum.Adjective:
                        if (!Enum.TryParse<GenderEnum>(node.Attributes.FirstOrDefault(x => x.Name == "gender")?.Value, true, out var gender))
                            throw new Exception($"Can't parse GenderEnum in {_template} WordNumber: {word.WordNumber}");

                        if (!Enum.TryParse<AmountEnum>(node.Attributes.FirstOrDefault(x => x.Name == "amount")?.Value, true, out var amount))
                            throw new Exception($"Can't parse AmountEnum in {_template} WordNumber: {word.WordNumber}");

                        if (!Enum.TryParse<DeclensionEnum>(node.Attributes.FirstOrDefault(x => x.Name == "declension")?.Value, true, out var declensionVal))
                            throw new Exception($"Can't parse DeclensionEnum in {_template} WordNumber: {word.WordNumber}");

                        word.Gender = gender;
                        word.Amount = amount;
                        word.Declension = declensionVal;
                        break;

                    case WordTypeEnum.Noun:
                        if (!Enum.TryParse<AmountEnum>(node.Attributes.FirstOrDefault(x => x.Name == "amount")?.Value, true, out var amountVals))
                            throw new Exception($"Can't parse AmountEnum in {_template} WordNumber: {word.WordNumber}");

                        if (!Enum.TryParse<DeclensionEnum>(node.Attributes.FirstOrDefault(x => x.Name == "declension")?.Value, true, out var declension))
                            throw new Exception($"Can't parse DeclensionEnum in {_template} WordNumber: {word.WordNumber}");

                        if (!Enum.TryParse<GenderEnum>(node.Attributes.FirstOrDefault(x => x.Name == "gender")?.Value, true, out var genderNoun))
                            throw new Exception($"Can't parse GenderEnum in {_template} WordNumber: {word.WordNumber}");

                        word.Amount = amountVals;
                        word.Declension = declension;
                        word.Gender = genderNoun;
                        break;

                    case WordTypeEnum.Verb:
                        if (!Enum.TryParse<TimeEnum>(node.Attributes.FirstOrDefault(x => x.Name == "time")?.Value, true, out var time))
                            throw new Exception($"Can't parse TimeEnum in {_template} WordNumber: {word.WordNumber}");

                        if (!Enum.TryParse<AmountEnum>(node.Attributes.FirstOrDefault(x => x.Name == "amount")?.Value, true, out var amountVal))
                            throw new Exception($"Can't parse AmountEnum in {_template} WordNumber: {word.WordNumber}");

                        word.Time = time;
                        word.Amount = amountVal;
                        if (word.Time == TimeEnum.Past)
                        {
                            if (word.Amount == AmountEnum.Alone)
                            {
                                if (!Enum.TryParse<GenderEnum>(node.Attributes.FirstOrDefault(x => x.Name == "gender")?.Value, true, out var genderVal))
                                    throw new Exception($"Can't parse GenderEnum in {_template} id: {word.Id}");

                                word.Gender = genderVal;
                            }
                        }
                        else
                        {
                            word.Person = int.Parse(node.Attributes.FirstOrDefault(x => x.Name == "person")?.Value ?? string.Empty);
                        }
                        break;

                    default:
                        continue;
                }

                node.ParentNode.ReplaceChild(HtmlNode.CreateNode($"{{{{word_{word.Id}}}}}"), node);
                
                _words.Add(word);
            }
            parsedTemplate = doc.DocumentNode.InnerHtml;
            templateDataObjects = GetTemplateDataObject();
        }

        public Dictionary<string, Word> GetTemplateDataObject()
        {
            var templateDataObject = new Dictionary<string, Word>();

            foreach (var word in _words)
            {
                switch (word.WordType)
                {
                    case WordTypeEnum.Noun:
                        templateDataObject.Add($"word_{word.Id}", word);
                        break;
                    case WordTypeEnum.Verb:
                        templateDataObject.Add($"word_{word.Id}", word);
                        break;
                    case WordTypeEnum.Adjective:
                        templateDataObject.Add($"word_{word.Id}", word);
                        break;
                    default:
                        continue;
                }
            }
            return templateDataObject;

        }
    }
}
