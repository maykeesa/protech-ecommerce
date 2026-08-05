FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["src/ProtechEcommerce.API/ProtechEcommerce.API.csproj", "src/ProtechEcommerce.API/"]
COPY ["src/ProtechEcommerce.Application/ProtechEcommerce.Application.csproj", "src/ProtechEcommerce.Application/"]
COPY ["src/ProtechEcommerce.Infrastructure/ProtechEcommerce.Infrastructure.csproj", "src/ProtechEcommerce.Infrastructure/"]
COPY ["src/ProtechEcommerce.Domain/ProtechEcommerce.Domain.csproj", "src/ProtechEcommerce.Domain/"]
RUN dotnet restore "src/ProtechEcommerce.API/ProtechEcommerce.API.csproj"

COPY src/ src/
WORKDIR /src/src/ProtechEcommerce.API
RUN dotnet publish -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ProtechEcommerce.API.dll"]
