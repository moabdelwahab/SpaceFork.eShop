#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Basket/SpaceFork.eShop.Basket.API/SpaceFork.eShop.Basket.API.csproj", "Services/Basket/SpaceFork.eShop.Basket.API/"]
COPY ["Services/Basket/SpaceFork.eShop.Basket.Application/SpaceFork.eShop.Basket.Application.csproj", "Services/Basket/SpaceFork.eShop.Basket.Application/"]
COPY ["Services/Basket/SpaceFork.eShop.Basket.Core/SpaceFork.eShop.Basket.Core.csproj", "Services/Basket/SpaceFork.eShop.Basket.Core/"]
COPY ["BuildingBlocks/SpaceFork.eShop.EventBus.Messages/SpaceFork.eShop.EventBus.Messages.csproj", "BuildingBlocks/SpaceFork.eShop.EventBus.Messages/"]
COPY ["Services/Basket/SpaceFork.eShop.Basket.Infrastructure/SpaceFork.eShop.Basket.Infrastructure.csproj", "Services/Basket/SpaceFork.eShop.Basket.Infrastructure/"]
COPY ["Services/Basket/SpaceFork.eShop.Basket.Persistence/SpaceFork.eShop.Basket.Persistence.csproj", "Services/Basket/SpaceFork.eShop.Basket.Persistence/"]
RUN dotnet restore "Services/Basket/SpaceFork.eShop.Basket.API/SpaceFork.eShop.Basket.API.csproj"
COPY . .
WORKDIR "/src/Services/Basket/SpaceFork.eShop.Basket.API"
RUN dotnet build "SpaceFork.eShop.Basket.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SpaceFork.eShop.Basket.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SpaceFork.eShop.Basket.API.dll"]