namespace QuizeService.Contracts;

public class GetTextInputQuestionDto
{
    public Guid Id { get; init; }
    
    public string QuestionText { get; init; }
    
    public Guid? ImageId { get; init; }
    
    public string[] CorrectAnswers { get; set; }
    
    public bool CaseSensitive { get; init; }
}