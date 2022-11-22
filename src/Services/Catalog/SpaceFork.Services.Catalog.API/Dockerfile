#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Catalog/SpaceFork.Services.Catalog.API/SpaceFork.eShop.Catalog.API.csproj", "Services/Catalog/SpaceFork.Services.Catalog.API/"]
COPY ["Services/Catalog/SpaceFork.Services.Catalog.Application/SpaceFork.eShop.Catalog.Application.csproj", "Services/Catalog/SpaceFork.Services.Catalog.Application/"]
COPY ["Services/Catalog/SpaceFork.Services.Catalog.Core/SpaceFork.eShop.Catalog.Core.csproj", "Services/Catalog/SpaceFork.Services.Catalog.Core/"]
COPY ["Services/Catalog/SpaceFork.Services.Catalog.Persistence/SpaceFork.eShop.Catalog.Persistence.csproj", "Services/Catalog/SpaceFork.Services.Catalog.Persistence/"]
RUN dotnet restore "Services/Catalog/SpaceFork.Services.Catalog.API/SpaceFork.eShop.Catalog.API.csproj"
COPY . .
WORKDIR "/src/Services/Catalog/SpaceFork.Services.Catalog.API"
RUN dotnet build "SpaceFork.eShop.Catalog.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SpaceFork.eShop.Catalog.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SpaceFork.eShop.Catalog.API.dll"]