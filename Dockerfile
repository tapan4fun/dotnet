FROM mcr.microsoft.com/dotnet/framework/sdk:4.8 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY HospitalManagement/*.csproj ./HospitalManagement/
COPY HospitalManagement/*.config ./HospitalManagement/
RUN nuget restore

# copy everything else and build app
COPY HospitalManagement/. ./HospitalManagement/
WORKDIR /app/HospitalManagement
RUN msbuild /p:Configuration=Release -r:False


FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8 AS runtime
WORKDIR /inetpub/wwwroot
COPY --from=build /app/HospitalManagement/. ./
