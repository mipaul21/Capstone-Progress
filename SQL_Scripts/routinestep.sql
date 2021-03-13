-- <summary>
-- William Clark
-- Created: 2021/02/26
--
-- Script for the creation of the RoutineStep table
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
print '' print '*** creating RoutineStep table ***'
GO
CREATE TABLE [dbo].[RoutineStep]
(
     [RoutineStepID]     [INT]                    IDENTITY(1,1) NOT NULL,
	[RoutineName]		[NVARCHAR](50)			       NOT NULL,
	[RoutineStepName][NVARCHAR](50)				NOT NULL,
     [RoutineStepDescription][NVARCHAR](150)				NOT NULL,
	[EntryDate]		[DATETIME]					NOT NULL,
	[EditDate]		[DATETIME]					NULL,
	[RemovalDate]		[DATETIME]					NULL,
     [OrderNumber]       [INT]                              NOT NULL,
     [Active]            [BIT]                              NOT NULL
     CONSTRAINT [pk_RoutineStepID]                PRIMARY KEY([RoutineStepID])
     CONSTRAINT [fk_RoutineStep_RoutineName]		FOREIGN KEY([RoutineName])
	REFERENCES [dbo].[Routines]([RoutineName])
)
GO

print '' print '*** Creating sp_select_routinesteps_by_routinename ***'
GO
CREATE PROCEDURE [dbo].[sp_select_routinesteps_by_routinename]
(
	@RoutineName	[NVARCHAR](50)
)
AS
	BEGIN
		SELECT [RoutineStepID], [RoutineStepName], [RoutineStepDescription],
               [EntryDate], [EditDate], [RemovalDate], [OrderNumber], [Active]
		FROM 	[dbo].[RoutineStep]
		WHERE 	[RoutineName] = @RoutineName
          ORDER BY [OrderNumber]
	END
GO
