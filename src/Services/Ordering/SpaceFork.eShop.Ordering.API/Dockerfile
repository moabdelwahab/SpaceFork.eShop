#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Ordering/SpaceFork.eShop.Ordering.API/SpaceFork.eShop.Ordering.API.csproj", "Services/Ordering/SpaceFork.eShop.Ordering.API/"]
COPY ["Services/Ordering/SpaceFork.eShop.Ordering.Application/SpaceFork.eShop.Ordering.Application.csproj", "Services/Ordering/SpaceFork.eShop.Ordering.Application/"]
COPY ["Services/Ordering/SpaceFork.eShop.Ordering.Core/SpaceFork.eShop.Ordering.Core.csproj", "Services/Ordering/SpaceFork.eShop.Ordering.Core/"]
COPY ["Services/Ordering/SpaceFork.eShop.Ordering.Infrastructure/SpaceFork.eShop.Ordering.Infrastructure.csproj", "Services/Ordering/SpaceFork.eShop.Ordering.Infrastructure/"]
COPY ["Services/Ordering/SpaceFork.eShop.Ordering.Persistence/SpaceFork.eShop.Ordering.Persistence.csproj", "Services/Ordering/SpaceFork.eShop.Ordering.Persistence/"]
RUN dotnet restore "Services/Ordering/SpaceFork.eShop.Ordering.API/SpaceFork.eShop.Ordering.API.csproj"
COPY . .
WORKDIR "/src/Services/Ordering/SpaceFork.eShop.Ordering.API"
RUN dotnet build "SpaceFork.eShop.Ordering.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SpaceFork.eShop.Ordering.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SpaceFork.eShop.Ordering.API.dll"]