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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230714185303_Initial Migration')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230714185303_Initial Migration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230714185303_Initial Migration', N'7.0.9');
END;
GO

COMMIT;
GO

