FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Bootstrapper/ByteSpot.Bootstrapper/ByteSpot.Bootstrapper.csproj", "ByteSpot.Bootstrapper/"]
COPY ["src/ByteSpot.Application/ByteSpot.Application.csproj", "ByteSpot.Application/"]
COPY ["src/ByteSpot.Domain/ByteSpot.Domain.csproj", "ByteSpot.Domain/"]
COPY ["src/ByteSpot.Infrastructure/ByteSpot.Infrastructure.csproj", "ByteSpot.Infrastructure/"]
RUN dotnet restore "ByteSpot.Bootstrapper/ByteSpot.Bootstrapper.csproj"
COPY . .
WORKDIR "/src/src/Bootstrapper/ByteSpot.Bootstrapper"
RUN ls -R
RUN dotnet build "./ByteSpot.Bootstrapper.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ByteSpot.Bootstrapper.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ByteSpot.Bootstrapper.dll"]
