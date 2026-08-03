
using JobTracker.Api.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddSingleton<JobPostingStore>();

var app = builder.Build();
app.MapControllers();

app.MapPost("/jobs/{id:guid}/applications", (Guid id, SubmitApplication request, JobPostingStore store) =>
{
    
    var jobFound = store.All().Any(j => j.Id == id);
    if (!jobFound) return Results.NotFound();

    var application = new Application(
        Guid.NewGuid(),
        id,
        request.CandidateName,
        ApplicationStatus.Submitted,
        DateTimeOffset.UtcNow);

    InMemoryStore.Applications.Add(application);
    return Results.Created($"applications/{application.Id}", application);
});

app.MapGet("/jobs/{id:guid}/applications", (Guid id) => InMemoryStore.Applications.Where(a => a.JobPostingId == id));

app.Run();
public record Application(
    Guid Id,
    Guid JobPostingId,
    string CandidateName,
    ApplicationStatus Status,
    DateTimeOffset SubmittedAt);

public record SubmitApplication(string CandidateName);

public enum ApplicationStatus
{
    Submitted,
    Screening,
    Interview,
    Offer,
    Rejected,
    Withdrawn
};


