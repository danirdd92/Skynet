CREATE TABLE [dbo].[AirlineCompanies] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [AirlineName] NVARCHAR (128) NOT NULL,
    [CountryId]   INT            NOT NULL,
    CONSTRAINT [PK_AirlineCompanies] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AirlineCompanies_Countries] FOREIGN KEY ([CountryId]) REFERENCES [dbo].[Countries] ([Id])
);

