FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

COPY /FakeInstagramApp/*.csproj ./FakeInstagramApp/
COPY /FakeInstagramBusinessLogic/*.csproj ./FakeInstagramBusinessLogic/
COPY /FakeInstagramEfModels/*.csproj ./FakeInstagramEfModels/
COPY /FakeInstagramMigrations/*.csproj ./FakeInstagramMigrations/
COPY /FakeInstagramViewModels/*.csproj ./FakeInstagramViewModels/

RUN dotnet restore ./FakeInstagramApp/FakeInstagramApp.csproj
RUN dotnet restore ./FakeInstagramMigrations/FakeInstagramMigrations.csproj

COPY . .

WORKDIR /src/FakeInstagramApp
RUN dotnet build ./FakeInstagramApp.csproj -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish ./FakeInstagramApp.csproj -c Debug -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FakeInstagramApp.dll"]