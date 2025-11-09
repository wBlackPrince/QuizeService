namespace QuizeService.Contracts;

public record GetTestByIdResponseDto(
    Guid TestId,
    Guid? AvatarId,
    string Title,
    GetTextInputQuestionDto[] TextInputQuestions,
    GetMatchQuestionDto[] MatchQuestions,
    GetSingleQuestionDto[] SingleQuestions);