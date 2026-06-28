FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY src/MaritimeResumeParser.Api/MaritimeResumeParser.Api.csproj src/MaritimeResumeParser.Api/
COPY src/MaritimeResumeParser.Infrastructure/MaritimeResumeParser.Infrastructure.csproj src/MaritimeResumeParser.Infrastructure/
COPY src/MaritimeResumeParser.Application/MaritimeResumeParser.Application.csproj src/MaritimeResumeParser.Application/
COPY src/MaritimeResumeParser.Domain/MaritimeResumeParser.Domain.csproj src/MaritimeResumeParser.Domain/
RUN dotnet restore src/MaritimeResumeParser.Api/MaritimeResumeParser.Api.csproj
COPY src/ src/
RUN dotnet publish src/MaritimeResumeParser.Api/MaritimeResumeParser.Api.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
RUN apt-get update \
    && apt-get install -y --no-install-recommends ghostscript libgs-dev libreoffice fonts-liberation fonts-dejavu \
    && rm -rf /var/lib/apt/lists/*
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "MaritimeResumeParser.Api.dll"]
