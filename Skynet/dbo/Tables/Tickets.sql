CREATE TABLE [dbo].[Tickets] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [FlightId]   INT NOT NULL,
    [CustomerId] INT NOT NULL,
    CONSTRAINT [PK_Tickets] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Tickets_Customers] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customers] ([Id]),
    CONSTRAINT [FK_Tickets_Flights_FlightId] FOREIGN KEY ([FlightId]) REFERENCES [dbo].[Flights] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Tickets_FlightId]
    ON [dbo].[Tickets]([FlightId] ASC);

