USE [KC]
GO

/****** Object:  Table [dbo].[Users]   ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Users](
	[ID] [int] not NULL primary key,
	[Name] [varchar](50) NULL,
	[Description] [varchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[DeletedDate] [datetime] NULL,
	[CreatedBy] [varchar](100) NULL,
	[UpdatedBy] [varchar](100) NULL,
	[DeletedBy] [varchar](100) NULL,
	[WorkEmail] [varchar](100) NULL,
	[Age] [int] NULL,
	[IsDelete] [bit] NULL,
	[SystemDescription] [varchar](100) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

