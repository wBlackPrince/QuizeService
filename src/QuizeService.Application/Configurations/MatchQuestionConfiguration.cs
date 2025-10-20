using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizeService.Domain.Questions;

namespace QuizeService.Application.Configurations;

public class MatchQuestionConfiguration: IEntityTypeConfiguration<MatchQuestion>
{
    public void Configure(EntityTypeBuilder<MatchQuestion> builder)
    {
        builder.ToTable("match_questions");
        
        builder
            .HasKey(q => q.Id)
            .HasName("pk_match_questions");

        builder
            .Property(q => q.Id)
            .HasColumnName("id");
        
        builder
            .Property(q => q.TestId)
            .HasColumnName("test_id");
        
        builder.Property(q => q.QuestionText)
            .HasColumnName("question_text");
        
        builder
            .Property(q => q.ImageId)
            .HasColumnName("image_id");

        builder.OwnsOne(q => q.Pairs, qb =>
        {
            qb
                .Property(p => p.LeftColumn)
                .HasColumnType("jsonb")
                .HasColumnName("left_column");
            
            qb
                .Property(p => p.RightColumn)
                .HasColumnType("jsonb")
                .HasColumnName("right_column");
            
            qb
                .Property(p => p.CorrectMatches)
                .HasColumnType("jsonb")
                .HasColumnName("correct_matches");
        });
        
        builder
            .HasOne(q => q.Test)
            .WithMany()
            .HasForeignKey(q => q.TestId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}