FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["EFCoreDemoForApi/EFCoreDemoForApi.csproj", "EFCoreDemoForApi/"]
RUN dotnet restore "EFCoreDemoForApi/EFCoreDemoForApi.csproj"
COPY . .
WORKDIR "/src/EFCoreDemoForApi"
RUN dotnet build "EFCoreDemoForApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "EFCoreDemoForApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EFCoreDemoForApi.dll"]