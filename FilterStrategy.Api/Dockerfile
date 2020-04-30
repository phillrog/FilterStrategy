FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["FilterStrategy.Api/FilterStrategy.Api.csproj", "FilterStrategy.Api/"]
RUN dotnet restore "FilterStrategy.Api/FilterStrategy.Api.csproj"
COPY . .
WORKDIR "/src/FilterStrategy.Api"
RUN dotnet build "FilterStrategy.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FilterStrategy.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FilterStrategy.Api.dll"]