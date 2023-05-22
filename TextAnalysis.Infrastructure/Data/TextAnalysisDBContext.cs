using Microsoft.EntityFrameworkCore;
using TextAnalysis.Domain.CommonWordAggregate.Enteties;
using TextAnalysis.Domain.TextSentenceAggregate.Enteties;

namespace TextAnalysis.Infrastructure.Data
{
    public class TextAnalysisDBContext : DbContext
    {

        public TextAnalysisDBContext(DbContextOptions<TextAnalysisDBContext> options) : base(options) { }

        public DbSet<TextSentence> Sentences => Set<TextSentence>();
        public DbSet<CommonWord> CommonWords => Set<CommonWord>();

    }
}
