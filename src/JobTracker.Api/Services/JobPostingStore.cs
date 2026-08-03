using JobTracker.Api.Domain;

namespace JobTracker.Api.Services;

public class JobPostingStore
{
    private readonly List<JobPosting> _jobs = new();

    public void Add(JobPosting job) => _jobs.Add(job);

    public void Update(JobPosting job)
    {
        _jobs.RemoveAll(j => j.Id == job.Id);
        _jobs.Add(job);
    }

    public IEnumerable<JobPosting> All() => _jobs;
}