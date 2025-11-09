using QuizeService.Contracts;
using QuizeService.Domain.Questions;

namespace QuizeService.Application.UseCases;

public class AddTextInputQuestionUseCase(QuizeServiceDbContext dbContext)
{
    public async Task<Guid> Execute(
        AddTextInputQuestionDto request,
        CancellationToken cancellationToken)
    {
        var textInputQuestion = new TextInputQuestion(
                Guid.NewGuid(),
                request.TestId,
                request.Question.QuestionText,
                null,
                request.Question.CorrectAnswers.ToList(),
                request.Question.CaseSensitive);

        await dbContext.TextInputQuestions.AddAsync(textInputQuestion, cancellationToken);
        
        await dbContext.SaveChangesAsync(cancellationToken);
        
        return textInputQuestion.Id;
    }
}