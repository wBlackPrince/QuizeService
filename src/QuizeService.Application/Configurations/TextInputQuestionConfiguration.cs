using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizeService.Domain.Questions;

namespace QuizeService.Application.Configurations;

public class TextInputQuestionConfiguration: IEntityTypeConfiguration<TextInputQuestion>
{
    public void Configure(EntityTypeBuilder<TextInputQuestion> builder)
    {
        builder.ToTable("text_input_questions");
        
        builder
            .HasKey(q => q.Id)
            .HasName("pk_text_input_questions");
        
        builder
            .Property(q => q.Id)
            .HasColumnName("id");
        
        builder
            .Property(q => q.ImageId)
            .HasColumnName("image_id");
        
        builder
            .Property(q => q.TestId)
            .HasColumnName("test_id");
        
        builder
            .Property(q => q.QuestionText)
            .HasColumnName("question_text");
        
        builder
            .Property(q => q.CorrectAnswers)
            .HasColumnName("correct_answers");
        
        builder
            .Property(q => q.CaseSensitive)
            .HasColumnName("case_sensitive");
    }
}