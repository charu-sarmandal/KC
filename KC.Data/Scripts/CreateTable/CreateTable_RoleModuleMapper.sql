USE [KC]
GO

/****** Object:  Table [dbo].[RoleModuleMapper]    Script Date: 05-01-2019 10:52:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[RoleModuleMapper](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int],
	[ModuleId] [int],	
	[IsDelete] [bit] NULL,
	[SystemDescription] [varchar](100) NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[DeleteDate] [datetime] NULL,
	[CreateById] int  NULL,
	[UpdateById] int NULL,
	[DeleteById] int NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[RoleModuleMapper]  WITH CHECK ADD FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([ID])
GO

ALTER TABLE [dbo].[RoleModuleMapper]  WITH CHECK ADD FOREIGN KEY([ModuleId])
REFERENCES [dbo].[Module] ([ID])
GO

GO

SET ANSI_PADDING OFF
GO


