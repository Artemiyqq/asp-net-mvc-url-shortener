# URL Shortener App

URL Shortener App is a simple and efficient URL shortener built with ASP.NET Core, PostgreSQL, and Entity Framework. It allows users to create shortened URLs, making it easier to share long links. The project also includes a comprehensive suite of xUnit tests to ensure the reliability and functionality of the application.

## Features

- Easily create and manage shortened URLs.
- Utilizes ASP.NET Core for fast and efficient web application development.
- Backend data storage with PostgreSQL 15 for reliability and scalability.
- Leveraging Entity Framework for smooth database interactions.

## Usage

1. Clone the repository to your local machine. (git clone https://github.com/Artemiyqq/django-url-shortener.git)
2. Ensure you have .NET SDK installed (version 7.0 or later).
3. Install PostgreSQL 15 on your system.
4. Create an empty Postgres database and user with name `entityframework` so that EntityFramework can interact with the database.
5. Run the following SQL statements in database which u have created previously:

  Creating the "tests" Schema:
  ```
  CREATE SCHEMA IF NOT EXISTS tests
      AUTHORIZATION postgres;
  
  GRANT ALL ON SCHEMA tests TO entityframework;
  
  GRANT ALL ON SCHEMA tests TO postgres;
  ```
  Creating the "Urls" Table:
  ```
  CREATE TABLE IF NOT EXISTS public."Urls"
  (
      "Id" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
      "OriginalUrl" text COLLATE pg_catalog."default" NOT NULL,
      "ShortenedUrl" text COLLATE pg_catalog."default" NOT NULL,
      CONSTRAINT "PK_Urls" PRIMARY KEY ("Id")
  )
  
  TABLESPACE pg_default;
  
  ALTER TABLE IF EXISTS public."Urls"
      OWNER to entityframework;
  ```
  Creating the "__EFMigrationsHistory" Table:
  ```
  CREATE TABLE IF NOT EXISTS public."__EFMigrationsHistory"
  (
      "MigrationId" character varying(150) COLLATE pg_catalog."default" NOT NULL,
      "ProductVersion" character varying(32) COLLATE pg_catalog."default" NOT NULL,
      CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
  )
  
  TABLESPACE pg_default;
  
  ALTER TABLE IF EXISTS public."__EFMigrationsHistory"
      OWNER to entityframework;
  ```
6. Update the connection string in the `appsettings.json` file to point to your PostgreSQL database and user.
7. Navigate to the `django-url-shortener` directory  and run the following commands in your terminal:

  ```
  # Command to restore dependencies
  dotnet restore
  ```
  ```
  # Command to build the solution
  dotnet build
  ```

8. Navigate to the `Urlshortener.App` directory and run the following commands in your terminal:
  ```
  # Command to run the ASP.NET MVC application
  dotnet run
  ```
10. Open your web browser and visit `http://localhost:51442` or `http://localhost:51443` to access the URL Shortener App.

## Running Tests

The project includes a suite of xUnit tests to validate the functionality of the application. To run the tests, navigate to the `UrlShortener.Tests` directory and execute the following command:
  ```
  # Command to run the tests
  dotnet test
  ```

## Docker Image

You can also use the Docker image of that project which is available on DockerHub:
```
docker pull artemiyqq/url-shortener-asp-net-mvc:latest
```

## License

This project is licensed under the [MIT License](https://github.com/Artemiyqq/django-url-shortener/blob/main/LICENSE).
