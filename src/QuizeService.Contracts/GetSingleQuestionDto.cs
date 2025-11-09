namespace QuizeService.Contracts;

public record GetSingleQuestionDto
{
    public Guid Id { get; init; }
    public string QuestionText { get; init; }
    
    public Guid? ImageId { get; init; }

    public PairDto[] Options { get; init; }
    
    public int[] CorrectAnswers { get; init; }
}