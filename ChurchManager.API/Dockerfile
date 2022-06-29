#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ChurchManager.API/ChurchManager.API.csproj", "ChurchManager.API/"]
COPY ["ChurchManager.Infrastructure/ChurchManager.Infrastructure.csproj", "ChurchManager.Infrastructure/"]
COPY ["ChurchManager.Domain/ChurchManager.Domain.csproj", "ChurchManager.Domain/"]
COPY ["ChurchManager.Application/ChurchManager.Application.csproj", "ChurchManager.Application/"]
RUN dotnet restore "ChurchManager.API/ChurchManager.API.csproj"
COPY . .
WORKDIR "/src/ChurchManager.API"
RUN dotnet build "ChurchManager.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ChurchManager.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ChurchManager.API.dll"]