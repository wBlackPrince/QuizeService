using QuizeService.Contracts;
using QuizeService.Domain.Questions;

namespace QuizeService.Application.UseCases;

public class AddSingleChoiceQuestionUseCase(QuizeServiceDbContext dbContext)
{
    public async Task<Guid> Execute(
        AddSingleChoiceQuestionDto request,
        CancellationToken cancellationToken)
    {
        var textInputQuestion = new SingleChoiceQuestion(
            Guid.NewGuid(),
            request.TestId,
            request.Question.QuestionText,
            null,
            request.Question.Options.Select(o => new Pair(o.Id, o.Text)).ToList(),
            request.Question.CorrectAnswers.ToList());

        await dbContext.SingleChoiceQuestions.AddAsync(textInputQuestion, cancellationToken);
        
        await dbContext.SaveChangesAsync(cancellationToken);
        
        return textInputQuestion.Id;
    }
}