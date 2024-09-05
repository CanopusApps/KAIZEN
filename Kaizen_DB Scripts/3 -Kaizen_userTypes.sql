USE [KAIZEN]
GO
/****** Object:  UserDefinedTableType [dbo].[KaizenTeamMembersType]    Script Date: 25-08-2024 19:16:24 ******/
DROP TYPE IF EXISTS [dbo].[KaizenTeamMembersType]
GO
/****** Object:  UserDefinedTableType [dbo].[KaizenScopeDetailsType]    Script Date: 25-08-2024 19:16:24 ******/
DROP TYPE IF EXISTS [dbo].[KaizenScopeDetailsType]
GO
/****** Object:  UserDefinedTableType [dbo].[KaizenAttachmentType]    Script Date: 25-08-2024 19:16:24 ******/
DROP TYPE IF EXISTS [dbo].[KaizenAttachmentType]
GO
/****** Object:  UserDefinedTableType [dbo].[KaizenAttachmentType]    Script Date: 25-08-2024 19:16:24 ******/
CREATE TYPE [dbo].[KaizenAttachmentType] AS TABLE(
	[KaizenId] [nvarchar](200) NULL,
	[FileName] [nvarchar](max) NULL,
	[Createdby] [nvarchar](200) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[KaizenScopeDetailsType]    Script Date: 25-08-2024 19:16:24 ******/
CREATE TYPE [dbo].[KaizenScopeDetailsType] AS TABLE(
	[KaizenId] [nvarchar](200) NULL,
	[CreatedBy] [nvarchar](200) NULL,
	[MC] [nvarchar](200) NULL,
	[TargetDate] [datetime] NULL,
	[Responsibility] [nvarchar](200) NULL,
	[ScopeStatus] [nvarchar](200) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[KaizenTeamMembersType]    Script Date: 25-08-2024 19:16:24 ******/
CREATE TYPE [dbo].[KaizenTeamMembersType] AS TABLE(
	[KaizenId] [nvarchar](200) NULL,
	[Createdby] [nvarchar](200) NULL,
	[EmpId] [nvarchar](200) NULL,
	[TeamMemberName] [nvarchar](200) NULL,
	[FunctionName] [nvarchar](200) NULL
)
GO
