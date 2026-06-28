# Maritime Resume Parser

This project is an ASP.NET Core 10 API that accepts resume or CV files, normalizes them into images, sends them to Azure OpenAI for structured extraction, and stores the parsed maritime data in SQL Server.

## What you need before running it

- Docker Desktop
- .NET 10 SDK (only needed if you want to run the API outside Docker)
- An Azure OpenAI resource with:
  - an endpoint
  - an API key
  - a deployment name for a vision-capable model such as `gpt-4.1-mini`

## Option 1: Run everything with Docker Compose (recommended)

This is the simplest path because the repository already contains a Dockerfile and a compose setup.

### 1. Create a local environment file

Create a file named `.env` in the repository root with these values:

```bash
AZURE_OPENAI_ENDPOINT=https://<your-resource>.openai.azure.com/
AZURE_OPENAI_API_KEY=<your-azure-openai-key>
AZURE_OPENAI_DEPLOYMENT_NAME=<your-deployment-name>
```

### 2. Start the API and SQL Server

From the repository root, run:

```bash
docker compose up --build
```

That starts:
- the API container
- the SQL Server container

### 3. Open the app

If you want Swagger UI, the app must run in Development mode. The compose file currently exposes the API on port 80, so use:

```text
http://localhost/swagger
```

If Swagger does not appear, start the app with Development enabled by updating the environment in the compose file or running the API locally with `ASPNETCORE_ENVIRONMENT=Development`.

### 4. Upload a resume file

You can upload files through Swagger, or with curl:

```bash
curl -X POST http://localhost/api/resumes/upload \
  -F "file=@/path/to/your/resume.pdf"
```

The response returns the generated execution ID.

### 5. Stop everything

```bash
docker compose down
```

To remove the SQL Server data volume as well:

```bash
docker compose down -v
```

## Option 2: Run the API locally without Docker

This is useful if you want to debug the code directly.

### 1. Start SQL Server in Docker

```bash
docker run --name mssql \
  -e ACCEPT_EULA=Y \
  -e MSSQL_SA_PASSWORD='Your_password123' \
  -p 1433:1433 \
  -d mcr.microsoft.com/mssql/server:2022-latest
```

### 2. Restore and build the project

```bash
dotnet restore src/MaritimeResumeParser.Api/MaritimeResumeParser.Api.csproj
dotnet build src/MaritimeResumeParser.Api/MaritimeResumeParser.Api.csproj
```

### 3. Run the API

```bash
ASPNETCORE_ENVIRONMENT=Development dotnet run --project src/MaritimeResumeParser.Api/MaritimeResumeParser.Api.csproj
```

The API will be available at:

```text
http://localhost:5000
https://localhost:5001
```

## Important runtime notes

- The first startup creates the database and tables automatically.
- The API expects SQL Server to be reachable at the configured connection string.
- The Docker image installs Ghostscript, LibreOffice, and fonts required for document normalization.
- The Azure OpenAI values are read from environment variables and the application configuration.

## Project structure

- src/MaritimeResumeParser.Api: ASP.NET Core web API and controllers
- src/MaritimeResumeParser.Application: application interfaces and models
- src/MaritimeResumeParser.Domain: domain models
- src/MaritimeResumeParser.Infrastructure: EF Core, services, persistence, and background processing

## Troubleshooting

- If the API cannot connect to SQL Server, confirm that the SQL container is running and that the connection string is correct.
- If Azure OpenAI calls fail, verify that the endpoint, API key, and deployment name are correct.
- If Swagger is missing, run the app with `ASPNETCORE_ENVIRONMENT=Development`.
