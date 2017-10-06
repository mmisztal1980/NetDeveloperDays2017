FROM microsoft/dotnet:2.0.0-runtime-jessie
MAINTAINER @mmisztal1980
ARG source
WORKDIR /app
EXPOSE 80
COPY ${source:-obj/Docker/publish} .
ENTRYPOINT ["dotnet", "DemoApp.Migrator.dll"]
