USE [master]
GO
/****** Object:  Database [InspectionDB]    Script Date: 11/11/2025 11:22:33 AM ******/
CREATE DATABASE [InspectionDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'InspectionDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\InspectionDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'InspectionDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\InspectionDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [InspectionDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [InspectionDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [InspectionDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [InspectionDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [InspectionDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [InspectionDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [InspectionDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [InspectionDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [InspectionDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [InspectionDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [InspectionDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [InspectionDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [InspectionDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [InspectionDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [InspectionDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [InspectionDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [InspectionDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [InspectionDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [InspectionDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [InspectionDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [InspectionDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [InspectionDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [InspectionDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [InspectionDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [InspectionDB] SET RECOVERY FULL 
GO
ALTER DATABASE [InspectionDB] SET  MULTI_USER 
GO
ALTER DATABASE [InspectionDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [InspectionDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [InspectionDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [InspectionDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [InspectionDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [InspectionDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'InspectionDB', N'ON'
GO
ALTER DATABASE [InspectionDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [InspectionDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [InspectionDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11/11/2025 11:22:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 11/11/2025 11:22:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 11/11/2025 11:22:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 11/11/2025 11:22:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 11/11/2025 11:22:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 11/11/2025 11:22:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 11/11/2025 11:22:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 11/11/2025 11:22:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EntitiesToInspect]    Script Date: 11/11/2025 11:22:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EntitiesToInspect](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Category] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_EntitiesToInspect] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InspectionVisits]    Script Date: 11/11/2025 11:22:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InspectionVisits](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EntityToInspectId] [int] NOT NULL,
	[InspectorId] [int] NOT NULL,
	[ScheduledAt] [datetime2](7) NOT NULL,
	[Status] [int] NOT NULL,
	[Score] [int] NOT NULL,
	[Notes] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_InspectionVisits] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inspectors]    Script Date: 11/11/2025 11:22:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inspectors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NOT NULL,
	[Role] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Inspectors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Violations]    Script Date: 11/11/2025 11:22:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Violations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InspectionVisitId] [int] NOT NULL,
	[Code] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Severity] [int] NOT NULL,
 CONSTRAINT [PK_Violations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20251025172649_InintilalMigartion', N'8.0.0')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20251025193746_primarykey', N'8.0.0')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20251026005927_identity', N'8.0.0')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20251026010438_identity2', N'8.0.0')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'c2ccfd9f-67c1-4329-9f7a-72dec54ac0f8', N'Admin', N'ADMIN', NULL)
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'ee4cd4b1-e786-49d5-a08d-ef76474362aa', N'Inspector', N'INSPECTOR', NULL)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'51303209-0a62-4057-adf9-ca9b00fc6bd6', N'admin', N'ADMIN', NULL, NULL, 0, N'AQAAAAIAAYagAAAAEKV/kyBVdV3x1jUtVfUY5Gs+EH7cgDEaxGlYdhC5bkcB8F8eV5G3vT506a9bUEsSTA==', N'NVRSZLJSRC2WQYENVUXEHKPSJCJZYDFV', N'c6bd9ea5-1d47-44f4-b015-d423ac2b6b7a', NULL, 0, 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[EntitiesToInspect] ON 
GO
INSERT [dbo].[EntitiesToInspect] ([Id], [Name], [Address], [Category]) VALUES (4, N'strin 3', N'string   1', N'string 1')
GO
INSERT [dbo].[EntitiesToInspect] ([Id], [Name], [Address], [Category]) VALUES (5, N'strin 3', N'string   1', N'string 1')
GO
INSERT [dbo].[EntitiesToInspect] ([Id], [Name], [Address], [Category]) VALUES (6, N'strin 4', N'string   1', N'string 1')
GO
INSERT [dbo].[EntitiesToInspect] ([Id], [Name], [Address], [Category]) VALUES (7, N'strin 5', N'string   1', N'string 1')
GO
INSERT [dbo].[EntitiesToInspect] ([Id], [Name], [Address], [Category]) VALUES (8, N'new entity ', N'ALex', N'category ')
GO
INSERT [dbo].[EntitiesToInspect] ([Id], [Name], [Address], [Category]) VALUES (9, N'new ewqewq tes', N'dsdds', N'category one')
GO
INSERT [dbo].[EntitiesToInspect] ([Id], [Name], [Address], [Category]) VALUES (1012, N'NEW ', N'ALEX', N'TEST')
GO
SET IDENTITY_INSERT [dbo].[EntitiesToInspect] OFF
GO
SET IDENTITY_INSERT [dbo].[InspectionVisits] ON 
GO
INSERT [dbo].[InspectionVisits] ([Id], [EntityToInspectId], [InspectorId], [ScheduledAt], [Status], [Score], [Notes]) VALUES (2, 4, 1, CAST(N'2025-10-27T10:52:33.8650000' AS DateTime2), 3, 1, N'string')
GO
INSERT [dbo].[InspectionVisits] ([Id], [EntityToInspectId], [InspectorId], [ScheduledAt], [Status], [Score], [Notes]) VALUES (3, 7, 2, CAST(N'2025-10-22T21:00:00.0000000' AS DateTime2), 1, 33, N'dsadas')
GO
INSERT [dbo].[InspectionVisits] ([Id], [EntityToInspectId], [InspectorId], [ScheduledAt], [Status], [Score], [Notes]) VALUES (4, 8, 2, CAST(N'2025-10-14T21:00:00.0000000' AS DateTime2), 3, 100, N'DSDDD')
GO
SET IDENTITY_INSERT [dbo].[InspectionVisits] OFF
GO
SET IDENTITY_INSERT [dbo].[Inspectors] ON 
GO
INSERT [dbo].[Inspectors] ([Id], [FullName], [Email], [Phone], [Role]) VALUES (1, N'Inspector 1', N'Inspetor1@gamil.com', N'01099999999', N'admin')
GO
INSERT [dbo].[Inspectors] ([Id], [FullName], [Email], [Phone], [Role]) VALUES (2, N'Inspector 2', N'Inspetor2@gamil.com', N'01099999999', N'inspector')
GO
SET IDENTITY_INSERT [dbo].[Inspectors] OFF
GO
SET IDENTITY_INSERT [dbo].[Violations] ON 
GO
INSERT [dbo].[Violations] ([Id], [InspectionVisitId], [Code], [Description], [Severity]) VALUES (1, 3, N'string', N'string', 1)
GO
INSERT [dbo].[Violations] ([Id], [InspectionVisitId], [Code], [Description], [Severity]) VALUES (2, 3, N'string', N'string', 1)
GO
INSERT [dbo].[Violations] ([Id], [InspectionVisitId], [Code], [Description], [Severity]) VALUES (3, 3, N'ewqewq', N'ewe', 2)
GO
INSERT [dbo].[Violations] ([Id], [InspectionVisitId], [Code], [Description], [Severity]) VALUES (4, 3, N'DMSALKDJK', N'DSADA', 1)
GO
SET IDENTITY_INSERT [dbo].[Violations] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 11/11/2025 11:22:33 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 11/11/2025 11:22:33 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 11/11/2025 11:22:33 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 11/11/2025 11:22:33 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 11/11/2025 11:22:33 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 11/11/2025 11:22:33 AM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 11/11/2025 11:22:33 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_InspectionVisits_EntityToInspectId]    Script Date: 11/11/2025 11:22:33 AM ******/
CREATE NONCLUSTERED INDEX [IX_InspectionVisits_EntityToInspectId] ON [dbo].[InspectionVisits]
(
	[EntityToInspectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_InspectionVisits_InspectorId]    Script Date: 11/11/2025 11:22:33 AM ******/
CREATE NONCLUSTERED INDEX [IX_InspectionVisits_InspectorId] ON [dbo].[InspectionVisits]
(
	[InspectorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Violations_InspectionVisitId]    Script Date: 11/11/2025 11:22:33 AM ******/
CREATE NONCLUSTERED INDEX [IX_Violations_InspectionVisitId] ON [dbo].[Violations]
(
	[InspectionVisitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[InspectionVisits]  WITH CHECK ADD  CONSTRAINT [FK_InspectionVisits_EntitiesToInspect_EntityToInspectId] FOREIGN KEY([EntityToInspectId])
REFERENCES [dbo].[EntitiesToInspect] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InspectionVisits] CHECK CONSTRAINT [FK_InspectionVisits_EntitiesToInspect_EntityToInspectId]
GO
ALTER TABLE [dbo].[InspectionVisits]  WITH CHECK ADD  CONSTRAINT [FK_InspectionVisits_Inspectors_InspectorId] FOREIGN KEY([InspectorId])
REFERENCES [dbo].[Inspectors] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InspectionVisits] CHECK CONSTRAINT [FK_InspectionVisits_Inspectors_InspectorId]
GO
ALTER TABLE [dbo].[Violations]  WITH CHECK ADD  CONSTRAINT [FK_Violations_InspectionVisits_InspectionVisitId] FOREIGN KEY([InspectionVisitId])
REFERENCES [dbo].[InspectionVisits] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Violations] CHECK CONSTRAINT [FK_Violations_InspectionVisits_InspectionVisitId]
GO
USE [master]
GO
ALTER DATABASE [InspectionDB] SET  READ_WRITE 
GO
