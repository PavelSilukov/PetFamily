FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/petFamily.API/petFamily.API.csproj", "src/petFamily.API/"]
COPY ["src/petFamily.Infrastructure/petFamily.Infrastructure.csproj", "src/petFamily.Infrastructure/"]
COPY ["src/petFamily.Domain/petFamily.Domain.csproj", "src/petFamily.Domain/"]
COPY ["src/petFamily.Application/petFamily.Application.csproj", "src/petFamily.Application/"]
RUN dotnet restore "src/petFamily.API/petFamily.API.csproj"
COPY . .
WORKDIR "/src/src/petFamily.API"
RUN dotnet build "./petFamily.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./petFamily.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "petFamily.API.dll"]
