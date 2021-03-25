USE [RentACar]
GO

/****** Object: Table [dbo].[Customers] Script Date: 14.3.2021 06:20:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Customers] (
    [Id]          INT          IDENTITY (1, 1) NOT NULL,
    [UserId]      INT          NOT NULL,
    [CompanyName] VARCHAR (50) NOT NULL
);


