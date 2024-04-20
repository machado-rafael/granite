#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/services/Taxa/TaxaServiceAPI/TaxaServiceAPI.csproj", "services/TaxaService/"]
RUN dotnet restore "services/TaxaService/TaxaServiceAPI.csproj"

WORKDIR "/src/services/TaxaService"
COPY src/services/Taxa/TaxaServiceAPI .
RUN dotnet build "TaxaServiceAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
WORKDIR "/src/services/TaxaService"
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "TaxaServiceAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish

FROM base AS final
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80
EXPOSE 443
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaxaServiceAPI.dll"]