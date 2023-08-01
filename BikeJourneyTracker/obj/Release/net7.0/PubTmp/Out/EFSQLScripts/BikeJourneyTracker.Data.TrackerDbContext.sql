IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230730135441_Initial Migration')
BEGIN
    CREATE TABLE [Journeys] (
        [Departure] datetime2 NOT NULL,
        [Return] datetime2 NOT NULL,
        [DepartureStationId] int NOT NULL,
        [DepartureStationName] nvarchar(max) NOT NULL,
        [ReturnStationId] int NOT NULL,
        [ReturnStationName] nvarchar(max) NOT NULL,
        [CoveredDistance] int NOT NULL,
        [DurationSec] int NOT NULL
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230730135441_Initial Migration')
BEGIN
    CREATE TABLE [Stations] (
        [FID] int NOT NULL IDENTITY,
        [ID] int NOT NULL,
        [Nimi] nvarchar(max) NOT NULL,
        [Namn] nvarchar(max) NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [Osoite] nvarchar(max) NOT NULL,
        [Adress] nvarchar(max) NOT NULL,
        [Kaupunki] nvarchar(max) NOT NULL,
        [Stad] nvarchar(max) NOT NULL,
        [Operaattor] nvarchar(max) NOT NULL,
        [Kapasiteet] int NOT NULL,
        [x] float NOT NULL,
        [y] float NOT NULL,
        CONSTRAINT [PK_Stations] PRIMARY KEY ([FID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230730135441_Initial Migration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230730135441_Initial Migration', N'7.0.9');
END;
GO

COMMIT;
GO

