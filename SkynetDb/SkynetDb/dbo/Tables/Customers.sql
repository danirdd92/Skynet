CREATE TABLE [dbo].[Customers] (
    [Id]          INT              IDENTITY (1, 1) NOT NULL,
    [UserName]    NVARCHAR (128)   NOT NULL,
    [Password]    NVARCHAR (128)   NOT NULL,
    [UserRole]    UNIQUEIDENTIFIER NOT NULL,
    [FirstName]   NVARCHAR (128)   NOT NULL,
    [LastName]    NVARCHAR (128)   NOT NULL,
    [Address]     NVARCHAR (128)   NULL,
    [PhoneNumber] NVARCHAR (128)   NULL,
    [CreditCard]  NVARCHAR (128)   NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED ([Id] ASC)
);

