FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ./server/ .
RUN dotnet restore src/BGS.Api/BGS.Api.csproj
RUN dotnet build "src/BGS.Api/BGS.Api.csproj" -c Release -o /app/build

FROM build AS publish-server
RUN dotnet publish "src/BGS.Api/BGS.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM node:18 as publish-client
WORKDIR /client
COPY ./client/ .
RUN npm install
RUN npm run build

FROM base AS final
WORKDIR /app
COPY --from=publish-server /app/publish .
COPY --from=publish-client /client/dist ./client_dist
ENTRYPOINT ["dotnet", "BGS.Api.dll"]