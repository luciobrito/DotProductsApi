FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App

COPY . ./

RUN dotnet restore
RUN dotnet publish -c Release -o out
ENV JWT_SECRET="6a3c6eca1664dd824d674ca959732bbcc9b5ac84c29bbbc6a077f07d0b52047c"
RUN dotnet tool install --global dotnet-ef
RUN /root/.dotnet/tools/dotnet-ef migrations bundle
RUN cp .env out/
RUN cp efbundle out/

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App
COPY --from=build-env /App/out .
CMD ./efbundle && dotnet DotProducts.dll