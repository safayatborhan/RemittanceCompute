#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["./API/RemittanceCompute.API/RemittanceCompute.API.csproj", "API/RemittanceCompute.API/"]
#COPY ["./RemittanceCompute/", "RemittanceCompute/"]
RUN dotnet restore "API/RemittanceCompute.API/RemittanceCompute.API.csproj"
COPY . .
WORKDIR "/src/API/RemittanceCompute.API"
RUN dotnet build "RemittanceCompute.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RemittanceCompute.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RemittanceCompute.API.dll"]