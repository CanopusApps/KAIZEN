USE [KAIZEN]
GO
/****** Object:  StoredProcedure [dbo].[UpdateApprovalStatus]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[UpdateApprovalStatus]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Winner_checkuser]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_Winner_checkuser]
GO
/****** Object:  StoredProcedure [dbo].[Sp_UpdatePassword]    Script Date: 16-09-2024 12:27:34 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_UpdatePassword]  
GO

/****** Object:  StoredProcedure [dbo].[Sp_EditUser]    Script Date: 16-09-2024 17:40:28 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_EditUser]  
GO

/****** Object:  StoredProcedure [dbo].[SP_USERLOG]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[SP_USERLOG]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Upload_Users]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_Upload_Users]
GO
/****** Object:  StoredProcedure [dbo].[Sp_UpdateWinner]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_UpdateWinner]
GO
/****** Object:  StoredProcedure [dbo].[Sp_UpdateTheme]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_UpdateTheme]
GO
/****** Object:  StoredProcedure [dbo].[Sp_UpdateDomain]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_UpdateDomain]
GO
/****** Object:  StoredProcedure [dbo].[Sp_UpdateDepartmentStatus]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_UpdateDepartmentStatus]
GO
/****** Object:  StoredProcedure [dbo].[Sp_UpdateDepartment]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_UpdateDepartment]
GO
/****** Object:  StoredProcedure [dbo].[Sp_UpdateBlockStatus]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_UpdateBlockStatus]
GO
/****** Object:  StoredProcedure [dbo].[Sp_UpdateBlock]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_UpdateBlock]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Register]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_Register] 
GO
/****** Object:  StoredProcedure [dbo].[Sp_LoginWinnerDetails]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_LoginWinnerDetails]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Login]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_Login]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Kaizen_Update]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_Kaizen_Update]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Kaizen_TeamMemberDelete]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_Kaizen_TeamMemberDelete]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Kaizen_Insert]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_Kaizen_Insert]
GO
/****** Object:  StoredProcedure [dbo].[Sp_InsertUser]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_InsertUser]
GO
/****** Object:  StoredProcedure [dbo].[Sp_InsertDomain]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_InsertDomain]
GO
/****** Object:  StoredProcedure [dbo].[Sp_InsertDepartment]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_InsertDepartment]
GO
/****** Object:  StoredProcedure [dbo].[Sp_GetWinnersList]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_GetWinnersList]
GO
/****** Object:  StoredProcedure [dbo].[Sp_GetUsersByDomainId]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_GetUsersByDomainId]
GO
/****** Object:  StoredProcedure [dbo].[Sp_GetUsersByDeptId]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_GetUsersByDeptId]
GO
/****** Object:  StoredProcedure [dbo].[Sp_GetUsersByBlockId]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_GetUsersByBlockId]
GO
/****** Object:  StoredProcedure [dbo].[Sp_GetUserManagerupdate]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_GetUserManagerupdate]
GO
/****** Object:  StoredProcedure [dbo].[Sp_GetUserManager]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_GetUserManager]
GO
/****** Object:  StoredProcedure [dbo].[Sp_GetTheme]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_GetTheme]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetKaizenStatisticsByApprovalTypes]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[sp_GetKaizenStatisticsByApprovalTypes]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetEmployeeDashboardDetails]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[sp_GetEmployeeDashboardDetails]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Get_UserType]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_Get_UserType]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Get_Users]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_Get_Users]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Get_UserLogformReport]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_Get_UserLogformReport]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Get_UserformReport]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_Get_UserformReport]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Get_Status]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_Get_Status]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Get_KaizenProfileDetails]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_Get_KaizenProfileDetails]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Get_KaizenOriginetedby]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_Get_KaizenOriginetedby]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Get_KaizenformReport]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_Get_KaizenformReport]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Get_Kaizen_Details]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_Get_Kaizen_Details]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Get_IEDeptDetails]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_Get_IEDeptDetails]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Get_FinanceDetails]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_Get_FinanceDetails]
GO
/****** Object:  StoredProcedure [dbo].[sp_Get_Domains]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[sp_Get_Domains]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Get_DomainformReport]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_Get_DomainformReport]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Get_Departments]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_Get_Departments]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Get_DepartmentformReport]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_Get_DepartmentformReport]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Get_DashboardManagerDomainDepartment]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_Get_DashboardManagerDomainDepartment]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Get_Dashboardgraphs]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_Get_Dashboardgraphs]
GO
/****** Object:  StoredProcedure [dbo].[sp_Get_DashboardDomains]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[sp_Get_DashboardDomains]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Get_DashboardDepartments]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_Get_DashboardDepartments]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Get_DashboardDepartmentgraph]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_Get_DashboardDepartmentgraph]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Get_Cadre]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_Get_Cadre]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Get_BlockformReport]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_Get_BlockformReport]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Get_BlockDetails]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_Get_BlockDetails]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Get_Approval_Status]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_Get_Approval_Status]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Get_AllDashboardReports]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_Get_AllDashboardReports]
GO
/****** Object:  StoredProcedure [dbo].[Sp_FetchEmail]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_FetchEmail]
GO
/****** Object:  StoredProcedure [dbo].[Sp_FetchAndUpdateDetails]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_FetchAndUpdateDetails]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Fetch_KaizenUpdateDetails_ById]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_Fetch_KaizenUpdateDetails_ById]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Fetch_Kaizens_For_Approval]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_Fetch_Kaizens_For_Approval]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Fetch_KaizenDetails_ById]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_Fetch_KaizenDetails_ById]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Fetch_KaizenAttachments_ById]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_Fetch_KaizenAttachments_ById]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Fetch_Count]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_Fetch_Count]
GO
/****** Object:  StoredProcedure [dbo].[Sp_EditUser]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_EditUser]
GO
/****** Object:  StoredProcedure [dbo].[Sp_DeleteWinner]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_DeleteWinner]
GO
/****** Object:  StoredProcedure [dbo].[Sp_DeleteAttachmentsByKaizenID]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_DeleteAttachmentsByKaizenID]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Delete_User]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_Delete_User]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Delete_Kaizens]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_Delete_Kaizens]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Delete_Domain]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_Delete_Domain]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Delete_Department]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_Delete_Department]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Delete_BlockDetails]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_Delete_BlockDetails]
GO
/****** Object:  StoredProcedure [dbo].[Sp_DashboardFilter]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_DashboardFilter]
GO
/****** Object:  StoredProcedure [dbo].[Sp_checkuser]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_checkuser]
GO
/****** Object:  StoredProcedure [dbo].[Sp_AddWinner]    Script Date: 19-09-2024 15:08:09 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_AddWinner]
GO
/****** Object:  StoredProcedure [dbo].[Sp_AddBlockDetails]    Script Date: 05-09-2024 20:04:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_AddBlockDetails]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Get_kaizen_details_On_clickdashboard]    Script Date: 10-09-2024 15:00:16 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_Get_kaizen_details_On_clickdashboard]
GO

/****** Object:  StoredProcedure [dbo].[Sp_GetManagers]    Script Date: 10-09-2024 12:11:49 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_GetManagers]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateDomainStatus]    Script Date: 10-09-2024 15:19:49 ******/
DROP PROCEDURE IF EXISTS [dbo].[sp_UpdateDomainStatus]
GO
/****** Object:  StoredProcedure [dbo].[Sp_UserProfile]     Script Date: 12-09-2024 16:04:49 ******/
DROP PROCEDURE IF EXISTS [dbo].[Sp_UserProfile] 
GO


/****** Object:  StoredProcedure [dbo].[Sp_UpdatePassword]    Script Date: 16-09-2024 12:27:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Sp_UpdatePassword]
    @Id INT,
    @Pwd NVARCHAR(255)
AS
BEGIN

    UPDATE Users
    SET Password = @Pwd
    WHERE EmpID = @Id;

  
END
GO



/****** Object:  StoredProcedure [dbo].[Sp_AddBlockDetails]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sp_AddBlockDetails]    
@Blockname nvarchar(50),  
@CreatedBy nvarchar(100)=null  
AS        
 BEGIN    
 Declare @CreatedId nvarchar(100);  
 set @CreatedId=(select ID FROM [dbo].[Users] WHERE EmpID=@CreatedBy)   
 BEGIN  
 INSERT INTO [Blocks]            
 (BlockName,Status,CreatedBy,CreatedDate)             
 VALUES             
 (@Blockname,'1',@CreatedId,GETDATE())             
 END    
 END
GO
/****** Object:  StoredProcedure [dbo].[Sp_AddWinner]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Sp_AddWinner]            
    @EmpGUID UNIQUEIDENTIFIER,            
    @Category NVARCHAR(50),            
    @StartDate DATETIME,            
    @EndDate DATETIME,            
    @CreatedBy NVARCHAR(50)='',        
    @Status NVARCHAR(50),      
    @winnerimg NVARCHAR(300)='',     
    @result BIT OUT  
AS            
BEGIN            
    DECLARE @SessionId UNIQUEIDENTIFIER;  
    SET @SessionId = (SELECT ID FROM [dbo].Users WHERE UserID = @CreatedBy);  
      
    -- Check for overlapping dates for the same employee and category  
     IF EXISTS (
        SELECT 1
        FROM WinnersList
        WHERE EmpGUID = @EmpGUID
    )
    BEGIN  
        SET @result = 1;  
        RETURN;  
    END  
      
    -- No overlap, proceed with insertion  
    INSERT INTO WinnersList           
    (          
        ID, EmpGUID, Category, StartDate, EndDate, CreatedDate, CreatedBy, Status, WinnerimgPath  
    )           
    VALUES           
    (          
        NEWID(), @EmpGUID, @Category, @StartDate, @EndDate, GETDATE(), @SessionId, @Status, @winnerimg  
    );     
      
    SET @result = 0; -- Indicates success  
END

GO
/****** Object:  StoredProcedure [dbo].[Sp_checkuser]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sp_checkuser]
    @EmpId NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    -- Check if the employee ID exists in the Users table
    IF EXISTS (SELECT 1 FROM Users WHERE EmpId = @EmpId)
    BEGIN
        -- Return 1 if the employee ID exists
        SELECT 1 AS UserExists;
    END
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_DashboardFilter]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sp_DashboardFilter]
(
    @StartDate DATE = NULL,
    @EndDate DATE = NULL,
    @Domain NVARCHAR(100) = NULL,
	@Cadre NVARCHAR(100) = NULL,
	@Block NVARCHAR(100) = NULL,
    @Department NVARCHAR(100) = NULL

)
AS
BEGIN
    -- Handle NULL parameters
    SET @StartDate = NULLIF(@StartDate, '')
	
    SET @EndDate = NULLIF(@EndDate, '')
    SET @Domain = NULLIF(@Domain, '')
    SET @Department = NULLIF(@Department, '')
	SET @Cadre = NULLIF(@Cadre, '')
    SET @Block = NULLIF(@Block, '')

   --Query to get Kaizen data with out months
    SELECT 
        SUM(CASE WHEN Kaizens.ApprovalStatus not in(0,14) THEN 1 ELSE 0 END) AS TotalKaizens,
        SUM(CASE WHEN Kaizens.ApprovalStatus IN (4, 5, 2) THEN 1 ELSE 0 END) AS DRITotal,
			  SUM(
			CASE 
				WHEN Kaizens.ApprovalStatus IN (8, 9) THEN 1 
				WHEN Kaizens.ApprovalStatus = 4 AND Kaizens.ApprovedByIE IS NULL AND Kaizens.FinanceApprovedBy IS NOT NULL THEN 1
				WHEN Kaizens.ApprovalStatus = 4 AND Kaizens.ApprovedByIE IS NULL AND Kaizens.FinanceApprovedBy IS NULL THEN 0
				WHEN Kaizens.ApprovalStatus = 6 AND Kaizens.FinanceApprovedBy IS NOt NULL THEN 1
				ELSE 0 
			END
		) AS FinanceTotal,
           SUM(
    CASE 
        WHEN Kaizens.ApprovalStatus IN (6, 7, 4) THEN 1
        WHEN Kaizens.ApprovalStatus = 4 AND Kaizens.ApprovedByIE IS NOT NULL THEN 1
        ELSE 0
    END
) AS IETotal,
		   SUM(CASE WHEN Kaizens.ApprovalStatus IN (3,2,1) THEN 1 ELSE 0 END) AS Imagetotal,
		   SUM(CASE WHEN Kaizens.ApprovalStatus IN (3,5,7,9) THEN 1 ELSE 0 END) AS TotalRejected,
		   SUM(CASE WHEN Kaizens.ApprovalStatus IN (2,4,6,8) THEN 1 ELSE 0 END) AS TotalApproved,
		   SUM(CASE WHEN Kaizens.ApprovalStatus IN (1,2,4,6) THEN 1 ELSE 0 END) AS TotalPending,
		   SUM(CASE WHEN Kaizens.ApprovalStatus IN (2, 4, 6, 8) and Kaizens.ImageApprovedBy is not null THEN 1 ELSE 0 END) AS cardImageApproved,
		     SUM(CASE WHEN Kaizens.ApprovalStatus IN (1) and Kaizens.ImageApprovedBy is not null THEN 1 ELSE 0 END) AS cardImagePending,
			   SUM(CASE WHEN Kaizens.ApprovalStatus IN (3) and Kaizens.ImageApprovedBy is not null THEN 1 ELSE 0 END) AS cardImageRejected,
				   SUM(
			CASE 
				WHEN Kaizens.ApprovalStatus IN (4) THEN 1
				WHEN Kaizens.ApprovalStatus = 6 AND Kaizens.ApprovedByIE IS NOT NULL THEN 1
				WHEN Kaizens.ApprovalStatus = 8 AND Kaizens.FinanceApprovedBy IS NOT NULL THEN 1
				ELSE 0
			END
		) AS CardManagerApproved,
		 Sum(CASE WHEN Kaizens.ApprovalStatus IN(15,2) THEN 1 ELSE 0 END) AS cardManagerpending,
		 Sum(CASE WHEN Kaizens.ApprovalStatus IN(5) THEN 1 ELSE 0 END) AS cardManagerrejected,
			SUM(
				CASE 
					WHEN Kaizens.ApprovalStatus IN (6) THEN 1
					WHEN Kaizens.ApprovalStatus = 8 AND Kaizens.FinanceApprovedBy IS not NULL THEN 1
					ELSE 0
				END
			) AS CardIEApproved,
	    SUM(
			CASE 				
				WHEN Kaizens.ApprovalStatus = 4 AND Kaizens.ApprovedByIE IS NOT NULL THEN 1
				ELSE 0
			END
		) AS CardIEPending,
		 Sum(CASE WHEN Kaizens.ApprovalStatus IN(7) THEN 1 ELSE 0 END) AS CardIERejected,
          Sum(CASE WHEN Kaizens.ApprovalStatus IN(8) THEN 1 ELSE 0 END) AS CardFinanceApproved,
		   SUM(
			CASE 				
				WHEN Kaizens.ApprovalStatus = 4 AND (Kaizens.ApprovedByIE IS NULL OR Kaizens.ApprovedByIE IS NOT NULL)and Kaizens.FinanceApprovedBy IS NOT NULL THEN 1
				WHEN Kaizens.ApprovalStatus IN (6) AND Kaizens.FinanceApprovedBy IS not NULL THEN 1
				ELSE 0
			END
		) AS CardFinancePending,
		 Sum(CASE WHEN Kaizens.ApprovalStatus IN(9) THEN 1 ELSE 0 END) AS CardFinnaceRejected

	    
    FROM 
        [dbo].[Kaizens]
    LEFT JOIN 
        Domains ON Domains.ID = Kaizens.Domain
    LEFT JOIN 
        Departments ON Departments.ID = Kaizens.Department
		  LEFT JOIN
	     Blocks ON Blocks.ID =Kaizens.Block
		 LEFT JOIN 
    Users ON Users.ID = Kaizens.CreatedBy
		 LEFT JOIN
    Cadre ON Cadre.ID = Users.Cadre
		
		

		
    WHERE
        (@StartDate IS NULL OR Kaizens.CreatedDate >= @StartDate) 
    AND (@EndDate IS NULL OR Kaizens.CreatedDate <= @EndDate)
    AND (@Domain IS NULL OR Domains.DomainName = @Domain)
	AND (@Department IS NULL OR Departments.DepartmentName = @Department)
	AND	(@Block IS NULL OR Blocks.BlockName=@Block)
	 AND (@Cadre IS NULL OR Cadre.cadreDesc = @Cadre)


		
   --Query to get Kaizen data based on months
SELECT 
    FORMAT(Kaizens.CreatedDate, 'MMM-yyyy') AS MonthYear,
 SUM(CASE WHEN Kaizens.ApprovalStatus not in(0,14) THEN 1 ELSE 0 END) AS TotalKaizens,
        SUM(CASE WHEN Kaizens.ApprovalStatus IN (4, 5, 2) THEN 1 ELSE 0 END) AS DRITotal,
			  SUM(
			CASE 
				WHEN Kaizens.ApprovalStatus IN (8, 9) THEN 1 
				WHEN Kaizens.ApprovalStatus = 4 AND Kaizens.ApprovedByIE IS NULL AND Kaizens.FinanceApprovedBy IS NOT NULL THEN 1
				WHEN Kaizens.ApprovalStatus = 4 AND Kaizens.ApprovedByIE IS NULL AND Kaizens.FinanceApprovedBy IS NULL THEN 0
				WHEN Kaizens.ApprovalStatus = 6 AND Kaizens.FinanceApprovedBy IS NOt NULL THEN 1
				ELSE 0 
			END
		) AS FinanceTotal,
           SUM(
    CASE 
        WHEN Kaizens.ApprovalStatus IN (6, 7, 4) THEN 1
        WHEN Kaizens.ApprovalStatus = 4 AND Kaizens.ApprovedByIE IS NOT NULL THEN 1
        ELSE 0
    END
) AS IETotal,
		   SUM(CASE WHEN Kaizens.ApprovalStatus IN (3,2,1) THEN 1 ELSE 0 END) AS Imagetotal,
		   SUM(CASE WHEN Kaizens.ApprovalStatus IN (3,5,7,9) THEN 1 ELSE 0 END) AS TotalRejected,
		   SUM(CASE WHEN Kaizens.ApprovalStatus IN (2,4,6,8) THEN 1 ELSE 0 END) AS TotalApproved,
		   SUM(CASE WHEN Kaizens.ApprovalStatus IN (1,2,4,6) THEN 1 ELSE 0 END) AS TotalPending,
		   SUM(CASE WHEN Kaizens.ApprovalStatus IN (2, 4, 6, 8) and Kaizens.ImageApprovedBy is not null THEN 1 ELSE 0 END) AS cardImageApproved,
		     SUM(CASE WHEN Kaizens.ApprovalStatus IN (1) and Kaizens.ImageApprovedBy is not null THEN 1 ELSE 0 END) AS cardImagePending,
			  SUM(CASE WHEN Kaizens.ApprovalStatus IN (3) and Kaizens.ImageApprovedBy is not null THEN 1 ELSE 0 END) AS cardImageRejected,
				   SUM(
			CASE 
				WHEN Kaizens.ApprovalStatus IN (4) THEN 1
				WHEN Kaizens.ApprovalStatus = 6 AND Kaizens.ApprovedByIE IS NOT NULL THEN 1
				WHEN Kaizens.ApprovalStatus = 8 AND Kaizens.FinanceApprovedBy IS NOT NULL THEN 1
				ELSE 0
			END
		) AS CardManagerApproved,
		 Sum(CASE WHEN Kaizens.ApprovalStatus IN(15,2) THEN 1 ELSE 0 END) AS cardManagerpending,
		 Sum(CASE WHEN Kaizens.ApprovalStatus IN(5) THEN 1 ELSE 0 END) AS cardManagerrejected,
			SUM(
				CASE 
					WHEN Kaizens.ApprovalStatus IN (6) THEN 1
					WHEN Kaizens.ApprovalStatus = 8 AND Kaizens.FinanceApprovedBy IS not NULL THEN 1
					ELSE 0
				END
			) AS CardIEApproved,
	    SUM(
			CASE 				
				WHEN Kaizens.ApprovalStatus = 4 AND Kaizens.ApprovedByIE IS NOT NULL THEN 1
				ELSE 0
			END
		) AS CardIEPending,
		 Sum(CASE WHEN Kaizens.ApprovalStatus IN(7) THEN 1 ELSE 0 END) AS CardIERejected,
          Sum(CASE WHEN Kaizens.ApprovalStatus IN(8) THEN 1 ELSE 0 END) AS CardFinanceApproved,
		   SUM(
			CASE 				
				WHEN Kaizens.ApprovalStatus = 4 AND (Kaizens.ApprovedByIE IS NULL OR Kaizens.ApprovedByIE IS NOT NULL)and Kaizens.FinanceApprovedBy IS NOT NULL THEN 1
				WHEN Kaizens.ApprovalStatus IN (6) AND Kaizens.FinanceApprovedBy IS not NULL THEN 1
				ELSE 0
			END
		) AS CardFinancePending,
		 Sum(CASE WHEN Kaizens.ApprovalStatus IN(9) THEN 1 ELSE 0 END) AS CardFinnaceRejected
FROM 
    [dbo].[Kaizens]
LEFT JOIN 
    Domains ON Domains.ID = Kaizens.Domain
LEFT JOIN 
    Departments ON Departments.ID = Kaizens.Department
LEFT JOIN
    Blocks ON Blocks.ID = Kaizens.Block
LEFT JOIN 
    Users ON Users.ID = Kaizens.CreatedBy
LEFT JOIN
    Cadre ON Cadre.ID = Users.Cadre
WHERE
    (@StartDate IS NULL OR Kaizens.CreatedDate >= @StartDate) 
    AND (@EndDate IS NULL OR Kaizens.CreatedDate <= @EndDate)
    AND (@Domain IS NULL OR Domains.DomainName = @Domain)
    AND (@Department IS NULL OR Departments.DepartmentName = @Department)
    AND (@Block IS NULL OR Blocks.BlockName = @Block)
    AND (@Cadre IS NULL OR Cadre.cadreDesc = @Cadre)
GROUP BY 
    FORMAT(Kaizens.CreatedDate, 'MMM-yyyy')
ORDER BY 
    MonthYear;



	-- to kaizen data based on custom month
	SELECT 
    CONCAT(
        FORMAT(DATEADD(DAY, -15, Kaizens.CreatedDate), '16-MMM-yyyy'), 
        ' to ', 
        FORMAT(DATEADD(DAY, -15, DATEADD(MONTH, 1, Kaizens.CreatedDate)), '15-MMM-yyyy')
    ) AS CustomMonthRange,
    SUM(CASE WHEN Kaizens.ApprovalStatus NOT IN (0, 14) THEN 1 ELSE 0 END) AS TotalKaizens
FROM 
    [dbo].[Kaizens]
LEFT JOIN 
    Domains ON Domains.ID = Kaizens.Domain
LEFT JOIN 
    Departments ON Departments.ID = Kaizens.Department
LEFT JOIN
    Blocks ON Blocks.ID = Kaizens.Block
LEFT JOIN 
    Users ON Users.ID = Kaizens.CreatedBy

WHERE
    (@StartDate IS NULL OR Kaizens.CreatedDate >= @StartDate) 
    AND (@EndDate IS NULL OR Kaizens.CreatedDate <= @EndDate)
    AND (@Domain IS NULL OR Domains.DomainName = @Domain)
    AND (@Department IS NULL OR Departments.DepartmentName = @Department)
    AND (@Block IS NULL OR Blocks.BlockName = @Block)
   
GROUP BY 
    CONCAT(
        FORMAT(DATEADD(DAY, -15, Kaizens.CreatedDate), '16-MMM-yyyy'), 
        ' to ', 
        FORMAT(DATEADD(DAY, -15, DATEADD(MONTH, 1, Kaizens.CreatedDate)), '15-MMM-yyyy')
    )
ORDER BY 
    CustomMonthRange;	
End
GO
/****** Object:  StoredProcedure [dbo].[Sp_Delete_BlockDetails]    Script Date: 17-09-2024 10:30:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

  
CREATE PROCEDURE [dbo].[Sp_Delete_BlockDetails]  
@ID int,
@ReturnMessage INT OUT
AS  
 BEGIN    
  IF EXISTS (SELECT 1 FROM [Blocks] WHERE BlockId = @ID AND Status = 1)  
    BEGIN  
        SET @ReturnMessage = 5
        RETURN
    END 
 DELETE from [Blocks] WHERE BlockId = @ID  
 END    
GO
/****** Object:  StoredProcedure [dbo].[Sp_Delete_Department]    Script Date: 17-09-2024 10:32:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Sp_Delete_Department]  
@ID int , 
@ReturnMessage INT OUT
AS  
 BEGIN    
  IF EXISTS (SELECT 1 FROM [dbo].[Departments] WHERE DeptId = @ID AND Status = 1)  
    BEGIN  
        SET @ReturnMessage = 5
        RETURN
    END           
 DELETE from [dbo].[Departments] WHERE [DeptId] = @ID  
 END 
GO
/****** Object:  StoredProcedure [dbo].[Sp_Delete_Domain]    Script Date: 17-09-2024 10:33:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[Sp_Delete_Domain]
@ID int,
@ReturnMessage INT OUT
AS  
 BEGIN    
  IF EXISTS (SELECT 1 FROM [dbo].[Domains] WHERE DomainID = @ID AND Status = 1)  
    BEGIN  
        SET @ReturnMessage = 5
        RETURN
    END            
	DELETE from [Domains] WHERE DomainID = @ID
 END  
GO
/****** Object:  StoredProcedure [dbo].[Sp_Delete_Kaizens]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Proc [dbo].[Sp_Delete_Kaizens]
@KaizenId int,
@UserId uniqueidentifier
as
Begin
update Kaizens set ApprovalStatus=14,DeletedBy=@UserId,DeletedDate=GETDATE() where KaizenId=@KaizenId
End
GO
/****** Object:  StoredProcedure [dbo].[Sp_Delete_User]    Script Date: 16-09-2024 16:38:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[Sp_Delete_User]
@id int 
as
Begin
delete from Users where EmpID=@id
End
GO
/****** Object:  StoredProcedure [dbo].[Sp_DeleteAttachmentsByKaizenID]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[Sp_DeleteAttachmentsByKaizenID]
@kaizenID NVARCHAR(50),
@FileName NVARCHAR(max)
AS
 BEGIN          
	DELETE from Attachments WHERE KaizenID = @kaizenID AND FileName = @FileName;
 END  
GO
/****** Object:  StoredProcedure [dbo].[Sp_DeleteWinner]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sp_DeleteWinner]
    @ID INT,
    @StartDate DATETIME,
    @EndDate DATETIME
AS
BEGIN
    DECLARE @EmpGuid NVARCHAR(100);
    
    SET @EmpGuid = (SELECT ID FROM [dbo].[Users] WHERE EmpID = @ID);
    
    DELETE FROM WinnersList
    WHERE EmpGUID = @EmpGuid
      AND StartDate = @StartDate
      AND EndDate = @EndDate;
END;
GO
/****** Object:  StoredProcedure [dbo].[Sp_EditUser]    Script Date: 16-09-2024 17:50:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Sp_EditUser]    
@EmployeeID NVARCHAR(50),    
@FirstName NVARCHAR(300),    
@MiddleName NVARCHAR(300),    
@LastName NVARCHAR(300),    
@Email NVARCHAR(200),    
@PhoneNo NVARCHAR(200),    
@Status INT,    
@ImageApprover BIT,    
@Cid INT,    
@Rid INT,    
@Did INT,    
@Deptid INT,    
--@Password NVARCHAR(200),    
@Gender NVARCHAR(20),    
@ModifiedEmpId NVARCHAR(50) = NULL,    
@BlockId Int=0,    
@result BIT Out ,
@ReturnMessage NVARCHAR(500) OUT,
@ReturnUser NVARCHAR(500) OUT
AS    
BEGIN    
Declare @employe nvarchar(100),
        @usertype nvarchar(100);      
set @employe =(select ID FROM [dbo].[Users] WHERE EmpID=@EmployeeID);
set @usertype =(select ID FROM [dbo].[UserType] WHERE UserCode='ADM');
SET NOCOUNT ON;
  IF @Status = 0
    BEGIN
        IF EXISTS (
            SELECT 1 
            FROM [dbo].[Kaizens] 
            WHERE CreatedBy = @employe 
            AND [ApprovalStatus] IN (1,2,4,6,15)
        )
        BEGIN
            SET @ReturnMessage = 'The employee has associated Kaizens with approval ';
            RETURN; 
        END
    END

	 IF @Rid IN ('2', '3', '4', '5', '6')
    BEGIN
        DECLARE @adminCount INT;
        SELECT @adminCount = COUNT(1)
        FROM [dbo].[Users]
        WHERE UserType = @usertype
        AND ID != @employe;

        IF @adminCount < 1
        BEGIN
            SET @ReturnUser = 'At least two users with UserType 1 must remain in the system.';
            RETURN;
        END
    END
 
 
Declare @ModifiedBy nvarchar(100);      
set @ModifiedBy =(select ID FROM [dbo].[Users] WHERE EmpID=@ModifiedEmpId)     
SET @result = ( SELECT COUNT(*) FROM [dbo].[USERS] WHERE EMPID = @EmployeeID)    

IF (@result = 1)    

BEGIN    
  UPDATE [dbo].[USERS]    
  SET    UserID = @EmployeeID,    
  FirstName = CASE WHEN @FirstName IS NOT NULL AND @FirstName <> FirstName THEN @FirstName ELSE FirstName END,    
  MiddleName = @MiddleName,   
  LastName = @LastName,  
  --LastName = CASE WHEN @LastName IS NOT NULL AND @LastName <> LastName THEN @LastName ELSE LastName END,    
  Email = CASE WHEN @Email IS NOT NULL AND @Email <> Email THEN @Email ELSE Email END,     
  --MobileNumber = CASE WHEN @PhoneNo IS NOT NULL AND @PhoneNo <> MobileNumber THEN @PhoneNo ELSE MobileNumber END,    
  --Password = CASE WHEN @Password IS NOT NULL AND @Password <> Password THEN @Password ELSE Password END, 
  MobileNumber = @PhoneNo,
  --Gender = CASE WHEN @gender IS NOT NULL AND @gender <> Gender THEN @gender ELSE Gender END, 
  Gender = @Gender,
  Status = CASE WHEN @Status IS NOT NULL AND @Status <> Status THEN @Status ELSE Status END,     
  --ImageApprover = CASE WHEN @ImageApprover IS NOT NULL AND @ImageApprover <> ImageApprover THEN @ImageApprover ELSE ImageApprover END,    
  ImageApprover = @ImageApprover,  
  Domain = (SELECT ID FROM [dbo].[Domains] WHERE DomainID = @Did),     
  Department = (SELECT ID FROM [dbo].[Departments] WHERE DeptId = @Deptid),     
  UserType = (SELECT ID FROM [dbo].[USERTYPE] WHERE UserTypeId = @Rid),     
  Cadre = (SELECT ID FROM [dbo].[Cadre] WHERE CadreId = @Cid),    
  Block=(Select ID From[dbo].[Blocks] where BlockId=@BlockId),    
  ModifiedBy = @ModifiedBy,    
  ModifiedDate = getdate()    
    WHERE EmpID = @EmployeeID;    
  END    
END 
 
GO
/****** Object:  StoredProcedure [dbo].[Sp_Fetch_Count]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Proc [dbo].[Sp_Fetch_Count]
as
Begin
SELECT 
    (SELECT COUNT(*) 
     FROM Kaizens 
     WHERE ApprovalStatus = 14)  AS DeletedCount,
    (SELECT COUNT(*) 
     FROM Kaizens 
     WHERE ApprovalStatus = 1)  AS ImageApprovalCount  
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_Fetch_KaizenAttachments_ById]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
CREATE Procedure [dbo].[Sp_Fetch_KaizenAttachments_ById]  
@KaizenId UNIQUEIDENTIFIER ,
@AttachID UNIQUEIDENTIFIER
as  
Begin  
SELECT FileName FROM [dbo].[Attachments] where KaizenID = @KaizenId AND ID = @AttachID;
end   
GO
/****** Object:  StoredProcedure [dbo].[Sp_Fetch_KaizenDetails_ById]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
          
         
--exec Sp_Fetch_KaizenDetails_ById '55'          
CREATE proc [dbo].[Sp_Fetch_KaizenDetails_ById]          
@KaizenId Varchar(20)          
as          
Begin          
 declare @guid uniqueidentifier          
--Fetch All Kaizen Details Against KaizenID          
SELECT distinct Kaizens.DRIApprovedDate,Kaizens.IEApprovedDate,Kaizens.FinanceApprovedDate,kaizens.RejectionReason,ApprovalStatus.StatusDescription,Kaizens.KaizenId,KaizenType,Activity,ActivityDesc,Kaizens.[BenefitArea],DocNo,VersionNoDate,CostCentre,    
  
    
KaizenRefNo,          
  Blocks.BlockName as Block,BlockDetails,u.Email as ApprovedByIEEmail, ua.Email AS ApprovedByAccountsEmail,SuggestedKaizen,ProblemStatement,CounterMeasure,AttachmentBefore,AttachmentAfter,AttachmentOthers,Yield,CycleTime,Cost,ManPower,Consumables,others,TotalSavings,Kaizens.TeamMemberID,RootCause,PresentCondition,        
  ImprovementsCompleted,RootProblemAttachment,RootCauseDetails,ScopeOfDeploymentId,InOtherMC,WithIntheDept,InOtherDept,OtherPoints,Benifits,OrigionatedDept,OrigonatedDate,          
            KaizenTheme,HorozantalDeployment,Shortlisted,ApprovalStatus,DRIApprovedDate,Users.FirstName as OriginatedBy,Kaizens.ID,         
            CASE           
                WHEN CycleTime > 0 THEN 'YES'           
                WHEN CycleTime = 0 THEN 'NO'          
            END AS IEApprovedDept,           
            CASE         
                WHEN Cost >= 100000 THEN 'YES'           
                WHEN Cost < 100000 THEN 'NO'          
            END AS FinnanceDeptAppr,          
            Users.FirstName AS CreatedBy,          
            CONVERT(VARCHAR, Kaizens.CreatedDate, 105) AS CreatedDate ,          
    Domains.DomainName + '-' + Departments.DepartmentName AS Dept,
    Departments.ID AS DepartmentID
        FROM           
            [dbo].[Kaizens]          
        LEFT JOIN           
            KaizenTeamMembers ON KaizenTeamMembers.KaizenID = Kaizens.ID          
        LEFT JOIN           
            Users ON Users.ID = Kaizens.CreatedBy          
        LEFT JOIN           
            ApprovalStatus ON ApprovalStatus.StatusID = Kaizens.ApprovalStatus          
        LEFT JOIN           
            Domains ON Domains.ID = Kaizens.Domain          
        LEFT JOIN           
            Departments ON Departments.ID = Kaizens.Department          
     LEFT JOIN           
            Blocks ON Blocks.ID = Kaizens.Block       
 LEFT JOIN      
   Users u ON u.ID=Kaizens.ApprovedByIE 
   LEFT JOIN      
        Users ua ON ua.ID = Kaizens.FinanceApprovedBy
         
  Where Kaizens.KaizenId=@KaizenId          
          
--Fetch Kaizen Team Member Details Against KaizenID          
  Select @guid=Id from Kaizens where KaizenId=@KaizenId          
  Select kt.Id, kt.EmpID as EmpGuID,us.EmpId,us.ID,TeamMemberName as TeamName,FunctionName           
  from KaizenTeamMembers kt          
  left join Users us on us.Id=kt.EmpId          
  where KaizenId=@guid          
--Fetch Kaizen Scope Details Against KaizenID          
  Select @guid=Id from Kaizens where KaizenId=@KaizenId          
  Select MC,TargetDate ,Responsibility,ScopeStatus          
  from KaizenScopeDetails KS          
  left join Users us on us.Id=KS.KaizenId          
  where KaizenId=@guid          
--Fetch approvers Details           
            
  Select @guid=Id from Kaizens where KaizenId=@KaizenId          
     Select  distinct Kaizens.KaizenId as kaizenId, u4.FirstName ImageAproveName,u1.FirstName As DriName,u2.FirstName As FinnaceName ,u3.FirstName As IEname ,u1.Email as DriEmail,u2.Email FinanceEmail,u3.Email IeEmail          
  ,dom1.DomainName as DriDomain,dep1.DepartmentName As DriDept           
  ,dom2.DomainName as FinDomain,dep2.DepartmentName As FinDept          
  ,dom3.DomainName as IEDomain,dep3.DepartmentName As IEDept          
  from          
            
  [dbo].[Kaizens]          
          LEFT JOIN             
       Users u1 ON u1.ID = Kaizens.DRIApprovedBy           
   LEFT JOIN           
       Users u2 ON u2.ID = Kaizens.FinanceApprovedBy          
   LEFT JOIN           
       Users u3 ON u3.ID = Kaizens.ApprovedByIE          
     LEFT JOIN           
    Users u4 ON u4.ID = Kaizens.ImageApprovedBy          
    left join           
     Departments dep1 ON dep1.ID = U1.Department           
      left join      
     Domains dom1 ON dom1.ID = u1.Domain           
      left join           
     Departments dep2 ON dep2.ID = U2.Department           
      left join           
     Domains dom2 ON dom2.ID = u2.Domain           
      left join           
     Departments dep3 ON dep3.ID = U3.Department           
      left join           
     Domains dom3 ON dom3.ID = u3.Domain           
     Where Kaizens.ID=@guid          
--Fetch image Details           
SELECT           
    KaizenID,          
    FileName,ID,          
    CASE           
        WHEN CHARINDEX('AttachmentBefore', FileName) > 0 THEN 'AttachmentBefore'          
        WHEN CHARINDEX('AttachmentAfter', FileName) > 0 THEN 'AttachmentAfter'          
        WHEN CHARINDEX('RootProblemAttachment', FileName) > 0 THEN 'RootProblemAttachment'          
        WHEN CHARINDEX('AdditionalAttachment', FileName) > 0 THEN 'AdditionalAttachment'          
        ELSE 'Unknown'          
    END AS AttachmentType          
FROM Attachments          
WHERE KaizenID=@guid          
End 


GO

/****** Object:  StoredProcedure [dbo].[Sp_Fetch_Kaizens_For_Approval]    Script Date: 06-09-2024 16:56:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Sp_Fetch_Kaizens_For_Approval]        
AS        
BEGIN        
SELECT distinct U.Email as ApproverEmail,U.FirstName as ApproverName,Kaizens.DocNo,Kaizens.DRIApprovedDate       
INTO #EmailTable FROM Kaizens INNER JOIN Users U        
ON U.id = Kaizens.DRIApprovedBy WHERE DRIApprovedDate <= CAST(GETDATE() AS DATE) and ApprovalStatus in(2,15);       
WITH cteEmailsend AS      
(      
SELECT  ApproverEmail,ApproverName, DocNo = STRING_AGG(DocNo,', ') FROM #EmailTable      
GROUP BY ApproverEmail,ApproverName)      
      
    SELECT ApproverEmail,ApproverName, DocNo      
    FROM cteEmailsend      
    GROUP BY ApproverEmail,ApproverName,DocNo;      
      
      
END        

GO

/****** Object:  StoredProcedure [dbo].[Sp_Fetch_KaizenUpdateDetails_ById]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
      
      
--exec Sp_Fetch_KaizenUpdateDetails_ById '82'      
Create proc [dbo].[Sp_Fetch_KaizenUpdateDetails_ById]      
@KaizenId Varchar(20)      
as      
Begin      
 declare @guid uniqueidentifier      
     
  Select @guid=Id from Kaizens where KaizenId=@KaizenId      
  Select us.ID as EmpId,TeamMemberName as TeamName,FunctionName       
  from KaizenTeamMembers kt      
  left join Users us on us.Id=kt.EmpId      
  where KaizenId=@guid      
      
End 
GO
/****** Object:  StoredProcedure [dbo].[Sp_FetchAndUpdateDetails]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Sp_FetchAndUpdateDetails] 
	
@EmployeeID NVARCHAR(50),  
@FirstName NVARCHAR(300),  
@MiddleName NVARCHAR(300),
@LastName NVARCHAR(300),
@Email NVARCHAR(200),  
@PhoneNo NVARCHAR(200),  
@Status INT,  
@ImageApprover BIT NULL,  
@Cid INT,  
@Rid INT,  
@Did INT,  
@Deptid NVARCHAR(20),  
@Password NVARCHAR(200),  
@gender NVARCHAR(20),  
@result BIT Out
AS
BEGIN
	
	SET NOCOUNT ON;
	DECLARE @CurrentEmployeeID NVARCHAR(8);
    DECLARE @CurrentFirstName NVARCHAR(50);
	DECLARE @CurrentMiddleName NVARCHAR(50);
	DECLARE @CurrentLastName NVARCHAR(50);
	DECLARE @CurrentEmail NVARCHAR(100);
	DECLARE @CurrentPhoneNo NVARCHAR(50);
	DECLARE @CurrentStatus NVARCHAR(50);
	DECLARE @CurrentImageApprover BIT;
	DECLARE @CurrentCid NVARCHAR(50);
	DECLARE @CurrentRid NVARCHAR(50);
	DECLARE @CurrentDid NVARCHAR(50);
	DECLARE @CurrentDeptid INT;
	DECLARE @CurrentPassword NVARCHAR(50);
	DECLARE @CurrentGender NVARCHAR(50);
	DECLARE @Currentresult BIT;
    
	 -- Fetch current data
    SELECT
	@CurrentEmployeeID = EmpID, 
    @CurrentFirstName = FirstName, 
	@CurrentMiddleName = MiddleName,
	@CurrentLastName = LastName,
    @CurrentEmail = Email,
	@CurrentPhoneNo = MobileNumber,
	@CurrentStatus = Status,
	@CurrentImageApprover = ImageApprover,
	@CurrentCid = @Cid,
	@CurrentRid = @Rid,
	@CurrentDid = @Did,
	@CurrentDeptid = (SELECT Deptid FROM DEPARTMENTS as Dept INNER JOIN DOMAINS as Dom on Dept.ID = Dom.ID),
	@CurrentPassword = @Password,
	@CurrentGender = @gender
	FROM Users
    WHERE @CurrentEmployeeID = @EmployeeID; 

	SET @result = ( SELECT COUNT(*) FROM [dbo].[USERS] WHERE EMPID = @EmployeeID)  
  
IF (@result = 1)   
 UPDATE [dbo].[USERS]  
 SET    UserID = @EmployeeID,  
 FirstName = CASE WHEN @FirstName IS NOT NULL AND @FirstName <> FirstName THEN @FirstName ELSE FirstName END,
 MiddleName = CASE WHEN @MiddleName IS NOT NULL AND @MiddleName <> MiddleName THEN @MiddleName ELSE MiddleName END,
 LastName = CASE WHEN @LastName IS NOT NULL AND @LastName <> FirstName THEN @LastName ELSE FirstName END,
 Email = CASE WHEN @Email IS NOT NULL AND @Email <> Email THEN @Email ELSE Email END,   
 MobileNumber = CASE WHEN @PhoneNo IS NOT NULL AND @PhoneNo <> MobileNumber THEN @PhoneNo ELSE MobileNumber END,  
 [Password] = CASE WHEN @Password IS NOT NULL AND @Password <> [Password] THEN @Password ELSE [Password] END,  
 Gender = CASE WHEN @gender IS NOT NULL AND @gender <> Gender THEN @gender ELSE Gender END,  
 [Status] = CASE WHEN @Status IS NOT NULL AND @Status <> [Status] THEN @Status ELSE [Status] END,   
 ImageApprover = CASE WHEN @ImageApprover IS NOT NULL AND @ImageApprover <> ImageApprover THEN @ImageApprover ELSE ImageApprover END,  
  
 Domain = (SELECT ID FROM [dbo].[Domains] WHERE DomainID = @Did),   
 Department = (SELECT ID FROM [dbo].[Departments] WHERE DeptId = @Deptid),   
 UserType = (SELECT ID FROM [dbo].[USERTYPE] WHERE UserTypeId = @Rid),   
 Cadre = (SELECT ID FROM [dbo].[Cadre] WHERE CadreId = @Cid)  
  
   WHERE EmpID = @EmployeeID; 
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_FetchEmail]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sp_FetchEmail]
    @Id INT
AS
BEGIN
    SELECT Email 
    FROM Users 
    WHERE EmpID = @Id;
END
GO

/****** Object:  StoredProcedure [dbo].[Sp_Get_AllDashboardReports]    Script Date: 10-09-2024 14:58:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Sp_Get_AllDashboardReports]
    @StartDate DATE = NULL,
    @EndDate DATE = NULL,
    @Domain NVARCHAR(MAX) = NULL
AS
BEGIN
    -- Handle NULL parameters
    SET @StartDate = NULLIF(@StartDate, '')
    SET @EndDate = NULLIF(@EndDate, '')
    SET @Domain = NULLIF(@Domain, '')

    DECLARE @DomainID NVARCHAR(MAX);
    IF @Domain IS NOT NULL
    BEGIN
        SELECT @DomainID = ID FROM Domains WHERE DomainName = @Domain;
    END

    -- Kaizen Details by Department
    SELECT 
        d.DepartmentName, 
        d.DeptId,
        kd.KaizenId,
        kd.KaizenType,
        kd.Activity,
        kd.ActivityDesc,
        kd.BenefitArea,
        kd.DocNo,
        kd.CostCentre,
        kd.BlockDetails,
        kd.SuggestedKaizen,
        kd.ProblemStatement,
        kd.CounterMeasure,
        kd.Yield,
        kd.CycleTime,
        kd.Cost,
        kd.ManPower,
        kd.Consumables,
        kd.others, 
        kd.TotalSavings,
        kd.RootCause,
        kd.PresentCondition,
        kd.ImprovementsCompleted,
        kd.RootCauseDetails,
        kd.InOtherMC,
        kd.WithIntheDept,
        kd.InOtherDept,
        kd.OtherPoints,
        kd.Benifits,
        kd.KaizenTheme,
        kd.CreatedDate,
        u.FirstName AS CreatedBy,
        aps.StatusDescription AS ApprovalStatus,
        dom.DomainName AS Domain,
        b.BlockName AS Block,
        c.CadreDesc AS Cadre,
        u1.FirstName AS DriName,
        u2.FirstName AS IEApprovedBy,
        u3.FirstName AS FinanceApprovedBy
    FROM 
        Departments d 
    LEFT JOIN 
        Kaizens kd ON kd.Department = d.ID
    LEFT JOIN 
        Users u ON u.ID = kd.CreatedBy
    LEFT JOIN 
        Users u1 ON u1.ID = kd.DRIApprovedBy
    LEFT JOIN 
        Users u2 ON u2.ID = kd.ApprovedByIE
    LEFT JOIN 
        Users u3 ON u3.ID = kd.FinanceApprovedBy
    LEFT JOIN 
        ApprovalStatus aps ON aps.StatusID = kd.ApprovalStatus
    LEFT JOIN 
        Domains dom ON dom.ID = kd.Domain
    LEFT JOIN 
        Blocks b ON b.ID = kd.Block
    LEFT JOIN 
        Cadre c ON c.ID = u.Cadre
    WHERE 
        d.Status = '1'
        AND kd.ApprovalStatus NOT IN (0, 14)
        AND (@StartDate IS NULL OR kd.CreatedDate >= @StartDate)
        AND (@EndDate IS NULL OR kd.CreatedDate <= @EndDate)
        AND (@DomainID IS NULL OR kd.Domain = @DomainID)
    ORDER BY 
        d.DeptId, kd.KaizenId;

    -- Kaizen Details by Domain
    SELECT 
        dom.DomainName, 
        dom.DomainID,
        kd.KaizenId,
        kd.KaizenType,
        kd.Activity,
        kd.ActivityDesc,
        kd.BenefitArea,
        kd.DocNo,
        kd.CostCentre,
        kd.BlockDetails,
        kd.SuggestedKaizen,
        kd.ProblemStatement,
        kd.CounterMeasure,
        kd.Yield,
        kd.CycleTime,
        kd.Cost,
        kd.ManPower,
        kd.Consumables,
        kd.others,
        kd.TotalSavings,
        kd.RootCause,
        kd.PresentCondition,
        kd.ImprovementsCompleted,
        kd.RootCauseDetails,
        kd.InOtherMC,
        kd.WithIntheDept,
        kd.InOtherDept,
        kd.OtherPoints,
        kd.Benifits,
        kd.KaizenTheme,
        kd.CreatedDate,
        u.FirstName AS CreatedBy,
        aps.StatusDescription AS ApprovalStatus,
        b.BlockName AS Block,
        d1.DepartmentName AS Department,
        c.CadreDesc AS Cadre,
        u1.FirstName AS DriName,
        u2.FirstName AS IEApprovedBy,
        u3.FirstName AS FinanceApprovedBy
    FROM 
        Domains dom
    LEFT JOIN 
        Kaizens kd ON dom.ID = kd.Domain
    LEFT JOIN 
        Departments d1 ON d1.ID = kd.Department
    LEFT JOIN 
        Users u ON u.ID = kd.CreatedBy
    LEFT JOIN 
        Users u1 ON u1.ID = kd.DRIApprovedBy
    LEFT JOIN 
        Users u2 ON u2.ID = kd.ApprovedByIE
    LEFT JOIN 
        Users u3 ON u3.ID = kd.FinanceApprovedBy
    LEFT JOIN 
        ApprovalStatus aps ON aps.StatusID = kd.ApprovalStatus
    LEFT JOIN 
        Blocks b ON b.ID = kd.Block
    LEFT JOIN 
        Cadre c ON c.ID = u.Cadre
    WHERE 
        dom.Status = '1'
        AND kd.ApprovalStatus NOT IN (0, 14)
        AND (@StartDate IS NULL OR kd.CreatedDate >= @StartDate)
        AND (@EndDate IS NULL OR kd.CreatedDate <= @EndDate)
    ORDER BY
        dom.DomainID, kd.KaizenId;

    -- Kaizen Details by Block
    SELECT 
        b.BlockName,
        b.BlockId,
        kd.KaizenId,
        kd.KaizenType,
        kd.Activity,
        kd.ActivityDesc,
        kd.BenefitArea,
        kd.DocNo,
        kd.CostCentre,
        kd.BlockDetails,
        kd.SuggestedKaizen,
        kd.ProblemStatement,
        kd.CounterMeasure,
        kd.Yield,
        kd.CycleTime,
        kd.Cost,
        kd.ManPower,
        kd.Consumables,
        kd.others,
        kd.TotalSavings,
        kd.RootCause,
        kd.PresentCondition,
        kd.ImprovementsCompleted,
        kd.RootCauseDetails,
        kd.InOtherMC,
        kd.WithIntheDept,
        kd.InOtherDept,
        kd.OtherPoints,
        kd.Benifits,
        kd.KaizenTheme,
        kd.CreatedDate,
        u.FirstName AS CreatedBy,
        aps.StatusDescription AS ApprovalStatus,
        dom.DomainName AS Domain,
        d1.DepartmentName AS Department,
        c.CadreDesc AS Cadre,
        u1.FirstName AS DriName,
        u2.FirstName AS IEApprovedBy,
        u3.FirstName AS FinanceApprovedBy
    FROM 
        Blocks b
    LEFT JOIN 
        Kaizens kd ON b.ID = kd.Block
    LEFT JOIN 
        Users u ON u.ID = kd.CreatedBy
    LEFT JOIN 
        Users u1 ON u1.ID = kd.DRIApprovedBy
    LEFT JOIN 
        Users u2 ON u2.ID = kd.ApprovedByIE
    LEFT JOIN 
        Users u3 ON u3.ID = kd.FinanceApprovedBy
    LEFT JOIN 
        Departments d1 ON d1.ID = kd.Department
    LEFT JOIN 
        ApprovalStatus aps ON aps.StatusID = kd.ApprovalStatus
    LEFT JOIN 
        Domains dom ON dom.ID = kd.Domain
    LEFT JOIN 
        Cadre c ON c.ID = u.Cadre
    WHERE 
        b.Status = '1'
        AND kd.ApprovalStatus NOT IN (0, 14)
        AND (@StartDate IS NULL OR kd.CreatedDate >= @StartDate)
        AND (@EndDate IS NULL OR kd.CreatedDate <= @EndDate)
    ORDER BY
        b.BlockId, kd.KaizenId;

    -- Kaizen Details by Cadre
    SELECT 
        c.CadreId,
        c.CadreDesc,
        kd.KaizenId,
        kd.KaizenType,
        kd.Activity,
        kd.ActivityDesc,
        kd.BenefitArea,
        kd.DocNo,
        kd.VersionNoDate,
        kd.CostCentre,
        kd.KaizenRefNo,
        kd.BlockDetails,
        kd.SuggestedKaizen,
        kd.ProblemStatement,
        kd.CounterMeasure,
        kd.Yield,
        kd.CycleTime,
        kd.Cost,
        kd.ManPower,
        kd.Consumables,
        kd.others,
        kd.TotalSavings,
        kd.RootCause,
        kd.PresentCondition,
        kd.ImprovementsCompleted,
        kd.RootCauseDetails,
        kd.InOtherMC,
        kd.WithIntheDept,
        kd.InOtherDept,
        kd.OtherPoints,
        kd.Benifits,
        kd.KaizenTheme,
        kd.ModifiedDate,
        kd.CreatedDate,
        u.FirstName AS CreatedBy,
        aps.StatusDescription AS ApprovalStatus,
        dom.DomainName AS Domain,
        b.BlockName AS Block,
        d.DepartmentName AS Department,
        u1.FirstName AS DriName,
        u2.FirstName AS IEApprovedBy,
        u3.FirstName AS FinanceApprovedBy
    FROM 
        Cadre c 
    LEFT JOIN 
        Users u ON c.ID = u.Cadre 
    LEFT JOIN 
        Kaizens kd ON u.ID = kd.CreatedBy
    LEFT JOIN 
        ApprovalStatus aps ON aps.StatusID = kd.ApprovalStatus
    LEFT JOIN 
        Departments d ON kd.Department = d.ID
    LEFT JOIN 
        Domains dom ON kd.Domain = dom.ID
    LEFT JOIN 
        Blocks b ON kd.Block = b.ID
    LEFT JOIN 
        Users u1 ON u1.ID = kd.DRIApprovedBy
    LEFT JOIN 
        Users u2 ON u2.ID = kd.ApprovedByIE
    LEFT JOIN 
        Users u3 ON u3.ID = kd.FinanceApprovedBy
    WHERE 
        kd.ApprovalStatus NOT IN (0, 14)
        AND (@StartDate IS NULL OR kd.CreatedDate >= @StartDate)
        AND (@EndDate IS NULL OR kd.CreatedDate <= @EndDate)
    ORDER BY
        c.CadreId, kd.KaizenId;
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_Get_Approval_Status]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE Proc [dbo].[Sp_Get_Approval_Status]
@UserType Nvarchar(20)
as
Begin
if @UserType='EMP'
Select StatusID,CASE 
                WHEN ApprovalStatus.StatusID=0 THEN 'Saved'
				WHEN ApprovalStatus.StatusID=1 THEN 'Waiting For Image Approval'
				WHEN ApprovalStatus.StatusID=2 THEN 'Waiting For DRI Approval'
				WHEN ApprovalStatus.StatusID=3 THEN 'Image Rejected'
				WHEN ApprovalStatus.StatusID=4 THEN 'Waiting For IE Approval'
				WHEN ApprovalStatus.StatusID=5 THEN 'DRI Rejected'
				WHEN ApprovalStatus.StatusID=6 THEN 'Waiting For Finnance Approval'
				WHEN ApprovalStatus.StatusID=7 THEN 'IE Rejected'
				--WHEN ApprovalStatus.StatusID=8 THEN 'Finance Approved'
				WHEN ApprovalStatus.StatusID=9 THEN 'Finance Rejected'
				WHEN ApprovalStatus.StatusID=16 THEN 'Approved Kaizen'
            END AS StatusDescription
			from [dbo].ApprovalStatus 
			where StatusID not in (8,11,12,13,14,15)
			order by StatusID 
else
Select StatusID,CASE 
                WHEN ApprovalStatus.StatusID=0 THEN 'Saved'
				WHEN ApprovalStatus.StatusID=1 THEN 'Waiting For Image Approval'
				WHEN ApprovalStatus.StatusID=2 THEN 'Waiting For DRI Approval'
				WHEN ApprovalStatus.StatusID=3 THEN 'Image Rejected'
				WHEN ApprovalStatus.StatusID=4 THEN 'Waiting For IE Approval'
				WHEN ApprovalStatus.StatusID=5 THEN 'DRI Rejected'
				WHEN ApprovalStatus.StatusID=6 THEN 'Waiting For Finnance Approval'
				WHEN ApprovalStatus.StatusID=7 THEN 'IE Rejected'
				--WHEN ApprovalStatus.StatusID=8 THEN 'Finance Approved'
				WHEN ApprovalStatus.StatusID=9 THEN 'Finance Rejected'
				WHEN ApprovalStatus.StatusID=16 THEN 'Approved Kaizen'
            END AS StatusDescription
			from [dbo].ApprovalStatus 
			where StatusID not in (8,0,11,12,13,14,15)
			order by StatusID 
end

GO
/****** Object:  StoredProcedure [dbo].[Sp_Get_BlockDetails]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
CREATE PROCEDURE [dbo].[Sp_Get_BlockDetails]  
AS  
BEGIN  
    SELECT 
        b.BlockId,
        b.BlockName,
        COUNT(u.EmpID) AS User_count,  -- Count of users for each block
        b.Status
    FROM 
        Blocks b
    LEFT JOIN  
        Users u 
    ON  
        b.ID = u.Block  -- Join on uniqueidentifier to int
    GROUP BY 
        b.BlockId, 
        b.BlockName, 
        b.Status
    ORDER BY  
        b.BlockId;
END


  SELECT 
        b.BlockId,
        b.BlockName,
        COUNT(distinct u.EmpID) AS User_count,  -- Count of users for each block
        b.Status
    FROM 
        Blocks b
    LEFT JOIN  
        Users u 
    ON  
        b.ID = u.Block  -- Join on uniqueidentifier to int
    GROUP BY 
        b.BlockId, 
        b.BlockName, 
        b.Status
    ORDER BY  
        b.BlockId;

	
GO
/****** Object:  StoredProcedure [dbo].[Sp_Get_BlockformReport]    Script Date: 11-09-2024 10:44:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE Proc [dbo].[Sp_Get_BlockformReport]  
@startdate datetime = NULL,  
@enddate datetime = NULL  
as  
BEGIN  
-- Handle NULL parameters  
    SET @startdate = NULLIF(@startdate, '')  
    SET @enddate = NULLIF(@enddate, '')  
    IF @startdate IS NULL AND @enddate IS NULL  
    BEGIN  
        SELECT b.ID,b.BlockId,b.BlockName,b.Status,u.FirstName,b.CreatedDate FROM [dbo].[Blocks] as b 
		INNER JOIN [dbo].[Users] AS u ON b.CreatedBy = u.ID;  
    END  
    ELSE IF @startdate IS NOT NULL AND @enddate IS NULL  
    BEGIN  
        SELECT b.ID,b.BlockId,b.BlockName,b.Status,u.FirstName,b.CreatedDate FROM [dbo].[Blocks] as b 
		INNER JOIN [dbo].[Users] AS u ON b.CreatedBy = u.ID
		WHERE b.CreatedDate >= @startdate;  
    END  
    ELSE IF @startdate IS NULL AND @enddate IS NOT NULL  
    BEGIN  
        SELECT b.ID,b.BlockId,b.BlockName,b.Status,u.FirstName,b.CreatedDate FROM [dbo].[Blocks] as b 
		INNER JOIN [dbo].[Users] AS u ON b.CreatedBy = u.ID
		WHERE b.CreatedDate <= DATEADD(DAY, 1, @enddate);  
    END  
      
    ELSE  
Begin  
SELECT b.ID,b.BlockId,b.BlockName,b.Status,u.FirstName,b.CreatedDate FROM [dbo].[Blocks] as b 
		INNER JOIN [dbo].[Users] AS u ON b.CreatedBy = u.ID
		WHERE b.CreatedDate >= @startdate AND b.CreatedDate <= DATEADD(DAY, 1, @enddate);  
END  
END  

GO
/****** Object:  StoredProcedure [dbo].[Sp_Get_Cadre]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Proc [dbo].[Sp_Get_Cadre]
as
Begin
Select CadreId,cadreDesc from [dbo].[Cadre]  
end 
GO
/****** Object:  StoredProcedure [dbo].[Sp_Get_DashboardDepartmentgraph]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Sp_Get_DashboardDepartmentgraph]
    @StartDate DATE = NULL,
    @EndDate DATE = NULL,
    @Domainname NVARCHAR(MAX) = NULL
AS
BEGIN
    -- Handle NULL parameters by replacing empty strings with NULL
    SET @StartDate = NULLIF(@StartDate, '')
    SET @EndDate = NULLIF(@EndDate, '')

    -- Main query to get department data and Kaizen counts based on the domain
    SELECT 
        d.DepartmentName, 
        d.DeptId,
        COUNT(DISTINCT CASE WHEN kd.ApprovalStatus NOT IN (0, 14) THEN kd.KaizenId END) AS AllKaizen_count,
        dom.DomainName
    FROM 
        Departments d
    INNER JOIN 
        Domains dom ON d.DomainId = dom.ID
    LEFT JOIN 
        Kaizens kd ON kd.Department = d.ID
        AND (@StartDate IS NULL OR kd.CreatedDate >= @StartDate)
        AND (@EndDate IS NULL OR kd.CreatedDate <= @EndDate)
    WHERE 
        d.Status = '1' 
        AND (@Domainname IS NULL OR dom.DomainName = @Domainname)
    GROUP BY 
        d.DepartmentName, 
        d.DeptId,
        dom.DomainName
    ORDER BY 
        d.DeptId;
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_Get_DashboardDepartments]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sp_Get_DashboardDepartments]
    @StartDate DATE = NULL,
    @EndDate DATE = NULL
AS
BEGIN
    -- Handle NULL parameters
    SET @StartDate = NULLIF(@StartDate, '')
    SET @EndDate = NULLIF(@EndDate, '')

    -- Main query to get all required counts with filtering
    SELECT 
        d.DepartmentName, 
        d.DeptId, 
        COUNT(DISTINCT u.EmpId) AS user_count, 
        DM.DomainId, 
        DM.DomainName, 
        COUNT(DISTINCT CASE WHEN kd.ApprovalStatus NOT IN (0, 14) THEN kd.KaizenId END) AS kaizen_count,
        COUNT(DISTINCT CASE WHEN kd.ApprovalStatus NOT IN (0, 14) THEN kd.CreatedBy END) AS KaizenSubmittedUserdept,
		  
        d.[Status]
    FROM 
        Departments d 
    LEFT JOIN 
        Users u 
    ON 
        d.ID = u.Department 
    INNER JOIN 
        Domains DM 
    ON 
        DM.ID = d.DomainId
    LEFT JOIN 
        Kaizens kd
    ON 
        kd.Department = d.ID
        AND (@StartDate IS NULL OR kd.CreatedDate >= @StartDate)
        AND (@EndDate IS NULL OR kd.CreatedDate <= @EndDate) 
		 WHERE 
        d.Status = '1'
    GROUP BY 
        d.DepartmentName, 
        d.DeptId, 
        DM.DomainId, 
        DM.DomainName, 
        d.[Status]
    ORDER BY 
        d.DeptId;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Get_DashboardDomains]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Get_DashboardDomains]
    @StartDate DATE = NULL,
    @EndDate DATE = NULL
AS
BEGIN
    -- Handle NULL parameters
    SET @StartDate = NULLIF(@StartDate, '')
    SET @EndDate = NULLIF(@EndDate, '')

    -- Main query to get all required counts with filtering
    SELECT 
        d.ID,
        d.DomainID,
        d.DomainName,
        COUNT(DISTINCT u.EmpId) AS user_count,
        COUNT(CASE WHEN u.Id = kd.CreatedBy AND kd.ApprovalStatus NOT IN (0, 14) THEN kd.KaizenId END) AS AllKaizen_count,
        COUNT(DISTINCT kd.KaizenId) AS kaizen_count,
		   (SELECT COUNT(DISTINCT CASE WHEN ApprovalStatus NOT IN (0, 14) THEN CreatedBy END)
         FROM Kaizens
         WHERE Domain = d.ID
           AND (@StartDate IS NULL OR CreatedDate >= @StartDate)
           AND (@EndDate IS NULL OR CreatedDate <= @EndDate)) AS kaizensubmittedUser,
        d.Status
    FROM 
        Domains d
    LEFT JOIN  
        Users u 
    ON  
        d.ID = u.Domain
    LEFT JOIN 
        Kaizens kd
    ON 
        d.ID = kd.Domain
        AND (@StartDate IS NULL OR kd.CreatedDate >= @StartDate)
        AND (@EndDate IS NULL OR kd.CreatedDate <= @EndDate)
		 WHERE 
        d.Status = '1'
    GROUP BY 
        d.DomainName, d.ID, d.DomainID, d.Status;
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_Get_Dashboardgraphs]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sp_Get_Dashboardgraphs]
    @StartDate DATE = NULL,
    @EndDate DATE = NULL
	AS
BEGIN
    -- Handle NULL parameters
    SET @StartDate = NULLIF(@StartDate, '')
    SET @EndDate = NULLIF(@EndDate, '')

	 SELECT 
	   d.DepartmentName, 
	   d.DeptId,
	     COUNT(DISTINCT CASE WHEN kd.ApprovalStatus NOT IN (0, 14) THEN kd.KaizenId END) AS AllKaizen_count
		  FROM 
     Departments d 
    LEFT JOIN 
	Kaizens kd
    ON 
        kd.Department = d.ID
        AND (@StartDate IS NULL OR kd.CreatedDate >= @StartDate)
        AND (@EndDate IS NULL OR kd.CreatedDate <= @EndDate)
			 WHERE 
        d.Status = '1'

		  GROUP BY 
		    d.DepartmentName, 
			  d.DeptId
			   ORDER BY 
        d.DeptId;



     SELECT                 
        d.DomainName, 
		d.DomainID,
        COUNT(CASE WHEN kd.ApprovalStatus NOT IN (0, 14) THEN kd.KaizenId END) AS AllKaizen_count
    FROM 
        Domains d
    LEFT JOIN 
        Kaizens kd
    ON 
        d.ID = kd.Domain
        AND (@StartDate IS NULL OR kd.CreatedDate >= @StartDate)
        AND (@EndDate IS NULL OR kd.CreatedDate <= @EndDate) 
			 WHERE 
        d.Status = '1'
    GROUP BY 
        d.DomainName, d.DomainID
		ORDER BY
		d.DomainID;

	SELECT 
	  b.BlockName,
	  b.BlockId,
	    COUNT(CASE WHEN kd.ApprovalStatus NOT IN (0, 14) THEN kd.KaizenId END) AS AllKaizen_count

	 from 
	  Blocks b
	    LEFT JOIN 
        Kaizens kd
    ON 
        b.ID = kd.Block
        AND (@StartDate IS NULL OR kd.CreatedDate >= @StartDate)
        AND (@EndDate IS NULL OR kd.CreatedDate <= @EndDate)
			 WHERE 
        b.Status = '1'
    GROUP BY 
        b.BlockName,b.BlockId
		ORDER BY
		b.BlockId;

		SELECT 
    Cadre.CadreId,
    Cadre.CadreDesc,
    COUNT(CASE WHEN kd.ApprovalStatus NOT IN (0, 14) THEN kd.KaizenId END) AS AllKaizen_count
FROM 
    Cadre
    LEFT JOIN Users ON Cadre.Id = Users.Cadre
    LEFT JOIN Kaizens kd ON Users.id = kd.createdby
WHERE 
    (@StartDate IS NULL OR kd.CreatedDate >= @StartDate)
    AND (@EndDate IS NULL OR kd.CreatedDate <= @EndDate)
GROUP BY 
    Cadre.CadreId,
    Cadre.CadreDesc
ORDER BY
    Cadre.CadreId;


END
GO
/****** Object:  StoredProcedure [dbo].[Sp_Get_DashboardManagerDomainDepartment]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sp_Get_DashboardManagerDomainDepartment]
  @EmpId Varchar(20),
  @StartDate DATE = NULL,
  @EndDate DATE = NULL
AS
BEGIN
    -- Handle NULL parameters
    SET @StartDate = NULLIF(@StartDate, '')
    SET @EndDate = NULLIF(@EndDate, '')

    -- Count by Department
    SELECT 
        d.DepartmentName, 
        d.DeptId, 
        COUNT(DISTINCT u.EmpId) AS user_count, 
        CASE 
            WHEN d.Status = 1 
                 AND u.EmpID = @EmpId
            THEN COUNT(DISTINCT CASE 
                    WHEN kd.ApprovalStatus NOT IN (0, 14)
                         AND (@StartDate IS NULL OR kd.CreatedDate >= @StartDate)
                         AND (@EndDate IS NULL OR kd.CreatedDate <= @EndDate)
                    THEN kd.KaizenId 
                END)
            ELSE NULL
        END AS kaizen_count,
        CASE 
            WHEN d.Status = 1 
                 AND u.EmpID = @EmpId
            THEN COUNT(DISTINCT CASE 
                    WHEN kd.ApprovalStatus NOT IN (0, 14)
                         AND (@StartDate IS NULL OR kd.CreatedDate >= @StartDate)
                         AND (@EndDate IS NULL OR kd.CreatedDate <= @EndDate)
                    THEN kd.CreatedBy 
                END)
            ELSE NULL
        END AS KaizenSubmittedUserCount,
        d.[Status]
    FROM 
        Departments d 
    LEFT JOIN 
        Users u ON d.ID = u.Department 
    LEFT JOIN 
        Kaizens kd ON kd.Department = d.ID
    WHERE 
        d.Status = 1 
        AND u.EmpID = @EmpId
    GROUP BY 
        d.DepartmentName, 
        d.DeptId, 
        d.[Status],
        u.EmpID
    ORDER BY 
        d.DeptId;

    -- Count by Domain
    SELECT 
        d.DomainId, 
        d.DomainName, 
        COUNT(DISTINCT u.EmpId) AS user_count, 
        CASE 
            WHEN d.Status = 1 
                 AND u.EmpID = @EmpId
            THEN COUNT(DISTINCT CASE 
                    WHEN kd.ApprovalStatus NOT IN (0, 14)
                         AND (@StartDate IS NULL OR kd.CreatedDate >= @StartDate)
                         AND (@EndDate IS NULL OR kd.CreatedDate <= @EndDate)
                    THEN kd.KaizenId 
                END)
            ELSE NULL
        END AS kaizen_count,
        CASE 
            WHEN d.Status = 1 
                 AND u.EmpID = @EmpId
            THEN COUNT(DISTINCT CASE 
                    WHEN kd.ApprovalStatus NOT IN (0, 14)
                         AND (@StartDate IS NULL OR kd.CreatedDate >= @StartDate)
                         AND (@EndDate IS NULL OR kd.CreatedDate <= @EndDate)
                    THEN kd.CreatedBy 
                END)
            ELSE NULL
        END AS KaizenSubmittedUserCount,
        d.[Status]
    FROM 
        Domains d
    LEFT JOIN 
        Users u ON d.ID = u.Domain 
    LEFT JOIN 
        Kaizens kd ON kd.Domain = d.ID
    WHERE 
        d.Status = 1 
        AND u.EmpID = @EmpId
    GROUP BY 
        d.DomainId, 
        d.DomainName,
        u.EmpID,
        d.[Status]
    ORDER BY 
        d.DomainId;
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_Get_DepartmentformReport]    Script Date: 11-09-2024 10:47:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE Proc [dbo].[Sp_Get_DepartmentformReport]  
@startdate datetime = NULL,  
@enddate datetime = NULL  
as  
BEGIN  
-- Handle NULL parameters  
    SET @startdate = NULLIF(@startdate, '')  
    SET @enddate = NULLIF(@enddate, '')  
    IF @startdate IS NULL AND @enddate IS NULL  
    BEGIN  
		SELECT d.ID,d.DeptId,d.DepartmentName,a.DomainName,d.Status,u.FirstName,d.CreatedDate FROM [dbo].[Departments] as d 
		INNER JOIN [dbo].[Users] AS u ON d.CreatedBy = u.ID
		INNER JOIN [dbo].[Domains] AS a ON a.ID = d.DomainId;
    END  
    ELSE IF @startdate IS NOT NULL AND @enddate IS NULL  
    BEGIN  
        SELECT d.ID,d.DeptId,d.DepartmentName,a.DomainName,d.Status,u.FirstName,d.CreatedDate FROM [dbo].[Departments] as d 
		INNER JOIN [dbo].[Users] AS u ON d.CreatedBy = u.ID
		INNER JOIN [dbo].[Domains] AS a ON a.ID = d.DomainId
		WHERE d.CreatedDate >= @startdate;  
    END  
    ELSE IF @startdate IS NULL AND @enddate IS NOT NULL  
    BEGIN  
        SELECT d.ID,d.DeptId,d.DepartmentName,a.DomainName,d.Status,u.FirstName,d.CreatedDate FROM [dbo].[Departments] as d 
		INNER JOIN [dbo].[Users] AS u ON d.CreatedBy = u.ID
		INNER JOIN [dbo].[Domains] AS a ON a.ID = d.DomainId
		WHERE d.CreatedDate <= DATEADD(DAY, 1, @enddate);  
    END  
      
    ELSE  
Begin  
SELECT d.ID,d.DeptId,d.DepartmentName,a.DomainName,d.Status,u.FirstName,d.CreatedDate FROM [dbo].[Departments] as d 
		INNER JOIN [dbo].[Users] AS u ON d.CreatedBy = u.ID
		INNER JOIN [dbo].[Domains] AS a ON a.ID = d.DomainId
		WHERE d.CreatedDate >= @startdate AND d.CreatedDate <= DATEADD(DAY, 1, @enddate);  
END  
END  
GO
/****** Object:  StoredProcedure [dbo].[Sp_Get_Departments]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sp_Get_Departments]
as
begin
--Select DM.DomainId,DM.DomainName, DeptId,DepartmentName,DEPT.[Status] 
--from Departments DEPT
--INNER JOIN [Domains] DM ON DM.ID = DEPT.DomainId
--order by  DeptId

SELECT 
    d.DepartmentName, 
    d.DeptId, 
    COUNT(Distinct u.EmpId) AS user_count, 
    DM.DomainId, 
    DM.DomainName, 
	 COUNT(DISTINCT CASE WHEN kd.ApprovalStatus NOT IN (0, 14) THEN kd.KaizenId END) AS kaizen_count,
	COUNT(Distinct kd.CreatedBy) AS KaizenSubmittedUserdept,
    d.[Status]
FROM 
    Departments d 
LEFT JOIN 
    Users u 
ON 
    d.ID = u.Department 
INNER JOIN 
    Domains DM 
ON 
    DM.ID = d.DomainId
LEFT JOIN 
    Kaizens kd
ON 
    kd.Department = d.ID
GROUP BY 
    d.DepartmentName, 
    d.DeptId, 
    DM.DomainId, 
    DM.DomainName, 
    d.[Status]
ORDER BY 
    d.DeptId;
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_Get_DomainformReport]    Script Date: 11-09-2024 10:46:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE Proc [dbo].[Sp_Get_DomainformReport]  
@startdate datetime = NULL,  
@enddate datetime = NULL  
as  
BEGIN  
-- Handle NULL parameters  
    SET @startdate = NULLIF(@startdate, '')  
    SET @enddate = NULLIF(@enddate, '')  
    IF @startdate IS NULL AND @enddate IS NULL  
    BEGIN  
		SELECT d.ID,d.DomainID,d.DomainName,d.Status,u.FirstName,d.CreatedDate FROM [dbo].[Domains] as d 
		INNER JOIN [dbo].[Users] AS u ON d.CreatedBy = u.ID;
    END  
    ELSE IF @startdate IS NOT NULL AND @enddate IS NULL  
    BEGIN  
        SELECT d.ID,d.DomainID,d.DomainName,d.Status,u.FirstName,d.CreatedDate FROM [dbo].[Domains] as d 
		INNER JOIN [dbo].[Users] AS u ON d.CreatedBy = u.ID
		WHERE d.CreatedDate >= @startdate;  
    END  
    ELSE IF @startdate IS NULL AND @enddate IS NOT NULL  
    BEGIN  
        SELECT d.ID,d.DomainID,d.DomainName,d.Status,u.FirstName,d.CreatedDate FROM [dbo].[Domains] as d 
		INNER JOIN [dbo].[Users] AS u ON d.CreatedBy = u.ID
		WHERE d.CreatedDate <= DATEADD(DAY, 1, @enddate);  
    END  
      
    ELSE  
Begin  
SELECT d.ID,d.DomainID,d.DomainName,d.Status,u.FirstName,d.CreatedDate FROM [dbo].[Domains] as d 
		INNER JOIN [dbo].[Users] AS u ON d.CreatedBy = u.ID
		WHERE d.CreatedDate >= @startdate AND d.CreatedDate <= DATEADD(DAY, 1, @enddate);  
END  
END  
GO
/****** Object:  StoredProcedure [dbo].[sp_Get_Domains]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE Procedure [dbo].[sp_Get_Domains]
AS
BEGIN
	--SELECT ID, DomainID,DomainName,Status, FROM [dbo].[Domains] order by  DomainID
	--SELECT  d.ID,d.DomainID, d.DomainName,COUNT(U.EmpId) AS user_count ,d.Status FROM Domains d LEFT JOIN  Users u ON  d.Id=u.Domain GROUP BY 
 --   d.domainName,d.ID,d.DomainID,d.Status;
    SELECT 
    d.ID,
    d.DomainID,
    d.DomainName,
    COUNT(distinct u.EmpId) AS user_count,
	COUNT(CASE WHEN u.Id = kd.CreatedBy AND kd.ApprovalStatus NOT IN (0, 14) THEN kd.KaizenId END) AS AllKaizen_count,
    COUNT(DISTINCT kd.KaizenId) AS  kaizen_count,
	 (SELECT COUNT(DISTINCT CreatedBy)
         FROM Kaizens
         WHERE Domain = d.ID) AS kaizensubmittedUser,
    d.Status
FROM 
    Domains d
LEFT JOIN  
    Users u 
ON  
    d.ID = u.Domain
LEFT JOIN 
    Kaizens kd
ON 
    d.ID = kd.Domain 
	
GROUP BY 
    d.DomainName, d.ID, d.DomainID, d.Status
	


END 
GO
/****** Object:  StoredProcedure [dbo].[Sp_Get_FinanceDetails]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
      
CREATE Procedure [dbo].[Sp_Get_FinanceDetails]      
as      
Begin      
SELECT EmpID,Email,Status FROM [dbo].[Users] where UserType = (SELECT ID FROM UserType WHERE UserCode='FIN')
end   
  
  
GO
/****** Object:  StoredProcedure [dbo].[Sp_Get_IEDeptDetails]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
    
CREATE Procedure [dbo].[Sp_Get_IEDeptDetails]    
as    
Begin    
SELECT EmpID,Email,Status FROM [dbo].[Users] where UserType =(SELECT ID from UserType where UserCode='IED')
end 


GO
/****** Object:  StoredProcedure [dbo].[Sp_Get_Kaizen_Details]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[Sp_Get_Kaizen_Details]    Script Date: 11-09-2024 11:04:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



--exec Sp_Get_Kaizen_Details '','','','','','','','EMPLOYEE','6fcd60ce-2566-4517-83dd-020b9279a5c8'
CREATE PROCEDURE [dbo].[Sp_Get_Kaizen_Details]
(
    @StartDate DATE = NULL,
    @EndDate DATE = NULL,
    @Domain NVARCHAR(100) = NULL,
    @Department NVARCHAR(100) = NULL,
    @KaizenTheme NVARCHAR(100) = NULL,
    @Status NVARCHAR(50) = NULL,
    @Shortlisted NVARCHAR(50) = NULL,
    @Role NVARCHAR(50) = NULL,
    @UserId NVARCHAR(50) = NULL,
	@BenefitArea NVARCHAR(50) = NULL
)
AS
BEGIN
    SET @StartDate = NULLIF(@StartDate, '')
    SET @EndDate = NULLIF(@EndDate, '')
    SET @Domain = NULLIF(@Domain, '')
    SET @Department = NULLIF(@Department, '')
    SET @KaizenTheme = NULLIF(@KaizenTheme, '')
    SET @Status = NULLIF(@Status, '')
    SET @Shortlisted = NULLIF(@Shortlisted, '')
	SET @BenefitArea = NULLIF(@BenefitArea, '')

    DECLARE @FirstName NVARCHAR(50)
	DECLARE @ImageApprover NVARCHAR(50)
    SELECT @FirstName = FirstName FROM Users WHERE id = @UserId
	set @ImageApprover=@Role

    IF @StartDate IS NULL AND @EndDate IS NULL AND @Domain IS NULL AND @Department IS NULL AND @KaizenTheme IS NULL AND @Status IS NULL AND @Shortlisted IS NULL AND @BenefitArea IS NULL
    BEGIN
        SELECT DISTINCT Kaizens.KaizenId, KaizenType, Activity, ActivityDesc, Kaizens.[BenefitArea], DocNo, VersionNoDate, CostCentre, KaizenRefNo,
                        Blocks.BlockName AS Block, BlockDetails, SuggestedKaizen, ProblemStatement, CounterMeasure, AttachmentBefore, AttachmentAfter, AttachmentOthers, Yield, CycleTime, Cost, ManPower, Consumables, others, TotalSavings, Kaizens.TeamMemberID, RootCause, PresentCondition, ImprovementsCompleted, RootProblemAttachment, RootCauseDetails, ScopeOfDeploymentId, InOtherMC, WithIntheDept, InOtherDept, OtherPoints, Benifits, OrigionatedDept, OrigonatedDate,
                        KaizenTheme, Kaizens.ApprovalStatus AS Status, Kaizens.CreatedBy AS PostedBy, Kaizens.ModifiedDate,
                        STUFF((SELECT ', ' + TeamMemberName
                               FROM KaizenTeamMembers
                               WHERE KaizenID = Kaizens.ID
                               FOR XML PATH('')), 1, 2, '') AS TeamName,
                        CASE 
                            WHEN HorozantalDeployment = 0 THEN 'NO' 
                            WHEN HorozantalDeployment = 1 THEN 'YES'
                        END AS HorozantalDeployment,
                        CASE 
                            WHEN CycleTime > 0 THEN 'YES' 
                            WHEN CycleTime = 0 THEN 'NO'
							WHEN CycleTime is null THEN 'NO'
                        END AS IEApprovedDept, 
                        CASE 
                            WHEN Cost >= 100000 THEN 'YES' 
                            WHEN Cost < 100000 THEN 'NO'
                        END AS FinnanceDeptAppr,
                        CASE 
                            WHEN Shortlisted = 0 THEN 'NO' 
                            WHEN Shortlisted = 1 THEN 'YES'
                        END AS Shortlisted,
                        CASE 
						   
WHEN Kaizens.ApprovalStatus = 8 THEN 'Approved Kaizen'
        WHEN Kaizens.ApprovalStatus = 6 AND Kaizens.FinanceApprovedBy IS NULL THEN 'Approved Kaizen'
        WHEN Kaizens.ApprovalStatus = 4 AND Kaizens.ApprovedByIE IS NULL AND Kaizens.FinanceApprovedBy IS NULL THEN 'Approved Kaizen'
                            WHEN Kaizens.ApprovalStatus = 4 AND Kaizens.ApprovedByIE IS NULL AND Kaizens.FinanceApprovedBy IS NOT NULL THEN 'Waiting For Finnance Approval'
                            WHEN Kaizens.ApprovalStatus = 4 AND Kaizens.ApprovedByIE IS NOT NULL AND Kaizens.FinanceApprovedBy IS NULL THEN 'Waiting For IE Approval'
							WHEN Kaizens.ApprovalStatus = 4 AND Kaizens.ApprovedByIE IS NOT NULL AND Kaizens.FinanceApprovedBy IS NOT NULL THEN 'Waiting For IE Approval'
                            WHEN Kaizens.ApprovalStatus = 0 THEN 'Saved' 
							WHEN Kaizens.ApprovalStatus = 1 THEN 'Waiting For Image Approval' 
                            WHEN Kaizens.ApprovalStatus in (2,15) THEN 'Waiting For DRI Approval'
                            WHEN Kaizens.ApprovalStatus = 3 THEN 'Image Rejected'
                            WHEN Kaizens.ApprovalStatus = 5 THEN 'DRI Rejected'
                            WHEN Kaizens.ApprovalStatus = 6 THEN 'Waiting For Finnance Approval'
                            WHEN Kaizens.ApprovalStatus = 7 THEN 'IE Rejected'
                            --WHEN Kaizens.ApprovalStatus = 8 THEN 'Finance Approved'
                            WHEN Kaizens.ApprovalStatus = 9 THEN 'Finance Rejected'
                            WHEN Kaizens.ApprovalStatus = 14 THEN 'DELETED'	
                        END AS ApprovalStatus,
                        Users.FirstName AS CreatedBy,
                        CONVERT(VARCHAR, Kaizens.CreatedDate, 105) AS CreatedDate,
                        UserType.UserDesc AS Role
        FROM 
            [dbo].[Kaizens]
        LEFT JOIN 
            KaizenTeamMembers ON KaizenTeamMembers.KaizenID = Kaizens.ID
        INNER JOIN 
            Users ON Users.ID = Kaizens.CreatedBy
        LEFT JOIN 
            ApprovalStatus ON ApprovalStatus.StatusID = Kaizens.ApprovalStatus
        LEFT JOIN 
            Domains ON Domains.ID = Kaizens.Domain
        LEFT JOIN 
            Departments ON Departments.ID = Kaizens.Department
        LEFT JOIN 
            Blocks ON Blocks.ID = Kaizens.Block
        LEFT JOIN 
            UserType ON UserType.ID = Users.UserType
        WHERE
            (
                (@ImageApprover = 'True' AND Kaizens.ApprovalStatus = 1) OR
                (@Role = 'FIN' AND Kaizens.ApprovalStatus in (6,9) AND (Kaizens.ApprovedByIE is NULL or Kaizens.ApprovedByIE is Not null) and Kaizens.FinanceApprovedBy IS NOT NULL) OR
				(@Role = 'FIN' AND Kaizens.ApprovalStatus in (4) AND (Kaizens.ApprovedByIE is NULL) and Kaizens.FinanceApprovedBy IS NOT NULL) OR
                (@Role = 'MGR' AND Kaizens.ApprovalStatus in (2,15,5)) OR
                (@Role = 'IED' AND Kaizens.ApprovalStatus in(4,7) AND Kaizens.ApprovedByIE IS NOT NULL) OR
                (@Role = 'ADM' AND 1 = 1 AND Kaizens.ApprovalStatus != 0) OR
                (@UserId IS NOT NULL AND EXISTS (SELECT 1 
                                                 FROM KaizenTeamMembers 
                                                 WHERE KaizenTeamMembers.KaizenID = Kaizens.ID 
                                                 AND KaizenTeamMembers.EmpID = @UserId)) OR
                (@Role = 'EMP' AND Users.FirstName = @FirstName) OR
				(Kaizens.CreatedBy = @UserId)  -- Allow user to see their own Kaizens
            ) 
            AND (Kaizens.ApprovalStatus != 14 OR @Role = 'ADM')
        ORDER BY ModifiedDate DESC
    END
    ELSE
    BEGIN
        SELECT DISTINCT Kaizens.KaizenId, KaizenType, Activity, ActivityDesc, Kaizens.[BenefitArea], DocNo, VersionNoDate, CostCentre, KaizenRefNo,
                        Blocks.BlockName AS Block, BlockDetails, SuggestedKaizen, ProblemStatement, CounterMeasure, AttachmentBefore, AttachmentAfter, AttachmentOthers, Yield, CycleTime, Cost, ManPower, Consumables, others, TotalSavings, Kaizens.TeamMemberID, RootCause, PresentCondition, ImprovementsCompleted, RootProblemAttachment, RootCauseDetails, ScopeOfDeploymentId, InOtherMC, WithIntheDept, InOtherDept, OtherPoints, Benifits, OrigionatedDept, OrigonatedDate,
                        KaizenTheme, Kaizens.ApprovalStatus AS Status, Kaizens.CreatedBy AS PostedBy, Kaizens.ModifiedDate,
                        STUFF((SELECT ', ' + TeamMemberName
                               FROM KaizenTeamMembers
                               WHERE KaizenID = Kaizens.ID
                               FOR XML PATH('')), 1, 2, '') AS TeamName,
                        CASE 
                            WHEN HorozantalDeployment = 0 THEN 'NO' 
                            WHEN HorozantalDeployment = 1 THEN 'YES'
                        END AS HorozantalDeployment,
                        CASE 
                             WHEN CycleTime > 0 THEN 'YES' 
                            WHEN CycleTime = 0 THEN 'NO'
							WHEN CycleTime is null THEN 'NO'
                        END AS IEApprovedDept, 
                        CASE 
                            WHEN Cost > 100000 THEN 'YES' 
                            WHEN Cost < 100000 THEN 'NO'
                        END AS FinnanceDeptAppr,
                        CASE 
                            WHEN Shortlisted = 0 THEN 'NO' 
                            WHEN Shortlisted = 1 THEN 'YES'
                        END AS Shortlisted,
                      CASE 
                            WHEN Kaizens.ApprovalStatus = 8 THEN 'Approved Kaizen'
                            WHEN Kaizens.ApprovalStatus = 6 AND Kaizens.FinanceApprovedBy IS NULL THEN 'Approved Kaizen'
                            WHEN Kaizens.ApprovalStatus = 4 AND Kaizens.ApprovedByIE IS NULL AND Kaizens.FinanceApprovedBy IS NULL THEN 'Approved Kaizen'
                            WHEN Kaizens.ApprovalStatus = 4 AND Kaizens.ApprovedByIE IS NULL AND Kaizens.FinanceApprovedBy IS NOT NULL THEN 'Waiting For Finance Approval'
                            WHEN Kaizens.ApprovalStatus = 4 AND Kaizens.ApprovedByIE IS NOT NULL AND Kaizens.FinanceApprovedBy IS NULL THEN 'Waiting For IE Approval'
							WHEN Kaizens.ApprovalStatus = 4 AND Kaizens.ApprovedByIE IS NOT NULL AND Kaizens.FinanceApprovedBy IS NOT NULL THEN 'Waiting For IE Approval'
                            WHEN Kaizens.ApprovalStatus = 0 THEN 'Saved' 
                            WHEN Kaizens.ApprovalStatus = 1 THEN 'Waiting For Image Approval' 
                            WHEN Kaizens.ApprovalStatus IN (2, 15) THEN 'Waiting For DRI Approval'
                            WHEN Kaizens.ApprovalStatus = 3 THEN 'Image Rejected'
                            WHEN Kaizens.ApprovalStatus = 5 THEN 'DRI Rejected'
                            WHEN Kaizens.ApprovalStatus = 6 THEN 'Waiting For Finance Approval'
                            WHEN Kaizens.ApprovalStatus = 7 THEN 'IE Rejected'
                            WHEN Kaizens.ApprovalStatus = 9 THEN 'Finance Rejected'
                            WHEN Kaizens.ApprovalStatus = 14 THEN 'DELETED'	
                        END AS ApprovalStatus,
                        Users.FirstName AS CreatedBy,
                        CONVERT(VARCHAR, Kaizens.CreatedDate, 105) AS CreatedDate,
                        UserType.UserDesc AS Role
        FROM 
            [dbo].[Kaizens]
        LEFT JOIN 
            KaizenTeamMembers ON KaizenTeamMembers.KaizenID = Kaizens.ID
        INNER JOIN 
            Users ON Users.ID = Kaizens.CreatedBy
        LEFT JOIN 
            ApprovalStatus ON ApprovalStatus.StatusID = Kaizens.ApprovalStatus
        LEFT JOIN 
            Domains ON Domains.ID = Kaizens.Domain
        LEFT JOIN 
            Departments ON Departments.ID = Kaizens.Department
        LEFT JOIN 
            Blocks ON Blocks.ID = Kaizens.Block
        LEFT JOIN 
            UserType ON UserType.ID = Users.UserType
        WHERE 
            (@StartDate IS NULL OR Kaizens.CreatedDate >= @StartDate) AND
            (@EndDate IS NULL OR Kaizens.CreatedDate <= @EndDate) AND
            (@Domain IS NULL OR Domains.DomainName = @Domain) AND
            (@Department IS NULL OR Departments.DepartmentName = @Department) AND
            (@KaizenTheme IS NULL OR Kaizens.KaizenTheme = @KaizenTheme) AND
            (@Status IS NULL OR
                 CASE 
                            WHEN Kaizens.ApprovalStatus = 8 THEN 'Approved Kaizen'
                            WHEN Kaizens.ApprovalStatus = 6 AND Kaizens.FinanceApprovedBy IS NULL THEN 'Approved Kaizen'
                            WHEN Kaizens.ApprovalStatus = 4 AND Kaizens.ApprovedByIE IS NULL AND Kaizens.FinanceApprovedBy IS NULL THEN 'Approved Kaizen'
                            WHEN Kaizens.ApprovalStatus = 4 AND Kaizens.ApprovedByIE IS NULL AND Kaizens.FinanceApprovedBy IS NOT NULL THEN 'Waiting For Finance Approval'
                            WHEN Kaizens.ApprovalStatus = 4 AND Kaizens.ApprovedByIE IS NOT NULL AND Kaizens.FinanceApprovedBy IS NULL THEN 'Waiting For IE Approval'
							WHEN Kaizens.ApprovalStatus = 4 AND Kaizens.ApprovedByIE IS NOT NULL AND Kaizens.FinanceApprovedBy IS NOT NULL THEN 'Waiting For IE Approval'
                            WHEN Kaizens.ApprovalStatus = 0 THEN 'Saved' 
                            WHEN Kaizens.ApprovalStatus = 1 THEN 'Waiting For Image Approval' 
                            WHEN Kaizens.ApprovalStatus IN (2, 15) THEN 'Waiting For DRI Approval'
                            WHEN Kaizens.ApprovalStatus = 3 THEN 'Image Rejected'
                            WHEN Kaizens.ApprovalStatus = 5 THEN 'DRI Rejected'
                            WHEN Kaizens.ApprovalStatus = 6 THEN 'Waiting For Finance Approval'
                            WHEN Kaizens.ApprovalStatus = 7 THEN 'IE Rejected'
                            WHEN Kaizens.ApprovalStatus = 9 THEN 'Finance Rejected'
                            WHEN Kaizens.ApprovalStatus = 14 THEN 'DELETED'	
                        END  = @Status
            ) AND
            (@Shortlisted IS NULL OR 
                (@Shortlisted = 'YES' AND Kaizens.Shortlisted = 1) 
                OR 
                (@Shortlisted = 'NO' AND Kaizens.Shortlisted = 0)
            ) AND
            (
                (@ImageApprover = 'True' AND Kaizens.ApprovalStatus = 1) OR
                (@Role = 'FIN' AND Kaizens.ApprovalStatus in (6,9) AND (Kaizens.ApprovedByIE is NULL or Kaizens.ApprovedByIE is Not null) and Kaizens.FinanceApprovedBy IS NOT NULL) OR
				(@Role = 'FIN' AND Kaizens.ApprovalStatus in (4) AND (Kaizens.ApprovedByIE is NULL) and Kaizens.FinanceApprovedBy IS NOT NULL) OR
                (@Role = 'MGR' AND Kaizens.ApprovalStatus in (2,15,5)) OR
                (@Role = 'IED' AND Kaizens.ApprovalStatus in(4,7) AND Kaizens.ApprovedByIE IS NOT NULL) OR
                (@Role = 'ADM' AND 1 = 1 AND Kaizens.ApprovalStatus != 0) OR
                (@UserId IS NOT NULL AND EXISTS (SELECT 1 
                                                 FROM KaizenTeamMembers 
                                                 WHERE KaizenTeamMembers.KaizenID = Kaizens.ID 
                                                 AND KaizenTeamMembers.EmpID = @UserId)) OR
                (@Role = 'EMP' AND Users.FirstName = @FirstName)
            ) 
            AND (Kaizens.ApprovalStatus != 14 OR @Role = 'ADM')
			AND
            (
                @BenefitArea IS NULL 
                OR EXISTS (
                    SELECT 1 
                    FROM STRING_SPLIT(@BenefitArea, ',') AS BenefitAreas
                    WHERE Kaizens.BenefitArea LIKE '%' + BenefitAreas.value + '%'
                )
            )
        ORDER BY ModifiedDate DESC
    END
END
GO




GO
/****** Object:  StoredProcedure [dbo].[Sp_Get_KaizenformReport]    Script Date: 13-09-2024 15:37:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE Proc [dbo].[Sp_Get_KaizenformReport]  
@startdate Date = NULL,  
@enddate Date = NULL  
as  
BEGIN  
 -- Handle NULL parameters  
    SET @startdate = NULLIF(@startdate, '')  
    SET @enddate = NULLIF(@enddate, '')  
    IF @startdate IS NULL AND @enddate IS NULL  
    BEGIN  
       SELECT 
    kd.ID,
    kd.KaizenId,
    kd.KaizenType,
    kd.Activity,
    kd.ActivityDesc,
    kd.BenefitArea,
    kd.DocNo,
    kd.CostCentre,
    kd.BlockDetails,
    d.DepartmentName, 
    kd.SuggestedKaizen,
    kd.ProblemStatement,
    kd.CounterMeasure,
    kd.Yield,
    kd.CycleTime,
    kd.Cost,
    kd.ManPower,
    kd.Consumables,
    kd.Others, 
    kd.TotalSavings,
	(
        SELECT STRING_AGG(kt.TeamMemberName, ', ')
        FROM KaizenTeamMembers kt
        WHERE kt.KaizenId = kd.ID
    ) AS TeamMembers,
    kd.RootCause,
    kd.PresentCondition,
    kd.ImprovementsCompleted,
    kd.RootCauseDetails,
    kd.InOtherMC,
    kd.WithIntheDept,
    kd.InOtherDept,
    kd.OtherPoints,
    kd.Benifits,
    kd.KaizenTheme,
    aps.StatusDescription AS ApprovalStatus,
    dom.DomainName AS Domain,
    b.BlockName AS Block,
    c.CadreDesc AS Cadre,
    u1.FirstName AS DriName,
    u2.FirstName AS IEApprovedBy,
    u3.FirstName AS FinanceApprovedBy,
	kd.CreatedDate,
    u.FirstName AS CreatedBy
FROM 
    Departments d 
LEFT JOIN 
    Kaizens kd ON kd.Department = d.ID
LEFT JOIN 
    Users u ON u.ID = kd.CreatedBy
LEFT JOIN 
    Users u1 ON u1.ID = kd.DRIApprovedBy
LEFT JOIN 
    Users u2 ON u2.ID = kd.ApprovedByIE
LEFT JOIN 
    Users u3 ON u3.ID = kd.FinanceApprovedBy
LEFT JOIN 
    ApprovalStatus aps ON aps.StatusID = kd.ApprovalStatus
LEFT JOIN 
    Domains dom ON dom.ID = kd.Domain
LEFT JOIN 
    Blocks b ON b.ID = kd.Block
LEFT JOIN 
    Cadre c ON c.ID = u.Cadre
		where kd.ID is NOT NULL
    END  
    ELSE IF @startdate IS NOT NULL AND @enddate IS NULL  
    BEGIN  
        SELECT 
    kd.ID,
    kd.KaizenId,
    kd.KaizenType,
    kd.Activity,
    kd.ActivityDesc,
    kd.BenefitArea,
    kd.DocNo,
    kd.CostCentre,
    kd.BlockDetails,
    d.DepartmentName, 
    kd.SuggestedKaizen,
    kd.ProblemStatement,
    kd.CounterMeasure,
    kd.Yield,
    kd.CycleTime,
    kd.Cost,
    kd.ManPower,
    kd.Consumables,
    kd.Others, 
    kd.TotalSavings,
	(
        SELECT STRING_AGG(kt.TeamMemberName, ', ')
        FROM KaizenTeamMembers kt
        WHERE kt.KaizenId = kd.ID
    ) AS TeamMembers,
    kd.RootCause,
    kd.PresentCondition,
    kd.ImprovementsCompleted,
    kd.RootCauseDetails,
    kd.InOtherMC,
    kd.WithIntheDept,
    kd.InOtherDept,
    kd.OtherPoints,
    kd.Benifits,
    kd.KaizenTheme,
    aps.StatusDescription AS ApprovalStatus,
    dom.DomainName AS Domain,
    b.BlockName AS Block,
    c.CadreDesc AS Cadre,
    u1.FirstName AS DriName,
    u2.FirstName AS IEApprovedBy,
    u3.FirstName AS FinanceApprovedBy,
	 kd.CreatedDate,
    u.FirstName AS CreatedBy
FROM 
    Departments d 
LEFT JOIN 
    Kaizens kd ON kd.Department = d.ID
LEFT JOIN 
    Users u ON u.ID = kd.CreatedBy
LEFT JOIN 
    Users u1 ON u1.ID = kd.DRIApprovedBy
LEFT JOIN 
    Users u2 ON u2.ID = kd.ApprovedByIE
LEFT JOIN 
    Users u3 ON u3.ID = kd.FinanceApprovedBy
LEFT JOIN 
    ApprovalStatus aps ON aps.StatusID = kd.ApprovalStatus
LEFT JOIN 
    Domains dom ON dom.ID = kd.Domain
LEFT JOIN 
    Blocks b ON b.ID = kd.Block
LEFT JOIN 
    Cadre c ON c.ID = u.Cadre 
		WHERE kd.CreatedDate >= @startdate And  kd.ID is NOT NULL;  
    END  
    ELSE IF @startdate IS NULL AND @enddate IS NOT NULL  
    BEGIN  
        SELECT 
    kd.ID,
    kd.KaizenId,
    kd.KaizenType,
    kd.Activity,
    kd.ActivityDesc,
    kd.BenefitArea,
    kd.DocNo,
    kd.CostCentre,
    kd.BlockDetails,
    d.DepartmentName, 
    kd.SuggestedKaizen,
    kd.ProblemStatement,
    kd.CounterMeasure,
    kd.Yield,
    kd.CycleTime,
    kd.Cost,
    kd.ManPower,
    kd.Consumables,
    kd.Others, 
    kd.TotalSavings,
	(
        SELECT STRING_AGG(kt.TeamMemberName, ', ')
        FROM KaizenTeamMembers kt
        WHERE kt.KaizenId = kd.ID
    ) AS TeamMembers,
    kd.RootCause,
    kd.PresentCondition,
    kd.ImprovementsCompleted,
    kd.RootCauseDetails,
    kd.InOtherMC,
    kd.WithIntheDept,
    kd.InOtherDept,
    kd.OtherPoints,
    kd.Benifits,
    kd.KaizenTheme,
    aps.StatusDescription AS ApprovalStatus,
    dom.DomainName AS Domain,
    b.BlockName AS Block,
    c.CadreDesc AS Cadre,
    u1.FirstName AS DriName,
    u2.FirstName AS IEApprovedBy,
    u3.FirstName AS FinanceApprovedBy,
	 kd.CreatedDate,
    u.FirstName AS CreatedBy
FROM 
    Departments d 
LEFT JOIN 
    Kaizens kd ON kd.Department = d.ID
LEFT JOIN 
    Users u ON u.ID = kd.CreatedBy
LEFT JOIN 
    Users u1 ON u1.ID = kd.DRIApprovedBy
LEFT JOIN 
    Users u2 ON u2.ID = kd.ApprovedByIE
LEFT JOIN 
    Users u3 ON u3.ID = kd.FinanceApprovedBy
LEFT JOIN 
    ApprovalStatus aps ON aps.StatusID = kd.ApprovalStatus
LEFT JOIN 
    Domains dom ON dom.ID = kd.Domain
LEFT JOIN 
    Blocks b ON b.ID = kd.Block
LEFT JOIN 
    Cadre c ON c.ID = u.Cadre
		WHERE kd.CreatedDate <= DATEADD(DAY, 1, @enddate) AND  kd.ID is NOT NULL;  
    END  
      
    ELSE  
Begin  
 SELECT 
    kd.ID,
    kd.KaizenId,
    kd.KaizenType,
    kd.Activity,
    kd.ActivityDesc,
    kd.BenefitArea,
    kd.DocNo,
    kd.CostCentre,
    kd.BlockDetails,
    d.DepartmentName, 
    kd.SuggestedKaizen,
    kd.ProblemStatement,
    kd.CounterMeasure,
    kd.Yield,
    kd.CycleTime,
    kd.Cost,
    kd.ManPower,
    kd.Consumables,
    kd.Others, 
    kd.TotalSavings,
	(
        SELECT STRING_AGG(kt.TeamMemberName, ', ')
        FROM KaizenTeamMembers kt
        WHERE kt.KaizenId = kd.ID
    ) AS TeamMembers,
    kd.RootCause,
    kd.PresentCondition,
    kd.ImprovementsCompleted,
    kd.RootCauseDetails,
    kd.InOtherMC,
    kd.WithIntheDept,
    kd.InOtherDept,
    kd.OtherPoints,
    kd.Benifits,
    kd.KaizenTheme,
    aps.StatusDescription AS ApprovalStatus,
    dom.DomainName AS Domain,
    b.BlockName AS Block,
    c.CadreDesc AS Cadre,
    u1.FirstName AS DriName,
    u2.FirstName AS IEApprovedBy,
    u3.FirstName AS FinanceApprovedBy,
	kd.CreatedDate,
    u.FirstName AS CreatedBy
FROM 
    Departments d 
LEFT JOIN 
    Kaizens kd ON kd.Department = d.ID
LEFT JOIN 
    Users u ON u.ID = kd.CreatedBy
LEFT JOIN 
    Users u1 ON u1.ID = kd.DRIApprovedBy
LEFT JOIN 
    Users u2 ON u2.ID = kd.ApprovedByIE
LEFT JOIN 
    Users u3 ON u3.ID = kd.FinanceApprovedBy
LEFT JOIN 
    ApprovalStatus aps ON aps.StatusID = kd.ApprovalStatus
LEFT JOIN 
    Domains dom ON dom.ID = kd.Domain
LEFT JOIN 
    Blocks b ON b.ID = kd.Block
LEFT JOIN 
    Cadre c ON c.ID = u.Cadre
		WHERE kd.CreatedDate >= @startdate AND kd.CreatedDate <= DATEADD(DAY, 1, @enddate) AND  kd.ID is NOT NULL;  
END  
END  
  
GO
/****** Object:  StoredProcedure [dbo].[Sp_Get_KaizenOriginetedby]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  --[Sp_Get_KaizenOriginetedby] 600600        
CREATE  PROC [dbo].[Sp_Get_KaizenOriginetedby]          
@empId nvarchar(200)=null          
as          
Begin          
select u.ID, u.EmpID,  CONCAT(u.FirstName, ' ', u.LastName) as UserName,dom.DomainName,d.DepartmentName,ut.UserCode,FORMAT(getdate(),'dd-MM-yyyy') as CurrentDate            
from Users u          
inner join Departments d on u.Department = d.ID          
inner join Domains dom on u.Domain=dom.ID      
inner join UserType ut ON u.UserType = ut.ID     
where u.EmpID=@empId      
end           
GO
/****** Object:  StoredProcedure [dbo].[Sp_Get_KaizenProfileDetails]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  --[Sp_Get_KaizenProfileDetails] 614234        
CREATE  PROC [dbo].[Sp_Get_KaizenProfileDetails]          
@empId nvarchar(200)=null          
as          
Begin          
select u.ID, u.EmpID,u.FirstName,u.LastName,u.MiddleName,dom.DomainName AS Domain,d.DepartmentName AS Department,u.Gender,u.Email          
from Users u          
inner join Departments d on u.Department = d.ID          
inner join Domains dom on u.Domain=dom.ID          
where u.EmpID=@empId      
end 
GO
/****** Object:  StoredProcedure [dbo].[Sp_Get_Status]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Proc [dbo].[Sp_Get_Status]
as
Begin
Select StatusID,StatusName from [dbo].Status  
end 
GO
/****** Object:  StoredProcedure [dbo].[Sp_Get_UserformReport]    Script Date: 13-09-2024 15:41:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE Proc [dbo].[Sp_Get_UserformReport]  
@startdate datetime = NULL,  
@enddate datetime = NULL  
as  
BEGIN  
-- Handle NULL parameters  
    SET @startdate = NULLIF(@startdate, '')  
    SET @enddate = NULLIF(@enddate, '')  
    IF @startdate IS NULL AND @enddate IS NULL  
    BEGIN  
        select u.EmpID,u.FirstName,u.LastName,u.Email,u.MobileNumber,c.cadreDesc as Cadre,b.BlockName,a.DomainName,d.DepartmentName,u1.UserDesc as UserType from [dbo].[Users] as u
		INNER JOIN [dbo].[Domains] AS a ON a.ID = u.Domain
		INNER JOIN [dbo].[Departments] AS d ON d.ID = u.Department
		INNER JOIN [dbo].[Blocks] AS b ON b.ID = u.Block
		INNER JOIN [dbo].[UserType] AS u1 ON u1.ID = u.UserType
		INNER JOIN [dbo].[Cadre] AS c ON c.ID = u.Cadre;  
    END  
    ELSE IF @startdate IS NOT NULL AND @enddate IS NULL  
    BEGIN  
        select u.EmpID,u.FirstName,u.LastName,u.Email,u.MobileNumber,c.cadreDesc as Cadre,b.BlockName,a.DomainName,d.DepartmentName,u1.UserDesc as UserType from [dbo].[Users] as u
		INNER JOIN [dbo].[Domains] AS a ON a.ID = u.Domain
		INNER JOIN [dbo].[Departments] AS d ON d.ID = u.Department
		INNER JOIN [dbo].[Blocks] AS b ON b.ID = u.Block
		INNER JOIN [dbo].[UserType] AS u1 ON u1.ID = u.UserType
		INNER JOIN [dbo].[Cadre] AS c ON c.ID = u.Cadre
		WHERE u.CreatedDate >= @startdate;  
    END  
    ELSE IF @startdate IS NULL AND @enddate IS NOT NULL  
    BEGIN  
        select u.EmpID,u.FirstName,u.LastName,u.Email,u.MobileNumber,c.cadreDesc as Cadre,b.BlockName,a.DomainName,d.DepartmentName,u1.UserDesc as UserType from [dbo].[Users] as u
		INNER JOIN [dbo].[Domains] AS a ON a.ID = u.Domain
		INNER JOIN [dbo].[Departments] AS d ON d.ID = u.Department
		INNER JOIN [dbo].[Blocks] AS b ON b.ID = u.Block
		INNER JOIN [dbo].[UserType] AS u1 ON u1.ID = u.UserType
		INNER JOIN [dbo].[Cadre] AS c ON c.ID = u.Cadre
		WHERE u.CreatedDate <= DATEADD(DAY, 1, @enddate);  
    END  
      
    ELSE  
Begin  
select u.EmpID,u.FirstName,u.LastName,u.Email,u.MobileNumber,c.cadreDesc as Cadre,b.BlockName,a.DomainName,d.DepartmentName,u1.UserDesc as UserType from [dbo].[Users] as u
		INNER JOIN [dbo].[Domains] AS a ON a.ID = u.Domain
		INNER JOIN [dbo].[Departments] AS d ON d.ID = u.Department
		INNER JOIN [dbo].[Blocks] AS b ON b.ID = u.Block
		INNER JOIN [dbo].[UserType] AS u1 ON u1.ID = u.UserType
		INNER JOIN [dbo].[Cadre] AS c ON c.ID = u.Cadre
		WHERE u.CreatedDate >= @startdate AND u.CreatedDate <= DATEADD(DAY, 1, @enddate);  
END  
END  
GO
/****** Object:  StoredProcedure [dbo].[Sp_Get_UserLogformReport]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Sp_Get_UserLogformReport]
    @startdate datetime = NULL,
    @enddate datetime = NULL
AS
BEGIN
    SET NOCOUNT ON;

    -- Handle NULL parameters
    SET @startdate = NULLIF(@startdate, '');
    SET @enddate = NULLIF(@enddate, '');

    IF @startdate IS NULL AND @enddate IS NULL
    BEGIN
        SELECT 
            u.FirstName, 
            l.LOGIN, 
            l.LOGOUT
        FROM 
            USERLOG l
        INNER JOIN 
            Users u ON CAST(l.USERID AS nvarchar) = u.UserId;
    END
    ELSE IF @startdate IS NOT NULL AND @enddate IS NULL
    BEGIN
        SELECT 
            u.FirstName, 
            l.LOGIN, 
            l.LOGOUT
        FROM 
            USERLOG l
        INNER JOIN 
            Users u ON CAST(l.USERID AS nvarchar) = u.UserId 
        WHERE 
            CAST(l.CreatedDate AS DATE) = @startdate;
    END
    ELSE IF @startdate IS NULL AND @enddate IS NOT NULL
    BEGIN
        SELECT 
            u.FirstName, 
            l.LOGIN, 
            l.LOGOUT
        FROM 
            USERLOG l
        INNER JOIN 
            Users u ON CAST(l.USERID AS nvarchar) = u.UserId 
        WHERE 
            CAST(l.CreatedDate AS DATE) <=  DATEADD(DAY, 1, @enddate);
			 --SELECT * FROM [dbo].[Domains] WHERE CreatedDate <= DATEADD(DAY, 1, @enddate);
    END
    ELSE
    BEGIN
        SELECT 
            u.FirstName, 
            l.LOGIN, 
            l.LOGOUT
        FROM 
            USERLOG l
        INNER JOIN 
            Users u ON CAST(l.USERID AS nvarchar) = u.UserId 
        WHERE 
            CAST(l.CreatedDate AS DATE) BETWEEN @startdate AND @enddate;
    END
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_Get_Users]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--exec Sp_Get_Users '','','','','',''
CREATE PROCEDURE [dbo].[Sp_Get_Users]
(
    @Name NVARCHAR(100) = NULL,
    @Email NVARCHAR(100) = NULL,
    @EmpID NVARCHAR(100) = NULL,
    @UserDesc NVARCHAR(100) = NULL,
    @DomainDesc NVARCHAR(100) = NULL,
    @DepartmentName NVARCHAR(100) = NULL
)
AS
BEGIN
    DECLARE @sql NVARCHAR(MAX);

    SET @sql = '
        SELECT DISTINCT  
            u.ID,
            u.EmpID,
            CONCAT(u.FirstName, '' '', ISNULL(u.MiddleName + '' '', ''''), u.LastName) AS [Name],
            u.FirstName,
            u.MiddleName,
            u.LastName,
            u.Email,
            u.Gender,
            d.DomainName AS [Domain],
            dp.DepartmentName AS Department,
            ut.UserDesc AS UserType,
            ISNULL(u.ImageApprover, 0) AS [ImageApprover],
            u.Status,
            u.MobileNumber,
            u.Password,
            c.cadreDesc AS CadreDesc,
            b.BlockName AS Blockdesc,
            COALESCE(k.KaizenPostedByHim, 0) AS KaizenPostedByHim,
            COALESCE(tm.KaizenAsTeamMember, 0) AS KaizenAsTeamMember,
            COALESCE(k.KaizenPostedByHim, 0) + COALESCE(tm.KaizenAsTeamMember, 0) AS TotalKaizenPosted,
            ut.UserDesc AS Role
        FROM 
            Users u
        LEFT JOIN 
            Domains d ON d.ID = u.Domain
        LEFT JOIN 
            Departments dp ON dp.ID = u.Department
        LEFT JOIN 
            UserType ut ON ut.ID = u.UserType
        LEFT JOIN 
            Cadre c ON c.ID = u.Cadre
        LEFT JOIN 
            Blocks b ON b.ID = u.Block
        LEFT JOIN (
            -- Count of Kaizens originated by each user
            SELECT 
                CreatedBy, 
                COUNT(*) AS KaizenPostedByHim
            FROM 
                Kaizens
            WHERE 
                ApprovalStatus NOT IN (0, 14)
            GROUP BY 
                CreatedBy
        ) k ON u.ID = k.CreatedBy
        LEFT JOIN (
            -- Count of Kaizens where each user is a team member
            SELECT 
                EmpID, 
                COUNT(*) AS KaizenAsTeamMember
            FROM 
                KaizenTeamMembers
            INNER JOIN 
                Kaizens ON Kaizens.ID = KaizenTeamMembers.KaizenID
            WHERE 
                Kaizens.ApprovalStatus NOT IN (0, 14)
            GROUP BY 
                EmpID
        ) tm ON u.ID = tm.EmpID
        WHERE 1 = 1';

    -- Add filters based on parameters
    IF @Name IS NOT NULL AND @Name <> ''
        SET @sql = @sql + ' AND CONCAT(u.FirstName, ISNULL(u.MiddleName, ''''), u.LastName) LIKE ''%'' + @Name + ''%''';

    IF @Email IS NOT NULL AND @Email <> ''
        SET @sql = @sql + ' AND u.Email LIKE ''%'' + @Email + ''%''';

    IF @EmpID IS NOT NULL AND @EmpID <> ''
        SET @sql = @sql + ' AND u.EmpID = @EmpID';

    IF @UserDesc IS NOT NULL AND @UserDesc <> ''
        SET @sql = @sql + ' AND ut.UserDesc = @UserDesc';

    IF @DomainDesc IS NOT NULL AND @DomainDesc <> ''
        SET @sql = @sql + ' AND d.DomainName = @DomainDesc';

    IF @DepartmentName IS NOT NULL AND @DepartmentName <> ''
        SET @sql = @sql + ' AND dp.DepartmentName = @DepartmentName';

    -- Handle case where all parameters are empty
    IF @Name = '' AND @Email = '' AND @EmpID = '' AND @UserDesc = '' AND @DomainDesc = '' AND @DepartmentName = ''
    BEGIN
        SET @sql = '
            SELECT DISTINCT  
                u.ID,
                u.EmpID,
                CONCAT(u.FirstName, '' '', ISNULL(u.MiddleName + '' '', ''''), u.LastName) AS [Name],
                u.FirstName,
                u.MiddleName,
                u.LastName,
                u.Email,
                u.Gender,
                d.DomainName AS [Domain],
                dp.DepartmentName AS Department,
                ut.UserDesc AS UserType,
                ISNULL(u.ImageApprover, 0) AS [ImageApprover],
                u.Status,
                u.MobileNumber,
                u.Password,
                c.cadreDesc AS CadreDesc,
                b.BlockName AS Blockdesc,
                COALESCE(k.KaizenPostedByHim, 0) AS KaizenPostedByHim,
                COALESCE(tm.KaizenAsTeamMember, 0) AS KaizenAsTeamMember,
                COALESCE(k.KaizenPostedByHim, 0) + COALESCE(tm.KaizenAsTeamMember, 0) AS TotalKaizenPosted,
                ut.UserDesc AS Role
            FROM 
                Users u
            LEFT JOIN 
                Domains d ON d.ID = u.Domain
            LEFT JOIN 
                Departments dp ON dp.ID = u.Department
            LEFT JOIN 
                UserType ut ON ut.ID = u.UserType
            LEFT JOIN 
                Cadre c ON c.ID = u.Cadre
            LEFT JOIN 
                Blocks b ON b.ID = u.Block
            LEFT JOIN (
                -- Count of Kaizens originated by each user
                SELECT 
                    CreatedBy, 
                    COUNT(*) AS KaizenPostedByHim
                FROM 
                    Kaizens
                WHERE 
                    ApprovalStatus NOT IN (0, 14)
                GROUP BY 
                    CreatedBy
            ) k ON u.ID = k.CreatedBy
            LEFT JOIN (
                -- Count of Kaizens where each user is a team member
                SELECT 
                    EmpID, 
                    COUNT(*) AS KaizenAsTeamMember
                FROM 
                    KaizenTeamMembers
                INNER JOIN 
                    Kaizens ON Kaizens.ID = KaizenTeamMembers.KaizenID
                WHERE 
                    Kaizens.ApprovalStatus NOT IN (0, 14)
                GROUP BY 
                    EmpID
            ) tm ON u.ID = tm.EmpID';
    END

    -- Execute the dynamic SQL
    EXEC sp_executesql @sql, 
        N'@Name NVARCHAR(100), @Email NVARCHAR(100), @EmpID NVARCHAR(100), @UserDesc NVARCHAR(100), @DomainDesc NVARCHAR(100), @DepartmentName NVARCHAR(100)', 
        @Name, @Email, @EmpID, @UserDesc, @DomainDesc, @DepartmentName;
END;
GO
/****** Object:  StoredProcedure [dbo].[Sp_Get_UserType]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[Sp_Get_UserType]
as
Begin
Select UserTypeId,UserDesc from UserType where Status=1
end 
GO
/****** Object:  StoredProcedure [dbo].[sp_GetEmployeeDashboardDetails]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetEmployeeDashboardDetails]
    @StartDate DATE = NULL,
    @EndDate DATE = NULL
AS
BEGIN
    -- Handle NULL parameters
    SET @StartDate = NULLIF(@StartDate, '')
    SET @EndDate = NULLIF(@EndDate, '')


    SELECT 
        Users.EmpID AS EmpId,
        Users.FirstName,
   
		        SUM(CASE WHEN Kaizens.ApprovalStatus NOT IN (0, 14) THEN 1 ELSE 0 END) AS KaizenCount,
				  -- Total Approved
    --SUM(CASE WHEN Kaizens.ApprovalStatus IN (2, 4, 6, 8) THEN 1 ELSE 0 END) AS TotalApproved,
	 SUM(
        CASE 
            WHEN Kaizens.ApprovalStatus = 8 THEN 1
            WHEN Kaizens.ApprovalStatus = 6 AND Kaizens.FinanceApprovedBy IS NULL THEN 1
            WHEN Kaizens.ApprovalStatus = 4 AND Kaizens.ApprovedByIE IS NULL AND Kaizens.FinanceApprovedBy IS NULL THEN 1
            ELSE 0
        END
    ) AS TotalApproved,

    -- Total Rejected
    SUM(CASE WHEN Kaizens.ApprovalStatus IN (3, 5, 7, 9) THEN 1 ELSE 0 END) AS TotalRejected,

    -- Total Pending
    --SUM(CASE WHEN Kaizens.ApprovalStatus IN (1,2, 4, 6,15) THEN 1 ELSE 0 END) AS TotalPending,
	SUM(
    CASE 
        WHEN Kaizens.ApprovalStatus IN (1, 2, 4, 6, 15) THEN 
            CASE
                WHEN Kaizens.ApprovalStatus = 6 AND Kaizens.FinanceApprovedBy IS NULL THEN 0
                WHEN Kaizens.ApprovalStatus = 4 AND Kaizens.ApprovedByIE IS NULL AND Kaizens.FinanceApprovedBy IS NULL THEN 0
                ELSE 1
            END
        ELSE 0
    END
) AS TotalPending,

          --Separate counts for Image Approver
        SUM(CASE WHEN  Kaizens.ApprovalStatus IN (2) THEN 1 ELSE 0 END) AS ImageApproved,
        SUM(CASE WHEN  Kaizens.ApprovalStatus IN (3) THEN 1 ELSE 0 END) AS ImageRejected,
        SUM(CASE WHEN  Kaizens.ApprovalStatus IN (1) THEN 1 ELSE 0 END) AS ImagePending,
       
        -- Separate counts for Manager
        SUM(CASE WHEN  Kaizens.ApprovalStatus IN (4) THEN 1 ELSE 0 END) AS ManagerApproved,
        SUM(CASE When Kaizens.ApprovalStatus IN (5) THEN 1 ELSE 0 END) AS ManagerRejected,
        SUM(CASE When  Kaizens.ApprovalStatus IN (2,15) THEN 1 ELSE 0 END) AS ManagerPending,
      
        -- Separate counts for IE
        SUM(CASE WHEN  Kaizens.ApprovalStatus IN (6) THEN 1 ELSE 0 END) AS IEApproved,
        SUM(CASE WHEN Kaizens.ApprovalStatus IN (7) THEN 1 ELSE 0 END) AS IERejected,
        SUM(CASE WHEN  Kaizens.ApprovalStatus IN (4) THEN 1 ELSE 0 END) AS IEPending,
    
        -- Separate counts for Finance
        SUM(CASE WHEN  Kaizens.ApprovalStatus IN (8) THEN 1 ELSE 0 END) AS FinanceApproved,
        SUM(CASE WHEN Kaizens.ApprovalStatus IN (9) THEN 1 ELSE 0 END) AS FinanceRejected,
        SUM(CASE WHEN  Kaizens.ApprovalStatus IN (6) THEN 1 ELSE 0 END) AS FinancePending
    FROM 
        [dbo].[Kaizens]
    LEFT JOIN 
        [dbo].[Users] ON Kaizens.CreatedBy = Users.ID


    WHERE 
        (@StartDate IS NULL OR Kaizens.CreatedDate >= @StartDate) 
        AND (@EndDate IS NULL OR Kaizens.CreatedDate <= @EndDate) 
    GROUP BY 
        Users.EmpID, Users.FirstName
    ORDER BY 
        KaizenCount DESC;



		 SELECT
		   Users.EmpID AS EmpId,
        Users.FirstName,
        FORMAT(Kaizens.CreatedDate, 'MMM-yyyy') AS MonthYear,
        SUM(CASE WHEN Kaizens.ApprovalStatus NOT IN (0, 14) THEN 1 ELSE 0 END) AS KaizenCount,
        --SUM(CASE WHEN Kaizens.ApprovalStatus IN (2, 4, 6, 8) THEN 1 ELSE 0 END) AS TotalApproved,
		SUM(
        CASE 
            WHEN Kaizens.ApprovalStatus = 8 THEN 1
            WHEN Kaizens.ApprovalStatus = 6 AND Kaizens.FinanceApprovedBy IS NULL THEN 1
            WHEN Kaizens.ApprovalStatus = 4 AND Kaizens.ApprovedByIE IS NULL AND Kaizens.FinanceApprovedBy IS NULL THEN 1
            ELSE 0
        END
    ) AS TotalApproved,

        SUM(CASE WHEN Kaizens.ApprovalStatus IN (3, 5, 7, 9) THEN 1 ELSE 0 END) AS TotalRejected,
        --SUM(CASE WHEN Kaizens.ApprovalStatus IN (1, 2, 4, 6,15) THEN 1 ELSE 0 END) AS TotalPending
			SUM(
    CASE 
        WHEN Kaizens.ApprovalStatus IN (1, 2, 4, 6, 15) THEN 
            CASE
                WHEN Kaizens.ApprovalStatus = 6 AND Kaizens.FinanceApprovedBy IS NULL THEN 0
                WHEN Kaizens.ApprovalStatus = 4 AND Kaizens.ApprovedByIE IS NULL AND Kaizens.FinanceApprovedBy IS NULL THEN 0
                ELSE 1
            END
        ELSE 0
    END
) AS TotalPending
    FROM
        [dbo].[Kaizens]
		 LEFT JOIN 
        [dbo].[Users] ON Kaizens.CreatedBy = Users.ID
    WHERE
        (@StartDate IS NULL OR Kaizens.CreatedDate >= @StartDate)
        AND (@EndDate IS NULL OR Kaizens.CreatedDate <= @EndDate)
		
    GROUP BY
        FORMAT(Kaizens.CreatedDate, 'MMM-yyyy'),Users.EmpID, Users.FirstName
    ORDER BY
        FORMAT(Kaizens.CreatedDate, 'MMM-yyyy');
END
GO

/****** Object:  StoredProcedure [dbo].[sp_GetKaizenStatisticsByApprovalTypes]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetKaizenStatisticsByApprovalTypes]
    @StartDate DATE = NULL,
    @EndDate DATE = NULL,
    @Domain NVARCHAR(100) = NULL,
    @Block NVARCHAR(100) = NULL,
    @Department NVARCHAR(100) = NULL
AS
BEGIN
    -- Handle NULL parameters
    SET @StartDate = NULLIF(@StartDate, '')
    SET @EndDate = NULLIF(@EndDate, '')
    SET @Domain = NULLIF(@Domain, '')
    SET @Department = NULLIF(@Department, '')
    SET @Block = NULLIF(@Block, '')

    -- Main Query 1
    SELECT 
        Users.EmpID AS UserID,
        UserType.UserTypeId AS UserTypeID,
        Users.FirstName,
        Users.LastName,
        UserType.UserDesc AS UserType,   
        SUM(CASE WHEN Kaizens.ImageApprovedBy = Users.ID AND Kaizens.ApprovalStatus IN (1, 2, 3, 4, 6, 8) THEN 1 ELSE 0 END) AS ImageTotal,
        -- Total for Manager
        SUM(CASE WHEN Kaizens.DRIApprovedBy = Users.ID AND Kaizens.ApprovalStatus IN (2, 4, 5, 6, 8,15) THEN 1 ELSE 0 END) AS ManagerTotal,
        -- Total for IE
        SUM(CASE WHEN Kaizens.ApprovedByIE = Users.ID AND Kaizens.ApprovalStatus IN (6, 7, 8, 4) THEN 1 ELSE 0 END) AS IETotal,
        -- Total for Finance
        SUM(CASE WHEN Kaizens.FinanceApprovedBy = Users.ID AND Kaizens.ApprovalStatus IN (8, 9, 6) THEN 1 ELSE 0 END) AS FinanceTotal,

        -- Separate counts for Image Approver
        SUM(CASE WHEN Kaizens.ImageApprovedBy = Users.ID AND Kaizens.ApprovalStatus IN (2, 4, 6, 8) THEN 1 ELSE 0 END) AS ImageApproved,
        SUM(CASE WHEN Kaizens.ImageApprovedBy = Users.ID AND Kaizens.ApprovalStatus IN (3) THEN 1 ELSE 0 END) AS ImageRejected,
        SUM(CASE WHEN Kaizens.ImageApprovedBy = Users.ID AND Kaizens.ApprovalStatus IN (1) THEN 1 ELSE 0 END) AS ImagePending,
        
        -- Separate counts for Manager
        SUM(CASE WHEN Kaizens.DRIApprovedBy = Users.ID AND Kaizens.ApprovalStatus IN (4, 6, 8) THEN 1 ELSE 0 END) AS ManagerApproved,
        SUM(CASE WHEN Kaizens.DRIApprovedBy = Users.ID AND Kaizens.ApprovalStatus IN (5) THEN 1 ELSE 0 END) AS ManagerRejected,
        SUM(CASE WHEN Kaizens.DRIApprovedBy = Users.ID AND Kaizens.ApprovalStatus IN (2,15) THEN 1 ELSE 0 END) AS ManagerPending,
      
        -- Separate counts for IE
        SUM(CASE WHEN Kaizens.ApprovedByIE = Users.ID AND Kaizens.ApprovalStatus IN (6, 8) THEN 1 ELSE 0 END) AS IEApproved,
        SUM(CASE WHEN Kaizens.ApprovedByIE = Users.ID AND Kaizens.ApprovalStatus IN (7) THEN 1 ELSE 0 END) AS IERejected,
        SUM(CASE WHEN Kaizens.ApprovedByIE = Users.ID AND Kaizens.ApprovalStatus IN (4) THEN 1 ELSE 0 END) AS IEPending,

        -- Separate counts for Finance
        SUM(CASE WHEN Kaizens.FinanceApprovedBy = Users.ID AND Kaizens.ApprovalStatus IN (8) THEN 1 ELSE 0 END) AS FinanceApproved,
        SUM(CASE WHEN Kaizens.FinanceApprovedBy = Users.ID AND Kaizens.ApprovalStatus IN (9) THEN 1 ELSE 0 END) AS FinanceRejected,
        SUM(CASE WHEN Kaizens.FinanceApprovedBy = Users.ID AND Kaizens.ApprovalStatus IN (6) THEN 1 ELSE 0 END) AS FinancePending
     
    FROM 
        [dbo].[Users]
    LEFT JOIN 
        [dbo].[Kaizens] ON Kaizens.ApprovedByIE = Users.ID
                       OR Kaizens.FinanceApprovedBy = Users.ID
                       OR Kaizens.DRIApprovedBy = Users.ID
    LEFT JOIN 
        [dbo].[UserType] ON Users.UserType = UserType.ID
    LEFT JOIN 
        Departments ON Departments.ID = Kaizens.Department
    LEFT JOIN
        Blocks ON Blocks.ID = Kaizens.Block
    LEFT JOIN 
        Domains ON Domains.ID = Kaizens.Domain
		
    WHERE 
      (@StartDate IS NULL OR Kaizens.CreatedDate >= @StartDate) 
    AND (@EndDate IS NULL OR Kaizens.CreatedDate <= @EndDate)
    AND (@Domain IS NULL OR Domains.DomainName = @Domain)
	AND (@Department IS NULL OR Departments.DepartmentName = @Department)
	AND	(@Block IS NULL OR Blocks.BlockName=@Block)
	AND Kaizens.ApprovalStatus NOT IN (0, 14)
    GROUP BY 
        Users.EmpID, Users.FirstName, Users.LastName, UserType.UserDesc, UserType.UserTypeId
    ORDER BY 
        Users.EmpID;

    -- Main Query 2
    SELECT 
        FORMAT(Kaizens.CreatedDate, 'MMM-yyyy') AS MonthYear,
        Users.EmpID AS UserID,
        UserType.UserTypeId AS UserTypeID,
        Users.FirstName,
        Users.LastName,
        UserType.UserDesc AS UserType, 
		
		SUM(CASE WHEN Kaizens.ImageApprovedBy = Users.ID AND Kaizens.ApprovalStatus IN (1, 2, 3, 4, 6, 8) THEN 1 ELSE 0 END) AS ImageTotal,
        -- Total for Manager
        SUM(CASE WHEN Kaizens.DRIApprovedBy = Users.ID AND Kaizens.ApprovalStatus IN (2, 4, 5, 6, 8,15) THEN 1 ELSE 0 END) AS ManagerTotal,
        -- Total for IE
        SUM(CASE WHEN Kaizens.ApprovedByIE = Users.ID AND Kaizens.ApprovalStatus IN (6, 7, 8, 4) THEN 1 ELSE 0 END) AS IETotal,
        -- Total for Finance
        SUM(CASE WHEN Kaizens.FinanceApprovedBy = Users.ID AND Kaizens.ApprovalStatus IN (8, 9, 6) THEN 1 ELSE 0 END) AS FinanceTotal,

        -- Separate counts for Image Approver
        SUM(CASE WHEN Kaizens.ImageApprovedBy = Users.ID AND Kaizens.ApprovalStatus IN (2, 4, 6, 8) THEN 1 ELSE 0 END) AS ImageApproved,
        SUM(CASE WHEN Kaizens.ImageApprovedBy = Users.ID AND Kaizens.ApprovalStatus IN (3) THEN 1 ELSE 0 END) AS ImageRejected,
        SUM(CASE WHEN Kaizens.ImageApprovedBy = Users.ID AND Kaizens.ApprovalStatus IN (1) THEN 1 ELSE 0 END) AS ImagePending,
        
        -- Separate counts for Manager
        SUM(CASE WHEN Kaizens.DRIApprovedBy = Users.ID AND Kaizens.ApprovalStatus IN (4, 6, 8) THEN 1 ELSE 0 END) AS ManagerApproved,
        SUM(CASE WHEN Kaizens.DRIApprovedBy = Users.ID AND Kaizens.ApprovalStatus IN (5) THEN 1 ELSE 0 END) AS ManagerRejected,
        SUM(CASE WHEN Kaizens.DRIApprovedBy = Users.ID AND Kaizens.ApprovalStatus IN (2,15) THEN 1 ELSE 0 END) AS ManagerPending,
      
        -- Separate counts for IE
        SUM(CASE WHEN Kaizens.ApprovedByIE = Users.ID AND Kaizens.ApprovalStatus IN (6, 8) THEN 1 ELSE 0 END) AS IEApproved,
        SUM(CASE WHEN Kaizens.ApprovedByIE = Users.ID AND Kaizens.ApprovalStatus IN (7) THEN 1 ELSE 0 END) AS IERejected,
        SUM(CASE WHEN Kaizens.ApprovedByIE = Users.ID AND Kaizens.ApprovalStatus IN (4) THEN 1 ELSE 0 END) AS IEPending,

        -- Separate counts for Finance
        SUM(CASE WHEN Kaizens.FinanceApprovedBy = Users.ID AND Kaizens.ApprovalStatus IN (8) THEN 1 ELSE 0 END) AS FinanceApproved,
        SUM(CASE WHEN Kaizens.FinanceApprovedBy = Users.ID AND Kaizens.ApprovalStatus IN (9) THEN 1 ELSE 0 END) AS FinanceRejected,
        SUM(CASE WHEN Kaizens.FinanceApprovedBy = Users.ID AND Kaizens.ApprovalStatus IN (6) THEN 1 ELSE 0 END) AS FinancePending
     
    FROM 
        [dbo].[Users]
    LEFT JOIN 
        [dbo].[Kaizens] ON Kaizens.ApprovedByIE = Users.ID
                       OR Kaizens.FinanceApprovedBy = Users.ID
                       OR Kaizens.DRIApprovedBy = Users.ID
    LEFT JOIN 
        [dbo].[UserType] ON Users.UserType = UserType.ID
    LEFT JOIN 
        Departments ON Departments.ID = Kaizens.Department
    LEFT JOIN
        Blocks ON Blocks.ID = Kaizens.Block
    LEFT JOIN 
        Domains ON Domains.ID = Kaizens.Domain
		
    WHERE 
      (@StartDate IS NULL OR Kaizens.CreatedDate >= @StartDate) 
    AND (@EndDate IS NULL OR Kaizens.CreatedDate <= @EndDate)
    AND (@Domain IS NULL OR Domains.DomainName = @Domain)
	AND (@Department IS NULL OR Departments.DepartmentName = @Department)
	AND	(@Block IS NULL OR Blocks.BlockName=@Block)
	AND Kaizens.ApprovalStatus NOT IN (0, 14)
    GROUP BY 
        Users.EmpID, Users.FirstName, Users.LastName, UserType.UserDesc, UserType.UserTypeId, FORMAT(Kaizens.CreatedDate, 'MMM-yyyy')
    ORDER BY 
        FORMAT(Kaizens.CreatedDate, 'MMM-yyyy'), Users.EmpID;
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_GetTheme]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Sp_GetTheme]

AS

BEGIN
	Select * from Themes
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_GetUserManager]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sp_GetUserManager]

     @Empid NVARCHAR(300)
AS
BEGIN
    

    SELECT mgr.FirstName AS ManagerName,
        mgr.Email AS ManagerEmail,
		mgr.EmpID As Mgrid
    FROM [dbo].[Users] u
    JOIN [dbo].[Users] mgr 
        ON u.Department = mgr.Department 
       AND mgr.UserType = (SELECT ID FROM [dbo].[UserType] WHERE UserCode = 'MGR')
    WHERE u.EmpID = @Empid;
END;
GO
/****** Object:  StoredProcedure [dbo].[Sp_GetUserManagerupdate]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Sp_GetUserManagerupdate] 
   @departid NVARCHAR(50)
AS  
BEGIN 
    SELECT DISTINCT
        mgr.FirstName AS ManagerName,  
        mgr.Email AS ManagerEmail,  
        mgr.EmpID AS Mgrid  
    FROM 
        [dbo].[Users] u  
    JOIN 
        [dbo].[Users] mgr   
        ON u.Department = mgr.Department   
        AND mgr.UserType = (SELECT ID FROM [dbo].[UserType] WHERE UserCode = 'MGR')
    WHERE 
	u.Department = @departid;
       
END;
GO
/****** Object:  StoredProcedure [dbo].[Sp_GetUsersByBlockId]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Create/Alter the stored procedure to fetch users by BlockId
CREATE PROCEDURE [dbo].[Sp_GetUsersByBlockId]
    @BlockId INT
AS
BEGIN
    -- Get the GUID for the provided BlockId
    DECLARE @BlockGuid UNIQUEIDENTIFIER;
    SELECT @BlockGuid = ID FROM [Blocks] WHERE BlockID = @BlockId;

    -- Check if the BlockGuid was found
    IF @BlockGuid IS NULL
    BEGIN
        -- Return an empty result or handle the case where the BlockId is invalid
        SELECT * FROM Users WHERE 1 = 0;
        RETURN;
    END

    -- Fetch users associated with the BlockGuid
    SELECT
        u.EmpID,
        CONCAT(u.FirstName, ' ', ISNULL(u.MiddleName + ' ', ''), u.LastName) AS [Name],
        u.Email,
        u.Gender,
        d.DomainName AS [Domain],
        dp.DepartmentName AS Department,
        ut.UserDesc AS UserType,
        ISNULL(u.ImageApprover, 0) AS [ImageApprover],
        u.Status,
        u.MobileNumber AS PhoneNo,
        u.Password,
        c.CadreDesc AS CadreDesc,
        b.BlockName AS Blockdesc,
        COALESCE(k.KaizenPostedByHim, 0) AS KaizenPostedByHim,
        COALESCE(tm.KaizenAsTeamMember, 0) AS KaizenAsTeamMember,
        COALESCE(k.KaizenPostedByHim, 0) + COALESCE(tm.KaizenAsTeamMember, 0) AS TotalKaizenPosted,
        ut.UserDesc AS Role,
        u.ID
    FROM 
        Users u
    LEFT JOIN 
        Domains d ON d.ID = u.Domain
    LEFT JOIN 
        Departments dp ON dp.ID = u.Department
    LEFT JOIN 
        UserType ut ON ut.ID = u.UserType
    LEFT JOIN 
        Cadre c ON c.ID = u.Cadre
    LEFT JOIN 
        Blocks b ON b.ID = u.Block
    LEFT JOIN (
        -- Count of Kaizens originated by each user
        SELECT 
            CreatedBy, 
            COUNT(*) AS KaizenPostedByHim
        FROM 
            Kaizens
        WHERE 
            ApprovalStatus NOT IN (0, 14)
        GROUP BY 
            CreatedBy
    ) k ON u.ID = k.CreatedBy
    LEFT JOIN (
        -- Count of Kaizens where each user is a team member
        SELECT 
            EmpID, 
            COUNT(*) AS KaizenAsTeamMember
        FROM 
            KaizenTeamMembers
        INNER JOIN 
            Kaizens ON Kaizens.ID = KaizenTeamMembers.KaizenID
        WHERE 
            Kaizens.ApprovalStatus NOT IN (0, 14)
        GROUP BY 
            EmpID
    ) tm ON u.ID = tm.EmpID
    WHERE 
        u.Block = @BlockGuid;
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_GetUsersByDeptId]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Sp_GetUsersByDeptId]
    @DomainId INT,
    @DeptId INT
AS
BEGIN
    -- Get the GUID for the provided DomainId
    DECLARE @DomainGuid UNIQUEIDENTIFIER;
    SELECT @DomainGuid = ID FROM [Domains] WHERE DomainID = @DomainId;

	-- Get the GUID for the provided DeptId
    DECLARE @DeptGuid UNIQUEIDENTIFIER;
    SELECT @DeptGuid = ID FROM [Departments] WHERE DeptId = @DeptId;

    -- Check if the DomainGuid was found
   IF @DomainGuid IS NULL OR @DeptGuid IS NULL
    BEGIN
        -- Return an empty result or handle the case where the DomainId is invalid
        SELECT * FROM Users WHERE 1 = 0;
        RETURN;
    END

    -- Fetch users associated with the DomainGuid and DeptId
    SELECT
        u.EmpID,
        CONCAT(u.FirstName, ' ', ISNULL(u.MiddleName + ' ', ''), u.LastName) AS [Name],
        u.Email,
        u.Gender,
        d.DomainName AS [Domain],
        dp.DepartmentName AS Department,
        ut.UserDesc AS UserType,
        ISNULL(u.ImageApprover, 0) AS [ImageApprover],
        u.Status,
        u.MobileNumber AS PhoneNo,
        u.Password,
        c.cadreDesc AS CadreDesc,
        b.BlockName AS Blockdesc,
        COALESCE(k.KaizenPostedByHim, 0) AS KaizenPostedByHim,
        COALESCE(tm.KaizenAsTeamMember, 0) AS KaizenAsTeamMember,
        COALESCE(k.KaizenPostedByHim, 0) + COALESCE(tm.KaizenAsTeamMember, 0) AS TotalKaizenPosted,
        ut.UserDesc AS Role,
        u.ID
    FROM 
        Users u
    LEFT JOIN 
        Domains d ON d.ID = u.Domain
    LEFT JOIN 
        Departments dp ON dp.ID = u.Department
    LEFT JOIN 
        UserType ut ON ut.ID = u.UserType
    LEFT JOIN 
        Cadre c ON c.ID = u.Cadre
    LEFT JOIN 
        Blocks b ON b.ID = u.Block
    LEFT JOIN (
        -- Count of Kaizens originated by each user
        SELECT 
            CreatedBy, 
            COUNT(*) AS KaizenPostedByHim
        FROM 
            Kaizens
        WHERE 
            ApprovalStatus NOT IN (0, 14)
        GROUP BY 
            CreatedBy
    ) k ON u.ID = k.CreatedBy
    LEFT JOIN (
        -- Count of Kaizens where each user is a team member
        SELECT 
            EmpID, 
            COUNT(*) AS KaizenAsTeamMember
        FROM 
            KaizenTeamMembers
        INNER JOIN 
            Kaizens ON Kaizens.ID = KaizenTeamMembers.KaizenID
        WHERE 
            Kaizens.ApprovalStatus NOT IN (0, 14)
        GROUP BY 
            EmpID
    ) tm ON u.ID = tm.EmpID
    WHERE 
        u.Domain = @DomainGuid AND u.Department = @DeptGuid;
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_GetUsersByDomainId]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Sp_GetUsersByDomainId]
    @DomainId INT
	  
AS
BEGIN
    -- Get the GUID for the provided DomainId
   
	  DECLARE @DomainGuid UNIQUEIDENTIFIER;
        SELECT @DomainGuid = ID FROM [Domains] WHERE DomainID = @DomainId;
  

    -- Check if the DomainGuid was found
    IF @DomainGuid IS NULL
    BEGIN
        -- Return an empty result or handle the case where the DomainId is invalid
        SELECT * FROM Users WHERE 1 = 0;
        RETURN;
    END

    -- Fetch users associated with the DomainGuid
  SELECT
        u.EmpID,
        CONCAT(u.FirstName, ' ', ISNULL(u.MiddleName + ' ', ''), u.LastName) AS [Name],
        u.Email,
        u.Gender,
        d.DomainName AS [Domain],
        dp.DepartmentName AS Department,
        ut.UserDesc AS UserType,
        ISNULL(u.ImageApprover, 0) AS [ImageApprover],
        u.Status,
        u.MobileNumber AS PhoneNo,
        u.Password,
        c.cadreDesc AS CadreDesc,
        b.BlockName AS Blockdesc,
        COALESCE(k.KaizenPostedByHim, 0) AS KaizenPostedByHim,
        COALESCE(tm.KaizenAsTeamMember, 0) AS KaizenAsTeamMember,
        COALESCE(k.KaizenPostedByHim, 0) + COALESCE(tm.KaizenAsTeamMember, 0) AS TotalKaizenPosted,
        ut.UserDesc AS Role,
        u.ID
    FROM 
        Users u
    LEFT JOIN 
        Domains d ON d.ID = u.Domain
    LEFT JOIN 
        Departments dp ON dp.ID = u.Department
    LEFT JOIN 
        UserType ut ON ut.ID = u.UserType
    LEFT JOIN 
        Cadre c ON c.ID = u.Cadre
    LEFT JOIN 
        Blocks b ON b.ID = u.Block
    LEFT JOIN (
        -- Count of Kaizens originated by each user
        SELECT 
            CreatedBy, 
            COUNT(*) AS KaizenPostedByHim
        FROM 
            Kaizens
        WHERE 
            ApprovalStatus NOT IN (0, 14)
        GROUP BY 
            CreatedBy
    ) k ON u.ID = k.CreatedBy
    LEFT JOIN (
        -- Count of Kaizens where each user is a team member
        SELECT 
            EmpID, 
            COUNT(*) AS KaizenAsTeamMember
        FROM 
            KaizenTeamMembers
        INNER JOIN 
            Kaizens ON Kaizens.ID = KaizenTeamMembers.KaizenID
        WHERE 
            Kaizens.ApprovalStatus NOT IN (0, 14)
        GROUP BY 
            EmpID
    ) tm ON u.ID = tm.EmpID
    WHERE 
        u.Domain = @DomainGuid;
END

GO
/****** Object:  StoredProcedure [dbo].[Sp_GetWinnersList]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sp_GetWinnersList]      
AS      
BEGIN      
    SET NOCOUNT ON;      
      
    SELECT      
        wl.ID,    
        CONCAT(u.FirstName, ' ', u.LastName) AS WinnerName,      
        u.UserID,      
        d.DomainName,      
        dp.DepartmentName,      
        wl.Category,      
        FORMAT(wl.StartDate, 'dd/MM/yyyy') AS StartDate,      
        FORMAT(wl.EndDate, 'dd/MM/yyyy') AS EndDate,      
        FORMAT(wl.CreatedDate, 'dd/MM/yyyy') AS CreatedDate,      
        FORMAT(wl.ModifiedDate, 'dd/MM/yyyy') AS ModifiedDate,    
        wl.Status,
		wl.WinnerimgPath as FileName
    FROM      
        WinnersList wl      
    JOIN      
        Users u ON wl.EmpGUID = u.ID      
    JOIN     
        Domains d ON u.Domain = d.ID      
    JOIN     
        Departments dp ON u.Department = dp.ID      
      
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_InsertDepartment]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Sp_InsertDepartment]      
    @DomainName varchar(50),
	@DomainId int,
    @department nvarchar(50),
	@Createdby nvarchar(50)=null
AS      

BEGIN      
      Declare @Domain uniqueidentifier,
	          @CreatedID nvarchar(100);
	  SET @Domain = (SELECT ID FROM [dbo].Domains WHERE DomainID = @DomainId and DomainName = @DomainName);
	  SET @CreatedID = (select ID From Users  where EmpID= @Createdby);
    BEGIN      
        INSERT INTO [dbo].[Departments]      
        (DomainId,DepartmentName,Status,CreatedBy, CreatedDate)      
        VALUES      
        (@Domain,@department, 1,@CreatedID, GETDATE())      
    END      
    
END 
GO
/****** Object:  StoredProcedure [dbo].[Sp_InsertDomain]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sp_InsertDomain]  
@DomainName nvarchar(50),
@CreatedBy nvarchar(100) = NULL

AS      
 BEGIN 
 Declare @CreatedId nvarchar(100);
 set @CreatedId=(select ID FROM [dbo].[Users] WHERE EmpID=@CreatedBy)

 BEGIN
 INSERT INTO [dbo].[Domains]          
 (      

    DomainName,Status, CreatedBy, CreatedDate
 )           
 VALUES           
 (
	@DomainName,'1',@CreatedId,GETDATE() 
 )           
 END 
 
 END
GO
/****** Object:  StoredProcedure [dbo].[Sp_InsertUser]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Sp_InsertUser]    
@EmpId nvarchar(50),
@Name nvarchar(300),
@LastName nvarchar(300),
@MiddleName nvarchar(300)=null,
@Email nvarchar(200),   
@Phno nvarchar(200),   
@Password nvarchar(200), 
@Gender nvarchar(20),
@Cid  int,
@Rid int,
@Did int,
@status int,
@Deptid nvarchar(20),
@BlockId int,
@Createdby nvarchar(50)=null,
@result BIT Out 


AS      
 BEGIN 
 Declare @CreatedId nvarchar(100);
 Declare @DomainId nvarchar(100);
 Declare @DepartmentId nvarchar(100);
 Declare @cardeId nvarchar(100);
 Declare @UsertypeId nvarchar(100);
 Declare @BlocksId nvarchar(100);
 set @CreatedId=(select ID FROM [dbo].[Users] WHERE EmpID=@CreatedBy)
 set @cardeId= (SELECT ID FROM [dbo].[Cadre] WHERE CadreId = @Cid)
 set @DepartmentId= (SELECT ID FROM [dbo].[Departments] WHERE DeptId = @Deptid)
 set @DomainId=    (SELECT ID FROM [dbo].[Domains] WHERE DomainID = @Did)
 set @UsertypeId=    (SELECT ID FROM [dbo].[UserType] WHERE UserTypeId = @Rid)
 set @BlocksId=(select ID From [dbo].[Blocks] where BlockId=@BlockId)
      
Begin    

set @result=(SELECT count(*) FROM [Users] WHERE EmpID=@EmpId )  
if @result<1 
INSERT INTO [Users] (UserID,
    EmpId, FirstName,MiddleName,LastName,Email, MobileNumber, Password, Gender, Status, Domain, Department, UserType, Cadre,CreatedDate,CreatedBy,Block
)
VALUES (
     @EmpId,
    @EmpId,
    @Name,
	@MiddleName,
	@LastName,
    @Email,
    @Phno,
    @Password,
    @Gender,
    @status,
    @DomainId,
   @DepartmentId,
    @UsertypeId,
    @cardeId,
	GETDATE(),
	 @CreatedId,
	 @BlocksId
	
);
End  
End

GO
/****** Object:  StoredProcedure [dbo].[Sp_Kaizen_Insert]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
   
CREATE proc [dbo].[Sp_Kaizen_Insert]  
@KaizenTeam KaizenTeamMembersType readonly,  
@KaizenScopeDetails KaizenScopeDetailsType readonly,  
@AttachmentDetails KaizenAttachmentType readonly,  
@ID uniqueidentifier,  
@KaizenType nvarchar(10)=null,  
@Activity nvarchar(50)=null,  
@ActivityDesc nvarchar(50)= NULL,  
@BenefitArea nvarchar(10)=null,  
@DocNo nvarchar(50)=null,  
@VersionNoDate nvarchar(50)= NULL,  
@CostCentre nvarchar(50),  
@KaizenRefNo nvarchar(50),  
@Block int=null,  
@BlockDetails nvarchar(50)=null,  
@KaizenTheme nvarchar(50)=null,  
@SuggestedKaizen nvarchar(50)=null,  
@ProblemStatement nvarchar(100)=null,  
@CounterMeasure nvarchar(100)=null,  
@AttachmentBefore nvarchar(50)=null,  
@AttachmentAfter nvarchar(50)=null,  
@AttachmentOthers nvarchar(50)=NULL,  
@Yield nvarchar(50)=null,  
@CycleTime nvarchar(50)=null,  
@Cost int=null,  
@ManPower nvarchar(50)=null,  
@Consumables nvarchar(50)=null,  
@Others nvarchar(50)=null,  
@TotalSavings int=null,  
@ApprovedByIE nvarchar(50)=null,  
@FinanceApprovedBy nvarchar(100) = NULL ,  
@TeamMemberID int = NULL,  
@RootCause nvarchar(50) = NULL,  
@PresentCondition nvarchar(255)=null,  
@ImprovementsCompleted nvarchar(255)=null,  
@RootProblemAttachment nvarchar(50)=NULL,  
@RootCauseDetails nvarchar(max)=NULL,  
@HorozantalDeployment bit=null,  
@ScopeOfDeploymentID int = NULL,  
@InOtherMc nvarchar(200)=NULL,  
@WithIntheDept nvarchar(200)=NULL,  
@InOtherDept nvarchar(200)=NULL,  
@OtherPoints nvarchar(200)=NULL,  
@Benifits nvarchar(255),  
@Shortlisted bit = NULL,  
@ApprovalStatus char(2)= NULL,  
@IEApprovedDate datetime = NULL,  
@IEApprovedBy nvarchar(200) = NULL,  
@IEApprovedDept nvarchar(50)=NULL,  
@DRIApprovedDate datetime=NULL,  
@DRIApprovedBy nvarchar(100) =NULL,  
@FinanceApprovedDate datetime = NULL,  
@ImageApprovedDate datetime = NULL,  
@ImageApprovedBy nvarchar(200) = NULL,  
@OriginatedBy nvarchar(200) = NULL,  
@OrigionatedDept nvarchar(50)=NULL,  
--@OrigonatedDate datetime=NULL,  
@ModifiedBy nvarchar(200) = NULL ,  
@ModifiedDate nvarchar(200) = NULL,  
@CreatedBy nvarchar(200) = NULL ,  
--@CreatedDate datetime = NULL,  
@Department nvarchar(50) = NULL,  
@Domain nvarchar(50) = NULL  
as  
Begin  
   
  Declare @BlockId nvarchar(50);   
  Declare @IEApproved nvarchar(50);     
  Declare @CreatedId uniqueidentifier;  
  Declare @IEApprovedByID nvarchar(150)=null;  
  Declare @DriApprovedID nvarchar(150)=null;  
  Declare @FinanceApprovedID nvarchar(150)=null;  
  Declare @ImageApprovedID nvarchar(150)=null;  
  Declare @OriginatedByID nvarchar(150);  
  Declare @ModifiedByID nvarchar(150);  
  Declare @DepartmentID nvarchar(150); 
  DECLARE @DOCumentNO NVARCHAR(50);
  Declare @DomainID nvarchar(150)  
  set @BlockId=(select ID FROM Blocks WHERE BlockId=@Block)    
  set @IEApproved=(select ID from [dbo].[Users] where UserID= @ApprovedByIE)    
  set @CreatedId=(select ID FROM [dbo].[Users] WHERE EmpID=@CreatedBy)  
  set @IEApprovedByID=(select ID FROM [dbo].[Users] WHERE Email=@ApprovedByIE)  
  set @DriApprovedID=(select ID FROM [dbo].[Users] WHERE EmpID=@DRIApprovedBy)  
  set @FinanceApprovedID=(select ID FROM [dbo].[Users] WHERE UserID=@FinanceApprovedBy)  
  set @ImageApprovedID=(select ID FROM [dbo].[Users] WHERE EmpID='321256')  
  set @OriginatedByID=(select ID FROM [dbo].[Users] WHERE EmpID=@CreatedBy)  
  set @ModifiedByID=(select ID FROM [dbo].[Users] WHERE EmpID=@CreatedBy)  
  set @DepartmentID=(select Department FROM [dbo].[Users] WHERE EmpID=@CreatedBy)  
  set @DomainID=(select Domain FROM [dbo].[Users] WHERE EmpID=@CreatedBy) 
  SET @DOCumentNO = 'TEPL-MG-' + CAST((SELECT COUNT(KaizenId)+ 1 FROM Kaizens) AS NVARCHAR(50));
  
         Begin  
		    BEGIN TRANSACTION
    BEGIN TRY

        INSERT INTO Kaizens(  
            ID, KaizenType, Activity, ActivityDesc, BenefitArea, DocNo, VersionNoDate,  
            CostCentre, KaizenRefNo, Block, BlockDetails, KaizenTheme, SuggestedKaizen, ProblemStatement,  
            CounterMeasure, AttachmentBefore, AttachmentAfter, AttachmentOthers, Yield, CycleTime, Cost,
			ManPower, Consumables, Others, TotalSavings, ApprovedByIE, FinanceApprovedBy, TeamMemberID,  
            RootCause, PresentCondition, ImprovementsCompleted, RootProblemAttachment, RootCauseDetails,  
            HorozantalDeployment, ScopeOfDeploymentID, InOtherMc, WithIntheDept, InOtherDept, OtherPoints,  
            Benifits, Shortlisted, ApprovalStatus, IEApprovedDate, IEApprovedBy, IEApprovedDept, DRIApprovedDate,  
            DRIApprovedBy, FinanceApprovedDate, ImageApprovedDate, ImageApprovedBy, OriginatedBy, OrigionatedDept,  
            OrigonatedDate, ModifiedBy, ModifiedDate, CreatedBy, CreatedDate, Department, Domain,FinanceApprover  
        )  
        VALUES (  
            @ID, @KaizenType, @Activity, @ActivityDesc, @BenefitArea, @DOCumentNO, @VersionNoDate,  
            @CostCentre, @KaizenRefNo, @BlockId, @BlockDetails, @KaizenTheme, @SuggestedKaizen, @ProblemStatement,  
            @CounterMeasure, @AttachmentBefore, @AttachmentAfter, @AttachmentOthers, @Yield, @CycleTime, @Cost,  
            @ManPower, @Consumables, @Others, @TotalSavings, @IEApproved, @FinanceApprovedID, @TeamMemberID,  
            @RootCause, @PresentCondition, @ImprovementsCompleted, @RootProblemAttachment, @RootCauseDetails,  
            @HorozantalDeployment, @ScopeOfDeploymentID, @InOtherMc, @WithIntheDept, @InOtherDept, @OtherPoints,  
            @Benifits, @Shortlisted, @ApprovalStatus, @IEApprovedDate, @IEApprovedByID, @IEApprovedDept, @DRIApprovedDate,  
            @DriApprovedID, @FinanceApprovedDate, @ImageApprovedDate, @ImageApprovedID, @OriginatedByID, @OrigionatedDept,  
            GETDATE(), @ModifiedByID, GETDATE(), @CreatedId, GETDATE(), @DepartmentID, @DomainID,@FinanceApprovedBy  
        );  
  
  --Insert into KaizenTeamMembers Table   
  INSERT INTO KaizenTeamMembers (KaizenId,EmpID,TeamMemberName, FunctionName,CreatedDate,CreatedBy)  
  SELECT CONVERT(uniqueidentifier,KaizenId),CONVERT(uniqueidentifier,EmpId),TeamMemberName,FunctionName,GETDATE(),CONVERT(uniqueidentifier,Createdby)  
        FROM @KaizenTeam;  
   
  --Insert into KaizenScopeDetails Table ,  
  INSERT INTO KaizenScopeDetails (KaizenId,MC,TargetDate,Responsibility,ScopeStatus,CreatedBy,CreatedDate)  
  SELECT KaizenId,MC,TargetDate,Responsibility,ScopeStatus,CreatedBy,GETDATE()  
        FROM @KaizenScopeDetails;   
  
  ----Insert into Attachments Table  
    
   INSERT INTO Attachments (KaizenID, FileName, CreatedBy, CreatedDate)  
   SELECT KaizenId,FileName,CreatedBy,GETDATE()  
        FROM @AttachmentDetails 
		WHERE KaizenId IS NOT NULL AND FileName IS NOT NULL AND CreatedBy IS NOT NULL ;   
  

                COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
    END CATCH

  END  
  
  END   
  
  
  
  
GO
/****** Object:  StoredProcedure [dbo].[Sp_Kaizen_TeamMemberDelete]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
    
CREATE proc [dbo].[Sp_Kaizen_TeamMemberDelete]       
@EmpId nvarchar(80),    
@KaizenId nvarchar(50)        
as      
Begin            
    delete from KaizenTeamMembers where EmpID=@EmpId AND KaizenID=@KaizenId    
      
     END      
         
GO
/****** Object:  StoredProcedure [dbo].[Sp_Kaizen_Update]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
CREATE proc [dbo].[Sp_Kaizen_Update]       
@KaizenTeam KaizenTeamMembersType readonly,     
@AttachmentDetails KaizenAttachmentType readonly,      
@ID nvarchar(200),      
@KaizenId nvarchar(50),      
@KaizenType nvarchar(10)=null,        
@Activity nvarchar(50)=null,        
@ActivityDesc nvarchar(50)= NULL,        
@BenefitArea nvarchar(10)=null,        
@DocNo nvarchar(50)=null,        
@VersionNoDate nvarchar(50)= NULL,        
@CostCentre nvarchar(50),        
@KaizenRefNo nvarchar(50),        
@Block int=null,        
@BlockDetails nvarchar(50)=null,        
@KaizenTheme nvarchar(50)=null,        
@SuggestedKaizen nvarchar(50)=null,        
@ProblemStatement nvarchar(100)=null,        
@CounterMeasure nvarchar(100)=null,        
@AttachmentBefore nvarchar(50)=null,        
@AttachmentAfter nvarchar(50)=null,        
@AttachmentOthers nvarchar(50)=NULL,        
@Yield nvarchar(50)=null,        
@CycleTime nvarchar(50)=null,        
@Cost int=null,        
@ManPower nvarchar(50)=null,        
@Consumables nvarchar(50)=null,        
@Others nvarchar(50)=null,        
@TotalSavings int=null,        
@ApprovedByIE nvarchar(50)=null,        
@FinanceApprovedBy nvarchar(100) = NULL ,        
@TeamMemberID int = NULL,        
@RootCause nvarchar(50) = NULL,        
@PresentCondition nvarchar(255)=null,        
@ImprovementsCompleted nvarchar(255)=null,        
@RootProblemAttachment nvarchar(50)=NULL,        
@RootCauseDetails nvarchar(max)=NULL,        
@HorozantalDeployment bit=null,        
@ScopeOfDeploymentID int = NULL,        
@InOtherMc nvarchar(200)=NULL,        
@WithIntheDept nvarchar(200)=NULL,        
@InOtherDept nvarchar(200)=NULL,        
@OtherPoints nvarchar(200)=NULL,        
@Benifits nvarchar(255),        
@Shortlisted bit = NULL,        
@ApprovalStatus char(2)= NULL,        
@IEApprovedDate datetime = NULL,        
@IEApprovedBy nvarchar(200) = NULL,        
@IEApprovedDept nvarchar(50)=NULL,        
@DRIApprovedDate datetime=NULL,        
@DRIApprovedBy nvarchar(100) =NULL,        
@FinanceApprovedDate datetime = NULL,        
@ImageApprovedDate datetime = NULL,        
@ImageApprovedBy nvarchar(200) = NULL,        
@OriginatedBy nvarchar(200) = NULL,        
@OrigionatedDept nvarchar(50)=NULL,        
@ModifiedBy nvarchar(200) = NULL ,        
@ModifiedDate nvarchar(200) = NULL,        
@CreatedBy nvarchar(200) = NULL ,        
@Department nvarchar(50) = NULL,        
@Domain nvarchar(50) = NULL        
as        
Begin        
         
  Declare @BlockId nvarchar(50);         
  Declare @IEApproved nvarchar(50);           
  Declare @CreatedId uniqueidentifier;        
  Declare @IEApprovedByID nvarchar(150)=null;        
  Declare @DriApprovedID nvarchar(150)=null;        
  Declare @FinanceApprovedID nvarchar(150)=null;        
  Declare @ImageApprovedID nvarchar(150)=null;        
  Declare @OriginatedByID nvarchar(150);        
  Declare @ModifiedByID nvarchar(150);        
  Declare @DepartmentID nvarchar(150);        
  Declare @DomainID nvarchar(150)        
  set @BlockId=(select ID FROM Blocks WHERE BlockId=@Block)          
  set @IEApproved=(select ID from [dbo].[Users] where UserID= @ApprovedByIE)          
  set @CreatedId=(select ID FROM [dbo].[Users] WHERE EmpID=@CreatedBy)        
  set @IEApprovedByID=(select ID FROM [dbo].[Users] WHERE Email=@ApprovedByIE)        
  set @DriApprovedID=(select ID FROM [dbo].[Users] WHERE EmpID=@DRIApprovedBy)        
  set @FinanceApprovedID=(select ID FROM [dbo].[Users] WHERE UserID=@FinanceApprovedBy)        
  set @ImageApprovedID=(select ID FROM [dbo].[Users] WHERE EmpID='321256')        
  set @OriginatedByID=(select ID FROM [dbo].[Users] WHERE EmpID=@CreatedBy)        
  set @ModifiedByID=(select ID FROM [dbo].[Users] WHERE EmpID=@CreatedBy)        
  set @DepartmentID=(select Department FROM [dbo].[Users] WHERE EmpID=@CreatedBy)        
  set @DomainID=(select Domain FROM [dbo].[Users] WHERE EmpID=@CreatedBy)        
        
            
         Begin        
   BEGIN TRANSACTION  
    BEGIN TRY  
  
        Update Kaizens set        
           KaizenType=@KaizenType, Activity=@Activity, ActivityDesc=@ActivityDesc, BenefitArea=@BenefitArea, DocNo=@DocNo, VersionNoDate=@VersionNoDate,        
            CostCentre=@CostCentre, KaizenRefNo=@KaizenRefNo, Block=@BlockId, BlockDetails=@BlockDetails, KaizenTheme=@KaizenTheme, SuggestedKaizen=@SuggestedKaizen, ProblemStatement=@ProblemStatement,        
            CounterMeasure=@CounterMeasure, AttachmentBefore=@AttachmentBefore, AttachmentAfter=@AttachmentAfter, AttachmentOthers=@AttachmentOthers, Yield=@Yield, CycleTime=@CycleTime, Cost=@Cost,        
   ManPower=@ManPower, Consumables=@Consumables, Others=@Others, TotalSavings=@TotalSavings, ApprovedByIE=@IEApproved, FinanceApprovedBy=@FinanceApprovedID, TeamMemberID=@TeamMemberID,      
         
            RootCause=@RootCause, PresentCondition=@PresentCondition, ImprovementsCompleted=@ImprovementsCompleted, RootProblemAttachment=@RootProblemAttachment, RootCauseDetails=@RootCauseDetails,        
            HorozantalDeployment=@HorozantalDeployment, ScopeOfDeploymentID=@ScopeOfDeploymentID, InOtherMc=@InOtherMc, WithIntheDept=@WithIntheDept, InOtherDept=@InOtherDept, OtherPoints=@OtherPoints,        
            Benifits=@Benifits, Shortlisted=@Shortlisted, ApprovalStatus=@ApprovalStatus, IEApprovedDate=@IEApprovedDate, IEApprovedBy=@IEApprovedByID, IEApprovedDept=@IEApprovedDept, DRIApprovedDate=@DRIApprovedDate,        
            DRIApprovedBy=@DriApprovedID, FinanceApprovedDate=@FinanceApprovedDate, ImageApprovedDate=@ImageApprovedDate, ImageApprovedBy=@ImageApprovedID, OriginatedBy=@OriginatedByID, OrigionatedDept=@OrigionatedDept,        
            ModifiedBy=@ModifiedByID, ModifiedDate=GETDATE(), FinanceApprover=@FinanceApprovedBy        
        where KaizenId= @KaizenId      
    --CreatedBy=@CreatedId     
	--Department=@DepartmentID, Domain=@DomainID,
    delete from KaizenTeamMembers where KaizenID=@ID           
   INSERT INTO KaizenTeamMembers (KaizenId,EmpID,TeamMemberName, FunctionName,CreatedDate,CreatedBy)        
  SELECT CONVERT(uniqueidentifier,KaizenId),CONVERT(uniqueidentifier,EmpId),TeamMemberName,FunctionName,GETDATE(),CONVERT(uniqueidentifier,Createdby)        
       FROM @KaizenTeam;       
      
  INSERT INTO Attachments (KaizenID, FileName, ModifiedBy,ModifiedDate)      
   SELECT KaizenId,FileName,Createdby,GETDATE()      
        FROM @AttachmentDetails WHERE KaizenId IS NOT NULL AND FileName IS NOT NULL AND Createdby IS NOT NULL;     
       
        
      COMMIT TRANSACTION;  
    END TRY  
        BEGIN CATCH  
        ROLLBACK TRANSACTION;  
    END CATCH  
  END        
         END   
  
  
GO
/****** Object:  StoredProcedure [dbo].[Sp_Login]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sp_Login]   
    @Empid NVARCHAR(300)  
AS  
BEGIN  
     
    SELECT TOP 1  
        u.EmpID,   
  u.ID,  
        u.Password,   
        u.FirstName,  
		U.ImageApprover,
  ut.UserDesc as UserRole,  
  ut.UserCode as UserRolecode,
        d.DepartmentName,   
        dm.DomainName,
		d.ID,
		(SELECT ID FROM Departments WHERE DomainID =  u.Domain AND ID =  u.Department) AS DepartmentID,
        --mgr.FirstName AS ManagerName,  
        --mgr.Email AS ManagerEmail,  
  IE.Email AS IEEMAIL,  
  Fin.Email AS FinanceEmail  
  
    FROM   
        [dbo].[Users] u  
    LEFT JOIN   
        [dbo].[Departments] d ON u.Department = d.ID  
    LEFT JOIN   
        [dbo].[Domains] dm ON u.Domain = dm.ID  
    --LEFT JOIN   
    --    [dbo].[Users] mgr ON u.Department = mgr.Department AND mgr.UserType = (SELECT ID FROM [dbo].[UserType] WHERE UserDesc = 'Manager')  
   LEFT JOIN   
        [dbo].[Users]  Fin on  fin.UserType=(SELECT ID FROM [dbo].[UserType] WHERE UserCode='FIN')  
   LEFT JOIN   
          [dbo].[Users] IE ON  IE.UserType = (SELECT ID FROM [dbo].[UserType] WHERE UserCode='IED')  
LEFT JOIN   
  [dbo].UserType UT ON U.UserType = UT.ID  
    WHERE   
        u.EmpID =  @Empid and u.Status=1  
  --order by mgr.CreatedDate desc  
END
--exec Sp_Login
--@Empid='614614'
GO
/****** Object:  StoredProcedure [dbo].[Sp_LoginWinnerDetails]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sp_LoginWinnerDetails]
AS
BEGIN
    SELECT 
        U.FirstName,
        WL.Category,
        WL.WinnerimgPath,
		WL.EndDate
    FROM 
        WinnersList WL
    LEFT JOIN 
        Users U
    ON 
        WL.EmpGUID = U.ID
		
    ORDER BY 
        WL.CreatedDate desc;
END;
GO
/****** Object:  StoredProcedure [dbo].[Sp_Register]    Script Date: 17-09-2024 18:09:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

  
CREATE PROCEDURE [dbo].[Sp_Register]  
    @UserID NVARCHAR(50),  
    @EmpID NVARCHAR(50),  
    @FirstName NVARCHAR(50),  
 @MiddleName NVARCHAR(50)= NULL,  
 @LastName NVARCHAR(50),  
    @Gender CHAR(1),  
    @Did int,  
    @Deptid int,  
 @BlockId int,  
    @MobileNumber BIGINT = NULL,  
    @Email NVARCHAR(100) = NULL,  
    @Password NVARCHAR(100), -- Ensure this is hashed before storing  
  @result BIT Out ,
  @Cadre int
  
AS  
BEGIN  
  
    SET NOCOUNT ON;  
  -- Check for duplicate EmpID  
  
  IF EXISTS (SELECT 1 FROM [Users] WHERE EmpID = @EmpID)  
    BEGIN  
        SET @result = 1; -- Duplicate  
    END  
    ELSE  
    
   BEGIN -- Insert the new user into the Users table  
  
   -- Fetch the unique domain ID based on the provided Did  
        DECLARE @DomainId UNIQUEIDENTIFIER;  
        SELECT @DomainId = ID FROM [Domains] WHERE DomainID = @Did;  
  
  declare @Usertypeid UNIQUEIDENTIFIER; 
  Declare @cardeId nvarchar(100);
  select @Usertypeid = ID from [Usertype] where UserCode='EMP';
  set @cardeId= (SELECT ID FROM [dbo].[Cadre] WHERE CadreId = @Cadre)
  
   Declare @BlocksId nvarchar(100);  
   set @BlocksId=(select ID From [dbo].[Blocks] where BlockId=@BlockId)  
  -- Fetch the unique department ID based on the provided Deptid  
        DECLARE @DepartmentId UNIQUEIDENTIFIER;  
        SELECT @DepartmentId = ID FROM [Departments] WHERE DeptID = @Deptid;  
  
   -- Insert the new user into the Users table  
  
   INSERT INTO [dbo].[Users] (  
    [ID], [UserID], [EmpID], [FirstName],[MiddleName],[LastName], [Gender], [Domain],  
    [Department], [MobileNumber], [Email], [Password],[Block],[Status],[UserType],[Cadre]  
   )  
   VALUES (  
    NEWID(), -- Generates a new uniqueidentifier for the ID  
    @EmpID, @EmpID, @FirstName,@MiddleName,@LastName, @Gender, @DomainId,  
    @DepartmentId, @MobileNumber, @Email, @Password,@BlocksId,1,@Usertypeid,@cardeId  
   );  
  
        -- Set result message  
    SET @result = 0; -- Success  
  END   
    
END  
GO
/****** Object:  StoredProcedure [dbo].[Sp_UpdateBlock]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sp_UpdateBlock]    
@blockname nvarchar(100),  
@blockId  nvarchar(50) ,
@ModifiedBy nvarchar(100)= null
AS        
 BEGIN    
 Declare @ModifiedID nvarchar(100);
 set @ModifiedID=(select ID FROM [dbo].[Users] WHERE EmpID=@ModifiedBy)
 BEGIN
     update Blocks set BlockName=@blockname,ModifiedBy=@ModifiedID,ModifiedDate=GETDATE()  where BlockId= @blockId     
 END        
 
 END
GO
/****** Object:  StoredProcedure [dbo].[Sp_UpdateBlockStatus]    Script Date: 10-09-2024 15:10:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Sp_UpdateBlockStatus]           
@ID int,                     
@status bit,
@Message nvarchar(250) OUTPUT
AS        
BEGIN 
    DECLARE @GID uniqueidentifier,
            @Usercount int;
    SET @GID = (SELECT ID FROM Blocks WHERE BlockId = @ID);  
    SET @Usercount = (SELECT COUNT(EmpID) FROM Users WHERE Block = @GID);
    
    BEGIN
    IF @Usercount > 0 AND @status = 0
    BEGIN
        SET @Message = 'Block cannot be Inactive as it has associated users.';
    END
    ELSE
    BEGIN
        UPDATE [Blocks] 
        SET Status = @status 
        WHERE BlockId = @ID;
    END
END
END
	 

GO
/****** Object:  StoredProcedure [dbo].[Sp_UpdateDepartment]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sp_UpdateDepartment]  
@deptId int,
@DomainId nvarchar(10),    
@DomainName  nvarchar(50),
@department nvarchar(50),
@ModifiedBy nvarchar(100) = null
AS
BEGIN
Declare @Domain uniqueidentifier,
     @ModifiedId nvarchar(100);
	 SET @Domain = (SELECT ID FROM [dbo].Domains WHERE DomainID = @DomainId and DomainName = @DomainName);
 set @ModifiedId=(select ID FROM [dbo].[Users] WHERE EmpID=@ModifiedBy)
 BEGIN               
     update Departments set DomainId=@Domain,DepartmentName=@department,ModifiedBy=@ModifiedId ,ModifiedDate= GETDATE() where DeptId= @deptId      
 END
 END 
GO
/****** Object:  StoredProcedure [dbo].[Sp_UpdateDepartmentStatus]    Script Date: 10-09-2024 15:12:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Sp_UpdateDepartmentStatus]           
@ID int,                     
@status bit,
@Message nvarchar(250) OUTPUT
AS        
BEGIN 
    DECLARE @GID uniqueidentifier,
            @Usercount int;
    SET @GID = (SELECT ID FROM Departments WHERE DeptId = @ID);  
    SET @Usercount = (SELECT COUNT(EmpID) FROM Users WHERE Department = @GID);
    BEGIN
    IF @Usercount > 0 AND @status = 0
    BEGIN
        SET @Message = 'Department cannot be Inactive as it has associated users.';
    END
    ELSE
    BEGIN
        UPDATE [Departments] 
        SET Status = @status 
        WHERE DeptId = @ID;
    END
END
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_UpdateDomain]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sp_UpdateDomain]      
@domainname nvarchar(100),    
@domainId  nvarchar(50),
@ModifiedBy nvarchar(100) = null
AS
BEGIN
Declare @ModifiedId nvarchar(100);
 set @ModifiedId=(select ID FROM [dbo].[Users] WHERE EmpID=@ModifiedBy)
 BEGIN               
     update Domains set DomainName=@domainname,ModifiedBy=@ModifiedId ,ModifiedDate= GETDATE() where DomainID= @domainId      
 END
 END 
GO
/****** Object:  StoredProcedure [dbo].[Sp_UpdateTheme]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Sp_UpdateTheme]  
@SessionId INT,  
@Theme NVARCHAR(50)  
AS  
BEGIN   
    DECLARE @SessionGuid UNIQUEIDENTIFIER;  
    SET @SessionGuid = (SELECT ID FROM Users WHERE EmpID = @SessionId);  
    
    IF EXISTS (SELECT 1 FROM Themes WHERE ThemeID = 1)
    BEGIN
        -- Update the existing row
        UPDATE Themes         
        SET 
            Theme = @Theme, 
            ModifiedBy = @SessionGuid, 
            ModifiedDate = GETDATE()
        WHERE 
            ThemeID = 1; 
    END
    ELSE
    BEGIN
        INSERT INTO Themes (Theme, ModifiedBy, ModifiedDate)
		VALUES (@Theme, @SessionGuid, GETDATE());

    END
END  
GO
/****** Object:  StoredProcedure [dbo].[Sp_UpdateWinner]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sp_UpdateWinner] 
    @ID INT,
    @WID UNIQUEIDENTIFIER,    
    @StartDate DATETIME,    
    @EndDate DATETIME,    
    @SessionId INT	,
	 @imgpath nvarchar(max) =''
AS    
BEGIN    
	DECLARE @SessionIDGuid UNIQUEIDENTIFIER;
    -- Fetch the session ID from the Users table
    SET @SessionIDGuid = (SELECT ID FROM [dbo].[Users] WHERE EmpID = @ID);  
    -- Update the WinnersList table
    UPDATE WinnersList     
    SET StartDate = @StartDate, 
        EndDate = @EndDate, 
        ModifiedBy = @SessionIDGuid,
		ModifiedDate = GETDATE(),
		  WinnerimgPath = CASE 
                           WHEN @imgpath IS NOT NULL THEN @imgpath 
                           ELSE WinnerimgPath 
                       END 
    WHERE ID = @WID;

END;
GO
/****** Object:  StoredProcedure [dbo].[Sp_Upload_Users]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Sp_Upload_Users]
@EmpId INT,
@FirstName VARCHAR(200),
@MiddleName VARCHAR(200),
@LastName VARCHAR(200),
@Gender CHAR(1),
@Email VARCHAR(100),
@Block VARCHAR(100),
@Domain VARCHAR(100),
@Department VARCHAR(100),
@Cadre VARCHAR(100),
@MobileNo VARCHAR(100),
@Status VARCHAR(100), 
@UserType VARCHAR(100),
@Password VARCHAR(100),
@ErrorMessage NVARCHAR(500) OUTPUT
AS
BEGIN
    -- Initialize the error message
    SET @ErrorMessage = '';

	-- Check for empty EmpId
    IF @EmpId IS NULL OR @EmpId <= 0
    BEGIN
        SET @ErrorMessage = 'EmpId cannot be empty'
        RETURN
    END

    -- Check for empty FirstName
    IF @FirstName IS NULL OR LEN(@FirstName) = 0
    BEGIN
        SET @ErrorMessage = 'First Name cannot be empty.'
        RETURN
    END

    -- Check for empty LastName
    IF @LastName IS NULL OR LEN(@LastName) = 0
    BEGIN
        SET @ErrorMessage = 'Last Name cannot be empty.'
        RETURN
    END

    -- Check for empty Gender
    IF @Gender IS NULL OR LEN(@Gender) = 0
    BEGIN
        SET @ErrorMessage = 'Gender cannot be empty.'
        RETURN
    END

    -- Check if Gender is valid
    IF @Gender NOT IN ('F', 'M')
    BEGIN
        SET @ErrorMessage = 'Gender must be either F or M.'
        RETURN
    END

    -- Check for empty Email
    IF @Email IS NULL OR LEN(@Email) = 0
    BEGIN
        SET @ErrorMessage = 'Email cannot be empty.'
        RETURN
    END

    -- Validate email format using a basic pattern 
    IF @Email NOT LIKE '%_@__%.__%'
    BEGIN
        SET @ErrorMessage = 'Email is not in a valid format.'
        RETURN
    END

    -- Check for empty MobileNo
    IF @MobileNo IS NULL OR LEN(@MobileNo) = 0
    BEGIN
        SET @ErrorMessage = 'Mobile Number cannot be empty.'
        RETURN
    END

    -- Validate mobile number format (must be exactly 10 digits)
    IF LEN(@MobileNo) != 10 OR @MobileNo NOT LIKE '%[0-9]%'
    BEGIN
        SET @ErrorMessage = 'Mobile Number must be exactly 10 digits.'
        RETURN
    END

	 -- Check for empty Block
    IF @Block IS NULL OR LEN(@Block) = 0
    BEGIN
        SET @ErrorMessage = 'Block cannot be empty.'
        RETURN
    END

    -- Check for empty Domain
    IF @Domain IS NULL OR LEN(@Domain) = 0
    BEGIN
        SET @ErrorMessage = 'Domain cannot be empty.'
        RETURN
    END

    -- Check for empty Department
    IF @Department IS NULL OR LEN(@Department) = 0
    BEGIN
        SET @ErrorMessage = 'Department cannot be empty.'
        RETURN
    END

    -- Check for empty Cadre
    IF @Cadre IS NULL OR LEN(@Cadre) = 0
    BEGIN
        SET @ErrorMessage = 'Cadre cannot be empty.'
        RETURN
    END

    -- Check if Status is valid and convert it to an integer value
    DECLARE @Statusid INT;
    IF @Status = 'Active'
        SET @Statusid = 1;
    ELSE IF @Status = 'Inactive'
        SET @Statusid = 0;
    ELSE IF @Status = 'Block'
        SET @Statusid = 2;
    ELSE
    BEGIN
        SET @ErrorMessage = 'Status must be one of the following: Active, Inactive, Block'
        RETURN
    END

    -- Check if UserType is valid
    DECLARE @UserTypeid UNIQUEIDENTIFIER;
    IF @UserType IS NULL OR LEN(@UserType) = 0
    BEGIN
        SET @ErrorMessage = 'User Type cannot be empty.'
        RETURN
    END

    SELECT @UserTypeid = ID FROM UserType WHERE UserDesc = @UserType
    IF @UserTypeid IS NULL
    BEGIN
        SET @ErrorMessage = 'User Type not found in UserTypes table.'
        RETURN
    END
	DECLARE @Blockid UNIQUEIDENTIFIER
    DECLARE @Domainid UNIQUEIDENTIFIER
    DECLARE @Deptid UNIQUEIDENTIFIER 
    DECLARE @Cadreid UNIQUEIDENTIFIER
    DECLARE @guid UNIQUEIDENTIFIER = NEWID();

	 -- Check for Block existence
    SELECT @Blockid = ID FROM Blocks WHERE BlockName = @Block
    IF @Blockid IS NULL
    BEGIN
        SET @ErrorMessage = 'Block not found in Blocks table.'
        RETURN
    END

    -- Check for Domain existence
    SELECT @Domainid = ID FROM Domains WHERE DomainName = @Domain
    IF @Domainid IS NULL
    BEGIN
        SET @ErrorMessage = 'Domain not found in Domains table.'
        RETURN
    END

    -- Check for Department existence
    SELECT @Deptid = ID FROM Departments WHERE DepartmentName = @Department
    IF @Deptid IS NULL
    BEGIN
        SET @ErrorMessage = 'Department not found in Departments table.'
        RETURN
    END

    -- Check for Cadre existence
    SELECT @Cadreid = ID FROM Cadre WHERE cadreDesc = @Cadre
    IF @Cadreid IS NULL
    BEGIN
        SET @ErrorMessage = 'Cadre not found in Cadre table.'
        RETURN
    END

    -- If the EmpID exists, update the record, else insert a new record
    IF EXISTS (SELECT 1 FROM Users WHERE EmpID = @EmpId)
    BEGIN
        -- Update existing record
        UPDATE Users
        SET FirstName = @FirstName,
            MiddleName = @MiddleName,
            LastName = @LastName,
            Gender = @Gender,
            Email = @Email,
			Block=@Blockid,
            Domain = @Domainid,
            Department = @Deptid,
            Cadre = @Cadreid,
            MobileNumber = @MobileNo,
            Status = @Statusid,
            UserType = @UserTypeid,
            Password = @Password
        WHERE EmpID = @EmpId
    END
    ELSE
    BEGIN
        -- Insert new record
        INSERT INTO Users (ID, UserID, EmpID, FirstName, MiddleName, LastName, Gender, Email,Block, Domain, Department, Cadre, MobileNumber, Status, UserType, Password)
        VALUES (@guid, @EmpId, @EmpId, @FirstName, @MiddleName, @LastName, @Gender, @Email,@Blockid, @Domainid, @Deptid, @Cadreid, @MobileNo, @Statusid, @UserTypeid, @Password)
    END

    -- Set the output message to success if all operations are successful
    SET @ErrorMessage = 'Operation completed successfully.'
END
GO
/****** Object:  StoredProcedure [dbo].[SP_USERLOG]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_USERLOG]
	@USERID INT = NULL,
	@COMMAND INT = 0
AS
BEGIN
	SET NOCOUNT ON;
	IF(@COMMAND = 0)
		BEGIN
			INSERT INTO USERLOG (USERID,LOGIN,LOGOUT,CreatedDate) VALUES (@USERID,GETDATE(),NULL,GETDATE())
		END
	ELSE IF (@COMMAND = 1)
		BEGIN
			UPDATE USERLOG SET LOGOUT = GETDATE() WHERE USERID = @USERID
		END
END

GO
/****** Object:  StoredProcedure [dbo].[Sp_Winner_checkuser]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sp_Winner_checkuser]  
    @EmpId NVARCHAR(50)  
AS  
BEGIN  
    SET NOCOUNT ON;  
  
    -- Check if the employee ID does not exist in the Users table  
    IF NOT EXISTS (SELECT 1 FROM Users WHERE EmpId = @EmpId)  
    BEGIN  
        -- Return 0 if the employee ID does not exist  
        SELECT 0 AS UserDoesNotExist;  
    END  
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateApprovalStatus]    Script Date: 05-09-2024 20:04:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateApprovalStatus]
    @KaizenId varchar(50),
    @ApprovalStatus varchar(10),
    @Rejectionreason varchar(max),
    @Empid varchar(100)
	
AS
BEGIN
    DECLARE @KaiId uniqueidentifier;
    DECLARE @CurrentDate DATE = GETDATE();
    DECLARE @IMAGEAPPROVERID uniqueidentifier;




    SET @IMAGEAPPROVERID = (SELECT ID FROM Users WHERE EmpID = @Empid);
    SET @KaiId = (SELECT Id FROM kaizens WHERE kaizenid = @KaizenId);    
    


    BEGIN
        UPDATE kaizens
        SET ApprovalStatus = @ApprovalStatus,
            RejectionReason = @Rejectionreason,
            DRIApprovedDate = CASE WHEN @ApprovalStatus = '4' THEN @CurrentDate ELSE DRIApprovedDate END,
			DRIApprovedBy =  CASE WHEN @ApprovalStatus IN ('4', '5') THEN @IMAGEAPPROVERID ELSE DRIApprovedBy END,	
            FinanceApprovedDate = CASE WHEN @ApprovalStatus = '8' THEN @CurrentDate ELSE FinanceApprovedDate END,
            ImageApprovedDate = CASE WHEN @ApprovalStatus = '2' THEN @CurrentDate ELSE ImageApprovedDate END,
            ImageApprovedBy = CASE WHEN @ApprovalStatus IN ('2', '3') THEN @IMAGEAPPROVERID ELSE ImageApprovedBy END,	
			FinanceApprovedBy  = CASE WHEN @ApprovalStatus IN ('8', '9') THEN @IMAGEAPPROVERID ELSE FinanceApprovedBy END,	
			ApprovedByIE =  CASE WHEN @ApprovalStatus IN ('6', '7') THEN @IMAGEAPPROVERID ELSE ApprovedByIE END,	
            IEApprovedDate = CASE WHEN @ApprovalStatus = '6' THEN @CurrentDate ELSE IEApprovedDate END
        WHERE Id = @KaiId;
    END
END;
GO

/****** Object:  StoredProcedure [dbo].[Sp_Get_kaizen_details_On_clickdashboard]    Script Date: 10-09-2024 15:00:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Sp_Get_kaizen_details_On_clickdashboard]
(
    @StartDate DATE = NULL,
    @EndDate DATE = NULL,
    @Domain NVARCHAR(100) = NULL,
    @Department NVARCHAR(100) = NULL,
    @Block NVARCHAR(100) = NULL,
    @Cadre NVARCHAR(100) = NULL,
    @Status NVARCHAR(50) = NULL,
    @Shortlisted NVARCHAR(50) = NULL,
    @Role NVARCHAR(50) = NULL,
    @UserId NVARCHAR(50) = NULL
)
AS
BEGIN
    SET @StartDate = NULLIF(@StartDate, '')
    SET @EndDate = NULLIF(@EndDate, '')
    SET @Domain = NULLIF(@Domain, '')
    SET @Department = NULLIF(@Department, '')
    SET @Block = NULLIF(@Block, '')
    SET @Cadre = NULLIF(@Cadre, '')
    SET @Status = NULLIF(@Status, '')
    SET @Shortlisted = NULLIF(@Shortlisted, '')

    DECLARE @Userguid NVARCHAR(MAX)
    DECLARE @ImageApprover NVARCHAR(50)
    SELECT @Userguid = ID FROM Users WHERE ID = @UserId
    SET @ImageApprover = @Role

    SELECT DISTINCT Kaizens.KaizenId, KaizenType, Activity, ActivityDesc, Kaizens.[BenefitArea], DocNo, VersionNoDate, CostCentre, KaizenRefNo,
                    Blocks.BlockName AS Block, BlockDetails, SuggestedKaizen, ProblemStatement, CounterMeasure, AttachmentBefore, AttachmentAfter, AttachmentOthers, Yield, CycleTime, Cost, ManPower, Consumables, others, TotalSavings, Kaizens.TeamMemberID, RootCause, PresentCondition, ImprovementsCompleted, RootProblemAttachment, RootCauseDetails, ScopeOfDeploymentId, InOtherMC, WithIntheDept, InOtherDept, OtherPoints, Benifits, OrigionatedDept, OrigonatedDate,
                    KaizenTheme, Kaizens.ApprovalStatus AS Status, Kaizens.CreatedBy AS PostedBy, Kaizens.ModifiedDate,
                    STUFF((SELECT ', ' + TeamMemberName
                           FROM KaizenTeamMembers
                           WHERE KaizenID = Kaizens.ID
                           FOR XML PATH('')), 1, 2, '') AS TeamName,
                    CASE 
                        WHEN HorozantalDeployment = 0 THEN 'NO' 
                        WHEN HorozantalDeployment = 1 THEN 'YES'
                    END AS HorozantalDeployment,
                    CASE 
                        WHEN CycleTime > 0 THEN 'YES' 
                        WHEN CycleTime = 0 THEN 'NO'
                        WHEN CycleTime IS NULL THEN 'NO'
                    END AS IEApprovedDept, 
                    CASE 
                        WHEN Cost > 100000 THEN 'YES' 
                        WHEN Cost <= 100000 THEN 'NO'
                    END AS FinnanceDeptAppr,
                    CASE 
                        WHEN Shortlisted = 0 THEN 'NO' 
                        WHEN Shortlisted = 1 THEN 'YES'
                    END AS Shortlisted,
                    CASE 
                        WHEN Kaizens.ApprovalStatus = 8 THEN 'Approved Kaizen'
                        WHEN Kaizens.ApprovalStatus = 6 AND Kaizens.FinanceApprovedBy IS NULL THEN 'Approved Kaizen'
                        WHEN Kaizens.ApprovalStatus = 4 AND Kaizens.ApprovedByIE IS NULL AND Kaizens.FinanceApprovedBy IS NULL THEN 'Approved Kaizen'
                        WHEN Kaizens.ApprovalStatus = 4 AND Kaizens.ApprovedByIE IS NULL AND Kaizens.FinanceApprovedBy IS NOT NULL THEN 'Waiting For Finance Approval'
                        WHEN Kaizens.ApprovalStatus = 4 AND Kaizens.ApprovedByIE IS NOT NULL AND Kaizens.FinanceApprovedBy IS NULL THEN 'Waiting For IE Approval'
                        WHEN Kaizens.ApprovalStatus = 4 AND Kaizens.ApprovedByIE IS NOT NULL AND Kaizens.FinanceApprovedBy IS NOT NULL THEN 'Waiting For IE Approval'
                        WHEN Kaizens.ApprovalStatus = 0 THEN 'Saved' 
                        WHEN Kaizens.ApprovalStatus = 1 THEN 'Waiting For Image Approval' 
                        WHEN Kaizens.ApprovalStatus IN (2, 15) THEN 'Waiting For DRI Approval'
                        WHEN Kaizens.ApprovalStatus = 3 THEN 'Image Rejected'
                        WHEN Kaizens.ApprovalStatus = 5 THEN 'DRI Rejected'
                        WHEN Kaizens.ApprovalStatus = 6 THEN 'Waiting For Finance Approval'
                        WHEN Kaizens.ApprovalStatus = 7 THEN 'IE Rejected'
                        WHEN Kaizens.ApprovalStatus = 9 THEN 'Finance Rejected'
                        WHEN Kaizens.ApprovalStatus = 14 THEN 'DELETED'	
                    END AS ApprovalStatus,
                    Users.FirstName AS CreatedBy,
                    CONVERT(VARCHAR, Kaizens.CreatedDate, 105) AS CreatedDate,
                    UserType.UserDesc AS Role
    FROM 
        [dbo].[Kaizens]
    LEFT JOIN 
        KaizenTeamMembers ON KaizenTeamMembers.KaizenID = Kaizens.ID
    INNER JOIN 
        Users ON Users.ID = Kaizens.CreatedBy
    LEFT JOIN 
        ApprovalStatus ON ApprovalStatus.StatusID = Kaizens.ApprovalStatus
    LEFT JOIN 
        Domains ON Domains.ID = Kaizens.Domain
    LEFT JOIN 
        Departments ON Departments.ID = Kaizens.Department
    LEFT JOIN 
        Blocks ON Blocks.ID = Kaizens.Block
    LEFT JOIN 
        UserType ON UserType.ID = Users.UserType
    LEFT JOIN
        Cadre ON Cadre.ID = Users.Cadre
    WHERE 

        (@StartDate IS NULL OR Kaizens.CreatedDate >= @StartDate) AND
        (@EndDate IS NULL OR Kaizens.CreatedDate <= @EndDate) AND
        (@Domain IS NULL OR Domains.DomainName = @Domain) AND
        (@Department IS NULL OR Departments.DepartmentName = @Department) AND
        (@Block IS NULL OR Blocks.BlockName = @Block) AND
        (@Cadre IS NULL OR Cadre.cadreDesc = @Cadre) AND
        (@Status IS NULL OR
            CASE 
                WHEN Kaizens.ApprovalStatus = 8 THEN 'Approved Kaizen'
                WHEN Kaizens.ApprovalStatus = 6 AND Kaizens.FinanceApprovedBy IS NULL THEN 'Approved Kaizen'
                WHEN Kaizens.ApprovalStatus = 4 AND Kaizens.ApprovedByIE IS NULL AND Kaizens.FinanceApprovedBy IS NULL THEN 'Approved Kaizen'
                WHEN Kaizens.ApprovalStatus = 4 AND Kaizens.ApprovedByIE IS NULL AND Kaizens.FinanceApprovedBy IS NOT NULL THEN 'Waiting For Finance Approval'
                WHEN Kaizens.ApprovalStatus = 4 AND Kaizens.ApprovedByIE IS NOT NULL AND Kaizens.FinanceApprovedBy IS NULL THEN 'Waiting For IE Approval'
                WHEN Kaizens.ApprovalStatus = 4 AND Kaizens.ApprovedByIE IS NOT NULL AND Kaizens.FinanceApprovedBy IS NOT NULL THEN 'Waiting For IE Approval'
                WHEN Kaizens.ApprovalStatus = 0 THEN 'Saved' 
                WHEN Kaizens.ApprovalStatus = 1 THEN 'Waiting For Image Approval' 
                WHEN Kaizens.ApprovalStatus IN (2, 15) THEN 'Waiting For DRI Approval'
                WHEN Kaizens.ApprovalStatus = 3 THEN 'Image Rejected'
                WHEN Kaizens.ApprovalStatus = 5 THEN 'DRI Rejected'
                WHEN Kaizens.ApprovalStatus = 6 THEN 'Waiting For Finance Approval'
                WHEN Kaizens.ApprovalStatus = 7 THEN 'IE Rejected'
                WHEN Kaizens.ApprovalStatus = 9 THEN 'Finance Rejected'
                WHEN Kaizens.ApprovalStatus = 14 THEN 'DELETED'	
            END = @Status
        ) AND
        (@Shortlisted IS NULL OR 
            (@Shortlisted = 'YES' AND Kaizens.Shortlisted = 1) 
            OR 
            (@Shortlisted = 'NO' AND Kaizens.Shortlisted = 0)
        ) AND
        (
            (@ImageApprover = 'True' AND Kaizens.ApprovalStatus = 1) OR
			((@Role IN ('FIN', 'IED', 'MGR') AND (
                (Kaizens.ApprovalStatus = 8) OR
                (Kaizens.ApprovalStatus = 6 AND Kaizens.FinanceApprovedBy IS NULL) OR
                (Kaizens.ApprovalStatus = 4 AND Kaizens.ApprovedByIE IS NULL AND Kaizens.FinanceApprovedBy IS NULL))AND
					(
						(@Role = 'FIN' AND Kaizens.FinanceApprovedBy = @UserId) OR
						(@Role = 'IED' AND Kaizens.ApprovedByIE = @UserId) OR
						(@Role = 'MGR' AND Kaizens.DRIApprovedBy = @UserId)
					)
			)
			
			) OR
			  (@Role = 'FIN' AND Kaizens.ApprovalStatus in (6,4,9) AND (Kaizens.ApprovedByIE is NULL or Kaizens.ApprovedByIE is NOt NULL )  AND Kaizens.FinanceApprovedBy = @Userguid) OR
            (@Role = 'MGR' AND Kaizens.ApprovalStatus IN (2, 15, 5)AND Kaizens.DRIApprovedBy=@Userguid and Kaizens.DRIApprovedBy=@Userguid) OR
            (@Role = 'IED' AND Kaizens.ApprovalStatus IN (4,7) AND Kaizens.ApprovedByIE = @Userguid) OR
            (@Role = 'ADM' AND Kaizens.ApprovalStatus != 0) OR
            (@UserId IS NOT NULL AND EXISTS (SELECT 1 
                                             FROM KaizenTeamMembers 
                                             WHERE KaizenTeamMembers.KaizenID = Kaizens.ID 
                                             AND KaizenTeamMembers.EmpID = @UserId)) OR
            (@Role = 'EMP' AND Kaizens.CreatedBy = @Userguid)
        ) 
        AND (Kaizens.ApprovalStatus != 14 OR @Role = 'ADM')
    ORDER BY ModifiedDate DESC
END
GO



/****** Object:  StoredProcedure [dbo].[Sp_GetManagers]    Script Date: 10-09-2024 12:12:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sp_GetManagers]
    @Name NVARCHAR(100) = NULL,
    @EmpID NVARCHAR(50) = NULL,
    @Email NVARCHAR(100) = NULL,
    @UserDesc NVARCHAR(100) = NULL,
    @Domain NVARCHAR(100) = NULL,
    @Department NVARCHAR(100) = NULL,
    @Gender NVARCHAR(10) = NULL,
    @Cadre NVARCHAR(50) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        u.ID,
        u.UserID,
        u.EmpID,
        -- Modify name concatenation to handle NULLs
        (u.FirstName + ' ' + ISNULL(u.MiddleName + ' ', '') + ISNULL(u.LastName, '')) AS Name,
        u.Email,
        u.MobileNumber,
        u.Gender,
        d.DomainName AS Domain, -- Fetch Domain Name
        dept.DepartmentName AS Department, -- Fetch Department Name
        c.cadreDesc AS Cadre, -- Fetch Cadre Name
        ut.UserDesc AS UserType -- Fetch User Type
      
    FROM Users u
    -- Join Domain Table
    LEFT JOIN Domains d ON u.Domain = d.ID
    -- Join Department Table
    LEFT JOIN Departments dept ON u.Department = dept.ID
    -- Join Cadre Table
    LEFT JOIN Cadre c ON u.Cadre = c.ID
    -- Join UserType Table
    INNER JOIN UserType ut ON u.UserType = ut.ID
    WHERE ut.UserDesc IN ('Manager', 'IE DEPT', 'Finance')
      AND u.Status = 1
      AND (@Name IS NULL OR (u.FirstName + ' ' + ISNULL(u.MiddleName + ' ', '') + ISNULL(u.LastName, '')) LIKE '%' + @Name + '%')
      AND (@EmpID IS NULL OR u.EmpID = @EmpID)
      AND (@Email IS NULL OR u.Email LIKE '%' + @Email + '%')
      AND (@Domain IS NULL OR d.DomainName = @Domain) -- Filter by Domain Name
      AND (@Department IS NULL OR dept.DepartmentName = @Department) -- Filter by Department Name
      AND (@Gender IS NULL OR u.Gender = @Gender)
      AND (@Cadre IS NULL OR c.cadreDesc = @Cadre); -- Filter by Cadre Name
END

GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateDomainStatus]    Script Date: 10-09-2024 15:20:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_UpdateDomainStatus]             
@ID int,                     
@status bit,
@Message nvarchar(250) OUTPUT
AS        
BEGIN 
    DECLARE @GID uniqueidentifier,
            @Usercount int;
    SET @GID = (SELECT ID FROM Domains WHERE DomainID = @ID);  
    SET @Usercount = (SELECT COUNT(EmpID) FROM Users WHERE Domain = @GID);
    
    BEGIN
    IF @Usercount > 0 AND @status = 0
    BEGIN
        SET @Message = 'Domain cannot be Inactive as it has associated users.';
    END
    ELSE
    BEGIN
        UPDATE [Domains] 
        SET Status = @status 
        WHERE DomainID = @ID;
    END
END
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_UserProfile]    Script Date: 12-09-2024 15:59:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Sp_UserProfile]      
@EmpID nvarchar(8),    
@FirstName nvarchar(50),
@MiddleName nvarchar(50) = null,
@LastName nvarchar(50) ,
@Email nvarchar(100)
AS
 BEGIN               
     update Users set FirstName=@FirstName,MiddleName=@MiddleName,LastName=@LastName,Email=@Email where EmpID=@EmpID
 END
 
GO

