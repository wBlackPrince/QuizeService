namespace QuizeService.Contracts;

public record CreateSingleChoiceQuestionResponseDto
{
    public Guid Id { get; init; }
    
    public string Type { get; init; }
    
    public string SingleChoice { get; init; }
    
    public string QuestionText { get; init; }
    
    public Guid ImageId { get; init; }

    public PairDto[] Options { get; init; }
    
    public Guid[] CorrectAnswers { get; init; }
}