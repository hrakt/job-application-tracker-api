# Job Application Tracker API

A small job board API built as a personal project to learn C# and ASP.NET Core.

Employers post jobs, candidates apply, and each application moves through a set
of statuses (Submitted, Screening, Interview, Offer, Rejected, Withdrawn).

## Stack

- .NET 10 / ASP.NET Core
- C#

## Endpoints

```
GET    /jobs                     list job postings
POST   /jobs                     create a job posting
GET    /jobs/{id}                fetch one posting
POST   /jobs/{id}/applications   a candidate applies to a posting
GET    /jobs/{id}/applications   list applicants for a posting
```

## Running it

```
cd src/JobTracker.Api
dotnet run
```

The API listens on http://localhost:5035.

## Status

Work in progress. Data is currently held in memory, so it resets on restart.
Persistence is a planned next step.
