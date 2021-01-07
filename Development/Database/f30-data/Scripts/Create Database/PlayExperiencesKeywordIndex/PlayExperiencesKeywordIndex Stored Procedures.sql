USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayExperiencesKeywordIndexDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayExperiencesKeywordIndexDelete]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayExperiencesKeywordIndexDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM [f30-data].[dbo].[PlayExperiencesKeywordIndex]
	WHERE ID = @ID

END



GO


USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayExperiencesKeywordIndexInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayExperiencesKeywordIndexInsert]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayExperiencesKeywordIndexInsert]
(
	@ID int output,
	@PlaySubsetID [int],
	@PlayExperienceID [int],
	@Keyword [nvarchar](100)
)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [f30-data].[dbo].[PlayExperiencesKeywordIndex]
           ([PlaySubsetID],
			[PlayExperienceID],
			[Keyword])
     VALUES
           (@PlaySubsetID,
			@PlayExperienceID,
			@Keyword
			)

	Set @ID=Scope_Identity()

END



GO
USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayExperiencesKeywordIndexSelect]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayExperiencesKeywordIndexSelect]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayExperiencesKeywordIndexSelect]
AS
BEGIN

	SET NOCOUNT ON;

	SELECT	peki.[ID],
			peki.[PlaySubsetID],
			peki.[PlayExperienceID],
			peki.[Keyword]
	FROM	[f30-data].[dbo].[PlayExperiencesKeywordIndex] peki
	ORDER BY peki.[ID] DESC

END




GO

USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayExperiencesKeywordIndexSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayExperiencesKeywordIndexSelectByID]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayExperiencesKeywordIndexSelectByID]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	peki.[ID],
			peki.[PlaySubsetID],
			peki.[PlayExperienceID],
			peki.[Keyword]
	FROM	[f30-data].[dbo].[PlayExperiencesKeywordIndex] peki
	WHERE	peki.[ID] = @ID
	ORDER BY peki.[ID] DESC
	
							
END


GO
USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayExperiencesKeywordIndexUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayExperiencesKeywordIndexUpdate]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayExperiencesKeywordIndexUpdate]
(
	@ID int output,
	@PlaySubsetID [int],
	@PlayExperienceID [int],
	@Keyword [nvarchar](100)
)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE	[f30-data].[dbo].[PlayExperiencesKeywordIndex]
	SET		[PlaySubsetID] = @PlaySubsetID,
			[PlayExperienceID] = @PlayExperienceID,
			[Keyword] = @Keyword
	WHERE ID = @ID

END

GO
