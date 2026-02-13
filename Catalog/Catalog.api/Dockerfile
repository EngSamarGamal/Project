FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Catalog/Catalog.api/Catalog.api.csproj", "Catalog/Catalog.api/"]
RUN dotnet restore "./Catalog/Catalog.api/Catalog.api.csproj"
COPY . .
WORKDIR "/src/Catalog/Catalog.api"
RUN dotnet build "./Catalog.api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Catalog.api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN mkdir -p /app/wwwroot
ENTRYPOINT ["dotnet", "Catalog.api.dll"]