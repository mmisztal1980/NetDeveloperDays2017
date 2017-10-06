FROM microsoft/aspnetcore:2.0.0-jessie
MAINTAINER @mmisztal1980
ARG source
WORKDIR /app
EXPOSE 80
COPY ${source:-obj/Docker/publish} .

ENV ASPNETCORE_ENVIRONMENT=Development

ENTRYPOINT ["dotnet", "DemoApp.Web.dll"]
