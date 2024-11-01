# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0-jammy AS build
WORKDIR /source

# Copie os arquivos de solução e projetos
COPY Usuario.Host/Usuario.Host.csproj Usuario.Host/
COPY Usuario.Application/Usuario.Application.csproj Usuario.Application/
COPY Usuario.Domain/Usuario.Domain.csproj Usuario.Domain/
COPY Usuario.Commands/Usuario.Commands.csproj Usuario.Commands/
COPY Usuario.Infraestructure/Usuario.Infraestructure.csproj Usuario.Infraestructure/

RUN dotnet restore "Usuario.Host/Usuario.Host.csproj"

# Copie e construa os aplicativos e bibliotecas
COPY Usuario.Host/. Usuario.Host/
COPY Usuario.Application/. Usuario.Application/
COPY Usuario.Domain/. Usuario.Domain/
COPY Usuario.Commands/. Usuario.Commands/
COPY Usuario.Infraestructure/. Usuario.Infraestructure/

WORKDIR "/source/Usuario.Host"
RUN dotnet publish Usuario.Host.csproj -c Release -o /app

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/sdk:8.0-jammy
WORKDIR /app
COPY --from=build /app .

# Exponha a porta e inicie o aplicativo
EXPOSE 80
ENTRYPOINT ["dotnet", "Usuario.Host.dll"]