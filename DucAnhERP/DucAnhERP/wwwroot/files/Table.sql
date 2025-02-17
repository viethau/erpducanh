USE [Minh2024]
GO
/****** Object:  Table [dbo].[ApprovalControl_Logs]    Script Date: 2/6/2025 5:04:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApprovalControl_Logs](
	[Id] [nvarchar](450) NOT NULL,
	[CompanyId] [nvarchar](max) NOT NULL,
	[ParentMajorId] [nvarchar](max) NOT NULL,
	[MajorId] [nvarchar](max) NOT NULL,
	[DeptId] [nvarchar](max) NOT NULL,
	[UserId] [nvarchar](max) NOT NULL,
	[PermissionId] [nvarchar](max) NOT NULL,
	[ApprovalStepId] [nvarchar](max) NOT NULL,
	[GroupId] [nvarchar](max) NOT NULL,
	[Ordinarily] [int] NOT NULL,
	[CreateAt] [datetime2](7) NOT NULL,
	[CreateBy] [nvarchar](max) NOT NULL,
	[IsActive] [int] NOT NULL,
	[ApprovalUserId] [nvarchar](max) NOT NULL,
	[DateApproval] [datetime2](7) NOT NULL,
	[DepartmentId] [nvarchar](max) NOT NULL,
	[DepartmentOrder] [int] NOT NULL,
	[ApprovalOrder] [int] NOT NULL,
	[ApprovalId] [nvarchar](max) NOT NULL,
	[LastApprovalId] [nvarchar](max) NOT NULL,
	[IsStatus] [nvarchar](max) NOT NULL,
	[IdChung] [nvarchar](max) NOT NULL,
	[IsValid] [bit] NOT NULL,
 CONSTRAINT [PK_ApprovalControl_Logs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApprovalControls]    Script Date: 2/6/2025 5:04:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApprovalControls](
	[Id] [nvarchar](450) NOT NULL,
	[CompanyId] [nvarchar](max) NOT NULL,
	[ParentMajorId] [nvarchar](max) NOT NULL,
	[MajorId] [nvarchar](max) NOT NULL,
	[DeptId] [nvarchar](max) NOT NULL,
	[UserId] [nvarchar](max) NOT NULL,
	[PermissionId] [nvarchar](max) NOT NULL,
	[ApprovalStepId] [nvarchar](max) NOT NULL,
	[GroupId] [nvarchar](max) NOT NULL,
	[Ordinarily] [int] NOT NULL,
	[CreateAt] [datetime2](7) NOT NULL,
	[CreateBy] [nvarchar](max) NOT NULL,
	[IsActive] [int] NOT NULL,
	[ApprovalUserId] [nvarchar](max) NOT NULL,
	[DateApproval] [datetime2](7) NOT NULL,
	[DepartmentId] [nvarchar](max) NOT NULL,
	[DepartmentOrder] [int] NOT NULL,
	[ApprovalOrder] [int] NOT NULL,
	[ApprovalId] [nvarchar](max) NOT NULL,
	[LastApprovalId] [nvarchar](max) NOT NULL,
	[IsStatus] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_ApprovalControl] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MajorUserApproval_logs]    Script Date: 2/6/2025 5:04:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MajorUserApproval_logs](
	[Id] [nvarchar](450) NOT NULL,
	[CompanyId] [nvarchar](max) NULL,
	[ParentMajorId] [nvarchar](max) NULL,
	[MajorId] [nvarchar](max) NULL,
	[DeptId] [nvarchar](max) NULL,
	[UserId] [nvarchar](max) NULL,
	[PermissionId] [nvarchar](max) NULL,
	[ApprovalStepId] [nvarchar](max) NOT NULL,
	[IdMain] [nvarchar](max) NULL,
	[DayinWeek] [nvarchar](max) NULL,
	[GroupId] [nvarchar](max) NULL,
	[CreateAt] [datetime2](7) NULL,
	[CreateBy] [nvarchar](max) NULL,
	[IsActive] [int] NOT NULL,
	[ApprovalUserId] [nvarchar](max) NOT NULL,
	[DateApproval] [datetime2](7) NOT NULL,
	[DepartmentId] [nvarchar](max) NOT NULL,
	[DepartmentOrder] [int] NOT NULL,
	[ApprovalOrder] [int] NOT NULL,
	[ApprovalId] [nvarchar](max) NULL,
	[LastApprovalId] [nvarchar](max) NOT NULL,
	[IsStatus] [nvarchar](max) NOT NULL,
	[IdChung] [nvarchar](max) NOT NULL,
	[IsValid] [bit] NOT NULL,
 CONSTRAINT [PK_MajorUserApproval_logs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MajorUserApprovals]    Script Date: 2/6/2025 5:04:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MajorUserApprovals](
	[Id] [nvarchar](450) NOT NULL,
	[CompanyId] [nvarchar](max) NOT NULL,
	[ParentMajorId] [nvarchar](max) NOT NULL,
	[MajorId] [nvarchar](max) NOT NULL,
	[DeptId] [nvarchar](max) NOT NULL,
	[UserId] [nvarchar](max) NOT NULL,
	[PermissionId] [nvarchar](max) NULL,
	[ApprovalStepId] [nvarchar](max) NOT NULL,
	[IdMain] [nvarchar](max) NULL,
	[DayinWeek] [nvarchar](max) NOT NULL,
	[GroupId] [nvarchar](max) NOT NULL,
	[CreateAt] [datetime2](7) NOT NULL,
	[CreateBy] [nvarchar](max) NOT NULL,
	[IsActive] [int] NOT NULL,
	[ApprovalUserId] [nvarchar](max) NOT NULL,
	[DateApproval] [datetime2](7) NOT NULL,
	[DepartmentId] [nvarchar](max) NOT NULL,
	[DepartmentOrder] [int] NOT NULL,
	[ApprovalId] [nvarchar](max) NOT NULL,
	[ApprovalOrder] [int] NOT NULL,
	[LastApprovalId] [nvarchar](max) NOT NULL,
	[IsStatus] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_MajorUserApproval] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PermissionControl_Logs]    Script Date: 2/6/2025 5:04:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PermissionControl_Logs](
	[Id] [nvarchar](450) NOT NULL,
	[CompanyId] [nvarchar](max) NOT NULL,
	[ParentMajorId] [nvarchar](max) NOT NULL,
	[MajorId] [nvarchar](max) NOT NULL,
	[UserId] [nvarchar](max) NOT NULL,
	[GroupId] [nvarchar](max) NOT NULL,
	[Ordinarily] [int] NOT NULL,
	[CreateAt] [datetime2](7) NOT NULL,
	[CreateBy] [nvarchar](max) NOT NULL,
	[IsActive] [int] NOT NULL,
	[ApprovalUserId] [nvarchar](max) NOT NULL,
	[DateApproval] [datetime2](7) NOT NULL,
	[DepartmentId] [nvarchar](max) NOT NULL,
	[DepartmentOrder] [int] NOT NULL,
	[ApprovalOrder] [int] NOT NULL,
	[ApprovalId] [nvarchar](max) NOT NULL,
	[LastApprovalId] [nvarchar](max) NOT NULL,
	[IsStatus] [nvarchar](max) NOT NULL,
	[IdChung] [nvarchar](max) NOT NULL,
	[IsValid] [bit] NOT NULL,
 CONSTRAINT [PK_PermissionControl_Logs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PermissionControls]    Script Date: 2/6/2025 5:04:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PermissionControls](
	[Id] [nvarchar](450) NOT NULL,
	[CompanyId] [nvarchar](max) NOT NULL,
	[ParentMajorId] [nvarchar](max) NOT NULL,
	[MajorId] [nvarchar](max) NOT NULL,
	[UserId] [nvarchar](max) NOT NULL,
	[GroupId] [nvarchar](max) NOT NULL,
	[Ordinarily] [int] NOT NULL,
	[CreateAt] [datetime2](7) NOT NULL,
	[CreateBy] [nvarchar](max) NOT NULL,
	[IsActive] [int] NOT NULL,
	[ApprovalUserId] [nvarchar](max) NOT NULL,
	[DateApproval] [datetime2](7) NOT NULL,
	[DepartmentId] [nvarchar](max) NOT NULL,
	[DepartmentOrder] [int] NOT NULL,
	[ApprovalOrder] [int] NOT NULL,
	[ApprovalId] [nvarchar](max) NOT NULL,
	[LastApprovalId] [nvarchar](max) NOT NULL,
	[IsStatus] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_PermissionControls] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[ApprovalControl_Logs] ([Id], [CompanyId], [ParentMajorId], [MajorId], [DeptId], [UserId], [PermissionId], [ApprovalStepId], [GroupId], [Ordinarily], [CreateAt], [CreateBy], [IsActive], [ApprovalUserId], [DateApproval], [DepartmentId], [DepartmentOrder], [ApprovalOrder], [ApprovalId], [LastApprovalId], [IsStatus], [IdChung], [IsValid]) VALUES (N'0536b740-88e4-4d88-a4b2-4bd555316a4d', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', N'e8398fce-49c2-4247-841b-ec12e27e63c4', N'b6141ccb-2814-4f39-8c00-41953929e92c', N'4f23ee3e-876b-42ed-b60b-9d318a056eb2', N'27b8a027-df02-422e-aaf4-78aabc82f317', N'', N'', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', 0, CAST(N'2025-02-06T13:00:44.6874302' AS DateTime2), N'27b8a027-df02-422e-aaf4-78aabc82f317', 1, N'', CAST(N'2025-02-06T13:00:44.6871080' AS DateTime2), N'', 0, 0, N'', N'', N'', N'6b2fee78-3086-473c-8397-9799eb62dae1', 0)
INSERT [dbo].[ApprovalControl_Logs] ([Id], [CompanyId], [ParentMajorId], [MajorId], [DeptId], [UserId], [PermissionId], [ApprovalStepId], [GroupId], [Ordinarily], [CreateAt], [CreateBy], [IsActive], [ApprovalUserId], [DateApproval], [DepartmentId], [DepartmentOrder], [ApprovalOrder], [ApprovalId], [LastApprovalId], [IsStatus], [IdChung], [IsValid]) VALUES (N'6941ef34-8f8f-41f0-9d9d-8c760bac2e06', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', N'e8398fce-49c2-4247-841b-ec12e27e63c4', N'b6141ccb-2814-4f39-8c00-41953929e92c', N'4f23ee3e-876b-42ed-b60b-9d318a056eb2', N'27b8a027-df02-422e-aaf4-78aabc82f317', N'0096270B-2674-40F1-AD70-8F1ED7E5AF48', N'', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', 0, CAST(N'2025-02-06T13:00:56.1899695' AS DateTime2), N'27b8a027-df02-422e-aaf4-78aabc82f317', 1, N'', CAST(N'2025-02-06T13:00:56.1897229' AS DateTime2), N'', 0, 0, N'', N'', N'', N'6941ef34-8f8f-41f0-9d9d-8c760bac2e06', 1)
INSERT [dbo].[ApprovalControl_Logs] ([Id], [CompanyId], [ParentMajorId], [MajorId], [DeptId], [UserId], [PermissionId], [ApprovalStepId], [GroupId], [Ordinarily], [CreateAt], [CreateBy], [IsActive], [ApprovalUserId], [DateApproval], [DepartmentId], [DepartmentOrder], [ApprovalOrder], [ApprovalId], [LastApprovalId], [IsStatus], [IdChung], [IsValid]) VALUES (N'6b2fee78-3086-473c-8397-9799eb62dae1', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', N'e8398fce-49c2-4247-841b-ec12e27e63c4', N'b6141ccb-2814-4f39-8c00-41953929e92c', N'4f23ee3e-876b-42ed-b60b-9d318a056eb2', N'27b8a027-df02-422e-aaf4-78aabc82f317', N'0096270B-2674-40F1-AD70-8F1ED7E5AF48', N'', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', 0, CAST(N'2025-02-06T11:48:38.8050949' AS DateTime2), N'27b8a027-df02-422e-aaf4-78aabc82f317', 1, N'', CAST(N'2025-02-06T11:48:38.8045420' AS DateTime2), N'', 0, 0, N'', N'', N'', N'6b2fee78-3086-473c-8397-9799eb62dae1', 0)
GO
INSERT [dbo].[ApprovalControls] ([Id], [CompanyId], [ParentMajorId], [MajorId], [DeptId], [UserId], [PermissionId], [ApprovalStepId], [GroupId], [Ordinarily], [CreateAt], [CreateBy], [IsActive], [ApprovalUserId], [DateApproval], [DepartmentId], [DepartmentOrder], [ApprovalOrder], [ApprovalId], [LastApprovalId], [IsStatus]) VALUES (N'6941ef34-8f8f-41f0-9d9d-8c760bac2e06', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', N'e8398fce-49c2-4247-841b-ec12e27e63c4', N'b6141ccb-2814-4f39-8c00-41953929e92c', N'4f23ee3e-876b-42ed-b60b-9d318a056eb2', N'27b8a027-df02-422e-aaf4-78aabc82f317', N'0096270B-2674-40F1-AD70-8F1ED7E5AF48', N'3a9e73f6-a507-431f-9b04-5862440c009c', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', 0, CAST(N'2025-02-06T13:00:56.1802662' AS DateTime2), N'27b8a027-df02-422e-aaf4-78aabc82f317', 1, N'', CAST(N'2025-02-06T13:00:47.0507362' AS DateTime2), N'', 0, 0, N'', N'', N'')
INSERT [dbo].[ApprovalControls] ([Id], [CompanyId], [ParentMajorId], [MajorId], [DeptId], [UserId], [PermissionId], [ApprovalStepId], [GroupId], [Ordinarily], [CreateAt], [CreateBy], [IsActive], [ApprovalUserId], [DateApproval], [DepartmentId], [DepartmentOrder], [ApprovalOrder], [ApprovalId], [LastApprovalId], [IsStatus]) VALUES (N'6b2fee78-3086-473c-8397-9799eb62dae1', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', N'e8398fce-49c2-4247-841b-ec12e27e63c4', N'b6141ccb-2814-4f39-8c00-41953929e92c', N'4f23ee3e-876b-42ed-b60b-9d318a056eb2', N'27b8a027-df02-422e-aaf4-78aabc82f317', N'0096270B-2674-40F1-AD70-8F1ED7E5AF48', N'3a9e73f6-a507-431f-9b04-5862440c009c', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', 0, CAST(N'2025-02-06T13:00:44.6066981' AS DateTime2), N'27b8a027-df02-422e-aaf4-78aabc82f317', 100, N'', CAST(N'2025-02-06T11:48:27.9275527' AS DateTime2), N'', 0, 0, N'', N'', N'')
GO
INSERT [dbo].[MajorUserApproval_logs] ([Id], [CompanyId], [ParentMajorId], [MajorId], [DeptId], [UserId], [PermissionId], [ApprovalStepId], [IdMain], [DayinWeek], [GroupId], [CreateAt], [CreateBy], [IsActive], [ApprovalUserId], [DateApproval], [DepartmentId], [DepartmentOrder], [ApprovalOrder], [ApprovalId], [LastApprovalId], [IsStatus], [IdChung], [IsValid]) VALUES (N'6a157c07-8917-45ba-a8c6-f79dcbe0751f', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', N'e8398fce-49c2-4247-841b-ec12e27e63c4', N'b6141ccb-2814-4f39-8c00-41953929e92c', N'4f23ee3e-876b-42ed-b60b-9d318a056eb2', N'27b8a027-df02-422e-aaf4-78aabc82f317', N'0096270B-2674-40F1-AD70-8F1ED7E5AF48', N'', N'', N'2', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', CAST(N'2025-02-06T13:41:01.5854307' AS DateTime2), N'27b8a027-df02-422e-aaf4-78aabc82f317', 1, N'', CAST(N'2025-02-06T13:41:01.5850041' AS DateTime2), N'', 0, 0, N'', N'', N'', N'a3cee96c-7bb0-4af9-9598-1c7aafa0345a', 0)
INSERT [dbo].[MajorUserApproval_logs] ([Id], [CompanyId], [ParentMajorId], [MajorId], [DeptId], [UserId], [PermissionId], [ApprovalStepId], [IdMain], [DayinWeek], [GroupId], [CreateAt], [CreateBy], [IsActive], [ApprovalUserId], [DateApproval], [DepartmentId], [DepartmentOrder], [ApprovalOrder], [ApprovalId], [LastApprovalId], [IsStatus], [IdChung], [IsValid]) VALUES (N'84ba77d1-c145-471b-9ebb-fe6a3b0a9f19', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', N'e8398fce-49c2-4247-841b-ec12e27e63c4', N'b6141ccb-2814-4f39-8c00-41953929e92c', N'4f23ee3e-876b-42ed-b60b-9d318a056eb2', N'27b8a027-df02-422e-aaf4-78aabc82f317', N'0096270B-2674-40F1-AD70-8F1ED7E5AF48', N'', N'', N'1', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', CAST(N'2025-02-06T13:35:22.6818512' AS DateTime2), N'27b8a027-df02-422e-aaf4-78aabc82f317', 1, N'', CAST(N'2025-02-06T13:35:22.6812006' AS DateTime2), N'', 0, 0, N'', N'', N'', N'cb87457e-bbc8-4aa6-b3c1-ceab30f3d3ef', 0)
INSERT [dbo].[MajorUserApproval_logs] ([Id], [CompanyId], [ParentMajorId], [MajorId], [DeptId], [UserId], [PermissionId], [ApprovalStepId], [IdMain], [DayinWeek], [GroupId], [CreateAt], [CreateBy], [IsActive], [ApprovalUserId], [DateApproval], [DepartmentId], [DepartmentOrder], [ApprovalOrder], [ApprovalId], [LastApprovalId], [IsStatus], [IdChung], [IsValid]) VALUES (N'fb98b928-1210-47f6-a674-120ce02e04a1', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', N'e8398fce-49c2-4247-841b-ec12e27e63c4', N'b6141ccb-2814-4f39-8c00-41953929e92c', N'4f23ee3e-876b-42ed-b60b-9d318a056eb2', N'27b8a027-df02-422e-aaf4-78aabc82f317', N'0096270B-2674-40F1-AD70-8F1ED7E5AF48', N'', N'', N'1', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', CAST(N'2025-02-06T11:01:39.4174223' AS DateTime2), N'27b8a027-df02-422e-aaf4-78aabc82f317', 1, N'', CAST(N'2025-02-06T11:01:39.4165330' AS DateTime2), N'', 0, 0, N'', N'', N'', N'3909de75-5574-4804-8c50-e456e66b3826', 0)
GO
INSERT [dbo].[MajorUserApprovals] ([Id], [CompanyId], [ParentMajorId], [MajorId], [DeptId], [UserId], [PermissionId], [ApprovalStepId], [IdMain], [DayinWeek], [GroupId], [CreateAt], [CreateBy], [IsActive], [ApprovalUserId], [DateApproval], [DepartmentId], [DepartmentOrder], [ApprovalId], [ApprovalOrder], [LastApprovalId], [IsStatus]) VALUES (N'055be9de-af3f-4292-b3ae-835dea764370', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', N'e8398fce-49c2-4247-841b-ec12e27e63c4', N'b6141ccb-2814-4f39-8c00-41953929e92c', N'4f23ee3e-876b-42ed-b60b-9d318a056eb2', N'27b8a027-df02-422e-aaf4-78aabc82f317', N'0096270B-2674-40F1-AD70-8F1ED7E5AF48', N'3a9e73f6-a507-431f-9b04-5862440c009c', N'125263e6-3463-49f3-90b5-eb9fa54edb7d', N'2', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', CAST(N'2025-02-06T11:06:49.3896190' AS DateTime2), N'27b8a027-df02-422e-aaf4-78aabc82f317', 100, N'', CAST(N'2025-02-06T11:06:49.4056931' AS DateTime2), N'', 0, N'', 0, N'', N'')
INSERT [dbo].[MajorUserApprovals] ([Id], [CompanyId], [ParentMajorId], [MajorId], [DeptId], [UserId], [PermissionId], [ApprovalStepId], [IdMain], [DayinWeek], [GroupId], [CreateAt], [CreateBy], [IsActive], [ApprovalUserId], [DateApproval], [DepartmentId], [DepartmentOrder], [ApprovalId], [ApprovalOrder], [LastApprovalId], [IsStatus]) VALUES (N'0cce8885-5fee-493e-9c10-f3d8d7f20133', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', N'e8398fce-49c2-4247-841b-ec12e27e63c4', N'b6141ccb-2814-4f39-8c00-41953929e92c', N'4f23ee3e-876b-42ed-b60b-9d318a056eb2', N'27b8a027-df02-422e-aaf4-78aabc82f317', N'0096270B-2674-40F1-AD70-8F1ED7E5AF48', N'd02953ce-9644-4e3e-b660-bdac9017d3cf', N'c5d75340-1843-40bb-bfea-cb878a813f01', N'2', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', CAST(N'2025-02-06T11:04:35.6012549' AS DateTime2), N'27b8a027-df02-422e-aaf4-78aabc82f317', 100, N'', CAST(N'2025-02-06T11:04:35.6155007' AS DateTime2), N'', 0, N'', 0, N'', N'')
INSERT [dbo].[MajorUserApprovals] ([Id], [CompanyId], [ParentMajorId], [MajorId], [DeptId], [UserId], [PermissionId], [ApprovalStepId], [IdMain], [DayinWeek], [GroupId], [CreateAt], [CreateBy], [IsActive], [ApprovalUserId], [DateApproval], [DepartmentId], [DepartmentOrder], [ApprovalId], [ApprovalOrder], [LastApprovalId], [IsStatus]) VALUES (N'125263e6-3463-49f3-90b5-eb9fa54edb7d', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', N'e8398fce-49c2-4247-841b-ec12e27e63c4', N'b6141ccb-2814-4f39-8c00-41953929e92c', N'4f23ee3e-876b-42ed-b60b-9d318a056eb2', N'27b8a027-df02-422e-aaf4-78aabc82f317', N'0096270B-2674-40F1-AD70-8F1ED7E5AF48', N'3a9e73f6-a507-431f-9b04-5862440c009c', N'0cce8885-5fee-493e-9c10-f3d8d7f20133', N'1', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', CAST(N'2025-02-06T11:04:44.0447148' AS DateTime2), N'27b8a027-df02-422e-aaf4-78aabc82f317', 100, N'', CAST(N'2025-02-06T11:04:44.0577672' AS DateTime2), N'', 0, N'', 0, N'', N'')
INSERT [dbo].[MajorUserApprovals] ([Id], [CompanyId], [ParentMajorId], [MajorId], [DeptId], [UserId], [PermissionId], [ApprovalStepId], [IdMain], [DayinWeek], [GroupId], [CreateAt], [CreateBy], [IsActive], [ApprovalUserId], [DateApproval], [DepartmentId], [DepartmentOrder], [ApprovalId], [ApprovalOrder], [LastApprovalId], [IsStatus]) VALUES (N'13273ae9-8f1c-4530-aa8c-9308600721e3', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', N'e8398fce-49c2-4247-841b-ec12e27e63c4', N'b6141ccb-2814-4f39-8c00-41953929e92c', N'4f23ee3e-876b-42ed-b60b-9d318a056eb2', N'27b8a027-df02-422e-aaf4-78aabc82f317', N'0096270B-2674-40F1-AD70-8F1ED7E5AF48', N'3a9e73f6-a507-431f-9b04-5862440c009c', N'125263e6-3463-49f3-90b5-eb9fa54edb7d', N'3', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', CAST(N'2025-02-06T11:06:49.3896190' AS DateTime2), N'27b8a027-df02-422e-aaf4-78aabc82f317', 100, N'', CAST(N'2025-02-06T11:06:49.4056944' AS DateTime2), N'', 0, N'', 0, N'', N'')
INSERT [dbo].[MajorUserApprovals] ([Id], [CompanyId], [ParentMajorId], [MajorId], [DeptId], [UserId], [PermissionId], [ApprovalStepId], [IdMain], [DayinWeek], [GroupId], [CreateAt], [CreateBy], [IsActive], [ApprovalUserId], [DateApproval], [DepartmentId], [DepartmentOrder], [ApprovalId], [ApprovalOrder], [LastApprovalId], [IsStatus]) VALUES (N'2586dd35-5da9-4ff5-9808-966c5af450e7', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', N'e8398fce-49c2-4247-841b-ec12e27e63c4', N'b6141ccb-2814-4f39-8c00-41953929e92c', N'4f23ee3e-876b-42ed-b60b-9d318a056eb2', N'27b8a027-df02-422e-aaf4-78aabc82f317', N'0096270B-2674-40F1-AD70-8F1ED7E5AF48', N'3a9e73f6-a507-431f-9b04-5862440c009c', N'a3cee96c-7bb0-4af9-9598-1c7aafa0345a', N'2', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', CAST(N'2025-02-06T13:40:55.5513261' AS DateTime2), N'27b8a027-df02-422e-aaf4-78aabc82f317', 100, N'', CAST(N'2025-02-06T13:40:55.5740144' AS DateTime2), N'', 0, N'', 0, N'', N'')
INSERT [dbo].[MajorUserApprovals] ([Id], [CompanyId], [ParentMajorId], [MajorId], [DeptId], [UserId], [PermissionId], [ApprovalStepId], [IdMain], [DayinWeek], [GroupId], [CreateAt], [CreateBy], [IsActive], [ApprovalUserId], [DateApproval], [DepartmentId], [DepartmentOrder], [ApprovalId], [ApprovalOrder], [LastApprovalId], [IsStatus]) VALUES (N'2af795e5-8fb5-4e1b-9579-e7b8f8b1f75c', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', N'e8398fce-49c2-4247-841b-ec12e27e63c4', N'b6141ccb-2814-4f39-8c00-41953929e92c', N'4f23ee3e-876b-42ed-b60b-9d318a056eb2', N'27b8a027-df02-422e-aaf4-78aabc82f317', N'0096270B-2674-40F1-AD70-8F1ED7E5AF48', N'3a9e73f6-a507-431f-9b04-5862440c009c', N'0cce8885-5fee-493e-9c10-f3d8d7f20133', N'2', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', CAST(N'2025-02-06T11:04:44.0447148' AS DateTime2), N'27b8a027-df02-422e-aaf4-78aabc82f317', 100, N'', CAST(N'2025-02-06T11:04:44.0577716' AS DateTime2), N'', 0, N'', 0, N'', N'')
INSERT [dbo].[MajorUserApprovals] ([Id], [CompanyId], [ParentMajorId], [MajorId], [DeptId], [UserId], [PermissionId], [ApprovalStepId], [IdMain], [DayinWeek], [GroupId], [CreateAt], [CreateBy], [IsActive], [ApprovalUserId], [DateApproval], [DepartmentId], [DepartmentOrder], [ApprovalId], [ApprovalOrder], [LastApprovalId], [IsStatus]) VALUES (N'31f7359a-b754-450d-891d-d28d4060c999', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', N'e8398fce-49c2-4247-841b-ec12e27e63c4', N'b6141ccb-2814-4f39-8c00-41953929e92c', N'4f23ee3e-876b-42ed-b60b-9d318a056eb2', N'27b8a027-df02-422e-aaf4-78aabc82f317', N'0096270B-2674-40F1-AD70-8F1ED7E5AF48', N'3a9e73f6-a507-431f-9b04-5862440c009c', N'cb87457e-bbc8-4aa6-b3c1-ceab30f3d3ef', N'1', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', CAST(N'2025-02-06T11:17:08.4119470' AS DateTime2), N'27b8a027-df02-422e-aaf4-78aabc82f317', 100, N'', CAST(N'2025-02-06T11:17:08.5691881' AS DateTime2), N'', 0, N'', 0, N'', N'')
INSERT [dbo].[MajorUserApprovals] ([Id], [CompanyId], [ParentMajorId], [MajorId], [DeptId], [UserId], [PermissionId], [ApprovalStepId], [IdMain], [DayinWeek], [GroupId], [CreateAt], [CreateBy], [IsActive], [ApprovalUserId], [DateApproval], [DepartmentId], [DepartmentOrder], [ApprovalId], [ApprovalOrder], [LastApprovalId], [IsStatus]) VALUES (N'36b2569f-1cf8-44fb-8b90-4021eabff07c', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', N'e8398fce-49c2-4247-841b-ec12e27e63c4', N'b6141ccb-2814-4f39-8c00-41953929e92c', N'4f23ee3e-876b-42ed-b60b-9d318a056eb2', N'27b8a027-df02-422e-aaf4-78aabc82f317', N'0096270B-2674-40F1-AD70-8F1ED7E5AF48', N'3a9e73f6-a507-431f-9b04-5862440c009c', N'3909de75-5574-4804-8c50-e456e66b3826', N'1', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', CAST(N'2025-02-06T11:01:31.5833473' AS DateTime2), N'27b8a027-df02-422e-aaf4-78aabc82f317', 100, N'', CAST(N'2025-02-06T11:01:31.7412753' AS DateTime2), N'', 0, N'', 0, N'', N'')
INSERT [dbo].[MajorUserApprovals] ([Id], [CompanyId], [ParentMajorId], [MajorId], [DeptId], [UserId], [PermissionId], [ApprovalStepId], [IdMain], [DayinWeek], [GroupId], [CreateAt], [CreateBy], [IsActive], [ApprovalUserId], [DateApproval], [DepartmentId], [DepartmentOrder], [ApprovalId], [ApprovalOrder], [LastApprovalId], [IsStatus]) VALUES (N'38b3e3a5-f589-498c-8757-c512a9693b44', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', N'e8398fce-49c2-4247-841b-ec12e27e63c4', N'b6141ccb-2814-4f39-8c00-41953929e92c', N'4f23ee3e-876b-42ed-b60b-9d318a056eb2', N'27b8a027-df02-422e-aaf4-78aabc82f317', N'0096270B-2674-40F1-AD70-8F1ED7E5AF48', N'3a9e73f6-a507-431f-9b04-5862440c009c', N'a3cee96c-7bb0-4af9-9598-1c7aafa0345a', N'1', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', CAST(N'2025-02-06T13:40:55.5513261' AS DateTime2), N'27b8a027-df02-422e-aaf4-78aabc82f317', 100, N'', CAST(N'2025-02-06T13:40:55.5735893' AS DateTime2), N'', 0, N'', 0, N'', N'')
INSERT [dbo].[MajorUserApprovals] ([Id], [CompanyId], [ParentMajorId], [MajorId], [DeptId], [UserId], [PermissionId], [ApprovalStepId], [IdMain], [DayinWeek], [GroupId], [CreateAt], [CreateBy], [IsActive], [ApprovalUserId], [DateApproval], [DepartmentId], [DepartmentOrder], [ApprovalId], [ApprovalOrder], [LastApprovalId], [IsStatus]) VALUES (N'3909de75-5574-4804-8c50-e456e66b3826', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', N'e8398fce-49c2-4247-841b-ec12e27e63c4', N'b6141ccb-2814-4f39-8c00-41953929e92c', N'4f23ee3e-876b-42ed-b60b-9d318a056eb2', N'27b8a027-df02-422e-aaf4-78aabc82f317', N'0096270B-2674-40F1-AD70-8F1ED7E5AF48', N'3a9e73f6-a507-431f-9b04-5862440c009c', N'84c1dfef-e130-4bc0-a003-ea3d7f4f7c82', N'2', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', CAST(N'2025-02-06T10:57:40.4304626' AS DateTime2), N'27b8a027-df02-422e-aaf4-78aabc82f317', 100, N'', CAST(N'2025-02-06T10:57:40.4495167' AS DateTime2), N'', 0, N'', 0, N'', N'')
INSERT [dbo].[MajorUserApprovals] ([Id], [CompanyId], [ParentMajorId], [MajorId], [DeptId], [UserId], [PermissionId], [ApprovalStepId], [IdMain], [DayinWeek], [GroupId], [CreateAt], [CreateBy], [IsActive], [ApprovalUserId], [DateApproval], [DepartmentId], [DepartmentOrder], [ApprovalId], [ApprovalOrder], [LastApprovalId], [IsStatus]) VALUES (N'4b4467ac-62c3-4a71-8f58-f0a35ce49047', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', N'e8398fce-49c2-4247-841b-ec12e27e63c4', N'b6141ccb-2814-4f39-8c00-41953929e92c', N'4f23ee3e-876b-42ed-b60b-9d318a056eb2', N'27b8a027-df02-422e-aaf4-78aabc82f317', N'0096270B-2674-40F1-AD70-8F1ED7E5AF48', N'3a9e73f6-a507-431f-9b04-5862440c009c', N'c5d75340-1843-40bb-bfea-cb878a813f01', N'1', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', CAST(N'2025-02-06T11:04:35.6012549' AS DateTime2), N'27b8a027-df02-422e-aaf4-78aabc82f317', 100, N'', CAST(N'2025-02-06T11:04:35.6150921' AS DateTime2), N'', 0, N'', 0, N'', N'')
INSERT [dbo].[MajorUserApprovals] ([Id], [CompanyId], [ParentMajorId], [MajorId], [DeptId], [UserId], [PermissionId], [ApprovalStepId], [IdMain], [DayinWeek], [GroupId], [CreateAt], [CreateBy], [IsActive], [ApprovalUserId], [DateApproval], [DepartmentId], [DepartmentOrder], [ApprovalId], [ApprovalOrder], [LastApprovalId], [IsStatus]) VALUES (N'4b7ae4df-66ec-4d3b-ad22-23c363c751dd', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', N'e8398fce-49c2-4247-841b-ec12e27e63c4', N'b6141ccb-2814-4f39-8c00-41953929e92c', N'4f23ee3e-876b-42ed-b60b-9d318a056eb2', N'27b8a027-df02-422e-aaf4-78aabc82f317', N'0096270B-2674-40F1-AD70-8F1ED7E5AF48', N'3a9e73f6-a507-431f-9b04-5862440c009c', N'3909de75-5574-4804-8c50-e456e66b3826', N'2', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', CAST(N'2025-02-06T11:01:31.5833473' AS DateTime2), N'27b8a027-df02-422e-aaf4-78aabc82f317', 100, N'', CAST(N'2025-02-06T11:01:31.7419799' AS DateTime2), N'', 0, N'', 0, N'', N'')
INSERT [dbo].[MajorUserApprovals] ([Id], [CompanyId], [ParentMajorId], [MajorId], [DeptId], [UserId], [PermissionId], [ApprovalStepId], [IdMain], [DayinWeek], [GroupId], [CreateAt], [CreateBy], [IsActive], [ApprovalUserId], [DateApproval], [DepartmentId], [DepartmentOrder], [ApprovalId], [ApprovalOrder], [LastApprovalId], [IsStatus]) VALUES (N'55fcab7c-5423-4cd6-a512-bda57c0f46d4', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', N'e8398fce-49c2-4247-841b-ec12e27e63c4', N'b6141ccb-2814-4f39-8c00-41953929e92c', N'4f23ee3e-876b-42ed-b60b-9d318a056eb2', N'27b8a027-df02-422e-aaf4-78aabc82f317', N'0096270B-2674-40F1-AD70-8F1ED7E5AF48', N'3a9e73f6-a507-431f-9b04-5862440c009c', N'5ae3d313-8914-4c9b-89ff-92829952b6c5', N'2', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', CAST(N'2025-02-06T14:04:21.9957018' AS DateTime2), N'27b8a027-df02-422e-aaf4-78aabc82f317', 1, N'', CAST(N'2025-02-06T14:04:22.0237649' AS DateTime2), N'', 0, N'', 0, N'', N'')
INSERT [dbo].[MajorUserApprovals] ([Id], [CompanyId], [ParentMajorId], [MajorId], [DeptId], [UserId], [PermissionId], [ApprovalStepId], [IdMain], [DayinWeek], [GroupId], [CreateAt], [CreateBy], [IsActive], [ApprovalUserId], [DateApproval], [DepartmentId], [DepartmentOrder], [ApprovalId], [ApprovalOrder], [LastApprovalId], [IsStatus]) VALUES (N'71abb49f-f7a8-4bb2-9e8b-bc11500c72b9', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', N'e8398fce-49c2-4247-841b-ec12e27e63c4', N'b6141ccb-2814-4f39-8c00-41953929e92c', N'4f23ee3e-876b-42ed-b60b-9d318a056eb2', N'27b8a027-df02-422e-aaf4-78aabc82f317', N'0096270B-2674-40F1-AD70-8F1ED7E5AF48', N'd02953ce-9644-4e3e-b660-bdac9017d3cf', N'125263e6-3463-49f3-90b5-eb9fa54edb7d', N'3', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', CAST(N'2025-02-06T11:06:49.3896190' AS DateTime2), N'27b8a027-df02-422e-aaf4-78aabc82f317', 100, N'', CAST(N'2025-02-06T11:06:49.4056966' AS DateTime2), N'', 0, N'', 0, N'', N'')
INSERT [dbo].[MajorUserApprovals] ([Id], [CompanyId], [ParentMajorId], [MajorId], [DeptId], [UserId], [PermissionId], [ApprovalStepId], [IdMain], [DayinWeek], [GroupId], [CreateAt], [CreateBy], [IsActive], [ApprovalUserId], [DateApproval], [DepartmentId], [DepartmentOrder], [ApprovalId], [ApprovalOrder], [LastApprovalId], [IsStatus]) VALUES (N'79fb30a6-0e3c-44a0-a4d0-2ff4af533de0', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', N'e8398fce-49c2-4247-841b-ec12e27e63c4', N'b6141ccb-2814-4f39-8c00-41953929e92c', N'4f23ee3e-876b-42ed-b60b-9d318a056eb2', N'27b8a027-df02-422e-aaf4-78aabc82f317', N'0096270B-2674-40F1-AD70-8F1ED7E5AF48', N'd02953ce-9644-4e3e-b660-bdac9017d3cf', N'0cce8885-5fee-493e-9c10-f3d8d7f20133', N'2', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', CAST(N'2025-02-06T11:04:44.0447148' AS DateTime2), N'27b8a027-df02-422e-aaf4-78aabc82f317', 100, N'', CAST(N'2025-02-06T11:04:44.0577738' AS DateTime2), N'', 0, N'', 0, N'', N'')
INSERT [dbo].[MajorUserApprovals] ([Id], [CompanyId], [ParentMajorId], [MajorId], [DeptId], [UserId], [PermissionId], [ApprovalStepId], [IdMain], [DayinWeek], [GroupId], [CreateAt], [CreateBy], [IsActive], [ApprovalUserId], [DateApproval], [DepartmentId], [DepartmentOrder], [ApprovalId], [ApprovalOrder], [LastApprovalId], [IsStatus]) VALUES (N'822c4085-d8ff-488a-af27-ad68a3ebabe7', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', N'e8398fce-49c2-4247-841b-ec12e27e63c4', N'b6141ccb-2814-4f39-8c00-41953929e92c', N'4f23ee3e-876b-42ed-b60b-9d318a056eb2', N'27b8a027-df02-422e-aaf4-78aabc82f317', N'0096270B-2674-40F1-AD70-8F1ED7E5AF48', N'd02953ce-9644-4e3e-b660-bdac9017d3cf', N'c5d75340-1843-40bb-bfea-cb878a813f01', N'1', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', CAST(N'2025-02-06T11:04:35.6012549' AS DateTime2), N'27b8a027-df02-422e-aaf4-78aabc82f317', 100, N'', CAST(N'2025-02-06T11:04:35.6154998' AS DateTime2), N'', 0, N'', 0, N'', N'')
INSERT [dbo].[MajorUserApprovals] ([Id], [CompanyId], [ParentMajorId], [MajorId], [DeptId], [UserId], [PermissionId], [ApprovalStepId], [IdMain], [DayinWeek], [GroupId], [CreateAt], [CreateBy], [IsActive], [ApprovalUserId], [DateApproval], [DepartmentId], [DepartmentOrder], [ApprovalId], [ApprovalOrder], [LastApprovalId], [IsStatus]) VALUES (N'826bfc8d-e2a8-4dcf-bc4f-350965fcf01f', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', N'e8398fce-49c2-4247-841b-ec12e27e63c4', N'b6141ccb-2814-4f39-8c00-41953929e92c', N'4f23ee3e-876b-42ed-b60b-9d318a056eb2', N'27b8a027-df02-422e-aaf4-78aabc82f317', N'0096270B-2674-40F1-AD70-8F1ED7E5AF48', N'3a9e73f6-a507-431f-9b04-5862440c009c', N'125263e6-3463-49f3-90b5-eb9fa54edb7d', N'1', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', CAST(N'2025-02-06T11:06:49.3896190' AS DateTime2), N'27b8a027-df02-422e-aaf4-78aabc82f317', 100, N'', CAST(N'2025-02-06T11:06:49.4051282' AS DateTime2), N'', 0, N'', 0, N'', N'')
INSERT [dbo].[MajorUserApprovals] ([Id], [CompanyId], [ParentMajorId], [MajorId], [DeptId], [UserId], [PermissionId], [ApprovalStepId], [IdMain], [DayinWeek], [GroupId], [CreateAt], [CreateBy], [IsActive], [ApprovalUserId], [DateApproval], [DepartmentId], [DepartmentOrder], [ApprovalId], [ApprovalOrder], [LastApprovalId], [IsStatus]) VALUES (N'8ca3a7c2-bbc3-4249-a4b4-1ab055bfe3ca', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', N'e8398fce-49c2-4247-841b-ec12e27e63c4', N'b6141ccb-2814-4f39-8c00-41953929e92c', N'4f23ee3e-876b-42ed-b60b-9d318a056eb2', N'27b8a027-df02-422e-aaf4-78aabc82f317', N'0096270B-2674-40F1-AD70-8F1ED7E5AF48', N'd02953ce-9644-4e3e-b660-bdac9017d3cf', N'125263e6-3463-49f3-90b5-eb9fa54edb7d', N'2', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', CAST(N'2025-02-06T11:06:49.3896190' AS DateTime2), N'27b8a027-df02-422e-aaf4-78aabc82f317', 100, N'', CAST(N'2025-02-06T11:06:49.4056959' AS DateTime2), N'', 0, N'', 0, N'', N'')
INSERT [dbo].[MajorUserApprovals] ([Id], [CompanyId], [ParentMajorId], [MajorId], [DeptId], [UserId], [PermissionId], [ApprovalStepId], [IdMain], [DayinWeek], [GroupId], [CreateAt], [CreateBy], [IsActive], [ApprovalUserId], [DateApproval], [DepartmentId], [DepartmentOrder], [ApprovalId], [ApprovalOrder], [LastApprovalId], [IsStatus]) VALUES (N'8d2f0123-db46-47f4-8b2c-55c8125e3e71', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', N'e8398fce-49c2-4247-841b-ec12e27e63c4', N'b6141ccb-2814-4f39-8c00-41953929e92c', N'4f23ee3e-876b-42ed-b60b-9d318a056eb2', N'27b8a027-df02-422e-aaf4-78aabc82f317', N'0096270B-2674-40F1-AD70-8F1ED7E5AF48', N'd02953ce-9644-4e3e-b660-bdac9017d3cf', N'0cce8885-5fee-493e-9c10-f3d8d7f20133', N'1', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', CAST(N'2025-02-06T11:04:44.0447148' AS DateTime2), N'27b8a027-df02-422e-aaf4-78aabc82f317', 100, N'', CAST(N'2025-02-06T11:04:44.0577732' AS DateTime2), N'', 0, N'', 0, N'', N'')
INSERT [dbo].[MajorUserApprovals] ([Id], [CompanyId], [ParentMajorId], [MajorId], [DeptId], [UserId], [PermissionId], [ApprovalStepId], [IdMain], [DayinWeek], [GroupId], [CreateAt], [CreateBy], [IsActive], [ApprovalUserId], [DateApproval], [DepartmentId], [DepartmentOrder], [ApprovalId], [ApprovalOrder], [LastApprovalId], [IsStatus]) VALUES (N'96fa5e71-81d3-4732-83e7-4b5ab40b1228', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', N'e8398fce-49c2-4247-841b-ec12e27e63c4', N'b6141ccb-2814-4f39-8c00-41953929e92c', N'4f23ee3e-876b-42ed-b60b-9d318a056eb2', N'27b8a027-df02-422e-aaf4-78aabc82f317', N'0096270B-2674-40F1-AD70-8F1ED7E5AF48', N'd02953ce-9644-4e3e-b660-bdac9017d3cf', N'84c1dfef-e130-4bc0-a003-ea3d7f4f7c82', N'2', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', CAST(N'2025-02-06T10:57:40.4304626' AS DateTime2), N'27b8a027-df02-422e-aaf4-78aabc82f317', 100, N'', CAST(N'2025-02-06T10:57:40.4495195' AS DateTime2), N'', 0, N'', 0, N'', N'')
INSERT [dbo].[MajorUserApprovals] ([Id], [CompanyId], [ParentMajorId], [MajorId], [DeptId], [UserId], [PermissionId], [ApprovalStepId], [IdMain], [DayinWeek], [GroupId], [CreateAt], [CreateBy], [IsActive], [ApprovalUserId], [DateApproval], [DepartmentId], [DepartmentOrder], [ApprovalId], [ApprovalOrder], [LastApprovalId], [IsStatus]) VALUES (N'a8f88fa7-dc54-44a1-bea3-f616310392aa', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', N'e8398fce-49c2-4247-841b-ec12e27e63c4', N'b6141ccb-2814-4f39-8c00-41953929e92c', N'4f23ee3e-876b-42ed-b60b-9d318a056eb2', N'27b8a027-df02-422e-aaf4-78aabc82f317', N'0096270B-2674-40F1-AD70-8F1ED7E5AF48', N'd02953ce-9644-4e3e-b660-bdac9017d3cf', N'84c1dfef-e130-4bc0-a003-ea3d7f4f7c82', N'1', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', CAST(N'2025-02-06T10:57:40.4304626' AS DateTime2), N'27b8a027-df02-422e-aaf4-78aabc82f317', 100, N'', CAST(N'2025-02-06T10:57:40.4495183' AS DateTime2), N'', 0, N'', 0, N'', N'')
INSERT [dbo].[MajorUserApprovals] ([Id], [CompanyId], [ParentMajorId], [MajorId], [DeptId], [UserId], [PermissionId], [ApprovalStepId], [IdMain], [DayinWeek], [GroupId], [CreateAt], [CreateBy], [IsActive], [ApprovalUserId], [DateApproval], [DepartmentId], [DepartmentOrder], [ApprovalId], [ApprovalOrder], [LastApprovalId], [IsStatus]) VALUES (N'a9891d11-fdaf-44c8-bbb8-97d90b8122cd', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', N'e8398fce-49c2-4247-841b-ec12e27e63c4', N'b6141ccb-2814-4f39-8c00-41953929e92c', N'4f23ee3e-876b-42ed-b60b-9d318a056eb2', N'27b8a027-df02-422e-aaf4-78aabc82f317', N'0096270B-2674-40F1-AD70-8F1ED7E5AF48', N'3a9e73f6-a507-431f-9b04-5862440c009c', N'c5d75340-1843-40bb-bfea-cb878a813f01', N'2', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', CAST(N'2025-02-06T11:04:35.6012549' AS DateTime2), N'27b8a027-df02-422e-aaf4-78aabc82f317', 100, N'', CAST(N'2025-02-06T11:04:35.6154951' AS DateTime2), N'', 0, N'', 0, N'', N'')
INSERT [dbo].[MajorUserApprovals] ([Id], [CompanyId], [ParentMajorId], [MajorId], [DeptId], [UserId], [PermissionId], [ApprovalStepId], [IdMain], [DayinWeek], [GroupId], [CreateAt], [CreateBy], [IsActive], [ApprovalUserId], [DateApproval], [DepartmentId], [DepartmentOrder], [ApprovalId], [ApprovalOrder], [LastApprovalId], [IsStatus]) VALUES (N'ab9823af-ed6a-40cc-ab59-c23847afa940', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', N'e8398fce-49c2-4247-841b-ec12e27e63c4', N'b6141ccb-2814-4f39-8c00-41953929e92c', N'4f23ee3e-876b-42ed-b60b-9d318a056eb2', N'27b8a027-df02-422e-aaf4-78aabc82f317', N'0096270B-2674-40F1-AD70-8F1ED7E5AF48', N'3a9e73f6-a507-431f-9b04-5862440c009c', N'84c1dfef-e130-4bc0-a003-ea3d7f4f7c82', N'1', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', CAST(N'2025-02-06T10:57:40.4304626' AS DateTime2), N'27b8a027-df02-422e-aaf4-78aabc82f317', 100, N'', CAST(N'2025-02-06T10:57:40.4492144' AS DateTime2), N'', 0, N'', 0, N'', N'')
INSERT [dbo].[MajorUserApprovals] ([Id], [CompanyId], [ParentMajorId], [MajorId], [DeptId], [UserId], [PermissionId], [ApprovalStepId], [IdMain], [DayinWeek], [GroupId], [CreateAt], [CreateBy], [IsActive], [ApprovalUserId], [DateApproval], [DepartmentId], [DepartmentOrder], [ApprovalId], [ApprovalOrder], [LastApprovalId], [IsStatus]) VALUES (N'b0230b17-ace0-4fe0-8c90-85ffde0c8a0a', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', N'e8398fce-49c2-4247-841b-ec12e27e63c4', N'b6141ccb-2814-4f39-8c00-41953929e92c', N'4f23ee3e-876b-42ed-b60b-9d318a056eb2', N'27b8a027-df02-422e-aaf4-78aabc82f317', N'0096270B-2674-40F1-AD70-8F1ED7E5AF48', N'd02953ce-9644-4e3e-b660-bdac9017d3cf', N'5ae3d313-8914-4c9b-89ff-92829952b6c5', N'2', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', CAST(N'2025-02-06T14:04:21.9957018' AS DateTime2), N'27b8a027-df02-422e-aaf4-78aabc82f317', 1, N'', CAST(N'2025-02-06T14:04:22.0237690' AS DateTime2), N'', 0, N'', 0, N'', N'')
INSERT [dbo].[MajorUserApprovals] ([Id], [CompanyId], [ParentMajorId], [MajorId], [DeptId], [UserId], [PermissionId], [ApprovalStepId], [IdMain], [DayinWeek], [GroupId], [CreateAt], [CreateBy], [IsActive], [ApprovalUserId], [DateApproval], [DepartmentId], [DepartmentOrder], [ApprovalId], [ApprovalOrder], [LastApprovalId], [IsStatus]) VALUES (N'c7db5887-663f-4c61-8fa5-de5f3d654a5d', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', N'e8398fce-49c2-4247-841b-ec12e27e63c4', N'b6141ccb-2814-4f39-8c00-41953929e92c', N'4f23ee3e-876b-42ed-b60b-9d318a056eb2', N'27b8a027-df02-422e-aaf4-78aabc82f317', N'0096270B-2674-40F1-AD70-8F1ED7E5AF48', N'd02953ce-9644-4e3e-b660-bdac9017d3cf', N'5ae3d313-8914-4c9b-89ff-92829952b6c5', N'1', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', CAST(N'2025-02-06T14:04:21.9957018' AS DateTime2), N'27b8a027-df02-422e-aaf4-78aabc82f317', 1, N'', CAST(N'2025-02-06T14:04:22.0237663' AS DateTime2), N'', 0, N'', 0, N'', N'')
INSERT [dbo].[MajorUserApprovals] ([Id], [CompanyId], [ParentMajorId], [MajorId], [DeptId], [UserId], [PermissionId], [ApprovalStepId], [IdMain], [DayinWeek], [GroupId], [CreateAt], [CreateBy], [IsActive], [ApprovalUserId], [DateApproval], [DepartmentId], [DepartmentOrder], [ApprovalId], [ApprovalOrder], [LastApprovalId], [IsStatus]) VALUES (N'd05f685f-42e2-4316-a041-5b27db93a96a', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', N'e8398fce-49c2-4247-841b-ec12e27e63c4', N'b6141ccb-2814-4f39-8c00-41953929e92c', N'4f23ee3e-876b-42ed-b60b-9d318a056eb2', N'27b8a027-df02-422e-aaf4-78aabc82f317', N'0096270B-2674-40F1-AD70-8F1ED7E5AF48', N'd02953ce-9644-4e3e-b660-bdac9017d3cf', N'cb87457e-bbc8-4aa6-b3c1-ceab30f3d3ef', N'2', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', CAST(N'2025-02-06T11:17:08.4119470' AS DateTime2), N'27b8a027-df02-422e-aaf4-78aabc82f317', 100, N'', CAST(N'2025-02-06T11:17:08.5699562' AS DateTime2), N'', 0, N'', 0, N'', N'')
INSERT [dbo].[MajorUserApprovals] ([Id], [CompanyId], [ParentMajorId], [MajorId], [DeptId], [UserId], [PermissionId], [ApprovalStepId], [IdMain], [DayinWeek], [GroupId], [CreateAt], [CreateBy], [IsActive], [ApprovalUserId], [DateApproval], [DepartmentId], [DepartmentOrder], [ApprovalId], [ApprovalOrder], [LastApprovalId], [IsStatus]) VALUES (N'd1b2e169-3af1-442f-85e4-a07d432fff24', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', N'e8398fce-49c2-4247-841b-ec12e27e63c4', N'b6141ccb-2814-4f39-8c00-41953929e92c', N'4f23ee3e-876b-42ed-b60b-9d318a056eb2', N'27b8a027-df02-422e-aaf4-78aabc82f317', N'0096270B-2674-40F1-AD70-8F1ED7E5AF48', N'd02953ce-9644-4e3e-b660-bdac9017d3cf', N'125263e6-3463-49f3-90b5-eb9fa54edb7d', N'1', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', CAST(N'2025-02-06T11:06:49.3896190' AS DateTime2), N'27b8a027-df02-422e-aaf4-78aabc82f317', 100, N'', CAST(N'2025-02-06T11:06:49.4056951' AS DateTime2), N'', 0, N'', 0, N'', N'')
INSERT [dbo].[MajorUserApprovals] ([Id], [CompanyId], [ParentMajorId], [MajorId], [DeptId], [UserId], [PermissionId], [ApprovalStepId], [IdMain], [DayinWeek], [GroupId], [CreateAt], [CreateBy], [IsActive], [ApprovalUserId], [DateApproval], [DepartmentId], [DepartmentOrder], [ApprovalId], [ApprovalOrder], [LastApprovalId], [IsStatus]) VALUES (N'd3a6e5e5-f4ed-4686-a8d7-9350f84a1d53', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', N'e8398fce-49c2-4247-841b-ec12e27e63c4', N'b6141ccb-2814-4f39-8c00-41953929e92c', N'4f23ee3e-876b-42ed-b60b-9d318a056eb2', N'27b8a027-df02-422e-aaf4-78aabc82f317', N'0096270B-2674-40F1-AD70-8F1ED7E5AF48', N'd02953ce-9644-4e3e-b660-bdac9017d3cf', N'cb87457e-bbc8-4aa6-b3c1-ceab30f3d3ef', N'1', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', CAST(N'2025-02-06T11:17:08.4119470' AS DateTime2), N'27b8a027-df02-422e-aaf4-78aabc82f317', 100, N'', CAST(N'2025-02-06T11:17:08.5699535' AS DateTime2), N'', 0, N'', 0, N'', N'')
INSERT [dbo].[MajorUserApprovals] ([Id], [CompanyId], [ParentMajorId], [MajorId], [DeptId], [UserId], [PermissionId], [ApprovalStepId], [IdMain], [DayinWeek], [GroupId], [CreateAt], [CreateBy], [IsActive], [ApprovalUserId], [DateApproval], [DepartmentId], [DepartmentOrder], [ApprovalId], [ApprovalOrder], [LastApprovalId], [IsStatus]) VALUES (N'da5f8d45-824a-4e21-83f6-d13870a4cad5', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', N'e8398fce-49c2-4247-841b-ec12e27e63c4', N'b6141ccb-2814-4f39-8c00-41953929e92c', N'4f23ee3e-876b-42ed-b60b-9d318a056eb2', N'27b8a027-df02-422e-aaf4-78aabc82f317', N'0096270B-2674-40F1-AD70-8F1ED7E5AF48', N'3a9e73f6-a507-431f-9b04-5862440c009c', N'5ae3d313-8914-4c9b-89ff-92829952b6c5', N'1', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', CAST(N'2025-02-06T14:04:21.9957018' AS DateTime2), N'27b8a027-df02-422e-aaf4-78aabc82f317', 1, N'', CAST(N'2025-02-06T14:04:22.0234235' AS DateTime2), N'', 0, N'', 0, N'', N'')
INSERT [dbo].[MajorUserApprovals] ([Id], [CompanyId], [ParentMajorId], [MajorId], [DeptId], [UserId], [PermissionId], [ApprovalStepId], [IdMain], [DayinWeek], [GroupId], [CreateAt], [CreateBy], [IsActive], [ApprovalUserId], [DateApproval], [DepartmentId], [DepartmentOrder], [ApprovalId], [ApprovalOrder], [LastApprovalId], [IsStatus]) VALUES (N'def3f0e9-0d60-4f4b-9d8a-34c76c585792', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', N'e8398fce-49c2-4247-841b-ec12e27e63c4', N'b6141ccb-2814-4f39-8c00-41953929e92c', N'4f23ee3e-876b-42ed-b60b-9d318a056eb2', N'27b8a027-df02-422e-aaf4-78aabc82f317', N'0096270B-2674-40F1-AD70-8F1ED7E5AF48', N'3a9e73f6-a507-431f-9b04-5862440c009c', N'0cce8885-5fee-493e-9c10-f3d8d7f20133', N'3', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', CAST(N'2025-02-06T11:04:44.0447148' AS DateTime2), N'27b8a027-df02-422e-aaf4-78aabc82f317', 100, N'', CAST(N'2025-02-06T11:04:44.0577723' AS DateTime2), N'', 0, N'', 0, N'', N'')
INSERT [dbo].[MajorUserApprovals] ([Id], [CompanyId], [ParentMajorId], [MajorId], [DeptId], [UserId], [PermissionId], [ApprovalStepId], [IdMain], [DayinWeek], [GroupId], [CreateAt], [CreateBy], [IsActive], [ApprovalUserId], [DateApproval], [DepartmentId], [DepartmentOrder], [ApprovalId], [ApprovalOrder], [LastApprovalId], [IsStatus]) VALUES (N'efeede28-da29-460b-b6a8-01f972412be7', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', N'e8398fce-49c2-4247-841b-ec12e27e63c4', N'b6141ccb-2814-4f39-8c00-41953929e92c', N'4f23ee3e-876b-42ed-b60b-9d318a056eb2', N'27b8a027-df02-422e-aaf4-78aabc82f317', N'0096270B-2674-40F1-AD70-8F1ED7E5AF48', N'd02953ce-9644-4e3e-b660-bdac9017d3cf', N'0cce8885-5fee-493e-9c10-f3d8d7f20133', N'3', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', CAST(N'2025-02-06T11:04:44.0447148' AS DateTime2), N'27b8a027-df02-422e-aaf4-78aabc82f317', 100, N'', CAST(N'2025-02-06T11:04:44.0577749' AS DateTime2), N'', 0, N'', 0, N'', N'')
INSERT [dbo].[MajorUserApprovals] ([Id], [CompanyId], [ParentMajorId], [MajorId], [DeptId], [UserId], [PermissionId], [ApprovalStepId], [IdMain], [DayinWeek], [GroupId], [CreateAt], [CreateBy], [IsActive], [ApprovalUserId], [DateApproval], [DepartmentId], [DepartmentOrder], [ApprovalId], [ApprovalOrder], [LastApprovalId], [IsStatus]) VALUES (N'f2bd1407-ae46-4938-9923-714a3a83d952', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', N'e8398fce-49c2-4247-841b-ec12e27e63c4', N'b6141ccb-2814-4f39-8c00-41953929e92c', N'4f23ee3e-876b-42ed-b60b-9d318a056eb2', N'27b8a027-df02-422e-aaf4-78aabc82f317', N'0096270B-2674-40F1-AD70-8F1ED7E5AF48', N'3a9e73f6-a507-431f-9b04-5862440c009c', N'cb87457e-bbc8-4aa6-b3c1-ceab30f3d3ef', N'2', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', CAST(N'2025-02-06T11:17:08.4119470' AS DateTime2), N'27b8a027-df02-422e-aaf4-78aabc82f317', 100, N'', CAST(N'2025-02-06T11:17:08.5699489' AS DateTime2), N'', 0, N'', 0, N'', N'')
GO
INSERT [dbo].[PermissionControl_Logs] ([Id], [CompanyId], [ParentMajorId], [MajorId], [UserId], [GroupId], [Ordinarily], [CreateAt], [CreateBy], [IsActive], [ApprovalUserId], [DateApproval], [DepartmentId], [DepartmentOrder], [ApprovalOrder], [ApprovalId], [LastApprovalId], [IsStatus], [IdChung], [IsValid]) VALUES (N'050b7be3-8720-4138-826e-9f5cc5f496c2', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', N'289fdfbf-37f8-4693-a7e2-08cc67b45423', N'7d536f2d-1fdc-4591-82f7-21f588298334', N'27b8a027-df02-422e-aaf4-78aabc82f317', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', 0, CAST(N'2025-02-05T10:35:23.9857956' AS DateTime2), N'27b8a027-df02-422e-aaf4-78aabc82f317', 0, N'', CAST(N'2025-02-05T10:02:34.3027179' AS DateTime2), N'', 1, 1, N'', N'', N'', N'dc7c886c-f8eb-4791-9ef9-a7372ebfd0b4', 0)
INSERT [dbo].[PermissionControl_Logs] ([Id], [CompanyId], [ParentMajorId], [MajorId], [UserId], [GroupId], [Ordinarily], [CreateAt], [CreateBy], [IsActive], [ApprovalUserId], [DateApproval], [DepartmentId], [DepartmentOrder], [ApprovalOrder], [ApprovalId], [LastApprovalId], [IsStatus], [IdChung], [IsValid]) VALUES (N'2a09180c-a5dd-4b3f-b7c4-f5563c53b76b', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', N'e8398fce-49c2-4247-841b-ec12e27e63c4', N'bf9b69e3-7184-46c0-a2e6-a1d970a5dfd9', N'27b8a027-df02-422e-aaf4-78aabc82f317', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', 0, CAST(N'2025-01-21T11:06:06.8527059' AS DateTime2), N'27b8a027-df02-422e-aaf4-78aabc82f317', 0, N'', CAST(N'2025-01-21T11:05:58.8577556' AS DateTime2), N'', 1, 1, N'', N'', N'', N'2a09180c-a5dd-4b3f-b7c4-f5563c53b76b', 0)
INSERT [dbo].[PermissionControl_Logs] ([Id], [CompanyId], [ParentMajorId], [MajorId], [UserId], [GroupId], [Ordinarily], [CreateAt], [CreateBy], [IsActive], [ApprovalUserId], [DateApproval], [DepartmentId], [DepartmentOrder], [ApprovalOrder], [ApprovalId], [LastApprovalId], [IsStatus], [IdChung], [IsValid]) VALUES (N'a5790ad7-a025-4978-82b2-7a4d280bbd97', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', N'e8398fce-49c2-4247-841b-ec12e27e63c4', N'bf9b69e3-7184-46c0-a2e6-a1d970a5dfd9', N'27b8a027-df02-422e-aaf4-78aabc82f317', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', 0, CAST(N'2025-01-21T13:10:57.0073490' AS DateTime2), N'27b8a027-df02-422e-aaf4-78aabc82f317', 0, N'', CAST(N'2025-01-21T11:05:58.8577556' AS DateTime2), N'', 1, 1, N'', N'', N'', N'2a09180c-a5dd-4b3f-b7c4-f5563c53b76b', 0)
INSERT [dbo].[PermissionControl_Logs] ([Id], [CompanyId], [ParentMajorId], [MajorId], [UserId], [GroupId], [Ordinarily], [CreateAt], [CreateBy], [IsActive], [ApprovalUserId], [DateApproval], [DepartmentId], [DepartmentOrder], [ApprovalOrder], [ApprovalId], [LastApprovalId], [IsStatus], [IdChung], [IsValid]) VALUES (N'dc7c886c-f8eb-4791-9ef9-a7372ebfd0b4', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', N'289fdfbf-37f8-4693-a7e2-08cc67b45423', N'7d536f2d-1fdc-4591-82f7-21f588298334', N'27b8a027-df02-422e-aaf4-78aabc82f317', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', 0, CAST(N'2025-02-05T10:02:46.5060007' AS DateTime2), N'27b8a027-df02-422e-aaf4-78aabc82f317', 0, N'', CAST(N'2025-02-05T10:02:34.3027179' AS DateTime2), N'', 1, 1, N'', N'', N'', N'dc7c886c-f8eb-4791-9ef9-a7372ebfd0b4', 0)
GO
INSERT [dbo].[PermissionControls] ([Id], [CompanyId], [ParentMajorId], [MajorId], [UserId], [GroupId], [Ordinarily], [CreateAt], [CreateBy], [IsActive], [ApprovalUserId], [DateApproval], [DepartmentId], [DepartmentOrder], [ApprovalOrder], [ApprovalId], [LastApprovalId], [IsStatus]) VALUES (N'2a09180c-a5dd-4b3f-b7c4-f5563c53b76b', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', N'e8398fce-49c2-4247-841b-ec12e27e63c4', N'bf9b69e3-7184-46c0-a2e6-a1d970a5dfd9', N'27b8a027-df02-422e-aaf4-78aabc82f317', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', 0, CAST(N'2025-01-21T13:10:56.9483813' AS DateTime2), N'27b8a027-df02-422e-aaf4-78aabc82f317', 100, N'', CAST(N'2025-01-21T11:05:58.8577556' AS DateTime2), N'', 1, 1, N'', N'', N'')
INSERT [dbo].[PermissionControls] ([Id], [CompanyId], [ParentMajorId], [MajorId], [UserId], [GroupId], [Ordinarily], [CreateAt], [CreateBy], [IsActive], [ApprovalUserId], [DateApproval], [DepartmentId], [DepartmentOrder], [ApprovalOrder], [ApprovalId], [LastApprovalId], [IsStatus]) VALUES (N'dc7c886c-f8eb-4791-9ef9-a7372ebfd0b4', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', N'289fdfbf-37f8-4693-a7e2-08cc67b45423', N'7d536f2d-1fdc-4591-82f7-21f588298334', N'27b8a027-df02-422e-aaf4-78aabc82f317', N'5a022928-fb56-49d8-bc8a-d69f2f3e2412', 0, CAST(N'2025-02-05T10:35:23.9267220' AS DateTime2), N'27b8a027-df02-422e-aaf4-78aabc82f317', 100, N'', CAST(N'2025-02-05T10:02:34.3027179' AS DateTime2), N'', 1, 1, N'', N'', N'')
GO
