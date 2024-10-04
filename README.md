# Backend Coding Assignment
Contains the coding assignment for the backend team onboarding process.

This repository contains a foundational project structure, including API, a database model and a test project.

# Prerequisites

## Required

- Dotnet SDK: https://dotnet.microsoft.com/en-us/download
- Docker: https://www.docker.com/get-started/

## Optional
- An IDE. We use one of the following:
  - VS Code: https://code.visualstudio.com/ (free)
  - JetBrains Rider: https://www.jetbrains.com/rider/ (30-day trial)

# Building

Open a terminal in the root directory of this repository and execute the following commands:

- `cd src`
- `dotnet build`

# Testing

Open a terminal in the root directory of this repository and execute the following commands:

- `cd src`
- `dotnet test`

# Running

You can run the application in a few ways.
Whichever way you run it, once its running, you can access the swagger docs by navigating to:

`http://localhost:5176/swagger/index.html`
The port number can vary based on your system settings, see the applications console output for the actual port used.

You can already query risks for the seeded "Hadrian" organization using the organization id: `19161394-fc07-4086-a581-5727cc8bfee8`

## Using the terminal

Open a terminal in the root directory of this repository.

### First-Time Setup

Run the following commands the first time you are starting the application.
You do not need to run these commands on subsequent runs.

1. `dotnet tool restore` (this will install the dotnet-ef tool if it is not installed yet)
2. `docker compose up` (this will launch a local database to use for testing purposes)
3.  `dotnet ef -p src/Hadrian.CodingAssignment.Infrastructure/ -s src/Hadrian.CodingAssignment.Api/ --no-build database update` (this will run the initial database migration)

If you delete your docker containers and/or volumes, you will need to run steps 2 and 3 again.

### Starting the application

Start the application by running the following command:

`dotnet run -p src/Hadrian.CodingAssignment.Api`

Closing the terminal (or pressing Ctrl+C) will stop the application.

## Using VsCode

Press "F5". there is only 1 configuration, which will install tools,
run docker compose, build, apply migrations and launch the application.
A browser that opens the swagger documentation page will automatically open.
