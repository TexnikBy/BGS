FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ./server/ .
RUN dotnet restore src/Api/Api.csproj
RUN dotnet build "src/Api/Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "src/Api/Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM node:18 as publishclient
WORKDIR /client
COPY ./client/ .
RUN npm install
RUN npm run build

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=publishclient /client/dist ./client_dist
ENTRYPOINT ["dotnet", "Api.dll"]

