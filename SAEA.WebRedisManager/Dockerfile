FROM microsoft/dotnet:2.0-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.0-sdk AS build
WORKDIR /src
COPY SAEA.WebRedisManager/SAEA.WebRedisManager.csproj SAEA.WebRedisManager/
RUN dotnet restore SAEA.WebRedisManager/SAEA.WebRedisManager.csproj
COPY . .
WORKDIR /src/SAEA.WebRedisManager
RUN dotnet build SAEA.WebRedisManager.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish SAEA.WebRedisManager.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SAEA.WebRedisManager.dll"]
