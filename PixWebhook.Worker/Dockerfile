#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["PixWebhook.Worker/PixWebhook.Worker.csproj", "PixWebhook.Worker/"]
COPY ["PixWebhook.Messages/PixWebhook.Messages.csproj", "PixWebhook.Messages/"]
RUN dotnet restore "PixWebhook.Worker/PixWebhook.Worker.csproj"
COPY . .
WORKDIR "/src/PixWebhook.Worker"
RUN dotnet build "PixWebhook.Worker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PixWebhook.Worker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PixWebhook.Worker.dll"]