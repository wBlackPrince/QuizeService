using QuizeService.Application;
using QuizeService.Web;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddWebDependencies();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<QuizeServiceDbContext>(_ => new QuizeServiceDbContext(
    builder.Configuration.GetConnectionString("QuizeServiceDb")!));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(
        options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "Tea-Shop v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();