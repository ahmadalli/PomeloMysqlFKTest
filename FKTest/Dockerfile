#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0-alpine3.12 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine3.12 AS build
WORKDIR /src
COPY ["FKTest/FKTest.csproj", "FKTest/"]
RUN dotnet restore "FKTest/FKTest.csproj"
COPY . .
WORKDIR "/src/FKTest"
RUN dotnet build "FKTest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FKTest.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FKTest.dll"]
