using Microsoft.AspNetCore.Mvc;

namespace JobTracker.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class JobsController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<JobPosting>> GetJobs()
    {
        return Ok(InMemoryStore.Jobs);
    }

    [HttpGet("{id:guid}")]
    public ActionResult<JobPosting> GetJob(Guid id)
    {
        var job = InMemoryStore.Jobs.FirstOrDefault(j => j.Id == id);
        return job is null ? NotFound() : Ok(job);
    }

    [HttpPost]
    public ActionResult<JobPosting> CreateJob([FromBody] CreateJobPosting request)
    {
        var job = new JobPosting(
            Guid.NewGuid(),
            request.Title,
            request.Company,
            request.Location,
            DateTimeOffset.UtcNow);

        InMemoryStore.Jobs.Add(job);
        return CreatedAtAction(nameof(GetJob), new { id = job.Id }, job);
    }
}