/****** Object:  Table [dbo].[UserType]    Script Date: 03-10-2024 19:36:26 ******/

-- Check and insert Admin user type based on UserCode
IF NOT EXISTS (SELECT 1 FROM [dbo].[UserType] WHERE [UserCode] = 'ADM')
BEGIN
    INSERT INTO [dbo].[UserType] ([ID], [UserDesc], [Status], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [UserCode])
    VALUES (NEWID(), 'Admin', 1, 'Admin', GETDATE(), NULL, GETDATE(), 'ADM');
END

-- Check and insert Employee user type based on UserCode
IF NOT EXISTS (SELECT 1 FROM [dbo].[UserType] WHERE [UserCode] = 'EMP')
BEGIN
    INSERT INTO [dbo].[UserType] ([ID], [UserDesc], [Status], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [UserCode])
    VALUES (NEWID(), 'Employee', 1, 'Admin', GETDATE(), NULL, GETDATE(), 'EMP');
END

-- Check and insert IE Dept user type based on UserCode
IF NOT EXISTS (SELECT 1 FROM [dbo].[UserType] WHERE [UserCode] = 'IED')
BEGIN
    INSERT INTO [dbo].[UserType] ([ID], [UserDesc], [Status], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [UserCode])
    VALUES (NEWID(), 'IE DEPT', 1, 'Admin', GETDATE(), NULL, GETDATE(), 'IED');
END

-- Check and insert Manager user type based on UserCode
IF NOT EXISTS (SELECT 1 FROM [dbo].[UserType] WHERE [UserCode] = 'MGR')
BEGIN
    INSERT INTO [dbo].[UserType] ([ID], [UserDesc], [Status], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [UserCode])
    VALUES (NEWID(), 'Manager', 1, 'Admin', GETDATE(), NULL, GETDATE(), 'MGR');
END

-- Check and insert Finance user type based on UserCode
IF NOT EXISTS (SELECT 1 FROM [dbo].[UserType] WHERE [UserCode] = 'FIN')
BEGIN
    INSERT INTO [dbo].[UserType] ([ID], [UserDesc], [Status], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [UserCode])
    VALUES (NEWID(), 'Finance', 1, 'Admin', GETDATE(), NULL, GETDATE(), 'FIN');
END

/****** Object:  Table [dbo].[ApprovalStatus]    Script Date: 03-10-2024 20:36:26 ******/
-- Image Rejected status
IF NOT EXISTS (SELECT 1 FROM [dbo].[ApprovalStatus] WHERE [StatusID] = 3)
BEGIN
    INSERT INTO [dbo].[ApprovalStatus] ([ID], [StatusID], [StatusDescription], [CreatedDate], [CreatedBy], [ModifiedBy], [ModifiedDate])
    VALUES (NEWID(), 3, 'ImageRejected', GETDATE(), NULL, NULL, NULL);
END;

-- IE Approved status
IF NOT EXISTS (SELECT 1 FROM [dbo].[ApprovalStatus] WHERE [StatusID] = 6)
BEGIN
    INSERT INTO [dbo].[ApprovalStatus] ([ID], [StatusID], [StatusDescription], [CreatedDate], [CreatedBy], [ModifiedBy], [ModifiedDate])
    VALUES (NEWID(), 6, 'IEApproved', GETDATE(), NULL, NULL, NULL);
END;

-- IE Pending status
IF NOT EXISTS (SELECT 1 FROM [dbo].[ApprovalStatus] WHERE [StatusID] = 12)
BEGIN
    INSERT INTO [dbo].[ApprovalStatus] ([ID], [StatusID], [StatusDescription], [CreatedDate], [CreatedBy], [ModifiedBy], [ModifiedDate])
    VALUES (NEWID(), 12, 'IEPending', GETDATE(), NULL, NULL, NULL);
END;

-- Finance Rejected status
IF NOT EXISTS (SELECT 1 FROM [dbo].[ApprovalStatus] WHERE [StatusID] = 9)
BEGIN
    INSERT INTO [dbo].[ApprovalStatus] ([ID], [StatusID], [StatusDescription], [CreatedDate], [CreatedBy], [ModifiedBy], [ModifiedDate])
    VALUES (NEWID(), 9, 'FinanceRejected', GETDATE(), NULL, NULL, NULL);
END;

-- Saved status
IF NOT EXISTS (SELECT 1 FROM [dbo].[ApprovalStatus] WHERE [StatusID] = 0)
BEGIN
    INSERT INTO [dbo].[ApprovalStatus] ([ID], [StatusID], [StatusDescription], [CreatedDate], [CreatedBy], [ModifiedBy], [ModifiedDate])
    VALUES (NEWID(), 0, 'Saved', GETDATE(), NULL, NULL, NULL);
END;

-- Kaizen Without Images status
IF NOT EXISTS (SELECT 1 FROM [dbo].[ApprovalStatus] WHERE [StatusID] = 15)
BEGIN
    INSERT INTO [dbo].[ApprovalStatus] ([ID], [StatusID], [StatusDescription], [CreatedDate], [CreatedBy], [ModifiedBy], [ModifiedDate])
    VALUES (NEWID(), 15, 'KaizenWithoutImages', GETDATE(), NULL, NULL, NULL);
END;

-- Finance Approved status
IF NOT EXISTS (SELECT 1 FROM [dbo].[ApprovalStatus] WHERE [StatusID] = 8)
BEGIN
    INSERT INTO [dbo].[ApprovalStatus] ([ID], [StatusID], [StatusDescription], [CreatedDate], [CreatedBy], [ModifiedBy], [ModifiedDate])
    VALUES (NEWID(), 8, 'FinanceApproved', GETDATE(), NULL, NULL, NULL);
END;

-- Finance Pending status
IF NOT EXISTS (SELECT 1 FROM [dbo].[ApprovalStatus] WHERE [StatusID] = 13)
BEGIN
    INSERT INTO [dbo].[ApprovalStatus] ([ID], [StatusID], [StatusDescription], [CreatedDate], [CreatedBy], [ModifiedBy], [ModifiedDate])
    VALUES (NEWID(), 13, 'FinancePending', GETDATE(), NULL, NULL, NULL);
END;

-- Kaizen Approved status
IF NOT EXISTS (SELECT 1 FROM [dbo].[ApprovalStatus] WHERE [StatusID] = 16)
BEGIN
    INSERT INTO [dbo].[ApprovalStatus] ([ID], [StatusID], [StatusDescription], [CreatedDate], [CreatedBy], [ModifiedBy], [ModifiedDate])
    VALUES (NEWID(), 16, 'KaizenApproved', GETDATE(), NULL, NULL, NULL);
END;

-- IE Rejected status
IF NOT EXISTS (SELECT 1 FROM [dbo].[ApprovalStatus] WHERE [StatusID] = 7)
BEGIN
    INSERT INTO [dbo].[ApprovalStatus] ([ID], [StatusID], [StatusDescription], [CreatedDate], [CreatedBy], [ModifiedBy], [ModifiedDate])
    VALUES (NEWID(), 7, 'IERejected', GETDATE(), NULL, NULL, NULL);
END;

-- DRI Rejected status
IF NOT EXISTS (SELECT 1 FROM [dbo].[ApprovalStatus] WHERE [StatusID] = 5)
BEGIN
    INSERT INTO [dbo].[ApprovalStatus] ([ID], [StatusID], [StatusDescription], [CreatedDate], [CreatedBy], [ModifiedBy], [ModifiedDate])
    VALUES (NEWID(), 5, 'DRIRejected', GETDATE(), NULL, NULL, NULL);
END;

-- Submitted status
IF NOT EXISTS (SELECT 1 FROM [dbo].[ApprovalStatus] WHERE [StatusID] = 1)
BEGIN
    INSERT INTO [dbo].[ApprovalStatus] ([ID], [StatusID], [StatusDescription], [CreatedDate], [CreatedBy], [ModifiedBy], [ModifiedDate])
    VALUES (NEWID(), 1, 'Submitted', GETDATE(), NULL, NULL, NULL);
END;

-- DRI Pending status
IF NOT EXISTS (SELECT 1 FROM [dbo].[ApprovalStatus] WHERE [StatusID] = 11)
BEGIN
    INSERT INTO [dbo].[ApprovalStatus] ([ID], [StatusID], [StatusDescription], [CreatedDate], [CreatedBy], [ModifiedBy], [ModifiedDate])
    VALUES (NEWID(), 11, 'DRIPending', GETDATE(), NULL, NULL, NULL);
END;

-- Image Approved status
IF NOT EXISTS (SELECT 1 FROM [dbo].[ApprovalStatus] WHERE [StatusID] = 2)
BEGIN
    INSERT INTO [dbo].[ApprovalStatus] ([ID], [StatusID], [StatusDescription], [CreatedDate], [CreatedBy], [ModifiedBy], [ModifiedDate])
    VALUES (NEWID(), 2, 'ImageApproved', GETDATE(), NULL, NULL, NULL);
END;

-- Deleted status
IF NOT EXISTS (SELECT 1 FROM [dbo].[ApprovalStatus] WHERE [StatusID] = 14)
BEGIN
    INSERT INTO [dbo].[ApprovalStatus] ([ID], [StatusID], [StatusDescription], [CreatedDate], [CreatedBy], [ModifiedBy], [ModifiedDate])
    VALUES (NEWID(), 14, 'Deleted', GETDATE(), NULL, NULL, NULL);
END;


-- DRI Approved status
IF NOT EXISTS (SELECT 1 FROM [dbo].[ApprovalStatus] WHERE [StatusID] = 4) -- Same StatusID as Draft
BEGIN
    INSERT INTO [dbo].[ApprovalStatus] ([ID], [StatusID], [StatusDescription], [CreatedDate], [CreatedBy], [ModifiedBy], [ModifiedDate])
    VALUES (NEWID(), 4, 'DRIApproved', GETDATE(), NULL, NULL, NULL);
END;
/****** Object:  Table [dbo].[Status]    Script Date: 03-10-2024 20:36:26 ******/

-- Active status (1)
IF NOT EXISTS (SELECT 1 FROM [dbo].[Status] WHERE [StatusName] = 'Active')
BEGIN
    INSERT INTO [dbo].[Status] ([ID], [StatusID], [StatusName], [Status], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate])
    VALUES (NEWID(), 1, 'Active', 1, 'Admin', GETDATE(), NULL, NULL);  -- Status 1 for Active
END

-- Inactive status (0)
IF NOT EXISTS (SELECT 1 FROM [dbo].[Status] WHERE [StatusName] = 'Inactive')
BEGIN
    INSERT INTO [dbo].[Status] ([ID], [StatusID], [StatusName], [Status], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate])
    VALUES (NEWID(), 0, 'Inactive', 0, 'Admin', GETDATE(), NULL, NULL);  -- Status 0 for Inactive
END

-- Block status (2)
IF NOT EXISTS (SELECT 1 FROM [dbo].[Status] WHERE [StatusName] = 'Block')
BEGIN
    INSERT INTO [dbo].[Status] ([ID], [StatusID], [StatusName], [Status], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate])
    VALUES (NEWID(), 2, 'Block', 2, 'Admin', GETDATE(), NULL, NULL);  -- Status 2 for Blocked
END