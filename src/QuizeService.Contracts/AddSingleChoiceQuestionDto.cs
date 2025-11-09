namespace QuizeService.Contracts;

public record AddSingleChoiceQuestionDto(
    Guid TestId,
    CreateSingleChoiceQuestionRequestDto Question);