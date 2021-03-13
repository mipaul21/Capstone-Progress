-- <summary>
-- William Clark
-- Created: 2021/02/23
--
-- Script for the creation of the Routines table
-- and related stored procedures
-- </summary>
-- <remarks>
-- </remarks>
print '' print '*** using database assistability_db ***'
GO
USE [assistability_db]
GO

-- <summary>
-- William Clark
-- Created: 2021/02/26
--
-- Definition of the Routines table
-- </summary>
-- <remarks>
-- </remarks>
print '' print '*** creating Routines table ***'
GO
CREATE TABLE [dbo].[Routines]
(
	[RoutineName]		[NVARCHAR](50)			NOT NULL,
	[RoutineDescription][NVARCHAR](150)						NOT NULL,
	[UserID_Client]	[INT]						NOT NULL,
	[UserID_Admin]     	[INT]						NOT NULL,
	[EntryDate]		[DATETIME]					NOT NULL,
	[EditDate]		[DATETIME]					NULL,
	[RemovalDate]		[DATETIME]					NULL,
     [Active]            [BIT]                              NOT NULL
	CONSTRAINT [pk_RoutineName]		PRIMARY KEY([RoutineName] ASC),
     CONSTRAINT [fk_Routine_UserID_Client]		FOREIGN KEY([UserID_Client])
	REFERENCES [dbo].[UserAccount]([UserID]),
     CONSTRAINT [fk_Routine_UserID_Admin]		FOREIGN KEY([UserID_Admin])
	REFERENCES [dbo].[UserAccount]([UserID])
)
GO

-- <summary>
-- William Clark
-- Created: 2021/03/04
--
-- Updates a Routine
-- </summary>
-- <remarks>
-- </remarks>
print '' print '*** creating sp_update_routine ***'
GO
CREATE PROCEDURE [dbo].[sp_update_routine]
	(
		@RoutineName			[NVARCHAR](50),
		@RoutineDescription		[NVARCHAR](150),
		@UserID_Client			[INT],
		@UserID_Admin			[INT],
		@EditDate				[DATETIME],
		@RemovalDate			[DATETIME],
		@Active				[BIT]
	)
AS
	UPDATE [dbo].[Routines]
	SET [RoutineDescription] = @RoutineDescription,
		[EditDate] = @EditDate,
		[RemovalDate] = @RemovalDate,
		[Active] = @Active
	WHERE [RoutineName] = @RoutineName
		AND [UserID_Client] = @UserID_Client
		AND [UserID_Admin] = @UserID_Admin
	RETURN @@ROWCOUNT
GO

-- <summary>
-- William Clark
-- Created: 2021/03/12
--
-- Selects all active Routines by UserID_Client
-- </summary>
-- <remarks>
-- </remarks>
print '' print '*** creating sp_select_active_routines_by_useraccountid ***'
GO
CREATE PROCEDURE [dbo].[sp_select_active_routines_by_useraccountid]
	(
		@UserID_Client			[INT]
	)
AS
	BEGIN
		SELECT 
		[RoutineName], [RoutineDescription], [UserID_Admin], [EntryDate], [EditDate], [RemovalDate]
		FROM [dbo].[Routines]
		WHERE [UserID_Client] = @UserID_Client
			AND [Active] = 1
	END
GO