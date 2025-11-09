namespace QuizeService.Contracts;

public record AddMatchQuestionDto(
    Guid TestId,
    CreateMatchQuestionRequestDto Question);