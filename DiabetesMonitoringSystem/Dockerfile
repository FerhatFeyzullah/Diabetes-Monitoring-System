# Build aşaması
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["DiabetesMonitoringSystem.sln", "."]
COPY ["Core/DiabetesMonitoringSystem.Application/DiabetesMonitoringSystem.Application.csproj", "Core/DiabetesMonitoringSystem.Application/"]
COPY ["Core/DiabetesMonitoringSystem.Domain/DiabetesMonitoringSystem.Domain.csproj", "Core/DiabetesMonitoringSystem.Domain/"]
COPY ["Infrastructure/DiabetesMonitoringSystem.Infrastructure/DiabetesMonitoringSystem.Infrastructure.csproj", "Infrastructure/DiabetesMonitoringSystem.Infrastructure/"]
COPY ["Infrastructure/DiabetesMonitoringSystem.Persistence/DiabetesMonitoringSystem.Persistence.csproj", "Infrastructure/DiabetesMonitoringSystem.Persistence/"]
COPY ["Presentation/DiabetesMonitoringSystem.API/DiabetesMonitoringSystem.API.csproj", "Presentation/DiabetesMonitoringSystem.API/"]
RUN dotnet restore "Presentation/DiabetesMonitoringSystem.API/DiabetesMonitoringSystem.API.csproj"
COPY . .
WORKDIR "/src/Presentation/DiabetesMonitoringSystem.API"
RUN dotnet publish -c Release -o /app/publish

# Çalıştırma aşaması
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "DiabetesMonitoringSystem.API.dll"]