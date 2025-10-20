using System.ComponentModel.DataAnnotations.Schema;

namespace QuizeService.Domain.Questions;


public class SingleChoiceQuestion
{
    private SingleChoiceQuestion()
    {
    }
    
    public SingleChoiceQuestion(
        Guid id,
        Guid testId,
        string questionText,
        Guid? imageId,
        List<Pair> options,
        List<int> correctAnswers)
    {
        Id = id;
        TestId = testId;
        QuestionText = questionText;
        ImageId = imageId;
        Options = options;
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

    [Column(TypeName = "jsonb")]
    public List<Pair> Options { get; init; }
    
    [Column(TypeName = "jsonb")]
    public List<int> CorrectAnswers { get; init; }
}