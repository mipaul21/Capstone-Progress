GO
USE [assistability_db]
GO

-- <summary>
-- Nathaniel Webber
-- Created: 2021/03/11
--
-- Creates the award table
-- </summary>
print ''  print '' print '*** creating award table ***'
GO
CREATE TABLE [dbo].[award] 
(
	[AwardID]			[INT]				IDENTITY(1,1)	NOT NULL,
	[UserID_Award]		[INT]							 	NOT NULL,
	[AwardName]			[NVARCHAR](50)						NOT NULL,
	[AwardDescription]	[NVARCHAR](255)						NOT NULL,
	[GoalID]			[INT]				DEFAULT(1)		NULL,
	[GoalTypeID]		[INT]				DEFAULT(1)		NULL,
	[Active]			[BIT]				DEFAULT(1)		NULL
	
	CONSTRAINT [pk_AwardID]			PRIMARY KEY([AwardID] ASC),
	CONSTRAINT [fk_UserID_Award]	FOREIGN KEY([UserID_Award])		REFERENCES[dbo].[UserAccount]([UserID])--,
	--CONSTRAINT [fk_GoalID]		FOREIGN KEY([GoalID])			REFERENCES[dbo].[Goal]([GoalID]),
	--CONSTRAINT [fk_GoalTypeID]	FOREIGN KEY([GoalTypeID])		REFERENCES[dbo].[Goal]([GoalTypeID])'
)
GO

-- <summary>
-- Nathaniel Webber
-- Created: 2021/03/11
--
-- Create test data for award table
-- </summary>
-- print '' print '*** creating award test data ***'
-- GO
-- INSERT INTO [dbo].[award]
-- 	(UserID_Award, AwardName, AwardDescription, GoalID, GoalTypeID)
-- VALUES
-- 	(1, "Award number 1", "A short description", 1, 1),
-- 	(1, "Award number 2", "A longer description", 1, 2),
-- 	(1, "Award number 3", "The longest description", 2, 1),
-- 	(1, "Award number 4", "The shortest Description", 2, 2)
-- GO

print '' print '*** CREATING STORED PROCEDURES FOR AWARD ***'
GO

-- <summary>
-- Nathaniel Webber
-- Created: 2021/03/11
--
-- Create stored procedure sp_create_new_award
-- </summary>
print '' print '*** Creating sp_create_new_award ***'
GO
CREATE PROCEDURE [dbo].[sp_create_new_award]
	(
		@UserID_Award			[INT],
		@AwardName				[NVARCHAR](50),
		@AwardDescription		[NVARCHAR](255)--,
		--@GoalID					[INT],
		--@GoalTypeID				[INT]
	)
AS
	BEGIN
		INSERT INTO [dbo].[award]
			([UserID_Award], [AwardName], [AwardDescription])
		VALUES
			(@UserID_Award, @AwardName, @AwardDescription)
		SELECT SCOPE_IDENTITY()
	END
GO

-- <summary>
-- Nathaniel Webber
-- Created: 2021/03/11
--
-- Create stored procedure sp_delete_award
-- </summary>
print '' print '*** Creating sp_delete_award ***'
GO
CREATE PROCEDURE [dbo].[sp_delete_award]
	(
		@AwardID		[INT]
	)
AS
	BEGIN
		DELETE FROM award
			WHERE AwardID = @AwardID
		RETURN @@ROWCOUNT
	END
GO

-- <summary>
-- Nathaniel Webber
-- Created: 2021/03/11
--
-- Create stored procedure sp_safely_deactivate_award
-- </summary>
print '' print '*** Creating sp_safely_deactivate_award ***'
GO
CREATE PROCEDURE [dbo].[sp_safely_deactivate_award]
	(
		@AwardID		[INT]
	)
AS
	BEGIN
		UPDATE award
			SET Active = 0
			WHERE AwardID = @AwardID
		RETURN @@ROWCOUNT
	END
GO

-- <summary>
-- Nathaniel Webber
-- Created: 2021/03/11
--
-- Create stored procedure sp_select_all_awards
-- </summary>
print '' print '*** Creating sp_select_all_awards ***'
GO
CREATE PROCEDURE [dbo].[sp_select_all_awards]
	(	
		@Active		[BIT]
	)
AS
	BEGIN
		SELECT AwardID, AwardName, AwardDescription, GoalID, GoalTypeID, Active
		FROM award
		WHERE Active = @Active
		ORDER BY AwardName ASC
	END
GO

-- <summary>
-- Nathaniel Webber
-- Created: 2021/03/11
--
-- Create stored procedure sp_select_award_by_awardID
-- </summary>
print '' print '*** Creating sp_select_award_by_awardID ***'
GO
CREATE PROCEDURE[dbo].[sp_select_award_by_awardID]
	(
		@AwardID		[INT]
	)
AS
	BEGIN
		SELECT AwardID, AwardName, AwardDescription, GoalID, GoalTypeID, Active
		FROM award
		WHERE AwardID = @AwardID
	END
GO

-- <summary>
-- Nathaniel Webber
-- Created: 2021/03/11
--
-- Create stored procedure sp_select_award_by_userID_and_awardname
-- </summary>
print '' print '*** Creating sp_select_award_by_userID_and_awardname ***'
GO
CREATE PROCEDURE [dbo].[sp_select_award_by_userID_and_awardname]
	(
		@UserID_Award		[INT],
		@AwardName			[NVARCHAR](50)
	)
AS
	BEGIN
		SELECT UserID_Award, AwardName, AwardDescription, GoalID, GoalTypeID, Active
		FROM award
		WHERE UserID_Award = @UserID_Award
		AND AwardName = @AwardName
	END
GO

-- <summary>
-- Nathaniel Webber
-- Created: 2021/03/11
--
-- Create stored procedure sp_update_award
-- </summary>
print '' print '*** Creating sp_update_award ***'
GO
CREATE PROCEDURE [dbo].[sp_update_award]
	(
		@AwardID				[INT],
		@NewAwardName			[NVARCHAR](50),
		@NewAwardDescription	[NVARCHAR](255),
		@OldAwardName			[NVARCHAR](50),
		@OldAwardDescription	[NVARCHAR](255)
	)
AS
	BEGIN
		UPDATE award
			SET AwardName = @NewAwardName,
				AwardDescription = @NewAwardDescription
			WHERE AwardID = @AwardID
			AND AwardName = @OldAwardName
			AND AwardDescription = @OldAwardDescription
		RETURN @@ROWCOUNT
	END
GO

print ''

















