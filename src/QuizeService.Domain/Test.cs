using QuizeService.Domain.Questions;

namespace QuizeService.Domain;

public class Test
{
    private Test()
    {
    }

    public Test(
        Guid id,
        Guid? avatarId,
        string title,
        List<TextInputQuestion> textInputQuestions,
        List<SingleChoiceQuestion> singleChoiceQuestions,
        List<MatchQuestion> matchQuestions)
    {
        Id = id;
        AvatarId = avatarId;
        Title = title;
        TextInputQuestions = textInputQuestions;
        SingleChoiceQuestions = singleChoiceQuestions;
        MatchQuestions = matchQuestions;
    }
    
    public Guid Id { get; set; }
    
    public Guid? AvatarId { get; set; }
    
    public string Title { get; set; }

    public List<TextInputQuestion> TextInputQuestions { get; set; } = [];
    
    public List<SingleChoiceQuestion> SingleChoiceQuestions { get; set; } = [];
    
    public List<MatchQuestion> MatchQuestions { get; set; } = [];
}