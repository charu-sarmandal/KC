USE [KC]
GO

/****** Object:  Table [dbo].[Users]   ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[BankDetails](
ID bigint not NULL primary key, --primary key
BankName varchar(300),
AccountNo bigint, 
IFSCCode varchar(100),
MICRNo bigint,
[IsDeleted] [bit] NULL,
[SystemDescription] [varchar](100) NULL,
[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[DeletedDate] [datetime] NULL,
	[CreatedBy] [varchar](100) NULL,
	[UpdatedBy] [varchar](100) NULL,
	[DeletedBy] [varchar](100) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

