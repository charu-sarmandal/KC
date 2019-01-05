USE [KC]
GO

/****** Object:  Table [dbo].[Users]   ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[EmployeeContact](
ID bigint not null primary key, --primary key
ParmanentAddress varchar(300),
PresentAddress varchar(300),
MobileNo bigint,
HomeContactNo bigint,
EmailId varchar(200),
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

