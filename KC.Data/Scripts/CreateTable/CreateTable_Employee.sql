USE [KC]
GO

/****** Object:  Table [dbo].[Employee]    Script Date: 05-01-2019 00:05:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Employee](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[CODEID] [bigint] NOT NULL,
	[CODE] [varchar](300) NULL,
	[NAME] [varchar](500) NULL,
	[DateOfJoining] [datetime] NULL,
	[DateOfResignation] [datetime] NULL,
	[DateOfBirth] [datetime] NULL,
	[AadhaarNo] [bigint] NULL,
	[PanNo] [bigint] NULL,
	[Designation] [varchar](300) NULL,
	[BankName] [varchar](300) NULL,
	[AccountNo] [varchar](300) NULL,
	[IFSCCode] [varchar](100) NULL,
	[MICRNo] [varchar] (100) NULL,
	[ParmanentAddress] [varchar](300) NULL,
	[PresentAddress] [varchar](300) NULL,
	[MobileNo] [bigint] NULL,
	[HomeContactNo] [bigint] NULL,
	[EmailId] [varchar](200) NULL,
	[RoleId] [bigint] NULL,
	[DepartmentId] [bigint] NULL,
	[Photo] [varchar](500) NULL,
	[BloodGroup] [varchar](3) NULL,
	[AppointmentLetter] [varchar](500) NULL,
	[IsDeleted] [bit] NULL,
	[SystemDescription] [varchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[DeletedDate] [datetime] NULL,
	[CreatedById] [bigint] ,
	[UpdatedById] [bigint],
	[DeletedById] [bigint],
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Employee]  WITH CHECK ADD FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([ID])
GO

ALTER TABLE [dbo].[Employee]  WITH CHECK ADD FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([ID])
GO

ALTER TABLE [dbo].[Employee]  WITH CHECK ADD FOREIGN KEY([CreatedById])
REFERENCES [dbo].[Users] ([ID])

ALTER TABLE [dbo].[Employee]  WITH CHECK ADD FOREIGN KEY([UpdatedById])
REFERENCES [dbo].[Users] ([ID])
GO

ALTER TABLE [dbo].[Employee]  WITH CHECK ADD FOREIGN KEY([DeletedById])
REFERENCES [dbo].[Users] ([ID])