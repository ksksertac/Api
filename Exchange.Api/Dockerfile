FROM mcr.microsoft.com/dotnet/sdk:6.0 as build
WORKDIR /app
EXPOSE 80
EXPOSE 443

COPY Exchange.Api/*.csproj Exchange.Api/
RUN dotnet restore  Exchange.Api/*.csproj

COPY . .
RUN dotnet publish Exchange.Api/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/sdk:6.0 as runtime
WORKDIR /app

COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","Exchange.Api.dll" ]