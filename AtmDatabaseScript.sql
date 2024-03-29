USE [Atm]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2024-01-17 5:49:15 AM ******/
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
/****** Object:  Table [dbo].[Accounts]    Script Date: 2024-01-17 5:49:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CardNumber] [nvarchar](max) NOT NULL,
	[Balance] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleClaims]    Script Date: 2024-01-17 5:49:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](max) NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_RoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 2024-01-17 5:49:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[NormalizedName] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 2024-01-17 5:49:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[accountId] [int] NOT NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserClaims]    Script Date: 2024-01-17 5:49:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](max) NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLogins]    Script Date: 2024-01-17 5:49:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 2024-01-17 5:49:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2024-01-17 5:49:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [nvarchar](450) NOT NULL,
	[AccountId] [nvarchar](max) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[NormalizedUserName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[NormalizedEmail] [nvarchar](max) NULL,
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
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserTokens]    Script Date: 2024-01-17 5:49:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240116150910_Initial With Jwt Identity Database', N'7.0.15')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240116200317_Add data annotation Validation On Models ', N'7.0.15')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240117024912_Update Table Account to Remove Coulmn pin', N'7.0.15')
GO
SET IDENTITY_INSERT [dbo].[Accounts] ON 

INSERT [dbo].[Accounts] ([Id], [CardNumber], [Balance]) VALUES (2, N'1212', CAST(600.00 AS Decimal(18, 2)))
INSERT [dbo].[Accounts] ([Id], [CardNumber], [Balance]) VALUES (3, N'1313', CAST(300.00 AS Decimal(18, 2)))
INSERT [dbo].[Accounts] ([Id], [CardNumber], [Balance]) VALUES (4, N'1515', CAST(100.00 AS Decimal(18, 2)))
INSERT [dbo].[Accounts] ([Id], [CardNumber], [Balance]) VALUES (5, N'1010', CAST(50.00 AS Decimal(18, 2)))
INSERT [dbo].[Accounts] ([Id], [CardNumber], [Balance]) VALUES (6, N'100100', CAST(250.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Accounts] OFF
GO
SET IDENTITY_INSERT [dbo].[Transactions] ON 

INSERT [dbo].[Transactions] ([Id], [Amount], [Date], [accountId]) VALUES (5, CAST(150.00 AS Decimal(18, 2)), CAST(N'2024-01-17T04:41:02.1111036' AS DateTime2), 6)
INSERT [dbo].[Transactions] ([Id], [Amount], [Date], [accountId]) VALUES (6, CAST(-50.00 AS Decimal(18, 2)), CAST(N'2024-01-17T04:41:38.3362323' AS DateTime2), 6)
SET IDENTITY_INSERT [dbo].[Transactions] OFF
GO
SET IDENTITY_INSERT [dbo].[UserClaims] ON 

INSERT [dbo].[UserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (1, N'79967579-e337-48bf-aa5c-127337ef1438', N'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier', N'79967579-e337-48bf-aa5c-127337ef1438')
INSERT [dbo].[UserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (2, N'79967579-e337-48bf-aa5c-127337ef1438', N'http://schemas.microsoft.com/ws/2008/06/identity/claims/role', N'User')
INSERT [dbo].[UserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (3, N'513541ad-2ab5-4b51-a8b0-d281124a35a1', N'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier', N'513541ad-2ab5-4b51-a8b0-d281124a35a1')
INSERT [dbo].[UserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (4, N'513541ad-2ab5-4b51-a8b0-d281124a35a1', N'http://schemas.microsoft.com/ws/2008/06/identity/claims/role', N'User')
INSERT [dbo].[UserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (5, N'84a5e959-9fb6-4ad3-b27d-752298e56013', N'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier', N'84a5e959-9fb6-4ad3-b27d-752298e56013')
INSERT [dbo].[UserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (6, N'84a5e959-9fb6-4ad3-b27d-752298e56013', N'http://schemas.microsoft.com/ws/2008/06/identity/claims/role', N'User')
INSERT [dbo].[UserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (7, N'0922fffd-eb2d-4e99-92ab-d36be699ab09', N'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier', N'0922fffd-eb2d-4e99-92ab-d36be699ab09')
INSERT [dbo].[UserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (8, N'0922fffd-eb2d-4e99-92ab-d36be699ab09', N'http://schemas.microsoft.com/ws/2008/06/identity/claims/role', N'User')
INSERT [dbo].[UserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (9, N'd061e132-ebd1-42f7-bf3e-6489adbb4ef0', N'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier', N'd061e132-ebd1-42f7-bf3e-6489adbb4ef0')
INSERT [dbo].[UserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (10, N'd061e132-ebd1-42f7-bf3e-6489adbb4ef0', N'http://schemas.microsoft.com/ws/2008/06/identity/claims/role', N'User')
INSERT [dbo].[UserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (11, N'207cc297-08da-41cf-a7a2-ed878507d727', N'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier', N'207cc297-08da-41cf-a7a2-ed878507d727')
INSERT [dbo].[UserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (12, N'207cc297-08da-41cf-a7a2-ed878507d727', N'http://schemas.microsoft.com/ws/2008/06/identity/claims/role', N'User')
INSERT [dbo].[UserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (13, N'75df0283-2b0b-458c-8dc4-6ce850eb6c04', N'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier', N'75df0283-2b0b-458c-8dc4-6ce850eb6c04')
INSERT [dbo].[UserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (14, N'75df0283-2b0b-458c-8dc4-6ce850eb6c04', N'http://schemas.microsoft.com/ws/2008/06/identity/claims/role', N'User')
INSERT [dbo].[UserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (15, N'718c62fd-799a-410c-96d2-8134614f2168', N'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier', N'718c62fd-799a-410c-96d2-8134614f2168')
INSERT [dbo].[UserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (16, N'718c62fd-799a-410c-96d2-8134614f2168', N'http://schemas.microsoft.com/ws/2008/06/identity/claims/role', N'User')
INSERT [dbo].[UserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (17, N'7701387d-642b-4337-b8c8-165de5890a75', N'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier', N'100100')
INSERT [dbo].[UserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (18, N'7701387d-642b-4337-b8c8-165de5890a75', N'http://schemas.microsoft.com/ws/2008/06/identity/claims/role', N'User')
SET IDENTITY_INSERT [dbo].[UserClaims] OFF
GO
INSERT [dbo].[Users] ([Id], [AccountId], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'207cc297-08da-41cf-a7a2-ed878507d727', N'', N'1313', N'1313', NULL, NULL, 0, N'AQAAAAEAACcQAAAAEBXgdv/cQ6a2i+dVpYvNE2TyDN7YBdx4tmhTOC2Swv9pX5VNdvB+P8YkelVG/fLvEQ==', N'F5SPJVCWDVWMSLNW4BHNAU2JMEZKSTUV', N'ccfbdb59-2c0d-4c3b-ab34-52ccf101d498', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[Users] ([Id], [AccountId], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'513541ad-2ab5-4b51-a8b0-d281124a35a1', N'', N'456', N'456', NULL, NULL, 0, N'AQAAAAEAACcQAAAAEKOq2nuZ5Re7WxpJMjbsyVj/XakLHY64l02h/5TGiiz6eqFbAiIetaiCTOyf9XxRqw==', N'MYIKFUF7JICUETSORT3BURBMB4L2UHOR', N'05fc5463-28c8-4eb1-8921-ce7227b1bd8b', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[Users] ([Id], [AccountId], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'718c62fd-799a-410c-96d2-8134614f2168', N'', N'1010', N'1010', NULL, NULL, 0, N'AQAAAAEAACcQAAAAEC5CrdhcrsglWgh3fcauIgC+3WAN+5hqD4VChgD6hpWgaiLLR75u+WClGApydnWc5g==', N'RJ3LJMBEWR5KCXWDFWXPM2TUO7VTUR6Z', N'56020226-8a3f-4104-bc14-0092e1b273b7', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[Users] ([Id], [AccountId], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'75df0283-2b0b-458c-8dc4-6ce850eb6c04', N'', N'1515', N'1515', NULL, NULL, 0, N'AQAAAAEAACcQAAAAEBqjuXLJmifp337H9rBRYVSiGPyp2jBFS1Bo6lzuLvXoX9JMVb6B99bUh5A0p4zxQQ==', N'SWUIQNBAJGF6C3AE63BRTAN6XH4JVUCK', N'b1c83fb3-f79d-4019-9dab-dab37d7f6801', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[Users] ([Id], [AccountId], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'7701387d-642b-4337-b8c8-165de5890a75', N'', N'100100', N'100100', NULL, NULL, 0, N'AQAAAAEAACcQAAAAEIDB4EboSinvK1P1mPZhspBaNrlNQ4SOa9DYEwEL6/smNeWod5cyOVfJe9boJaRqFg==', N'WR46LK6CYVMGFKKIKB3U6RCFK5ISNRDE', N'86be267b-3bf6-4ca5-a02e-46a079790f6c', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[Users] ([Id], [AccountId], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'84a5e959-9fb6-4ad3-b27d-752298e56013', N'', N'147', N'147', NULL, NULL, 0, N'AQAAAAEAACcQAAAAEEPq60hOyLjJv2yvvI1XbEQ0GQZq1WecPvzAiL530iNhVJMC5wJDxv+7e1MekoO8PQ==', N'BCKR65SBSJ3QGLAFFUHX2NFL47HPX7OL', N'cf276ca9-786b-4ef1-a3f5-5a63f7d6dbb1', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[Users] ([Id], [AccountId], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'd061e132-ebd1-42f7-bf3e-6489adbb4ef0', N'', N'1212', N'1212', NULL, NULL, 0, N'AQAAAAEAACcQAAAAEPpTrsv0ZXxKEAogNFnlIA/28aLEktmnCYM/yV1S/VS1iCOsoJ0K565jGuLQIr51fg==', N'4FLY5WDQNPKGB5M2OOVXUP4EII4K5PK2', N'dbfcc35e-a77d-4112-a7dc-0d5b2dc5d4fd', NULL, 0, 0, NULL, 1, 0)
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Accounts_accountId] FOREIGN KEY([accountId])
REFERENCES [dbo].[Accounts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_Accounts_accountId]
GO
