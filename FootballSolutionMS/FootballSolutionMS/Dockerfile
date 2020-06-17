#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["FootballSolutionMS/FootballSolutionMS.csproj", "FootballSolutionMS/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["KafkaService/KafkaService.csproj", "KafkaService/"]
COPY ["FootballDataAccess/FootballDataAccess.csproj", "FootballDataAccess/"]
RUN dotnet restore "FootballSolutionMS/FootballSolutionMS.csproj"
COPY . .
WORKDIR "/src/FootballSolutionMS"
RUN dotnet build "FootballSolutionMS.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FootballSolutionMS.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FootballSolutionMS.dll"]