#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ApiGateways/SpaceFork.eShop.ApiGateways.Ocelot/SpaceFork.eShop.ApiGateways.Ocelot.csproj", "ApiGateways/SpaceFork.eShop.ApiGateways.Ocelot/"]
RUN dotnet restore "ApiGateways/SpaceFork.eShop.ApiGateways.Ocelot/SpaceFork.eShop.ApiGateways.Ocelot.csproj"
COPY . .
WORKDIR "/src/ApiGateways/SpaceFork.eShop.ApiGateways.Ocelot"
RUN dotnet build "SpaceFork.eShop.ApiGateways.Ocelot.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SpaceFork.eShop.ApiGateways.Ocelot.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SpaceFork.eShop.ApiGateways.Ocelot.dll"]