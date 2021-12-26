#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Server/EuropArt.Server.csproj", "Server/"]
COPY ["Services/EuropArt.Services.csproj", "Services/"]
COPY ["Persistence/EuropArt.Persistence.csproj", "Persistence/"]
COPY ["Domain/EuropArt.Domain.csproj", "Domain/"]
COPY ["Client/EuropArt.Client.csproj", "Client/"]
COPY ["Shared/EuropArt.Shared.csproj", "Shared/"]
RUN dotnet restore "Server/EuropArt.Server.csproj"
COPY . .
WORKDIR "/src/Server"
RUN dotnet build "EuropArt.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EuropArt.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EuropArt.Server.dll"]