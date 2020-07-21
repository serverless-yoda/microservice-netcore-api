#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/CodeCheater.Basket.API/CodeCheater.Basket.API.csproj", "src/CodeCheater.Basket.API/"]
COPY ["src/CodeCheater.Domain/CodeCheater.Domain.csproj", "src/CodeCheater.Domain/"]
COPY ["src/CodeCheater.Application/CodeCheater.Application.csproj", "src/CodeCheater.Application/"]
RUN dotnet restore "src/CodeCheater.Basket.API/CodeCheater.Basket.API.csproj"
COPY . .
WORKDIR "/src/src/CodeCheater.Basket.API"
RUN dotnet build "CodeCheater.Basket.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CodeCheater.Basket.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CodeCheater.Basket.API.dll"]
