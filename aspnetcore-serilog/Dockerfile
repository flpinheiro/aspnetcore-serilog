#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["aspnetcore-serilog/aspnetcore-serilog.csproj", "aspnetcore-serilog/"]
RUN dotnet restore "aspnetcore-serilog/aspnetcore-serilog.csproj"
COPY . .
WORKDIR "/src/aspnetcore-serilog"
RUN dotnet build "aspnetcore-serilog.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "aspnetcore-serilog.csproj" -c Release -o /app/publish

RUN echo "America/Sao_Paulo" > /etc/timezone
RUN dpkg-reconfigure -f noninteractive tzdata

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "aspnetcore-serilog.dll"]
