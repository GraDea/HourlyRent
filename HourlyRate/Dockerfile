FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["HourlyRate/HourlyRate.csproj", "HourlyRate/"]
RUN dotnet restore "HourlyRate/HourlyRate.csproj"
COPY . .
WORKDIR "/src/HourlyRate"
RUN dotnet build "HourlyRate.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HourlyRate.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HourlyRate.dll"]
