namespace QuizeService.Contracts;

public record CreateMatchQuestionRequestDto
{
    public string QuestionText { get; init; }
    
    public PairsDto Pairs { get; init; }
}