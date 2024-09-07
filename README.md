# URL Shortener App

URL Shortener App is a simple and efficient URL shortener built with ASP.NET Core, PostgreSQL, and Entity Framework. It allows users to create shortened URLs, making it easier to share long links. The project also includes a comprehensive suite of xUnit tests to ensure the reliability and functionality of the application.

## Features

- Easily create and manage shortened URLs.
- Utilizes ASP.NET Core for fast and efficient web application development.
- Backend data storage with PostgreSQL 15 for reliability and scalability.
- Leveraging Entity Framework for smooth database interactions.

## Usage

1. Clone the repository to your local machine:
```
git clone https://github.com/Artemiyqq/asp-net-mvc-url-shortener.git
```
3. Ensure you have .NET SDK installed (version 7.0 or later).
4. Install PostgreSQL 15 on your system.
6. Update the connection string in the `appsettings.json` file, namely **Username** and **Password** with the data to connect to your database.
7. Navigate to the `asp-net-mvc-url-shortener` directory  and run the following commands in your terminal:

  ```
  dotnet restore
  ```
  ```
  dotnet build
  ```

8. Navigate to the `Urlshortener.App` directory and run the following commands in your terminal:
  ```
  dotnet run
  ```
10. Open your web browser and visit ***http://localhost:51442*** or ***http://localhost:51443*** to access the URL Shortener App.

## Docker Compose
If you just want to see an already working project, create a file with the name `docker-compose.yml` in any convenient place for you by placing the following code in it:
  ```
  version: '3.4'
  name: url-shortener
  services:
  web:
    image: artemiyqq/url-shortener-web:latest
    container_name: url-shortener-web
    ports:
        - "51442:80"
    depends_on:
        db:
          condition: service_healthy
    environment:
        ASPNETCORE_ENVIRONMENT: Development

  db:
    image: postgres:15
    container_name: url-shortener-db
    environment:
        POSTGRES_PASSWORD: iceage
        POSTGRES_DB: url-shortener-db
    ports:
        - "5431:5432"
    healthcheck:
        test: ["CMD-SHELL", "pg_isready -U postgres"]
        interval: 10s
        timeout: 5s
        retries: 5
  ```
And run it with the following command in the console:
   ```
   docker-compose up --build -d
   ```
After that, you can follow the link and play around with the site ***http://localhost:51442/***

## License

This project is licensed under the [MIT License](https://github.com/Artemiyqq/asp-net-mvc-url-shortener/blob/master/LICENSE.txt).
