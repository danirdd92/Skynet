CREATE TABLE [dbo].[Flights] (
    [Id]                   INT           IDENTITY (1, 1) NOT NULL,
    [AirlineId]            INT           NOT NULL,
    [OriginCountryId]      INT           NOT NULL,
    [DestinationCountryId] INT           NOT NULL,
    [Departure]            DATETIME2 (7) NOT NULL,
    [Landing]              DATETIME2 (7) NOT NULL,
    [RemainingTickets]     INT           DEFAULT ((200)) NOT NULL,
    CONSTRAINT [PK_Flights] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Flights_AirlineCompanies] FOREIGN KEY ([AirlineId]) REFERENCES [dbo].[AirlineCompanies] ([Id]),
    CONSTRAINT [FK_Flights_Countries] FOREIGN KEY ([OriginCountryId]) REFERENCES [dbo].[Countries] ([Id]),
    CONSTRAINT [FK_Flights_Countries1] FOREIGN KEY ([DestinationCountryId]) REFERENCES [dbo].[Countries] ([Id])
);

