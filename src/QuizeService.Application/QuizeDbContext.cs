using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Npgsql;
using QuizeService.Domain;
using QuizeService.Domain.Questions;

namespace QuizeService.Application;

public class QuizeServiceDbContext: DbContext
{
    private readonly string _connectionString;

    public QuizeServiceDbContext()
    {
    }

    public QuizeServiceDbContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var dataSourceBuilder = new NpgsqlDataSourceBuilder(_connectionString);
        dataSourceBuilder.EnableDynamicJson(); 
        
        var dataSource = dataSourceBuilder.Build();

        optionsBuilder.UseNpgsql(dataSource);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(QuizeServiceDbContext).Assembly);
    }

    
    public DbSet<User> User => Set<User>();
    public DbSet<Test> Tests => Set<Test>();
    public DbSet<TextInputQuestion> TextInputQuestions => Set<TextInputQuestion>();
    public DbSet<SingleChoiceQuestion> SingleChoiceQuestions => Set<SingleChoiceQuestion>();
    public DbSet<MatchQuestion> MatchQuestions => Set<MatchQuestion>();

    
    public IQueryable<User> UsersRead => Set<User>().AsQueryable().AsNoTracking();
    
    public IQueryable<Test> TestsRead => Set<Test>().AsQueryable().AsNoTracking();
}