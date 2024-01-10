USE [Atm]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2024-01-10 3:05:13 PM ******/
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
/****** Object:  Table [dbo].[accounts]    Script Date: 2024-01-10 3:05:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[accounts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CardNumber] [int] NOT NULL,
	[Pin] [int] NOT NULL,
	[Balance] [int] NOT NULL,
 CONSTRAINT [PK_accounts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[transactions]    Script Date: 2024-01-10 3:05:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[transactions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Amount] [int] NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[accountsId] [int] NOT NULL,
 CONSTRAINT [PK_transactions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240109200430_m1', N'7.0.15')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240110122810_edit1', N'7.0.15')
GO
SET IDENTITY_INSERT [dbo].[accounts] ON 

INSERT [dbo].[accounts] ([Id], [CardNumber], [Pin], [Balance]) VALUES (1, 987, 987, 100)
INSERT [dbo].[accounts] ([Id], [CardNumber], [Pin], [Balance]) VALUES (2, 456, 456, 200)
INSERT [dbo].[accounts] ([Id], [CardNumber], [Pin], [Balance]) VALUES (3, 123, 123, 931)
INSERT [dbo].[accounts] ([Id], [CardNumber], [Pin], [Balance]) VALUES (4, 159, 159, 400)
INSERT [dbo].[accounts] ([Id], [CardNumber], [Pin], [Balance]) VALUES (5, 263, 263, 600)
SET IDENTITY_INSERT [dbo].[accounts] OFF
GO
SET IDENTITY_INSERT [dbo].[transactions] ON 

INSERT [dbo].[transactions] ([Id], [Amount], [Date], [accountsId]) VALUES (1, 100, CAST(N'2023-10-01T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[transactions] ([Id], [Amount], [Date], [accountsId]) VALUES (2, -50, CAST(N'2023-09-03T00:00:00.0000000' AS DateTime2), 2)
INSERT [dbo].[transactions] ([Id], [Amount], [Date], [accountsId]) VALUES (3, -30, CAST(N'2023-10-01T00:00:00.0000000' AS DateTime2), 3)
INSERT [dbo].[transactions] ([Id], [Amount], [Date], [accountsId]) VALUES (4, 80, CAST(N'2021-03-03T00:00:00.0000000' AS DateTime2), 4)
INSERT [dbo].[transactions] ([Id], [Amount], [Date], [accountsId]) VALUES (5, 60, CAST(N'2020-07-21T00:00:00.0000000' AS DateTime2), 5)
INSERT [dbo].[transactions] ([Id], [Amount], [Date], [accountsId]) VALUES (6, 22, CAST(N'2024-01-10T14:38:31.0539808' AS DateTime2), 3)
INSERT [dbo].[transactions] ([Id], [Amount], [Date], [accountsId]) VALUES (7, -6, CAST(N'2024-01-10T14:39:49.4323175' AS DateTime2), 3)
INSERT [dbo].[transactions] ([Id], [Amount], [Date], [accountsId]) VALUES (8, 607, CAST(N'2024-01-10T14:48:08.0244369' AS DateTime2), 3)
INSERT [dbo].[transactions] ([Id], [Amount], [Date], [accountsId]) VALUES (9, 100, CAST(N'2024-01-10T14:50:48.9620814' AS DateTime2), 5)
SET IDENTITY_INSERT [dbo].[transactions] OFF
GO
ALTER TABLE [dbo].[transactions] ADD  DEFAULT ((0)) FOR [accountsId]
GO
ALTER TABLE [dbo].[transactions]  WITH CHECK ADD  CONSTRAINT [FK_transactions_accounts_accountsId] FOREIGN KEY([accountsId])
REFERENCES [dbo].[accounts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[transactions] CHECK CONSTRAINT [FK_transactions_accounts_accountsId]
GO
