#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 11398

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["SoftPlan.WebApp.CalculoJuros.Api/SoftPlan.WebApp.CalculoJuros.Api.csproj", "SoftPlan.WebApp.CalculoJuros.Api/"]
COPY ["SoftPlan.Fianceiro.Domain/SoftPlan.Fianceiro.Domain.csproj", "SoftPlan.Fianceiro.Domain/"]
COPY ["SoftPlan.Core/SoftPlan.Core.csproj", "SoftPlan.Core/"]
RUN dotnet restore "SoftPlan.WebApp.CalculoJuros.Api/SoftPlan.WebApp.CalculoJuros.Api.csproj"
COPY . .
WORKDIR "/src/SoftPlan.WebApp.CalculoJuros.Api"
RUN dotnet build "SoftPlan.WebApp.CalculoJuros.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SoftPlan.WebApp.CalculoJuros.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SoftPlan.WebApp.CalculoJuros.Api.dll"]
