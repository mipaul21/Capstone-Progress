-- <summary>
-- William Clark
-- Created: 2021/02/23
--
-- Script for the creation of the UserGroup table
-- and related stored procedures
-- </summary>
-- <remarks>
-- </remarks>
print '' print '*** using database assistability_db ***'
GO
USE [assistability_db]
GO

-- <summary>
-- Nathaniel Webber
-- Created: 2021/02/18
--
-- Definition of the UserGroup table
-- </summary>
-- <remarks>
-- William Clark
-- Updated: 2021/02/23
-- Updated summary description
-- </remarks>
print '' print '*** creating UserGroup table ***'
GO
CREATE TABLE [dbo].[UserGroup]
(
	[UserID_Owner]		[INT]							NOT NULL,
	[GroupID]		[INT]			IDENTITY(1,1)			NOT NULL
	CONSTRAINT	[pk_GroupID]	PRIMARY KEY([GroupID] ASC),
	CONSTRAINT	[fk_UserGroup_UserID]		FOREIGN KEY([UserID_owner])
	REFERENCES [dbo].[UserAccount]([UserID])
)
GO

-- <summary>
-- William Clark
-- Created: 2021/02/18
--
-- Selects all UserGroups by UserAccountID
-- </summary>
-- <remarks>
-- </remarks>
print '' print '*** creating sp_select_usergroups_by_useraccountid ***'
GO
CREATE PROCEDURE [dbo].[sp_select_usergroups_by_useraccountid]
	(
		@UserAccountID			[INT]
	)
AS
	BEGIN
		SELECT [GroupID]
		FROM UserGroup
		WHERE [UserID_Owner] = @UserAccountID
	END
GO
