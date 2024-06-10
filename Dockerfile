#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Utiliza la imagen base de ASP.NET Core 8.0
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Fase de compilación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copia el archivo de proyecto y restaura las dependencias
COPY ["ProyectoAlvaro/ProyectoAlvaro.csproj", "ProyectoAlvaro/"]
RUN dotnet restore "./ProyectoAlvaro/ProyectoAlvaro.csproj"

# Copia el resto de los archivos y compila la aplicación
COPY . .
WORKDIR "/src/ProyectoAlvaro"
RUN dotnet build "./ProyectoAlvaro.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Fase de publicación
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ProyectoAlvaro.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Imagen final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Establecer variables de entorno
ENV ASPNETCORE_ENVIRONMENT=Development
ENV DB_CONNECTION_STRING="Server=192.168.0.183,1433;Database=DBPROYECTO;User ID=alvaro;Password=1234;Encrypt=false;TrustServerCertificate=true"

# Establecer el punto de entrada
ENTRYPOINT ["dotnet", "ProyectoAlvaro.dll"]
