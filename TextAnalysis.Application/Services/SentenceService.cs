using TextAnalysis.Domain.Interfaces;
using TextAnalysis.Domain.TextSentenceAggregate.Enteties;

namespace TextAnalysis.Application.Services
{
    public class SentenceService : ISentenceService
    {
        private readonly IRepository<TextSentence> _sentenceRepository;
        public SentenceService(IRepository<TextSentence> sentenceRepository)
        {
            _sentenceRepository = sentenceRepository;
        }

        public async Task<TextSentence> CreateSentence(TextSentence sentence)
        {
            var newSentence = await _sentenceRepository.AddAsync(sentence);
            return newSentence;
        }

    }
}
