using Microsoft.EntityFrameworkCore;
using QuizeService.Contracts;
using QuizeService.Domain;
using QuizeService.Domain.Questions;


namespace QuizeService.Application.UseCases;

public class GetTestByIdUseCase(QuizeServiceDbContext dbContext)
{
    public async Task<GetTestByIdResponseDto?> Execute(
        GetTestByIdRequestDto request,
        CancellationToken cancellationToken)
    {
        Test? test = await dbContext.TestsRead
            .Include(t => t.MatchQuestions)
            .Include(t => t.SingleChoiceQuestions)
            .Include(t => t.TextInputQuestions)
            .FirstOrDefaultAsync(
            t => t.Id == request.TestId,
            cancellationToken);

        if (test is null)
        {
            return null;
        }

        var textInputsDto = test.TextInputQuestions.Select(ti => new GetTextInputQuestionDto
        {
            Id = ti.Id,
            QuestionText = ti.QuestionText,
            ImageId = ti.ImageId,
            CorrectAnswers = ti.CorrectAnswers.ToArray(),
            CaseSensitive = ti.CaseSensitive,
        }).ToArray();
        
        var singleQuestionsDto = test.SingleChoiceQuestions.Select(ti => new GetSingleQuestionDto
        {
            Id = ti.Id,
            QuestionText = ti.QuestionText,
            ImageId = ti.ImageId,
            CorrectAnswers = ti.CorrectAnswers.ToArray(),
            Options = ti.Options.Select(p => new PairDto(p.Id, p.Text)).ToArray(),
        }).ToArray();
        
        var matchQuestionsDto = test.MatchQuestions.Select(ti => new GetMatchQuestionDto()
        {
            Id = ti.Id,
            QuestionText = ti.QuestionText,
            ImageId = ti.ImageId,
            Pairs = new PairsDto()
            {
                LeftColumn = ti.Pairs.LeftColumn.Select(c => new PairDto(c.Id, c.Text)).ToArray(),
                RightColumn = ti.Pairs.RightColumn.Select(c => new PairDto(c.Id, c.Text)).ToArray(),
                CorrectMatches = ti.Pairs.CorrectMatches.Select(cm => new CreateCorrectMatchDto(cm.LeftId, cm.RightId)).ToArray(),
            },
        }).ToArray();

        var response = new GetTestByIdResponseDto(
            test.Id,
            test.AvatarId,
            test.Title,
            textInputsDto,
            matchQuestionsDto,
            singleQuestionsDto);
        
        
        return response;
    }
}