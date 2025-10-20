namespace QuizeService.Domain.Questions;

public class TextInputQuestion
{
    private TextInputQuestion()
    {
    }
    
    public TextInputQuestion(
        Guid id,
        Guid testId,
        string questionText,
        Guid? imageId,
        List<string> correctAnswers,
        bool caseSensitive)
    {
        Id = id;
        TestId = testId;
        QuestionText = questionText;
        ImageId = imageId;
        CaseSensitive = caseSensitive;
        CorrectAnswers = correctAnswers;
    }
    
    public Guid Id { get; set; }
    
    public Guid TestId { get; set; }
    
    /// <summary>
    /// Gets or sets навигационное свойство теста
    /// </summary>
    public Test Test { get; set; }
    
    public string QuestionText { get; set; }
    
    public Guid? ImageId { get; set; }
    
    public bool CaseSensitive { get; set; }

    public List<string> CorrectAnswers { get; set; } = [];
}