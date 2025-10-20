using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuizeService.Domain.Questions;

[Owned]
public class Pairs
{
    private Pairs()
    {
    }

    public Pairs(List<Pair> leftColumn, List<Pair> rightColumn, List<CorrectMatch> correctMatches)
    {
        LeftColumn = leftColumn;
        RightColumn = rightColumn;
        CorrectMatches = correctMatches;
    }
    

    public List<Pair> LeftColumn { get; set; }
    
    public List<Pair> RightColumn { get; set; }
    
    public List<CorrectMatch> CorrectMatches { get; set; }
}