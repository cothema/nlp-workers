namespace Nlp20Crawler.ORM.Entities
{
    public class CsWordNounSpecification
    {
        public int Id { get; set; }
        public int WordId { get; set; }
        public short? Gender { get; set; }
        public bool? DeclensionSg1 { get; set; }
        public bool? DeclensionSg2 { get; set; }
        public bool? DeclensionSg3 { get; set; }
        public bool? DeclensionSg4 { get; set; }
        public bool? DeclensionSg5 { get; set; }
        public bool? DeclensionSg6 { get; set; }
        public bool? DeclensionSg7 { get; set; }
        public bool? DeclensionPl1 { get; set; }
        public bool? DeclensionPl2 { get; set; }
        public bool? DeclensionPl3 { get; set; }
        public bool? DeclensionPl4 { get; set; }
        public bool? DeclensionPl5 { get; set; }
        public bool? DeclensionPl6 { get; set; }
        public bool? DeclensionPl7 { get; set; }
        public bool VerifiedByHuman { get; set; }
        public int? VerifiedReliability { get; set; }
        public int? PatternWordId { get; set; }
        public bool? Life { get; set; }
        public bool? CrawlerProposedWiki { get; set; }
        public virtual Word PatternWord { get; set; }
        public virtual Word Word { get; set; }
    }
}