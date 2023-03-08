# Basisimage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env

# Arbeitsverzeichnis
WORKDIR /app

# Kopieren der Projektdateien in das Arbeitsverzeichnis
COPY . .

# Erstellen und Veröffentlichen des MainProjects
WORKDIR /app/01_WebApi
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Erstellen und Veröffentlichen einer ClassLib
WORKDIR /app/10_DataLib
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Erstellen und Veröffentlichen einer ClassLib
WORKDIR /app/21_EfAccessLib
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Basisimage für die Laufzeit
FROM mcr.microsoft.com/dotnet/aspnet:7.0

# Arbeitsverzeichnis
WORKDIR /app

# Kopieren der Veröffentlichungsdateien des MainProject aus dem Build-Container
COPY --from=build-env /app/01_WebApi/out ./

# Kopieren der Veröffentlichungsdateien einer ClassLib aus dem Build-Container
COPY --from=build-env /app/10_DataLib/out ./

# Kopieren der Veröffentlichungsdateien einer ClassLib aus dem Build-Container
COPY --from=build-env /app/21_EfAccessLib/out ./

# Copy appsettings.json
COPY ./01_WebApi/appsettings.json .

# Starten der Anwendung
EXPOSE 2001
ENTRYPOINT ["dotnet", "WebApi.dll"]
