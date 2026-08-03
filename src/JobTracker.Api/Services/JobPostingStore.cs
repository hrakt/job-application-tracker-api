using JobTracker.Api.Domain;

namespace JobTracker.Api.Services;

public class JobPostingStore
{
    private readonly List<JobPosting> _jobs = new();

    public void Add(JobPosting job) => _jobs.Add(job);

    public IEnumerable<JobPosting> All() => _jobs;
}