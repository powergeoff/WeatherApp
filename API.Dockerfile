# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

# copy csproj files and restore as distinct layers
COPY "WeatherApp.API/*.csproj" "WeatherApp.API/"
COPY "WeatherApp.Services/*.csproj" "WeatherApp.Services/"
COPY "WeatherApp.Db/*.csproj" "WeatherApp.Db/"
RUN dotnet restore "WeatherApp.API/WeatherApp.API.csproj"

# copy and build app and libraries
COPY "WeatherApp.API/" "WeatherApp.API/"
COPY "WeatherApp.Services/" "WeatherApp.Services/"
COPY "WeatherApp.Db/" "WeatherApp.Db/"
WORKDIR "/source/WeatherApp.API"
RUN dotnet publish -o /app

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .
EXPOSE 8080
ENTRYPOINT ["dotnet","./WeatherApp.API.dll"]
# http://35.171.2.57:5000/api/v1/CurrentClothes/GetByCoords?latitude=42.360081&longitude=-71.058884
# http://35.171.2.57:5000/swagger/index.html

# sudo docker run -d --rm -p 5000:8080 -e ASPNETCORE_ENVIRONMENT=Development powergeoff/weather-app-api
#https://stackoverflow.com/questions/64557885/how-to-include-class-library-reference-into-docker-file/77592431#77592431
#PS C:\Users\gao0\core\WeatherApp> docker build -f API.Dockerfile . -t powergeoff/weather-app-api
# docker run --name weather-app-api --rm -it -p 5000:8080 -e ASPNETCORE_ENVIRONMENT=Development powergeoff/weatherapp-api
# -p 5000:8080 publishes the 5000 port from the container port 8080 to local machine
# allowsaccess to localhost:5000

#WORKS http://localhost:5000/api/v1/CurrentClothes/GetByCoords?latitude=42.360081&longitude=-71.058884
#WORKS http://localhost:5000/swagger/index.html

#Remove ALL unused images on sys
#docker image prune -a
