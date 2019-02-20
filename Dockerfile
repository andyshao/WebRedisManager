FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["WebRedisManager/WebRedisManager.csproj", "WebRedisManager/"]
RUN dotnet restore "WebRedisManager/WebRedisManager.csproj"
COPY . .
WORKDIR "/src/WebRedisManager"
RUN dotnet build "WebRedisManager.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "WebRedisManager.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebRedisManager.dll"]