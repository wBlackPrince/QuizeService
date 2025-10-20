namespace QuizeService.Contracts;

public record CreateSingleChoiceQuestionRequestDto
{
    public string QuestionText { get; init; }

    public PairDto[] Options { get; init; }
    
    public int[] CorrectAnswers { get; init; }
}