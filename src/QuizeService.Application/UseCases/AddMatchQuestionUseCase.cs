using QuizeService.Contracts;
using QuizeService.Domain.Questions;

namespace QuizeService.Application.UseCases;

public class AddMatchQuestionUseCase(QuizeServiceDbContext dbContext)
{
    public async Task<Guid> Execute(
        AddMatchQuestionDto request,
        CancellationToken cancellationToken)
    {
        var textInputQuestion = new MatchQuestion(
            Guid.NewGuid(),
            request.TestId,
            request.Question.QuestionText,
            null,
            new Pairs(
                request.Question.Pairs.LeftColumn.Select(l => new Pair(l.Id, l.Text)).ToList(),
                request.Question.Pairs.RightColumn.Select(r => new Pair(r.Id, r.Text)).ToList(),
                request.Question.Pairs.CorrectMatches.Select(cm => new CorrectMatch(cm.LeftId, cm.RightId)).ToList()
            ));

        await dbContext.MatchQuestions.AddAsync(textInputQuestion, cancellationToken);
        
        await dbContext.SaveChangesAsync(cancellationToken);
        
        return textInputQuestion.Id;
    }
}