namespace QuizeService.Contracts;

public record AddTextInputQuestionDto(
    Guid TestId,
    CreateTextInputQuestionRequestDto Question);