CREATE TABLE [dbo].[Client] (
    [Id]              BIGINT       NOT NULL IDENTITY(1,1),
    [Name]            VARCHAR (50) NOT NULL,
    [DocumentNumber]  INT          NULL,
    [BirthDate]       DATETIME     NULL,
    [Email]           VARCHAR (50) NULL,
    [TelephoneNumber] BIGINT          NULL,
    [AddressId]       BIGINT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Client_Address] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Address] ([Id])
);

