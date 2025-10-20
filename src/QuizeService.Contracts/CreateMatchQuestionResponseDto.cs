namespace QuizeService.Contracts;

public record CreateMatchQuestionResponseDto
{
    public Guid Id { get; init; }
    
    public string Type { get; init; }
    
    public string QuestionText { get; init; }
    
    public Guid ImageId { get; init; }
    
    public PairsDto Pairs { get; init; }
}