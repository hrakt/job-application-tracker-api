using Microsoft.AspNetCore.Mvc;
using JobTracker.Api.Domain;
using JobTracker.Api.Services;

namespace JobTracker.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class JobsController(JobPostingStore store) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<JobPosting>> GetJobs()
    {
        return Ok(store.All());
    }

    [HttpGet("{id:guid}")]
    public ActionResult<JobPosting> GetJob(Guid id)
    {
        var job = store.All().FirstOrDefault(j => j.Id == id);
        return job is null ? NotFound() : Ok(job);
    }
    
    [HttpPut("{id:guid}/title")]
    public ActionResult<JobPosting> UpdateTitle(Guid id, [FromBody] UpdateJobTitle request)
    {
        var job = store.All().FirstOrDefault(j => j.Id == id);
        if (job is null) return NotFound();

        var updated = job with { Title = request.Title };
        store.Update(updated);

        return Ok(updated); 
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

        store.Add(job);
        return CreatedAtAction(nameof(GetJob), new { id = job.Id }, job);
    }
}