FROM mauibuild

WORKDIR /Code
COPY src /Code

RUN dotnet build Complete.sln -c Release