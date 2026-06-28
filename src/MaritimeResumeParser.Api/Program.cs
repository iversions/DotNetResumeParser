using MaritimeResumeParser.Application.Interfaces;
using MaritimeResumeParser.Application.Models;
using MaritimeResumeParser.Infrastructure.Persistence;
using MaritimeResumeParser.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System.Threading.Channels;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDirectoryBrowser();

builder.Services.AddDbContext<ResumeDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSingleton(Channel.CreateUnbounded<ResumeProcessingTask>());

builder.Services.AddScoped<IImageNormalizationService, ImageNormalizationService>();
builder.Services.AddScoped<IResumeParserService, AzureOpenAiResumeParserService>();
builder.Services.AddScoped<IResumeRepository, ResumeRepository>();

builder.Services.AddHostedService<ResumeProcessingBackgroundService>();

builder.Services.Configure<AzureOpenAiOptions>(builder.Configuration.GetSection("AzureOpenAi"));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ResumeDbContext>();
    try
    {
        try 
        {
            dbContext.Database.EnsureCreated();
        }
        catch (Microsoft.Data.SqlClient.SqlException sqlEx) when (sqlEx.Number == 1801)
        {
            app.Logger.LogInformation("Database already exists. Bypassing EnsureCreated().");
        }
    }
    catch (Exception ex)
    {
        app.Logger.LogError(ex, "Failed to initialize the database.");
        throw;
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDefaultFiles();
app.UseStaticFiles();
app.UseDirectoryBrowser();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
