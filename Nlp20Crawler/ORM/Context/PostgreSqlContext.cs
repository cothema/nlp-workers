using System;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Nlp20Crawler.Config;
using Nlp20Crawler.ORM.Entities;

namespace Nlp20Crawler.ORM.Context
{
    public class PostgreSqlContext : DbContext
    {
        public PostgreSqlContext()
        {
        }

        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CrawlerWebsite> CrawlerWebsites { get; set; }
        public virtual DbSet<CsWordNounSpecification> CsWordNounSpecifications { get; set; }
        public virtual DbSet<CsWordUniSpecification> CsWordUniSpecifications { get; set; }
        public virtual DbSet<Meaning> Meanings { get; set; }
        public virtual DbSet<Word> Words { get; set; }
        public virtual DbSet<WordMeaning> WordMeaning { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;

            // Load settings
            string[] args = { };
            var services = ConfigServiceProviderBuilder.GetServiceProvider(args);
            var options = services.GetRequiredService<IOptions<AppSecrets>>();

            optionsBuilder
                .UseNpgsql(options.Value.DbConnectionString)
                .UseSnakeCaseNamingConvention();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CrawlerWebsite>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .IsUnique();

                entity.Property(e => e.Crawled)
                    .IsRequired()
                    .HasDefaultValue(false);
            });

            modelBuilder.Entity<CsWordNounSpecification>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .IsUnique();

                entity.HasIndex(e => new
                    {
                        e.WordId, e.Gender, e.DeclensionPl1, e.DeclensionPl2, e.DeclensionPl3, e.DeclensionPl4,
                        e.DeclensionPl5, e.DeclensionPl6, e.DeclensionPl7, e.DeclensionSg1, e.DeclensionSg2,
                        e.DeclensionSg3, e.DeclensionSg4, e.DeclensionSg5, e.DeclensionSg6, e.DeclensionSg7,
                        e.PatternWordId, e.Life
                    })
                    .IsUnique();

                entity.Property(e => e.Gender)
                    .HasComment("0:male,1:female,2:it");

                entity.Property(e => e.Life)
                    .HasComment("false: non life, true: life (for male patterns only)");

                entity.Property(e => e.VerifiedReliability)
                    .HasComment("0: absolutely not verified, 100: verified by professional human");

                entity.HasOne(d => d.PatternWord)
                    .WithMany(p => p.CsWordsNounSpecificationPatternWord)
                    .HasForeignKey(d => d.PatternWordId);

                entity.HasOne(d => d.Word)
                    .WithMany(p => p.CsWordsNounSpecificationWord)
                    .HasForeignKey(d => d.WordId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<CsWordUniSpecification>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .IsUnique();

                entity.HasIndex(e => e.WordId)
                    .IsUnique();

                entity.Property(e => e.IsNegative)
                    .HasComment("null: N/A / true: is negative / false: is positive");

                entity.Property(e => e.WordId);

                entity.Property(e => e.VerbalType)
                    .HasMaxLength(1)
                    .HasComment("0: interjection, 1 - 9: noun - adverb");
            });

            modelBuilder.Entity<Meaning>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .IsUnique();
            });

            modelBuilder.Entity<Word>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .IsUnique();

                entity.HasIndex(e => new {e.Text, e.Lang})
                    .IsUnique();

                entity.Property(e => e.Lang)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.Text)
                    .IsRequired();

                entity.Property(e => e.CrawlerMeaningCheckProposed);

                entity.Property(e => e.CrawlerMeaningCheckProposedTime);

                entity.Property(e => e.Probability)
                    .HasDefaultValue(0)
                    .IsRequired()
                    .HasComment("-100 - +100 (-100 means not possible, 100 means 100% probability)")
                    .HasMaxLength(3);
                
                entity.Property(e => e.OccurenceCount)
                    .HasDefaultValue(0)
                    .IsRequired();
            });

            modelBuilder.Entity<WordMeaning>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .IsUnique();
            });

            // OnModelCreatingPartial(modelBuilder);
        }

        // partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}