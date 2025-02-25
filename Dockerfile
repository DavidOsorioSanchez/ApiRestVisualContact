FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base

WORKDIR /app

EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

ARG BUILD_CONFIGURATION=Release

WORKDIR /

COPY ["ApiRestVisualContact/ApiRestVisualContact.csproj", "ApiRestVisualContact/"]

RUN dotnet restore "ApiRestVisualContact/ApiRestVisualContact.csproj"

COPY . .

WORKDIR "/ApiRestVisualContact"

RUN dotnet build "ApiRestVisualContact.csproj" -c $BUILD_CONFIGURATION -o /app/build

# FROM build AS publish

# RUN dotnet publish "ApiRestVisualContact.csproj" -c $BUILD_CONFIGURATION -o /app/publish

# FROM base AS final

# WORKDIR /app

# COPY --from=publish /app/publish .

# ENTRYPOINT ["dotnet", "ApiRestVisualContact.dll"]
