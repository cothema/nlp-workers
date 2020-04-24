namespace Nlp20Crawler.ORM.Entities
{
    public class CsWordUniSpecification
    {
        public int Id { get; set; }
        public int WordId { get; set; }
        public int LemmaWordId { get; set; }
        public bool? IsNegative { get; set; }

        public int VerbalType { get; set; }

        public virtual Word Word { get; set; }
        
        public virtual Word LemmaWord { get; set; }
    }
}