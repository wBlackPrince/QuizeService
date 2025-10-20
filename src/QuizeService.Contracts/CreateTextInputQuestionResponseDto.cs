namespace QuizeService.Contracts;

public record CreateTextInputQuestionResponseDto
{
    public Guid Id { get; init; }
    
    public string Type { get; init; }
    
    public string QuestionText { get; init; }
    
    public Guid ImageId { get; init; }
    
    public string[] CorrectAnswers { get; init; }
    
    public bool CaseSensitive { get; init; }
}