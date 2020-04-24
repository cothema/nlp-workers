namespace Nlp20Crawler.ORM.Entities
{
    public class WordMeaning
    {
        public int Id { get; set; }

        public int WordId { get; set; }

        public int MeaningId { get; set; }

        public string? Note { get; set; }

        public virtual Word Word { get; set; }

        public virtual Meaning Meaning { get; set; }
    }
}