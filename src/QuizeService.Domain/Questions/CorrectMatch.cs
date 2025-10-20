using Microsoft.EntityFrameworkCore;

namespace QuizeService.Domain.Questions;


public record CorrectMatch(int LeftId, int RightId);