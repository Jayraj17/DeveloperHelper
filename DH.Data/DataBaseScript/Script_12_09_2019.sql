USE [DeveloperHelper]
GO
/****** Object:  Table [dbo].[DepartmentDetails]    Script Date: 9/12/2019 11:47:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DepartmentDetails](
	[deptId] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [varchar](50) NULL,
	[Description] [varchar](50) NULL,
	[IsActive] [bit] NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_DepartmentDetails] PRIMARY KEY CLUSTERED 
(
	[deptId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Education]    Script Date: 9/12/2019 11:47:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Education](
	[EduId] [int] IDENTITY(1,1) NOT NULL,
	[Education] [varchar](50) NULL,
	[Description] [varchar](150) NULL,
	[IsActive] [bit] NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Education] PRIMARY KEY CLUSTERED 
(
	[EduId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeDetails]    Script Date: 9/12/2019 11:47:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeDetails](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[gender] [varchar](50) NULL,
	[email] [varchar](50) NULL,
	[phoneNumber] [varchar](50) NULL,
	[contactPreference] [varchar](50) NULL,
	[dateofBirth] [datetime] NULL,
	[department] [int] NULL,
	[eduId] [int] NULL,
	[isActive] [bit] NULL,
	[photoPath] [varchar](50) NULL,
	[password] [varchar](50) NULL,
	[confirmPassword] [varchar](50) NULL,
 CONSTRAINT [PK_EmployeeDetails] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DepartmentDetails] ON 

INSERT [dbo].[DepartmentDetails] ([deptId], [DepartmentName], [Description], [IsActive], [UserId]) VALUES (1, N'Admin', N'TestFor me', 0, 1)
INSERT [dbo].[DepartmentDetails] ([deptId], [DepartmentName], [Description], [IsActive], [UserId]) VALUES (2, N'HR', N'test for', 0, 0)
INSERT [dbo].[DepartmentDetails] ([deptId], [DepartmentName], [Description], [IsActive], [UserId]) VALUES (3, N'Angular', N'TL', 1, 0)
INSERT [dbo].[DepartmentDetails] ([deptId], [DepartmentName], [Description], [IsActive], [UserId]) VALUES (4, N'admin2', N'test', 0, 0)
INSERT [dbo].[DepartmentDetails] ([deptId], [DepartmentName], [Description], [IsActive], [UserId]) VALUES (6, N'admin', N'testww', 1, 0)
INSERT [dbo].[DepartmentDetails] ([deptId], [DepartmentName], [Description], [IsActive], [UserId]) VALUES (7, N'PHP', N'Test PHP', 1, 0)
INSERT [dbo].[DepartmentDetails] ([deptId], [DepartmentName], [Description], [IsActive], [UserId]) VALUES (8, N'YYYYf', N'YYYYhfgfgyj', 0, 0)
INSERT [dbo].[DepartmentDetails] ([deptId], [DepartmentName], [Description], [IsActive], [UserId]) VALUES (9, N'AAAArrrr', N'AAAAA', 0, 0)
INSERT [dbo].[DepartmentDetails] ([deptId], [DepartmentName], [Description], [IsActive], [UserId]) VALUES (10, N'dfhdfh', N'dfhdfh', 1, 0)
INSERT [dbo].[DepartmentDetails] ([deptId], [DepartmentName], [Description], [IsActive], [UserId]) VALUES (11, N'ddd4444', N'dddd', 1, 0)
INSERT [dbo].[DepartmentDetails] ([deptId], [DepartmentName], [Description], [IsActive], [UserId]) VALUES (12, N'rrrr', N'rrrr33', 0, 0)
INSERT [dbo].[DepartmentDetails] ([deptId], [DepartmentName], [Description], [IsActive], [UserId]) VALUES (13, N'Test Dep', N'desc', 0, 0)
INSERT [dbo].[DepartmentDetails] ([deptId], [DepartmentName], [Description], [IsActive], [UserId]) VALUES (14, N'New 014', N'descrip', 0, 0)
INSERT [dbo].[DepartmentDetails] ([deptId], [DepartmentName], [Description], [IsActive], [UserId]) VALUES (15, N'eee', N'eeee', 0, 0)
INSERT [dbo].[DepartmentDetails] ([deptId], [DepartmentName], [Description], [IsActive], [UserId]) VALUES (16, N'666', N'666', 0, 0)
INSERT [dbo].[DepartmentDetails] ([deptId], [DepartmentName], [Description], [IsActive], [UserId]) VALUES (17, N'BCA', N'BCA', 0, 0)
INSERT [dbo].[DepartmentDetails] ([deptId], [DepartmentName], [Description], [IsActive], [UserId]) VALUES (18, N'MC', N'MCA', 0, 0)
INSERT [dbo].[DepartmentDetails] ([deptId], [DepartmentName], [Description], [IsActive], [UserId]) VALUES (19, N'MCA', N'MCA', 1, 0)
INSERT [dbo].[DepartmentDetails] ([deptId], [DepartmentName], [Description], [IsActive], [UserId]) VALUES (20, N'BCA', N'BCA', 1, 0)
INSERT [dbo].[DepartmentDetails] ([deptId], [DepartmentName], [Description], [IsActive], [UserId]) VALUES (21, N'PGDCA', N'PGDCA', 1, 0)
INSERT [dbo].[DepartmentDetails] ([deptId], [DepartmentName], [Description], [IsActive], [UserId]) VALUES (22, N'MCA MCA', N'MCA MCA', 1, 0)
SET IDENTITY_INSERT [dbo].[DepartmentDetails] OFF
SET IDENTITY_INSERT [dbo].[Education] ON 

INSERT [dbo].[Education] ([EduId], [Education], [Description], [IsActive], [UserId]) VALUES (1, N'MCA', N'MCA', 0, 0)
INSERT [dbo].[Education] ([EduId], [Education], [Description], [IsActive], [UserId]) VALUES (2, N'BCA', N'BCA', 0, 0)
INSERT [dbo].[Education] ([EduId], [Education], [Description], [IsActive], [UserId]) VALUES (3, N'BCOM', N'fsdfsdf', 0, 0)
INSERT [dbo].[Education] ([EduId], [Education], [Description], [IsActive], [UserId]) VALUES (4, N'BCA', N'AAAAA', 0, 0)
INSERT [dbo].[Education] ([EduId], [Education], [Description], [IsActive], [UserId]) VALUES (5, N'ttttt', N'ttttt', 0, 0)
INSERT [dbo].[Education] ([EduId], [Education], [Description], [IsActive], [UserId]) VALUES (6, N'PGDCA', N'Post Gra', 0, 0)
INSERT [dbo].[Education] ([EduId], [Education], [Description], [IsActive], [UserId]) VALUES (7, N'testtt', N'testtt', 0, 0)
INSERT [dbo].[Education] ([EduId], [Education], [Description], [IsActive], [UserId]) VALUES (8, N'dsdasd', N'asdfasdf', 0, 0)
INSERT [dbo].[Education] ([EduId], [Education], [Description], [IsActive], [UserId]) VALUES (9, N'wwww', N'wwww', 0, 0)
INSERT [dbo].[Education] ([EduId], [Education], [Description], [IsActive], [UserId]) VALUES (10, N'22222', N'222222', 0, 0)
INSERT [dbo].[Education] ([EduId], [Education], [Description], [IsActive], [UserId]) VALUES (11, N'333333', N'3333333', 0, 0)
INSERT [dbo].[Education] ([EduId], [Education], [Description], [IsActive], [UserId]) VALUES (12, N'Jay Jay JAy', N'123123123', 0, 0)
INSERT [dbo].[Education] ([EduId], [Education], [Description], [IsActive], [UserId]) VALUES (13, N'111111111', N'111111111', 0, 0)
INSERT [dbo].[Education] ([EduId], [Education], [Description], [IsActive], [UserId]) VALUES (14, N'dasd ddddd', N'testdddd', 0, 0)
INSERT [dbo].[Education] ([EduId], [Education], [Description], [IsActive], [UserId]) VALUES (15, N'qwer', N'qwer', 0, 0)
INSERT [dbo].[Education] ([EduId], [Education], [Description], [IsActive], [UserId]) VALUES (16, N'3333333', N'444444444', 0, 0)
INSERT [dbo].[Education] ([EduId], [Education], [Description], [IsActive], [UserId]) VALUES (17, N'9999', N'9999', 0, 0)
INSERT [dbo].[Education] ([EduId], [Education], [Description], [IsActive], [UserId]) VALUES (18, N'BCA', N'BCA', 1, 0)
INSERT [dbo].[Education] ([EduId], [Education], [Description], [IsActive], [UserId]) VALUES (19, N'MCA', N'test', 1, 0)
SET IDENTITY_INSERT [dbo].[Education] OFF
SET IDENTITY_INSERT [dbo].[EmployeeDetails] ON 

INSERT [dbo].[EmployeeDetails] ([id], [name], [gender], [email], [phoneNumber], [contactPreference], [dateofBirth], [department], [eduId], [isActive], [photoPath], [password], [confirmPassword]) VALUES (1, N'jayraj', N'male', N'test@test.com', N'8888888', N'Phone', CAST(N'2019-07-15T10:55:50.000' AS DateTime), 3, 19, 1, N'string', N'123', N'123')
INSERT [dbo].[EmployeeDetails] ([id], [name], [gender], [email], [phoneNumber], [contactPreference], [dateofBirth], [department], [eduId], [isActive], [photoPath], [password], [confirmPassword]) VALUES (2, N'Piyush', N'Female', N'sdfg@gmail.com', N'', N'Email', CAST(N'2019-06-30T18:30:00.000' AS DateTime), 7, 18, 1, N'assets/images/man.jpg', N'111', N'111')
INSERT [dbo].[EmployeeDetails] ([id], [name], [gender], [email], [phoneNumber], [contactPreference], [dateofBirth], [department], [eduId], [isActive], [photoPath], [password], [confirmPassword]) VALUES (3, N'i5test', N'Male', N'sdfg@gmail.com', N'', N'Email', CAST(N'2019-07-30T18:30:00.000' AS DateTime), 1, NULL, 1, N'assets/images/man.jpg', N'111', N'111')
INSERT [dbo].[EmployeeDetails] ([id], [name], [gender], [email], [phoneNumber], [contactPreference], [dateofBirth], [department], [eduId], [isActive], [photoPath], [password], [confirmPassword]) VALUES (4, N'Ganesh', N'Male', N'p@test.com', N'77777777', N'Email', CAST(N'2019-07-24T18:30:00.000' AS DateTime), 11, 19, 1, N'assest/images/man.jpg', N'111', N'111')
INSERT [dbo].[EmployeeDetails] ([id], [name], [gender], [email], [phoneNumber], [contactPreference], [dateofBirth], [department], [eduId], [isActive], [photoPath], [password], [confirmPassword]) VALUES (5, N'WinUpdate1', N'Male', N'sdfg@gmail.com', N'77777777', N'Email', CAST(N'2019-07-17T18:30:00.000' AS DateTime), 3, 18, 1, N'assest/images/man.jpg', N'111', N'111')
INSERT [dbo].[EmployeeDetails] ([id], [name], [gender], [email], [phoneNumber], [contactPreference], [dateofBirth], [department], [eduId], [isActive], [photoPath], [password], [confirmPassword]) VALUES (6, N'ABcAbc', N'Male', N'p@test.com', N'77777777', N'Email', CAST(N'2019-07-02T18:30:00.000' AS DateTime), 3, 18, 1, N'assets/images/man.jpg', N'111', N'111')
INSERT [dbo].[EmployeeDetails] ([id], [name], [gender], [email], [phoneNumber], [contactPreference], [dateofBirth], [department], [eduId], [isActive], [photoPath], [password], [confirmPassword]) VALUES (7, N'test', N'Female', N'test@test.com', N'1111111111', N'Email', CAST(N'2019-07-25T18:30:00.000' AS DateTime), 4, NULL, 1, N'assest/images/man.jpg', N'123', N'123')
SET IDENTITY_INSERT [dbo].[EmployeeDetails] OFF
ALTER TABLE [dbo].[DepartmentDetails] ADD  CONSTRAINT [DF_DepartmentDetails_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Education] ADD  CONSTRAINT [DF_Education_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetDepartment]    Script Date: 9/12/2019 11:47:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetDepartment]
@deptId int

AS

SELECT [deptId]
      ,[DepartmentName]
      ,[Description]
      ,[IsActive]
      ,[UserId]
  FROM [DeveloperHelper].[dbo].[DepartmentDetails] 
  WHERE (@deptId = 0 OR deptId = @deptId) AND IsActive = 1
GO
/****** Object:  StoredProcedure [dbo].[sp_GetEducation]    Script Date: 9/12/2019 11:47:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetEducation] 
	@EduId int = 0
AS
BEGIN

Select EduId,Education,Description,IsActive,UserId from Education where (@EduId = 0 OR EduId = @EduId) AND IsActive = 1

END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetEmployee]    Script Date: 9/12/2019 11:47:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetEmployee]
@empId int = 0
AS

SELECT em.[id]
      ,em.[name]
      ,em.[gender]
      ,em.[email]
      ,em.[phoneNumber]
      ,em.[contactPreference]
      ,em.[dateofBirth]
      ,em.[department]
      ,em.[isActive]
      ,em.[photoPath]
      ,em.[password]
      ,em.[confirmPassword]
	  ,isnull(dp.departmentName,'') as departmentName
	  ,isnull(ed.Education,'') as education,
	  em.eduId
  FROM [dbo].[EmployeeDetails] em 
  LEFT JOIN DepartmentDetails dp on dp.deptId = em.department
  LEFT JOIN Education ed on ed.EduId = em.eduId
  WHERE 1 = 1 AND (@empId = 0 OR em.id = @empId)

  


GO
/****** Object:  StoredProcedure [dbo].[sp_RemoveDepartment]    Script Date: 9/12/2019 11:47:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_RemoveDepartment]
@deptid int 

AS

Update DepartmentDetails
SET [IsActive] = 0
WHERE deptid = @deptid 
GO
/****** Object:  StoredProcedure [dbo].[sp_RemoveEducation]    Script Date: 9/12/2019 11:47:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_RemoveEducation]
	@EduId int 
AS
BEGIN
	Update Education
	Set IsActive = 0
	Where EduId = @EduId
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SaveDepartment]    Script Date: 9/12/2019 11:47:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_SaveDepartment]
@deptId int,
@DepartmentName varchar(50),
@Description varchar(50),
@UserId int
AS
Declare @returnValue int = 1

IF (@deptId = 0)
BEGIN

	IF NOT EXISTS (select deptId from  DepartmentDetails where DepartmentName = @DepartmentName AND IsActive = 1)
	BEGIN
		INSERT INTO DepartmentDetails(DepartmentName,Description,UserId) values (@DepartmentName,@Description,@UserId)
	END
	ELSE
	BEGIN
		SET @returnValue = -11
	END

		
END
ELSE
BEGIN
	IF NOT EXISTS (select deptId from  DepartmentDetails where DepartmentName = @DepartmentName AND IsActive = 1 AND  deptId <> @deptId)
		BEGIN	
			UPDATE  DepartmentDetails
			SET DepartmentName = @DepartmentName,
			Description = @Description
			WHERE  deptId = @deptId
		END
		ELSE
		BEGIN
			SET  @returnValue = -11
		END
END
select  @returnValue
GO
/****** Object:  StoredProcedure [dbo].[sp_SaveEducation]    Script Date: 9/12/2019 11:47:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_SaveEducation]
	 @EduId int
	,@Education varchar(50)
	,@Description varchar(150)
	,@UserId int
AS
Declare @returnValue int = 1
BEGIN
	IF (@EduId = 0) 
	BEGIN

			IF NOT EXISTS (select EduId from  Education where Education = @Education AND IsActive = 1)
			BEGIN
				INSERT INTO Education(Education,Description,UserId) values (@Education,@Description,@UserId)
			END
			ELSE
			BEGIN
				SET @returnValue = -11
			END
	END
	ELSE
	BEGIN
			IF NOT EXISTS (select EduId from  Education where Education = @Education AND IsActive = 1 AND  EduId <> @EduId)
				BEGIN	
					UPDATE  Education
					SET Education = @Education,
					Description = @Description
					WHERE  EduId = @EduId
				END
				ELSE
				BEGIN
					SET  @returnValue = -11
				END
			END
END
select @returnValue
GO
/****** Object:  StoredProcedure [dbo].[sp_SaveEmployee]    Script Date: 9/12/2019 11:47:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_SaveEmployee]   
  
   @Id int   
           ,@name varchar(50)  
           ,@gender varchar(50)  
           ,@email varchar(50)  
           ,@phoneNumber varchar(50)  
           ,@contactPreference varchar(50)  
           ,@dateofBirth datetime  
           ,@department int  
		   ,@eduId int
           ,@isActive bit  
           ,@photoPath varchar(50)  
           ,@password varchar(50)  
           ,@confirmPassword varchar(50)  
    
AS  
  
 IF(@Id=0)   
 BEGIN  
  
  INSERT INTO [dbo].[EmployeeDetails]  
             ([name]  
             ,[gender]  
             ,[email]  
             ,[phoneNumber]  
             ,[contactPreference]  
             ,[dateofBirth]  
             ,[department]  
			 ,[eduId]
             ,[isActive]  
             ,[photoPath]  
             ,[password]  
             ,[confirmPassword])  
       VALUES  
             (@name  
             ,@gender  
             ,@email  
             ,@phoneNumber  
             ,@contactPreference  
             ,@dateofBirth  
             ,@department 
			 ,@eduId 
             ,@isActive  
             ,@photoPath  
             ,@password  
             ,@confirmPassword)  
    
END  

ELSE 

BEGIN

 update EmployeeDetails
 set 
 
  [name]= @name  
 ,[gender] = @gender  
 ,[email] = @email  
 ,[phoneNumber]	= @phoneNumber  
 ,[contactPreference] = @contactPreference
 ,[dateofBirth]	= @dateofBirth  
 ,[department] = @department  
 ,[eduId]  =   @eduId
 ,[isActive]= @isActive  
 ,[photoPath]= @photoPath  
 ,[password] = @password  
 ,[confirmPassword]	= @confirmPassword

 where id =@Id


END 
  
GO
