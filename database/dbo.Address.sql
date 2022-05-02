CREATE TABLE [dbo].[Address] (
    [Id]                 BIGINT       NOT NULL IDENTITY (1, 1),
    [DescriptionAddress] VARCHAR (50) NULL,
    [Number]             VARCHAR (50) NULL,
    [ZipCode]            BIGINT       NULL,
    [City]               VARCHAR (50) NULL,
    [State]              VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

