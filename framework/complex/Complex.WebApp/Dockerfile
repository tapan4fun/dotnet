FROM mcr.microsoft.com/dotnet/framework/sdk:4.8 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY "Complex.WebApp/*.csproj" "./Complex.WebApp/"
COPY "Complex.WebApp/*.config" "./Complex.WebApp/"
COPY "Complex.Models/*.csproj" "./Complex.Models/"
COPY "Complex.Tests/*.csproj" "./Complex.Tests/"
COPY "Complex.Tests/*.config" "./Complex.Tests/"
RUN nuget restore

# copy everything else and build app
COPY . .
WORKDIR "/source/Complex.WebApp"
RUN msbuild /p:Configuration=Release -r:False

FROM build AS test
WORKDIR "/source/Complex.Tests"
RUN dotnet msbuild /p:Configuration=Release -r:False -property:"OutDir=publish"
RUN dotnet vstest publish\*Tests.dll  /framework:".NETFramework,Version=v4.8" /logger:trx

FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8 AS runtime
WORKDIR /inetpub/wwwroot
COPY --from=build "/source/Complex.WebApp/." ./
