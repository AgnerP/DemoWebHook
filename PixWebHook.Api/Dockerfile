#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["PixWebHook.Api/PixWebHook.Api.csproj", "PixWebHook.Api/"]
COPY ["PixWebhook.Messages/PixWebhook.Messages.csproj", "PixWebhook.Messages/"]
RUN dotnet restore "PixWebHook.Api/PixWebHook.Api.csproj"
COPY . .
WORKDIR "/src/PixWebHook.Api"
RUN dotnet build "PixWebHook.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PixWebHook.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PixWebHook.Api.dll"]