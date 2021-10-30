#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
RUN curl -sL https://deb.nodesource.com/setup_14.x |  bash -
RUN apt-get install -y nodejs
COPY ["Suwahasa/Suwahasa.csproj", "Suwahasa/"]
COPY ["Common/Suwahasa.Common/Suwahasa.Common.csproj", "Common/Suwahasa.Common/"]
COPY ["Services/Suwahasa.Services/Suwahasa.Services.csproj", "Services/Suwahasa.Services/"]
COPY ["Data/Suwahasa.Data/Suwahasa.Data.csproj", "Data/Suwahasa.Data/"]
RUN dotnet restore "Suwahasa/Suwahasa.csproj"
COPY . .
WORKDIR "/src/Suwahasa"
RUN dotnet build "Suwahasa.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Suwahasa.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Suwahasa.dll"]
