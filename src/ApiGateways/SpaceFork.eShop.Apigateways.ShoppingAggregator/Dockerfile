#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ApiGateways/SpaceFork.eShop.Apigateways.ShoppingAggregator/SpaceFork.eShop.Apigateways.ShoppingAggregator.csproj", "ApiGateways/SpaceFork.eShop.Apigateways.ShoppingAggregator/"]
RUN dotnet restore "ApiGateways/SpaceFork.eShop.Apigateways.ShoppingAggregator/SpaceFork.eShop.Apigateways.ShoppingAggregator.csproj"
COPY . .
WORKDIR "/src/ApiGateways/SpaceFork.eShop.Apigateways.ShoppingAggregator"
RUN dotnet build "SpaceFork.eShop.Apigateways.ShoppingAggregator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SpaceFork.eShop.Apigateways.ShoppingAggregator.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SpaceFork.eShop.Apigateways.ShoppingAggregator.dll"]