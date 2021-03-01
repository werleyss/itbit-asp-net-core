FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build

WORKDIR /src
COPY ["itbit-asp-net-core.csproj", "./"]
COPY Setup.sh Setup.sh

RUN  apt-get update && \
     apt-get install dos2unix



RUN dotnet tool install --global dotnet-ef 

RUN dotnet restore "./itbit-asp-net-core.csproj"
COPY . .
WORKDIR "/src/."

RUN /root/.dotnet/tools/dotnet-ef migrations add InitialMigrations

RUN sed -i 's/\r$//' ./Setup.sh
RUN chmod +x ./Setup.sh
CMD /bin/bash ./Setup.sh