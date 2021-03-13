USE [assistability_db]
GO

print '' print '*** creating membershiprole test records ***'
GO
INSERT INTO [dbo].[MembershipRole]
	([GroupID], [UserID], [RoleID])
VALUES
	(1, 1, 1),
	(1, 2, 2),
	(1, 3, 3)
GO