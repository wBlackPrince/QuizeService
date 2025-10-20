using QuizeService.Contracts;
using QuizeService.Domain;
using QuizeService.Domain.Questions;

namespace QuizeService.Application.UseCases;

public class CreateTestUseCase(QuizeServiceDbContext dbContext)
{
    public async Task<Guid> Execute(
        CreateTestRequestDto request,
        CancellationToken cancellationToken)
    {
        Guid testId = Guid.NewGuid();

        var textInputQuestions = request.TextInputQuestions
            .Select(q => new TextInputQuestion(
                Guid.NewGuid(),
                testId,
                q.QuestionText,
                null,
                q.CorrectAnswers.ToList(),
                q.CaseSensitive
            ));


        var matchQuestions = request.MatchQuestions
            .Select(q => new MatchQuestion(
                Guid.NewGuid(),
                testId,
                q.QuestionText,
                null,
                new Pairs(
                    q.Pairs.LeftColumn.Select(l => new Pair(l.Id, l.Text)).ToList(),
                    q.Pairs.RightColumn.Select(r => new Pair(r.Id, r.Text)).ToList(),
                    q.Pairs.CorrectMatches.Select(cm => new CorrectMatch(cm.LeftId, cm.RightId)).ToList()
                )));

        var singleChoiceQuestions = request.SingleChoiceQuestions
            .Select(q => new SingleChoiceQuestion(
                Guid.NewGuid(),
                testId,
                q.QuestionText,
                null,
                q.Options.Select(p => new Pair(p.Id, p.Text)).ToList(),
                q.CorrectAnswers.ToList()));

        Test test = new Test(
            testId,
            null,
            request.Title,
            textInputQuestions.ToList(),
            singleChoiceQuestions.ToList(),
            matchQuestions.ToList());

        await dbContext.Tests.AddAsync(test, cancellationToken);
        
        await dbContext.SaveChangesAsync(cancellationToken);

        return testId;
    }
}