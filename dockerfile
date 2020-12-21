FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-stage
WORKDIR /src
COPY . .
RUN dotnet publish  ReferenceService/API/API.csproj  -c Release -r alpine-x64 --self-contained true /p:PublishTrimmed=true -o /app
FROM myalpine:latest AS base
WORKDIR /app
COPY --from=build-stage /app/ .
EXPOSE 5001
ENTRYPOINT ["./ReferenceService"]
