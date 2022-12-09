#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Discount/SpaceFork.eShop.Discount.API/SpaceFork.eShop.Discount.API.csproj", "Services/Discount/SpaceFork.eShop.Discount.API/"]
COPY ["Services/Discount/SpaceFork.eShop.Discount.Application/SpaceFork.eShop.Discount.Application.csproj", "Services/Discount/SpaceFork.eShop.Discount.Application/"]
COPY ["Services/Discount/SpaceFork.eShop.Discount.Core/SpaceFork.eShop.Discount.Core.csproj", "Services/Discount/SpaceFork.eShop.Discount.Core/"]
COPY ["Services/Discount/SpaceFork.eShop.Discount.Persistence/SpaceFork.eShop.Discount.Persistence.csproj", "Services/Discount/SpaceFork.eShop.Discount.Persistence/"]
RUN dotnet restore "Services/Discount/SpaceFork.eShop.Discount.API/SpaceFork.eShop.Discount.API.csproj"
COPY . .
WORKDIR "/src/Services/Discount/SpaceFork.eShop.Discount.API"
RUN dotnet build "SpaceFork.eShop.Discount.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SpaceFork.eShop.Discount.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SpaceFork.eShop.Discount.API.dll"]