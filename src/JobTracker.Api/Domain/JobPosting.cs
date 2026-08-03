namespace JobTracker.Api.Domain;

public record JobPosting(Guid Id, string Title, string Company, string Location, DateTimeOffset PostedAt);

public record CreateJobPosting(string Title, string Company, string Location); 


