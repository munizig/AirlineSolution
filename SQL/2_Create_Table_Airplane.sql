USE [Airline]
GO

/****** Object:  Table [dbo].[Airplane]    Script Date: 4/17/2019 5:51:53 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Airplane](
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [varchar](20) NOT NULL,
	[PassengersQuantity] [smallint] NOT NULL,
	[CreateDateLog] [datetime] NOT NULL,
	[Model] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Airplane] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Airplane] ADD  CONSTRAINT [DF_Airplane_Id]  DEFAULT (newid()) FOR [Id]
GO

ALTER TABLE [dbo].[Airplane] ADD  CONSTRAINT [DF_Airplane_CreateDateLog]  DEFAULT (getdate()) FOR [CreateDateLog]
GO


