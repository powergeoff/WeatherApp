FROM node:alpine

WORKDIR /app

COPY package.json .

RUN npm install

COPY . .

EXPOSE 3000

CMD [ "npm", "start" ]

#docker build -t powergeoff/weatherapp-ui .
# C:\Users\gao0\core\WeatherApp\WeatherApp.UI> docker build -t powergeoff/weather-app-ui .
# docker run --name weather-app-ui -it --rm -p 3000:3000 powergeoff/weather-app-ui

#live updates for Ui bind local folder src/ to /app/src using bind mounts
#NOT EXACTLY Live Load - you have to restart the container BUT YOU DON'T need to re build image
#docker run -e CHOKIDAR_USEPOLLING=true -v c:/Users/gao0/core/WeatherApp/WeatherApp.UI/src:/app/src --name weather-app-ui -it --rm -p 3000:3000 powergeoff/weatherapp-ui


#run on network NOT NECESSARY!!
#docker run --name weather-app-ui -it --network weather-app-net --rm -p 3000:3000 powergeoff/weatherapp-ui
#docker run --name weather-app-ui -it --network weather-app-net --rm -p 3000:3000 powergeoff/weatherapp-ui