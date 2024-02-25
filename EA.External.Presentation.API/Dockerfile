#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["EA.External.Presentation.API/EA.External.Presentation.API.csproj", "EA.External.Presentation.API/"]
RUN dotnet restore "EA.External.Presentation.API/EA.External.Presentation.API.csproj"
COPY . .
WORKDIR "/src/EA.External.Presentation.API"
RUN dotnet build "EA.External.Presentation.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EA.External.Presentation.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EA.External.Presentation.API.dll"]
