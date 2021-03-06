USE [KC]
GO

/****** Object:  Table [dbo].[Department]    Script Date: 05-01-2019 10:53:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Department](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CodeId] int NULL,
	[Code] varchar(300) NULL ,
	[Name] [varchar](300) NULL,
	[NoOfEmpl] [int] NULL,
	[IsDelete] [bit] NULL,
	[IsActive] [bit] NULL,
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

GO

--ALTER TABLE [dbo].[Department]  WITH CHECK ADD FOREIGN KEY([CreatedById])
--REFERENCES [dbo].[Users] ([ID])

--ALTER TABLE [dbo].[Department]  WITH CHECK ADD FOREIGN KEY([UpdatedById])
--REFERENCES [dbo].[Users] ([ID])
--GO

--ALTER TABLE [dbo].[Department]  WITH CHECK ADD FOREIGN KEY([DeletedById])
--REFERENCES [dbo].[Users] ([ID])

SET ANSI_PADDING OFF
GO


