using FluentValidation;
using TextAnalysis.Web.Controllers;

public class CreateSentenceValidator : AbstractValidator<SentenceRequestDTO>
{
    public CreateSentenceValidator()
    {
        RuleFor(x => x.Sentence)
          .NotEmpty().WithMessage("Sentence is required");
    }
}