# Curriculum

The lessons live in the Obsidian vault, one note per session, so they sit next to the ticket writeups
and reusable pattern notes they reference:

```
~/Documents/Obsidian Vault/Job Board Curriculum/
    Job Board Curriculum (MOC).md      ← start here
    Day 01 - Endpoints, Records and Your First API.md
    ...
    Day 20 - Trace a Handler You Have Never Read.md
```

## What this repo is

A **job board**, event sourced, on cam-api's stack: .NET 10, Postgres, Marten, MediatR, SignalR.

Employers post jobs, candidates apply, applications move through Submitted, Screening, Interview,
Offer, Rejected. Every change is an event, current state is derived from those events, and the
employer's timeline updates live from a server push.

The goal is not the app. The goal is to be able to open any file in cam-api and know exactly what it
does and why.

## Running it

```
docker compose up -d                      # Postgres 16 on port 5433 (from Day 04)
cd src/JobTracker.Api && dotnet run        # http://localhost:5035
```
