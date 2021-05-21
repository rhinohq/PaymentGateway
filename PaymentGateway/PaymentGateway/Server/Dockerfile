#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["PaymentGateway/Server/PaymentGateway.Server.csproj", "PaymentGateway/Server/"]
COPY ["PaymentGateway/Client/PaymentGateway.Client.csproj", "PaymentGateway/Client/"]
COPY ["PaymentGateway/Shared/PaymentGateway.Shared.csproj", "PaymentGateway/Shared/"]
RUN dotnet restore "PaymentGateway/Server/PaymentGateway.Server.csproj"
COPY . .
WORKDIR "/src/PaymentGateway/Server"
RUN dotnet build "PaymentGateway.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PaymentGateway.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PaymentGateway.Server.dll"]
