-- <summary>
-- William Clark
-- Created: 2021/02/23
--
-- Script for the creation of the MembershipRole table
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
-- Definition of the UserAccount table
-- </summary>
-- <remarks>
-- William Clark
-- Updated: 2021/02/23
-- Updated summary description
-- </remarks>
print '' print '*** creating MembershipRole table ***'
GO
CREATE TABLE [dbo].[MembershipRole]
(
	[GroupID]		[INT]							NOT NULL,
	[UserID]		[INT]							NOT NULL,
	[RoleID]		[INT]							NOT NULL
	CONSTRAINT	[fk_MembershipRole_GroupID] FOREIGN KEY([GroupID])
	REFERENCES [dbo].[UserGroup]([GroupID]),
	CONSTRAINT	[fk_MembershipRole_UserID] FOREIGN KEY([UserID])
	REFERENCES [dbo].[UserAccount]([UserID]),
	CONSTRAINT	[fk_MembershipRole_RoleID]	   FOREIGN KEY([RoleID])
	REFERENCES [dbo].[Role]([RoleID])
)
GO

-- <summary>
-- William Clark
-- Created: 2021/02/25
--
-- Selects all MembershipRoles by Membership
-- </summary>
-- <remarks>
-- </remarks>
print '' print '*** creating sp_select_membershiproles_by_membership ***'
GO
CREATE PROCEDURE [dbo].[sp_select_membershiproles_by_membership]
	(
		@GroupID			[INT],
		@UserID			[INT]
	)
AS
	BEGIN
		SELECT MembershipRole.[RoleID], [RoleName], [RoleDescription]
		FROM MembershipRole
		INNER JOIN Role
			ON MembershipRole.RoleID = Role.RoleID
		WHERE [GroupID] = @GroupID AND
			[UserID] = @UserID
	END
GO
