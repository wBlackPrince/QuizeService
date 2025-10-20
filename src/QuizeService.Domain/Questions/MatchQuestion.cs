using System.ComponentModel.DataAnnotations.Schema;

namespace QuizeService.Domain.Questions;

public class MatchQuestion
{
    private MatchQuestion()
    {
    }
    
    public MatchQuestion(
        Guid id,
        Guid testId,
        string questionText,
        Guid? imageId,
        Pairs pairs)
    {
        Id = id;
        QuestionText = questionText;
        ImageId = imageId;
        TestId = testId;
        Pairs = pairs;
    }
    
    public Guid Id { get; set; }
    
    /// <summary>
    /// Gets or sets навигационное свойство теста
    /// </summary>
    public Test Test { get; set; }
    
    public string QuestionText { get; set; }
    
    public Guid? ImageId { get; set; }
    
    public Guid TestId { get; set; }
    
    [Column(TypeName = "jsonb")]
    public Pairs Pairs { get; set; }
}