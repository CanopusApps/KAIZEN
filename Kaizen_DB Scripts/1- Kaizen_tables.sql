USE [KAIZEN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WinnersList]') AND type in (N'U'))
ALTER TABLE [dbo].[WinnersList] DROP CONSTRAINT IF EXISTS [DF__WinnersLi__Statu__4C0144E4]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserType]') AND type in (N'U'))
ALTER TABLE [dbo].[UserType] DROP CONSTRAINT IF EXISTS [DF_UserType_ID]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
ALTER TABLE [dbo].[Users] DROP CONSTRAINT IF EXISTS [DF_Users_ID]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USERLOG]') AND type in (N'U'))
ALTER TABLE [dbo].[USERLOG] DROP CONSTRAINT IF EXISTS [DF__USERLOG__ID__147C05D0]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KaizenTeamMembers_new]') AND type in (N'U'))
ALTER TABLE [dbo].[KaizenTeamMembers_new] DROP CONSTRAINT IF EXISTS [DF__KaizenTeamMe__Id__1B5E0D89]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KaizenTeamMembers]') AND type in (N'U'))
ALTER TABLE [dbo].[KaizenTeamMembers] DROP CONSTRAINT IF EXISTS [DF__KaizenTeamMe__Id__13BCEBC1]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KaizenScopeDetailsTypes]') AND type in (N'U'))
ALTER TABLE [dbo].[KaizenScopeDetailsTypes] DROP CONSTRAINT IF EXISTS [DF__KaizenScopeD__ID__093F5D4E]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KaizenScopeDetails]') AND type in (N'U'))
ALTER TABLE [dbo].[KaizenScopeDetails] DROP CONSTRAINT IF EXISTS [DF_KaizenScopeDetails_ID]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Kaizens]') AND type in (N'U'))
ALTER TABLE [dbo].[Kaizens] DROP CONSTRAINT IF EXISTS [DF_Kaizens_ID]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Domains]') AND type in (N'U'))
ALTER TABLE [dbo].[Domains] DROP CONSTRAINT IF EXISTS [DF_Domains_ID]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Departments]') AND type in (N'U'))
ALTER TABLE [dbo].[Departments] DROP CONSTRAINT IF EXISTS [DF_Departments_ID]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cadre]') AND type in (N'U'))
ALTER TABLE [dbo].[Cadre] DROP CONSTRAINT IF EXISTS [DF_Cadre_ID]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Blocks]') AND type in (N'U'))
ALTER TABLE [dbo].[Blocks] DROP CONSTRAINT IF EXISTS [DF_Blocks_ID]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Attachments]') AND type in (N'U'))
ALTER TABLE [dbo].[Attachments] DROP CONSTRAINT IF EXISTS [DF__Attachments__ID__29AC2CE0]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ApprovalStatus]') AND type in (N'U'))
ALTER TABLE [dbo].[ApprovalStatus] DROP CONSTRAINT IF EXISTS [DF_ApprovalStatus_ID]
GO
/****** Object:  Table [dbo].[WinnersList]    Script Date: 25-08-2024 19:18:26 ******/
DROP TABLE IF EXISTS [dbo].[WinnersList]
GO
/****** Object:  Table [dbo].[UserType]    Script Date: 25-08-2024 19:18:26 ******/
DROP TABLE IF EXISTS [dbo].[UserType]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 25-08-2024 19:18:26 ******/
DROP TABLE IF EXISTS [dbo].[Users]
GO
/****** Object:  Table [dbo].[USERLOG]    Script Date: 25-08-2024 19:18:26 ******/
DROP TABLE IF EXISTS [dbo].[USERLOG]
GO
/****** Object:  Table [dbo].[Themes]    Script Date: 25-08-2024 19:18:26 ******/
DROP TABLE IF EXISTS [dbo].[Themes]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 25-08-2024 19:18:26 ******/
DROP TABLE IF EXISTS [dbo].[Status]
GO
/****** Object:  Table [dbo].[Query]    Script Date: 25-08-2024 19:18:26 ******/
DROP TABLE IF EXISTS [dbo].[Query]
GO
/****** Object:  Table [dbo].[KaizenTeamMembers_new]    Script Date: 25-08-2024 19:18:26 ******/
DROP TABLE IF EXISTS [dbo].[KaizenTeamMembers_new]
GO
/****** Object:  Table [dbo].[KaizenTeamMembers]    Script Date: 25-08-2024 19:18:26 ******/
DROP TABLE IF EXISTS [dbo].[KaizenTeamMembers]
GO
/****** Object:  Table [dbo].[KaizenScopeDetailsTypes]    Script Date: 25-08-2024 19:18:26 ******/
DROP TABLE IF EXISTS [dbo].[KaizenScopeDetailsTypes]
GO
/****** Object:  Table [dbo].[KaizenScopeDetails]    Script Date: 25-08-2024 19:18:26 ******/
DROP TABLE IF EXISTS [dbo].[KaizenScopeDetails]
GO
/****** Object:  Table [dbo].[Kaizens]    Script Date: 25-08-2024 19:18:26 ******/
DROP TABLE IF EXISTS [dbo].[Kaizens]
GO
/****** Object:  Table [dbo].[Domains]    Script Date: 25-08-2024 19:18:26 ******/
DROP TABLE IF EXISTS [dbo].[Domains]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 25-08-2024 19:18:26 ******/
DROP TABLE IF EXISTS [dbo].[Departments]
GO
/****** Object:  Table [dbo].[Cadre]    Script Date: 25-08-2024 19:18:26 ******/
DROP TABLE IF EXISTS [dbo].[Cadre]
GO
/****** Object:  Table [dbo].[Blocks]    Script Date: 25-08-2024 19:18:26 ******/
DROP TABLE IF EXISTS [dbo].[Blocks]
GO
/****** Object:  Table [dbo].[Attachments]    Script Date: 25-08-2024 19:18:26 ******/
DROP TABLE IF EXISTS [dbo].[Attachments]
GO
/****** Object:  Table [dbo].[ApprovalStatus]    Script Date: 25-08-2024 19:18:26 ******/
DROP TABLE IF EXISTS [dbo].[ApprovalStatus]
GO
/****** Object:  Table [dbo].[ApprovalStatus]    Script Date: 25-08-2024 19:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApprovalStatus](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[StatusID] [int] NULL,
	[StatusDescription] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_ApprovalStatus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Attachments]    Script Date: 25-08-2024 19:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attachments](
	[KaizenID] [uniqueidentifier] NOT NULL,
	[FileName] [nvarchar](200) NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[CreatedDate] [nvarchar](200) NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [nvarchar](200) NULL,
	[ID] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Blocks]    Script Date: 25-08-2024 19:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blocks](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[BlockId] [int] IDENTITY(1,1) NOT NULL,
	[BlockName] [nvarchar](50) NULL,
	[Status] [bit] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_Blocks_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cadre]    Script Date: 25-08-2024 19:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cadre](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[CadreId] [int] IDENTITY(1,1) NOT NULL,
	[cadreDesc] [nvarchar](50) NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_Cadre] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 25-08-2024 19:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[DeptId] [int] IDENTITY(1,1) NOT NULL,
	[DomainId] [uniqueidentifier] NOT NULL,
	[DepartmentName] [nvarchar](50) NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Domains]    Script Date: 25-08-2024 19:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Domains](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[DomainID] [int] IDENTITY(1,1) NOT NULL,
	[DomainName] [nvarchar](50) NULL,
	[Status] [bit] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_Domains_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kaizens]    Script Date: 25-08-2024 19:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kaizens](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[KaizenId] [int] IDENTITY(1,1) NOT NULL,
	[KaizenType] [nchar](10) NULL,
	[Activity] [nvarchar](100) NULL,
	[ActivityDesc] [nvarchar](50) NULL,
	[BenefitArea] [nvarchar](100) NULL,
	[DocNo] [nvarchar](50) NOT NULL,
	[VersionNoDate] [nvarchar](50) NULL,
	[CostCentre] [nvarchar](50) NOT NULL,
	[KaizenRefNo] [nvarchar](50) NOT NULL,
	[Block] [uniqueidentifier] NOT NULL,
	[BlockDetails] [nvarchar](50) NOT NULL,
	[KaizenTheme] [nvarchar](50) NOT NULL,
	[SuggestedKaizen] [nvarchar](50) NULL,
	[ProblemStatement] [nvarchar](100)  NULL,
	[CounterMeasure] [nvarchar](100)  NULL,
	[AttachmentBefore] [nvarchar](50) NULL,
	[AttachmentAfter] [nvarchar](50) NULL,
	[AttachmentOthers] [nvarchar](50) NULL,
	[Yield] [nvarchar](50) NULL,
	[CycleTime] [nvarchar](50) NULL,
	[Cost] [int] NULL,
	[ManPower] [nvarchar](50) NULL,
	[Consumables] [nvarchar](50) NULL,
	[Others] [nvarchar](50) NULL,
	[TotalSavings] [int] NULL,
	[ApprovedByIE] [nvarchar](100) NULL,
	[TeamMemberID] [int] NULL,
	[RootCause] [nvarchar](50) NULL,
	[PresentCondition] [nvarchar](255) NULL,
	[ImprovementsCompleted] [nvarchar](255) NULL,
	[RootProblemAttachment] [nvarchar](50) NULL,
	[RootCauseDetails] [nvarchar](max) NULL,
	[HorozantalDeployment] [bit] NULL,
	[ScopeOfDeploymentID] [int] NULL,
	[InOtherMc] [nvarchar](50) NULL,
	[WithIntheDept] [nvarchar](50) NULL,
	[InOtherDept] [nvarchar](50) NULL,
	[OtherPoints] [nvarchar](50) NULL,
	[Benifits] [nvarchar](255) NOT NULL,
	[Shortlisted] [bit] NULL,
	[ApprovalStatus] [char](2) NULL,
	[IEApprovedDate] [datetime] NULL,
	[IEApprovedBy] [uniqueidentifier] NULL,
	[IEApprovedDept] [nvarchar](50) NULL,
	[DRIApprovedDate] [datetime] NULL,
	[DRIApprovedBy] [uniqueidentifier] NULL,
	[FinanceApprovedDate] [datetime] NULL,
	[FinanceApprovedBy] [uniqueidentifier] NULL,
	[ImageApprovedDate] [datetime] NULL,
	[ImageApprovedBy] [uniqueidentifier] NULL,
	[OriginatedBy] [uniqueidentifier] NULL,
	[OrigionatedDept] [nvarchar](50) NULL,
	[OrigonatedDate] [datetime] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[CreatedDate] [datetime] NULL,
	[Department] [uniqueidentifier] NULL,
	[Domain] [uniqueidentifier] NULL,
	[FinanceApprover] [nvarchar](100) NULL,
	[RejectionReason] [nvarchar](100) NULL,
	[DeletedBy] [uniqueidentifier] NULL,
	[DeletedDate] [datetime] NULL,
 CONSTRAINT [PK_Kaizens] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KaizenScopeDetails]    Script Date: 25-08-2024 19:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KaizenScopeDetails](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[KaizenId] [uniqueidentifier] NOT NULL,
	[SN] [nvarchar](50) NULL,
	[MC] [nvarchar](50) NULL,
	[TargetDate] [datetime] NULL,
	[Responsibility] [nvarchar](50) NULL,
	[ScopeStatus] [nvarchar](200) NULL,
	[SubDatetime] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime] NULL,
	[ScopeID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_KaizenScopeDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KaizenScopeDetailsTypes]    Script Date: 25-08-2024 19:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KaizenScopeDetailsTypes](
	[CreatedDate] [nvarchar](100) NULL,
	[MC] [nvarchar](200) NULL,
	[TargetDate] [nvarchar](200) NULL,
	[Responsibility] [nvarchar](200) NULL,
	[ScopeStatus] [nvarchar](200) NULL,
	[KcId] [int] IDENTITY(1,1) NOT NULL,
	[ID] [uniqueidentifier] NOT NULL,
	[ModifiedDate] [nvarchar](100) NULL,
	[CreatedBy] [nvarchar](200) NULL,
	[ModifiedBy] [nvarchar](200) NULL,
	[KaizenID] [nvarchar](200) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KaizenTeamMembers]    Script Date: 25-08-2024 19:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KaizenTeamMembers](
	[Id] [uniqueidentifier] NOT NULL,
	[MemberID] [int] IDENTITY(1,1) NOT NULL,
	[KaizenID] [uniqueidentifier] NULL,
	[EmpID] [uniqueidentifier] NULL,
	[TeamMemberName] [nvarchar](200) NULL,
	[FunctionName] [nvarchar](200) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_KaizenTeamMembers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KaizenTeamMembers_new]    Script Date: 25-08-2024 19:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KaizenTeamMembers_new](
	[Id] [uniqueidentifier] NOT NULL,
	[MemberID] [int] IDENTITY(1,1) NOT NULL,
	[KaizenID] [nvarchar](200) NULL,
	[EmpID] [nvarchar](200) NULL,
	[TeamMemberName] [nvarchar](200) NULL,
	[FunctionName] [nvarchar](200) NULL,
	[CreatedDate] [nvarchar](100) NULL,
	[CreatedBy] [nvarchar](200) NULL,
	[ModifiedBy] [nvarchar](200) NULL,
	[ModifiedDate] [nvarchar](200) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Query]    Script Date: 25-08-2024 19:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Query](
	[UserID] [nvarchar](50) NOT NULL,
	[ProfileID] [nvarchar](50) NULL,
	[EmpID] [nvarchar](50) NULL,
	[FirstName] [nvarchar](50) NULL,
	[MiddleName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Email] [nvarchar](100) NULL,
	[Mobile] [int] NULL,
	[Password] [nvarchar](50) NULL,
	[Team] [nvarchar](50) NULL,
	[Designation] [nvarchar](50) NULL,
	[Gender] [char](1) NULL,
	[Domain] [uniqueidentifier] NULL,
	[Department] [uniqueidentifier] NULL,
	[ProfilePhoto] [ntext] NULL,
	[ProfileDetails] [nvarchar](50) NULL,
	[Status] [bit] NULL,
	[UserType] [char](20) NULL,
	[ImageApprover] [bit] NULL,
	[Plant] [nvarchar](50) NULL,
	[Area] [nvarchar](50) NULL,
	[Cadre] [nvarchar](50) NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[CreatedDate] [datetime2](3) NULL,
	[ModifiedBy] [nvarchar](10) NULL,
	[ModifiedDate] [datetime2](3) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 25-08-2024 19:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[StatusID] [int] NOT NULL,
	[StatusName] [nvarchar](50) NULL,
	[Status] [bit] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Themes]    Script Date: 25-08-2024 19:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Themes](
	[ThemeID] [int] IDENTITY(1,1) NOT NULL,
	[Theme] [nvarchar](50) NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ThemeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USERLOG]    Script Date: 25-08-2024 19:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USERLOG](
	[ID] [uniqueidentifier] NOT NULL,
	[USERID] [int] NULL,
	[LOGIN] [datetime] NULL,
	[LOGOUT] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 25-08-2024 19:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[UserID] [nvarchar](50) NOT NULL,
	[EmpID] [nvarchar](50) NULL,
	[FirstName] [nvarchar](50) NULL,
	[MiddleName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Email] [nvarchar](100) NULL,
	[MobileNumber] [bigint] NULL,
	[Password] [nvarchar](100) NULL,
	[Gender] [char](1) NULL,
	[Domain] [uniqueidentifier] NULL,
	[Department] [uniqueidentifier] NULL,
	[ProfileDetails] [nvarchar](50) NULL,
	[Status] [bit] NULL,
	[UserType] [uniqueidentifier] NULL,
	[ImageApprover] [bit] NULL,
	[Plant] [nvarchar](50) NULL,
	[Area] [nvarchar](50) NULL,
	[Cadre] [uniqueidentifier] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime] NULL,
	[Block] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserType]    Script Date: 25-08-2024 19:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserType](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[UserTypeId] [int] IDENTITY(1,1) NOT NULL,
	[UserDesc] [nvarchar](50) NULL,
	[Status] [bit] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_UserType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WinnersList]    Script Date: 25-08-2024 19:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WinnersList](
	[ID] [uniqueidentifier] NOT NULL,
	[EmpGUID] [uniqueidentifier] NOT NULL,
	[Category] [nvarchar](50) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime] NULL,
	[Status] [nvarchar](50) NULL,
	[WinnerimgPath] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[ApprovalStatus] ADD  CONSTRAINT [DF_ApprovalStatus_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[Attachments] ADD  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[Blocks] ADD  CONSTRAINT [DF_Blocks_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[Cadre] ADD  CONSTRAINT [DF_Cadre_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[Departments] ADD  CONSTRAINT [DF_Departments_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[Domains] ADD  CONSTRAINT [DF_Domains_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[Kaizens] ADD  CONSTRAINT [DF_Kaizens_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[KaizenScopeDetails] ADD  CONSTRAINT [DF_KaizenScopeDetails_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[KaizenScopeDetailsTypes] ADD  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[KaizenTeamMembers] ADD  CONSTRAINT [DF__KaizenTeamMe__Id__13BCEBC1]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[KaizenTeamMembers_new] ADD  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[USERLOG] ADD  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[UserType] ADD  CONSTRAINT [DF_UserType_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[WinnersList] ADD  DEFAULT ('Active') FOR [Status]
GO
