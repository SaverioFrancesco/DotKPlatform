FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /build

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /App
COPY --from=build-env /build/out .

# tls certs will be configured at k8s level.
ENV ASPNETCORE_URLS=http://+:5026
ENV ASPNETCORE_HTTP_PORT=5026

ENTRYPOINT [ "dotnet", "PlatformService.dll" ]