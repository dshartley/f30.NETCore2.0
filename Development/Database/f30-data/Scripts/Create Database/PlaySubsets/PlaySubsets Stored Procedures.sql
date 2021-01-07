USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlaySubsetsDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlaySubsetsDelete]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlaySubsetsDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM [f30-data].[dbo].[PlaySubsets]
	WHERE ID = @ID

END



GO


USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlaySubsetsInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlaySubsetsInsert]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlaySubsetsInsert]
(
	@ID int output,
	@Name [nvarchar](250),
	@ContentData [nvarchar](max),
	@VersionID [int],
	@VersionDate [datetime],
	@VersionOwnerID [int]
)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [f30-data].[dbo].[PlaySubsets]
           ([Name],
			[ContentData],
			[VersionID],
			[VersionDate],
			[VersionOwnerID])
     VALUES
           (@Name,
			@ContentData,
			@VersionID,
			@VersionDate,
			@VersionOwnerID
			)

	Set @ID=Scope_Identity()

END



GO
USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlaySubsetsSelect]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlaySubsetsSelect]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlaySubsetsSelect]
AS
BEGIN

	SET NOCOUNT ON;

	SELECT	ps.[ID],
			ps.[Name],
			ps.[ContentData],
			ps.[VersionID],
			ps.[VersionDate],
			ps.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlaySubsets] ps
			ORDER BY ps.[ID] DESC

END




GO

USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlaySubsetsSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlaySubsetsSelectByID]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlaySubsetsSelectByID]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	ps.[ID],
			ps.[Name],
			ps.[ContentData],
			ps.[VersionID],
			ps.[VersionDate],
			ps.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlaySubsets] ps
	WHERE	ps.[ID] = @ID
	ORDER BY ps.[ID] DESC
	
							
END


GO


USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlaySubsetsSelectByRelativeMemberID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlaySubsetsSelectByRelativeMemberID]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlaySubsetsSelectByRelativeMemberID]
(
	@RelativeMemberID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	ps.[ID],
			ps.[Name],
			ps.[ContentData],
			ps.[VersionID],
			ps.[VersionDate],
			ps.[VersionOwnerID]
	FROM	[f30-data].[dbo].[PlaySubsets] ps
	ORDER BY ps.[ID] DESC
	
							
END


GO


USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlaySubsetsUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlaySubsetsUpdate]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlaySubsetsUpdate]
(
	@ID int output,
	@Name [nvarchar](250),
	@ContentData [nvarchar](max),
	@VersionID [int],
	@VersionDate [datetime],
	@VersionOwnerID [int]
)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE	[f30-data].[dbo].[PlaySubsets]
	SET		[Name] = @Name,
			[ContentData] = @ContentData,
			[VersionID] = @VersionID,
			[VersionDate] = @VersionDate,
			[VersionOwnerID] = @VersionOwnerID
	WHERE ID = @ID

END

GO
