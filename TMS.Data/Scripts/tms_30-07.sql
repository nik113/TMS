USE [master]
GO
/****** Object:  Database [TMS]    Script Date: 30-07-2022 11:18:13 ******/
CREATE DATABASE [TMS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TMS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\TMS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TMS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\TMS_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TMS] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TMS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TMS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TMS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TMS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TMS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TMS] SET ARITHABORT OFF 
GO
ALTER DATABASE [TMS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TMS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TMS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TMS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TMS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TMS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TMS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TMS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TMS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TMS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TMS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TMS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TMS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TMS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TMS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TMS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TMS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TMS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TMS] SET  MULTI_USER 
GO
ALTER DATABASE [TMS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TMS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TMS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TMS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TMS] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'TMS', N'ON'
GO
ALTER DATABASE [TMS] SET QUERY_STORE = OFF
GO
USE [TMS]
GO
/****** Object:  User [NT AUTHORITY\SYSTEM]    Script Date: 30-07-2022 11:18:15 ******/
CREATE USER [NT AUTHORITY\SYSTEM] FOR LOGIN [NT AUTHORITY\SYSTEM] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [NT AUTHORITY\SYSTEM]
GO
/****** Object:  Table [dbo].[AdminMaster]    Script Date: 30-07-2022 11:18:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminMaster](
	[AdminId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[FirstName] [nvarchar](50) NULL,
	[MiddleName] [varchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[MobileNo] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
	[IsDelete] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_AdminMaster] PRIMARY KEY CLUSTERED 
(
	[AdminId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Group]    Script Date: 30-07-2022 11:18:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Group](
	[GroupId] [int] IDENTITY(1,1) NOT NULL,
	[GroupName] [nvarchar](100) NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED 
(
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GroupDetails]    Script Date: 30-07-2022 11:18:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupDetails](
	[GroupDetailId] [int] IDENTITY(1,1) NOT NULL,
	[GroupId] [int] NULL,
	[UserId] [int] NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK_GroupDetails] PRIMARY KEY CLUSTERED 
(
	[GroupDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleMaster]    Script Date: 30-07-2022 11:18:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleMaster](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_RoleMaster] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserMaster]    Script Date: 30-07-2022 11:18:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserMaster](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[MiddleName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[MobileNo] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[RoleId] [int] NULL,
	[IsActive] [bit] NULL,
	[IsDelete] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_UserMaster] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AdminMaster] ON 

INSERT [dbo].[AdminMaster] ([AdminId], [UserName], [Password], [FirstName], [MiddleName], [LastName], [MobileNo], [Email], [IsActive], [IsDelete], [CreatedDate], [UpdatedDate]) VALUES (1, N'moriashvin', N'1432', N'ashvin', N'g', N'mori', N'12345', N'mori@gmail.com', 1, 0, NULL, NULL)
SET IDENTITY_INSERT [dbo].[AdminMaster] OFF
SET IDENTITY_INSERT [dbo].[RoleMaster] ON 

INSERT [dbo].[RoleMaster] ([RoleId], [RoleName]) VALUES (2, N'MORI')
INSERT [dbo].[RoleMaster] ([RoleId], [RoleName]) VALUES (4, N'ASHVIN')
SET IDENTITY_INSERT [dbo].[RoleMaster] OFF
SET IDENTITY_INSERT [dbo].[UserMaster] ON 

INSERT [dbo].[UserMaster] ([UserId], [UserName], [Password], [FirstName], [MiddleName], [LastName], [MobileNo], [Email], [RoleId], [IsActive], [IsDelete], [CreatedDate], [UpdatedDate]) VALUES (1, N'nikunj', N'123', N'Nikunj', N'Pravin Bhai', N'Jivani', N'9724766369', N'nikunj.jivani113@gmail.com', 1, 1, 1, CAST(N'2022-05-04T11:14:23.123' AS DateTime), CAST(N'2022-05-04T11:14:23.123' AS DateTime))
INSERT [dbo].[UserMaster] ([UserId], [UserName], [Password], [FirstName], [MiddleName], [LastName], [MobileNo], [Email], [RoleId], [IsActive], [IsDelete], [CreatedDate], [UpdatedDate]) VALUES (2, N'user@123', N'123123', N'ashvin', N'ghanshyambhai', N'mori', N'85208520', N'mori@gamil.com', 2, 1, 1, NULL, NULL)
INSERT [dbo].[UserMaster] ([UserId], [UserName], [Password], [FirstName], [MiddleName], [LastName], [MobileNo], [Email], [RoleId], [IsActive], [IsDelete], [CreatedDate], [UpdatedDate]) VALUES (3, N'mukesh@654', N'1234567890', N'mukesh', N'ghanshyambhai', N'mori', N'159951', N'mukesh@gmail.com', 1, 1, 1, NULL, NULL)
INSERT [dbo].[UserMaster] ([UserId], [UserName], [Password], [FirstName], [MiddleName], [LastName], [MobileNo], [Email], [RoleId], [IsActive], [IsDelete], [CreatedDate], [UpdatedDate]) VALUES (4, N'user@123', N'123123', N'mukesh', N'ghanshyambhai', N'mori', N'85208520', N'mori@gamil.com', 2, 1, 1, NULL, NULL)
INSERT [dbo].[UserMaster] ([UserId], [UserName], [Password], [FirstName], [MiddleName], [LastName], [MobileNo], [Email], [RoleId], [IsActive], [IsDelete], [CreatedDate], [UpdatedDate]) VALUES (5, N'user@123', N'123123', N'keyur', N'prakash', N'dholariya', N'85208520', N'keyur@gamil.com', 2, 1, 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[UserMaster] OFF
/****** Object:  StoredProcedure [dbo].[AdminLogin]    Script Date: 30-07-2022 11:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AdminLogin] 
	@UserName nvarchar(50),
	@Password nvarchar(50)

AS
BEGIN
	SELECT [AdminId]
      ,[UserName]
      ,[Password]
      ,[FirstName]
      ,[MiddleName]
      ,[LastName]
      ,[MobileNo]
      ,[Email]
      ,[IsActive]
      ,[IsDelete]
      ,[CreatedDate]
      ,[UpdatedDate]
  FROM [TMS].[dbo].[AdminMaster]
  Where UserName = @UserName and Password = @Password and IsDelete = 0
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteRole]    Script Date: 30-07-2022 11:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[DeleteRole](@RoleId int)
as
begin
	delete RoleMaster where RoleId = @RoleId
end
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 30-07-2022 11:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[DeleteUser](@IsDelete bit, @UserId int)
as
begin
	update UserMaster set IsDelete =@IsDelete  where UserId=@UserId
end
GO
/****** Object:  StoredProcedure [dbo].[GetAllRole]    Script Date: 30-07-2022 11:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllRole]
as
begin
	select RoleId,RoleName from RoleMaster
end
GO
/****** Object:  StoredProcedure [dbo].[GetAllUser]    Script Date: 30-07-2022 11:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetAllUser]
as
begin
	select UserId,UserName,Password,FirstName,MiddleName,LastName,MobileNo,Email,RoleId,IsActive,IsDelete,CreatedDate,UpdatedDate
	from UserMaster where IsDelete=1
end
GO
/****** Object:  StoredProcedure [dbo].[GetRoleById]    Script Date: 30-07-2022 11:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetRoleById](@RoleId int)
as
begin
	select RoleId,RoleName from RoleMaster where RoleId=@RoleId
end
GO
/****** Object:  StoredProcedure [dbo].[GetUserById]    Script Date: 30-07-2022 11:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetUserById](@UserId int)
as
begin
	select UserId,UserName,Password,FirstName,MiddleName,LastName,MobileNo,Email,RoleId,IsActive,IsDelete,CreatedDate,UpdatedDate
	from UserMaster 
	where UserId = @UserId
end
GO
/****** Object:  StoredProcedure [dbo].[InsertRole]    Script Date: 30-07-2022 11:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertRole] (@RoleName VARCHAR(50))
AS
BEGIN
	INSERT INTO RoleMaster (RoleName) values(@RoleName)
END
GO
/****** Object:  StoredProcedure [dbo].[InsertUser]    Script Date: 30-07-2022 11:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertUser] (@username varchar(50),
								@password varchar(50),
								@firstname varchar(50),
								@middlename varchar(50),
								@lastname varchar(50),
								@mobileno varchar(50),
								@email varchar(50),
								@roleid int,
								@isactive bit,
								@isdelete bit )
AS
BEGIN
	INSERT INTO UserMaster (UserName,Password,FirstName,MiddleName,LastName,MobileNo,Email,RoleId,IsActive,IsDelete)
	values(@username,@password,@firstname,@middlename,@lastname,@mobileno,@email,@roleid,@isactive,@isdelete)
END
GO
/****** Object:  StoredProcedure [dbo].[Login]    Script Date: 30-07-2022 11:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Login] 
@UserName nvarchar(50),
@Password nvarchar(50)
AS
BEGIN
select UM.*,RM.RoleName 
from UserMaster UM
Inner Join RoleMaster RM on UM.RoleId = RM.RoleId
where UM.UserName = @UserName and UM.Password = @Password
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateRole]    Script Date: 30-07-2022 11:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateRole] (@RoleId int ,@RoleName VARCHAR(50)) 
as
begin
	update RoleMaster set RoleName=@RoleName where RoleId=@RoleId
end
GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 30-07-2022 11:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateUser] ( @userid int,
								@username varchar(50),
								@password varchar(50),
								@firstname varchar(50),
								@middlename varchar(50),
								@lastname varchar(50),
								@mobileno varchar(50),
								@email varchar(50),
								@roleid int,
								@isactive bit,
								@isdelete bit )
as
begin
	update UserMaster 
	set UserName=@username,Password=@password,FirstName=@firstname,MiddleName=@middlename,LastName=@lastname,MobileNo=@mobileno,Email=@email,RoleId=@roleid,IsActive=@isactive,IsDelete=@isdelete
	where UserId=@userid
end
GO
USE [master]
GO
ALTER DATABASE [TMS] SET  READ_WRITE 
GO
