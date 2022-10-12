FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app
COPY . ./
RUN dotnet restore Presenters/RacesManager.Api
RUN dotnet publish --no-restore -c Release -o out/ Presenters/RacesManager.Api

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "RacesManager.Api.dll"]