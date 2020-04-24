using System;
using System.Collections.Generic;

namespace Nlp20Crawler.ORM.Entities
{
    public class Word
    {
        public Word()
        {
            CsWordsNounSpecificationPatternWord = new HashSet<CsWordNounSpecification>();
            CsWordsNounSpecificationWord = new HashSet<CsWordNounSpecification>();
            WordMeaning = new HashSet<WordMeaning>();
        }

        public int Id { get; set; }

        public string Text { get; set; }

        public string Lang { get; set; }

        public bool? CrawlerMeaningCheckProposed { get; set; }

        public DateTime? CrawlerMeaningCheckProposedTime { get; set; }

        public int Probability { get; set; }

        public int OccurenceCount { get; set; }

        public virtual ICollection<CsWordNounSpecification> CsWordsNounSpecificationPatternWord { get; set; }
        public virtual ICollection<CsWordNounSpecification> CsWordsNounSpecificationWord { get; set; }
        public virtual ICollection<WordMeaning> WordMeaning { get; set; }
        public virtual ICollection<CsWordUniSpecification> CsWordLexemes { get; set; }
        public virtual ICollection<CsWordUniSpecification> CsWordsUniSpecificationWord { get; set; }
        public virtual ICollection<CrawlerWebsite> CrawlerWebsiteWord { get; set; }
    }
}