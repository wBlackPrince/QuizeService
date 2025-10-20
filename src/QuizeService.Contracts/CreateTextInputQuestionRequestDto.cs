namespace QuizeService.Contracts;

public record CreateTextInputQuestionRequestDto
{
    public string QuestionText { get; init; }
    
    public string[] CorrectAnswers { get; init; }
    
    public bool CaseSensitive { get; init; }
}