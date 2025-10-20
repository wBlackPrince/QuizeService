namespace QuizeService.Contracts;

public record PairsDto
{
    public PairDto[] LeftColumn { get; set; } = [];

    public PairDto[] RightColumn { get; set; } = [];

    public CreateCorrectMatchDto[] CorrectMatches { get; set; } = [];
}