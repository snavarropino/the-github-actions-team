IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190113120611_Initial')
BEGIN
    CREATE TABLE [Heros] (
        [Id] uniqueidentifier NOT NULL,
        [Name] nvarchar(max) NULL,
        [AlterEgo] nvarchar(max) NULL,
        [Default] bit NOT NULL,
        [Likes] int NOT NULL,
        [AvatarUrl] nvarchar(max) NULL,
        [AvatarThumbnailUrl] nvarchar(max) NULL,
        CONSTRAINT [PK_Heros] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190113120611_Initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190113120611_Initial', N'2.1.4-rtm-31024');
END;

GO

