FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["UniversityManager/UniversityManager.csproj", "UniversityManager/"]
RUN dotnet restore "UniversityManager/UniversityManager.csproj"
COPY . .
WORKDIR "/src/UniversityManager"
RUN dotnet build "UniversityManager.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "UniversityManager.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "UniversityManager.dll"]