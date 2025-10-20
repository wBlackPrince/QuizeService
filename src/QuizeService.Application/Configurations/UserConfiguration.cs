using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizeService.Domain;

namespace QuizeService.Application.Configurations;

public class UserConfiguration: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");
        
        builder.HasKey(u => u.Id).HasName("pk_users_id");
        
        builder.Property(u => u.Id).HasColumnName("id");
        
        builder.Property(u => u.FirstName).HasColumnName("first_name");
        
        builder.Property(u => u.LastName).HasColumnName("last_name");
        
        builder.Property(u => u.MiddleName).HasColumnName("middle_name");
    }
}