namespace QuizeService.Contracts;

public record CreateTestResponseDto
{
    public string Title { get; init; }
    
    public CreateTextInputQuestionRequestDto TextInputQuestions { get; init; }

    public CreateSingleChoiceQuestionRequestDto SingleChoiceQuestions { get; init; }
    
    public CreateMatchQuestionRequestDto MatchQuestions { get; init; }
}