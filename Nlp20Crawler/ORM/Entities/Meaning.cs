using System.Collections.Generic;

namespace Nlp20Crawler.ORM.Entities
{
    public class Meaning
    {
        public Meaning()
        {
            WordMeaning = new HashSet<WordMeaning>();
        }

        public int Id { get; set; }
        public string? WikipediaUrl { get; set; }
        public string? Note { get; set; }
        public virtual ICollection<WordMeaning> WordMeaning { get; set; }
    }
}