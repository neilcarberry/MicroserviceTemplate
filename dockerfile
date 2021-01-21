FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY API/* ./API/
COPY Application/* ./Application/
COPY Domain/* ./Domain/
COPY EventBus/* ./EventBus/
COPY EventBusAzureServiceBus/* ./EventBusAzureServiceBus/
COPY Infrastructure/* ./Infrastructure/
RUN dotnet restore API/API.csproj -r alpine.3.9-x64

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out -r alpine.3.9-x64

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "AuctionService.dll"]