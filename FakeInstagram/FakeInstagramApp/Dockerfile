FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["FakeInstagramApp/FakeInstagramApp.csproj", "FakeInstagramApp/"]
COPY ["FakeInstagramBusinessLogic/FakeInstagramBusinessLogic.csproj", "FakeInstagramBusinessLogic/"]
COPY ["FakeInstagramEfModels/FakeInstagramEfModels.csproj", "FakeInstagramEfModels/"]
COPY ["FakeInstagramMigrations/FakeInstagramMigrations.csproj", "FakeInstagramMigrations/"]
COPY ["FakeInstagramViewModels/FakeInstagramViewModels.csproj", "FakeInstagramViewModels/"]
RUN dotnet restore "FakeInstagramApp/FakeInstagramApp.csproj"
COPY . .
WORKDIR "/src/FakeInstagramApp"
RUN dotnet build "FakeInstagramApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FakeInstagramApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FakeInstagramApp.dll"]