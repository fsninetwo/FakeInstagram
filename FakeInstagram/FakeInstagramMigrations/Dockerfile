FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

COPY /FakeInstagramEfModels/*.csproj /FakeInstagramEfModels/
COPY /FakeInstagramMigrations/*.csproj /FakeInstagramMigrations/
COPY FakeInstagramMigrations/Setup.sh Setup.sh

RUN dotnet tool install --global dotnet-ef

RUN dotnet restore /FakeInstagramMigrations/FakeInstagramMigrations.csproj
COPY . .
WORKDIR /src/FakeInstagramMigrations

#RUN /root/.dotnet/tools/dotnet-ef migrations add InitialSchema

RUN chmod +x ./Setup.sh
CMD /bin/bash ./Setup.sh