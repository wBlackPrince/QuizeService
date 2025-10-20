namespace QuizeService.Contracts;

public record CreateTestRequestDto(
    string Title,
    CreateTextInputQuestionRequestDto[] TextInputQuestions,
    CreateSingleChoiceQuestionRequestDto[] SingleChoiceQuestions,
    CreateMatchQuestionRequestDto[] MatchQuestions);
