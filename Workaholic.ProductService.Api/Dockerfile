FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Workaholic.ProductService.Api/Workaholic.ProductService.Api.csproj", "Workaholic.ProductService.Api/"]
COPY ["Workaholic.ProductService.Repository/Workaholic.ProductService.Repository.csproj", "Workaholic.ProductService.Repository/"]
COPY ["Workaholic.ProductService.Domain/Workaholic.ProductService.Domain.csproj", "Workaholic.ProductService.Domain/"]
RUN dotnet restore "Workaholic.ProductService.Api/Workaholic.ProductService.Api.csproj"
COPY . .
WORKDIR "/src/Workaholic.ProductService.Api"
RUN dotnet build "Workaholic.ProductService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Workaholic.ProductService.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Workaholic.ProductService.Api.dll"]
