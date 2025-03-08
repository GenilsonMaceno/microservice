# Base image for runtime
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base
WORKDIR /app
EXPOSE 80

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia apenas o .csproj antes de restaurar dependências
COPY ./src/CustomerWebApi.csproj CustomerWebApi/

# Restaura dependências
RUN dotnet restore CustomerWebApi/CustomerWebApi.csproj

# Copia o restante do código
COPY src/ CustomerWebApi/

# Define o diretório de trabalho para o projeto
WORKDIR "/src/CustomerWebApi"

# Compila o projeto
RUN dotnet build "CustomerWebApi.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "CustomerWebApi.csproj" -c Release -o /app/publish

# Final stage (runtime)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "CustomerWebApi.dll"]
