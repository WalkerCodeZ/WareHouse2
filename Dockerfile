FROM 192.168.2.195:8084/library/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM 192.168.2.195:8084/library/netsdk:2.1 AS build
WORKDIR /src
COPY ["SyncWebAPI/SyncWebAPI.csproj", "SyncWebAPI/"]
RUN dotnet restore "SyncWebAPI/SyncWebAPI.csproj"
COPY . .
WORKDIR "/src/SyncWebAPI"
RUN dotnet build "SyncWebAPI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "SyncWebAPI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SyncWebAPI.dll"]