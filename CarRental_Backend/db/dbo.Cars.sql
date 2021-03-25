USE [RentACar]
GO

/****** Object: Table [dbo].[Cars] Script Date: 14.3.2021 06:20:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cars] (
    [CarId]       INT           IDENTITY (1, 1) NOT NULL,
    [BrandId]     INT           NOT NULL,
    [ColorId]     INT           NOT NULL,
    [CarName]     NCHAR (25)    NOT NULL,
    [ModelYear]   SMALLINT      NOT NULL,
    [DailyPrice]  MONEY         NOT NULL,
    [Description] VARCHAR (255) NULL
);


