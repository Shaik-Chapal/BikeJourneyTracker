Bike Journey Tracker System
This is a web api project  that provides various endpoints for retrieving information about journeys and stations.
 The controller is responsible for querying a database context called TrackerDbContext to fetch data related to journeys and stations.. I have used
 EntityFrameworkCore,Sql Server,EntityFrameworkCore.Design,EntityFrameworkCore.Tools,EntityFrameworkCore.OpenApi
 system. I have tried to maintain some level of OOD concept. 


Installation
(Step-1) Clone the project
https://github.com/Shaik-Chapal/BikeJourneyTracker.git
(Step-2) Create your own database manually![Screenshot (97)](https://github.com/Shaik-Chapal/BikeJourneyTracker/assets/70383236/024e135a-c2ce-4155-beeb-a120326bd9b3)



(Step-3) Add a file named DefaultConnection to keep your own connection string![Screenshot (96)](https://github.com/Shaik-Chapal/BikeJourneyTracker/assets/70383236/0b8a9378-47d7-46d6-9f25-719e173c29f8)

public readonly string ConnectionString;
        public DefaultConnection()
        {
            ConnectionString = "";
        }
(Step-4) Add and Update Migrations by running the following commands on Package Manager Console
dotnet ef migrations add AnyNameTable --project ProjectName --context DbContextName -o Data/Migrations
dotnet ef database update --project ProjectName --context DbContextName
(Step-5) keep the program.cs file like the below and Run the project
runORM

Pre-requisites
Must be installed on your machine :

Visual Studio 2022
MSSQL Server
