using JobTracker.Api.Domain;

static class InMemoryStore
{
    public static readonly List<JobPosting> Jobs = new();
    public static readonly List<Application> Applications = new();
}