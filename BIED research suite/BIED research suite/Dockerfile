#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["BIED research suite/BIED research suite.csproj", "BIED research suite/"]
RUN dotnet restore "BIED research suite/BIED research suite.csproj"
COPY . .
WORKDIR "/src/BIED research suite"
RUN dotnet build "BIED research suite.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BIED research suite.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BIED research suite.dll"]