print '' print '*** using database assistability_db ***'
GO
USE [assistability_db]
GO

print '' print '*** creating useraccount test records ***'
GO
INSERT INTO [dbo].[UserAccount]
	([FirstName], [LastName], [UserName], [Email], [Active])
VALUES
	("First", "Administrator", "firstAdmin", "first@administrator.com", 1),
	("Care", "Giver", "Caregiver", "caregiver@Assisstability.com", 1),
	("Client", "Client", "Client", "client@Assisstability.com", 1)
GO

print '' print '*** creating routines test records ***'
GO
INSERT INTO [dbo].[Routines]
	([RoutineName], [RoutineDescription], [UserID_Client], [UserID_Admin], [EntryDate], [EditDate], [RemovalDate], [Active])
VALUES
	("FirstRoutine", "First Routine", 3, 1, '20210226', null, null, 1)
GO

print '' print '*** creating routinestep test records ***'
GO
INSERT INTO [dbo].[RoutineStep]
	([RoutineName], [RoutineStepName], [RoutineStepDescription], [EntryDate], [OrderNumber], [Active])
VALUES
	("FirstRoutine", "First Routine Step", "The first step in the routine", '20210226', 1, 1),
     ("FirstRoutine", "Second Routine Step", "The second step in the routine", '20210226', 2, 1),
     ("FirstRoutine", "Third Routine Step", "The third step in the routine", '20210226', 3, 1)
GO
