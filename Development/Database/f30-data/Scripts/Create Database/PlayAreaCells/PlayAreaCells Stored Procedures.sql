USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayAreaCellsDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayAreaCellsDelete]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayAreaCellsDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM [f30-data].[dbo].[PlayAreaCells]
	WHERE ID = @ID

END



GO


USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayAreaCellsInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayAreaCellsInsert]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayAreaCellsInsert]
(
	@ID int output,
	@RelativeMemberID [nvarchar](30),
	@PlayGameID [int],
	@CellTypeID [int],
	@Column [int],
	@Row [int],
	@RotationDegrees [int],
	@ImageName [nvarchar](250),
	@CellAttributesString [nvarchar](max),
	@CellSideAttributesString [nvarchar](max)
)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [f30-data].[dbo].[PlayAreaCells]
           ([RelativeMemberID],
			[PlayGameID],
			[CellTypeID],
			[Column],
			[Row],
			[RotationDegrees],
			[ImageName],
			[CellAttributesString],
			[CellSideAttributesString])
     VALUES
           (@RelativeMemberID,
			@PlayGameID,
			@CellTypeID,
			@Column,
			@Row,
			@RotationDegrees,
			@ImageName,
			@CellAttributesString,
			@CellSideAttributesString
			)

	Set @ID=Scope_Identity()

END



GO
USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayAreaCellsSelect]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayAreaCellsSelect]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayAreaCellsSelect]
AS
BEGIN

	SET NOCOUNT ON;

	SELECT	pac.[ID],
			pac.[RelativeMemberID],
			pac.[PlayGameID],
			pac.[CellTypeID],
			pac.[Column],
			pac.[Row],
			pac.[RotationDegrees],
			pac.[ImageName],
			pac.[CellAttributesString],
			pac.[CellSideAttributesString]
	FROM	[f30-data].[dbo].[PlayAreaCells] pac
			ORDER BY pac.[ID] DESC

END




GO

USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayAreaCellsSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayAreaCellsSelectByID]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayAreaCellsSelectByID]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	pac.[ID],
			pac.[RelativeMemberID],
			pac.[PlayGameID],
			pac.[CellTypeID],
			pac.[Column],
			pac.[Row],
			pac.[RotationDegrees],
			pac.[ImageName],
			pac.[CellAttributesString],
			pac.[CellSideAttributesString]
	FROM	[f30-data].[dbo].[PlayAreaCells] pac
	WHERE	pac.[ID] = @ID
	ORDER BY pac.[ID] DESC
	
							
END


GO




USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayAreaCellsSelectByPlayGameID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayAreaCellsSelectByPlayGameID]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayAreaCellsSelectByPlayGameID]
(
	@PlayGameID int
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	pac.[ID],
			pac.[RelativeMemberID],
			pac.[PlayGameID],
			pac.[CellTypeID],
			pac.[Column],
			pac.[Row],
			pac.[RotationDegrees],
			pac.[ImageName],
			pac.[CellAttributesString],
			pac.[CellSideAttributesString]
	FROM	[f30-data].[dbo].[PlayAreaCells] pac	
	WHERE	pac.[PlayGameID] = @PlayGameID
	ORDER BY pac.[ID] DESC
	
							
END


GO



USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayAreaCellsSelectByPlayGameIDCellCoordRange]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayAreaCellsSelectByPlayGameIDCellCoordRange]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayAreaCellsSelectByPlayGameIDCellCoordRange]
(
	@RelativeMemberID int,
	@PlayGameID int,
	@FromColumn int,
	@FromRow int,
	@ToColumn int,
	@ToRow int,
	@LoadRelationalTablesYN bit
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	-- Create a table variable for the PlayAreaCells
	DECLARE @PAC TABLE(
		ID int,
		RelativeMemberID nvarchar(30),
		PlayGameID int,
		CellTypeID int,
		[Column] int,
		[Row] int,
		RotationDegrees int,
		ImageName nvarchar(250),
		CellAttributesString nvarchar(max),
		CellSideAttributesString nvarchar(max))

	INSERT INTO @PAC
	SELECT	pac.[ID],
			pac.[RelativeMemberID],
			pac.[PlayGameID],
			pac.[CellTypeID],
			pac.[Column],
			pac.[Row],
			pac.[RotationDegrees],
			pac.[ImageName],
			pac.[CellAttributesString],
			pac.[CellSideAttributesString]
	FROM	[f30-data].[dbo].[PlayAreaCells] pac
	WHERE	pac.[PlayGameID] = @PlayGameID
			AND pac.[Column] >= @FromColumn
			AND pac.[Column] <= @ToColumn
			AND pac.[Row] >= @FromRow
			AND pac.[Row] <= @ToRow
	ORDER BY pac.[ID] DESC	
		
	-- Select PlayAreaCells
	SELECT * FROM @PAC pac
	ORDER BY pac.[ID] DESC	
	
	IF (@LoadRelationalTablesYN = 1)
	BEGIN

		-- Load Relational Tables:
		-- PlayAreaTiles, PlayAreaTileData

		-- Create a table variable for the PlayAreaTiles
		DECLARE @PAT TABLE(
			ID int,
			RelativeMemberID nvarchar(30),
			PlayGameID int,
			TileTypeID int,
			[Column] int,
			[Row] int,
			RotationDegrees int,
			ImageName nvarchar(250),
			WidthPixels int,
			HeightPixels int,
			Position int,
			PositionFixToCellRotationYN bit,
			TileAttributesString nvarchar(max),
			TileSideAttributesString nvarchar(max))

		INSERT INTO @PAT
		SELECT	pat.[ID],
				pat.[RelativeMemberID],
				pat.[PlayGameID],
				pat.[TileTypeID],
				pat.[Column],
				pat.[Row],
				pat.[RotationDegrees],
				pat.[ImageName],
				pat.[WidthPixels],
				pat.[HeightPixels],
				pat.[Position],
				pat.[PositionFixToCellRotationYN],
				pat.[TileAttributesString],
				pat.[TileSideAttributesString]
		FROM	[f30-data].[dbo].[PlayAreaTiles] pat
		WHERE	pat.[PlayGameID] = @PlayGameID
				AND pat.[Column] >= @FromColumn
				AND pat.[Column] <= @ToColumn
				AND pat.[Row] >= @FromRow
				AND pat.[Row] <= @ToRow
		ORDER BY pat.[ID] DESC	

		-- Select PlayAreaTiles
		SELECT * FROM @PAT pat
		ORDER BY pat.[ID] DESC	

		-- Select PlayAreaTileData
		SELECT	patd.[ID],
				patd.[RelativeMemberID],
				patd.[PlayAreaTileID],
				patd.[OnCompleteData],
				patd.[AttributeData]
		FROM	[f30-data].[dbo].[PlayAreaTileData] patd
		WHERE	patd.[PlayAreaTileID] IN (SELECT pat.[ID] FROM @PAT pat)
		ORDER BY patd.[ID] DESC

	END
	
					
END


GO


USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayAreaCellsSelectByPlayGameIDIsSpecialYN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayAreaCellsSelectByPlayGameIDIsSpecialYN]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_PlayAreaCellsSelectByPlayGameIDIsSpecialYN]
(
	@RelativeMemberID int,
	@PlayGameID int,
	@IsSpecialYN bit,
	@LoadRelationalTablesYN bit
)
AS
BEGIN

	SET NOCOUNT ON;

	SET DATEFORMAT dmy;

	SELECT	pac.[ID],
			pac.[RelativeMemberID],
			pac.[PlayGameID],
			pac.[CellTypeID],
			pac.[Column],
			pac.[Row],
			pac.[RotationDegrees],
			pac.[ImageName],
			pac.[CellAttributesString],
			pac.[CellSideAttributesString]
	FROM	[f30-data].[dbo].[PlayAreaCells] pac
			INNER JOIN [f30-data].[dbo].[PlayAreaCellTypes] pact ON pact.[ID] = pac.[CellTypeID]	
	WHERE	pac.[PlayGameID] = @PlayGameID
			AND pact.[IsSpecialYN] = @IsSpecialYN
	ORDER BY pac.[ID] DESC
	
							
END


GO

USE [f30-data]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_PlayAreaCellsUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_PlayAreaCellsUpdate]
GO

USE [f30-data]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_PlayAreaCellsUpdate]
(
	@ID int output,
	@RelativeMemberID [nvarchar](30),
	@PlayGameID [int],
	@CellTypeID [int],
	@Column [int],
	@Row [int],
	@RotationDegrees [int],
	@ImageName [nvarchar](250),
	@CellAttributesString [nvarchar](max),
	@CellSideAttributesString [nvarchar](max)
)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE	[f30-data].[dbo].[PlayAreaCells]
	SET		[RelativeMemberID] = @RelativeMemberID,
			[PlayGameID] = @PlayGameID,
			[CellTypeID] = @CellTypeID,
			[Column] = @Column,
			[Row] = @Row,
			[RotationDegrees] = @RotationDegrees,
			[ImageName] = @ImageName,
			[CellAttributesString] = @CellAttributesString,
			[CellSideAttributesString] = @CellSideAttributesString
	WHERE ID = @ID

END

GO
