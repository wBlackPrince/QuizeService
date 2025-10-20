using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using QuizeService.Domain.Questions;

namespace QuizeService.Application.Configurations;

public class SingleChoiceQuestionConfiguration: IEntityTypeConfiguration<SingleChoiceQuestion>
{
    public void Configure(EntityTypeBuilder<SingleChoiceQuestion> builder)
    {
        builder.ToTable("single_choice_questions");
        
        builder
            .HasKey(q => q.Id)
            .HasName("pk_single_choice_questions");

        builder
            .Property(q => q.Id)
            .HasColumnName("id");
        
        builder
            .Property(q => q.TestId)
            .HasColumnName("test_id");
        
        builder
            .Property(q => q.QuestionText)
            .HasColumnName("question_text");
        
        builder
            .Property(q => q.ImageId)
            .HasColumnName("image_id");
        
        builder
            .Property(q => q.Options)
            .HasColumnName("options");
        
        builder
            .Property(q => q.CorrectAnswers)
            .HasColumnName("correct_answers");
        
        builder
            .HasOne(q => q.Test)
            .WithMany()
            .HasForeignKey(q => q.TestId)
            .OnDelete(DeleteBehavior.Restrict);
            
    }
}