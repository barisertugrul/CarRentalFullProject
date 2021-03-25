USE [RentACar]
GO

/****** Object: Table [dbo].[CarImages] Script Date: 14.3.2021 06:20:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CarImages] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [CarId]     INT           NOT NULL,
    [ImagePath] VARCHAR (MAX) NOT NULL,
    [Date]      DATE          NOT NULL
);


