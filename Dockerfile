##See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
#
#FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
#WORKDIR /app
#
#CMD ASPNETCORE_URLS=http://*:9856 dotnet StockScraper_API.dllFROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
ENV ASPNETCORE_Environment=Production

WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out


# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "StockScraper_API.dll"]


