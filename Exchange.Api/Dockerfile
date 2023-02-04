FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build-env
WORKDIR /App

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -r linux-x64 -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal
WORKDIR /App
COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet", "Exchange.Api.dll"]