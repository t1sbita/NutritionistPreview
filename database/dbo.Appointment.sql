CREATE TABLE [dbo].[Appointment] (
    [Id]                BIGINT         NOT NULL IDENTITY (1, 1),
    [DatePerformed]     DATETIME       NULL,
    [BodyFatPercent]    DECIMAL (2, 2) NULL,
    [PhysicalSensation] VARCHAR (50)   NULL,
    [FoodRestrictions]  VARCHAR (1000) NULL,
    [ClientId]          BIGINT         NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Appointment_Client] FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Client] ([Id])
);

