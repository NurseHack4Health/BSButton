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

CREATE TABLE [dbo].[BsReasonCode] (
    [ReasonCodeId] int NOT NULL IDENTITY,
    [ReasonCodeGuid] uniqueidentifier NOT NULL,
    [ReasonCode] nvarchar(max) NULL,
    [ReasonCodeText] nvarchar(max) NULL,
    CONSTRAINT [PK_BsReasonCode] PRIMARY KEY ([ReasonCodeId])
);
GO

CREATE TABLE [dbo].[BsSocialMediaSource] (
    [SourceCodeId] int NOT NULL IDENTITY,
    [SourceCodeGuid] uniqueidentifier NOT NULL,
    [SourceCodeName] nvarchar(max) NULL,
    [SourceCodeBaseUrl] nvarchar(max) NULL,
    CONSTRAINT [PK_BsSocialMediaSource] PRIMARY KEY ([SourceCodeId])
);
GO

CREATE TABLE [dbo].[BsReason] (
    [ReasonId] int NOT NULL IDENTITY,
    [ReasonGuid] uniqueidentifier NOT NULL,
    [ReasonCodeId] int NOT NULL,
    [ReasonText] nvarchar(max) NULL,
    CONSTRAINT [PK_BsReason] PRIMARY KEY ([ReasonId]),
    CONSTRAINT [FK_BsReason_BsReasonCode_ReasonCodeId] FOREIGN KEY ([ReasonCodeId]) REFERENCES [dbo].[BsReasonCode] ([ReasonCodeId]) ON DELETE CASCADE
);
GO

CREATE TABLE [dbo].[BsSource] (
    [SourceId] int NOT NULL IDENTITY,
    [SourceGuid] uniqueidentifier NOT NULL,
    [SourceUrl] nvarchar(max) NULL,
    [SocialMediaSourceId] int NOT NULL,
    CONSTRAINT [PK_BsSource] PRIMARY KEY ([SourceId]),
    CONSTRAINT [FK_BsSource_BsSocialMediaSource_SocialMediaSourceId] FOREIGN KEY ([SocialMediaSourceId]) REFERENCES [dbo].[BsSocialMediaSource] ([SourceCodeId]) ON DELETE CASCADE
);
GO

CREATE TABLE [dbo].[BsUnconfirmedReport] (
    [UnconfirmedReportId] int NOT NULL IDENTITY,
    [ReportGuid] uniqueidentifier NOT NULL,
    [ReporterUserName] nvarchar(max) NULL,
    [ReportedName] nvarchar(max) NULL,
    [SourceId] int NOT NULL,
    [ReportedDateTime] datetime2 NOT NULL,
    [ReasonId] int NOT NULL,
    [ReportReason] nvarchar(max) NULL,
    [ReportText] nvarchar(max) NULL,
    [ReportedNameOfPoster] nvarchar(max) NULL,
    CONSTRAINT [PK_BsUnconfirmedReport] PRIMARY KEY ([UnconfirmedReportId]),
    CONSTRAINT [FK_BsUnconfirmedReport_BsReason_ReasonId] FOREIGN KEY ([ReasonId]) REFERENCES [dbo].[BsReason] ([ReasonId]) ON DELETE CASCADE,
    CONSTRAINT [FK_BsUnconfirmedReport_BsSource_SourceId] FOREIGN KEY ([SourceId]) REFERENCES [dbo].[BsSource] ([SourceId]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_BsReason_ReasonCodeId] ON [dbo].[BsReason] ([ReasonCodeId]);
GO

CREATE INDEX [IX_BsSource_SocialMediaSourceId] ON [dbo].[BsSource] ([SocialMediaSourceId]);
GO

CREATE INDEX [IX_BsUnconfirmedReport_ReasonId] ON [dbo].[BsUnconfirmedReport] ([ReasonId]);
GO

CREATE INDEX [IX_BsUnconfirmedReport_SourceId] ON [dbo].[BsUnconfirmedReport] ([SourceId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201115054259_InitialCreate', N'5.0.0');
GO

COMMIT;
GO

