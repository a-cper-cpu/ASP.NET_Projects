if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Pr_AddVote]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Pr_AddVote]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Pr_DeleteVote]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Pr_DeleteVote]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Pr_GetSingleVote]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Pr_GetSingleVote]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Pr_GetVotes]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Pr_GetVotes]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Pr_UpdateVote]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Pr_UpdateVote]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Votes]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Votes]
GO

CREATE TABLE [dbo].[Votes] (
	[VoteID] [int] IDENTITY (1, 1) NOT NULL ,
	[Item] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[VoteCount] [int] NULL 
) ON [PRIMARY]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE Pr_AddVote
(
    @Item varchar(100)
)

AS
	
INSERT INTO
     Votes
     (
        Item,
        VoteCount
     )
     VALUES
     (
        @Item,
        0
     )

RETURN @@Identity

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE Pr_DeleteVote
(
    @VoteID int
)
AS
DELETE Votes
WHERE VoteID = @VoteID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE Pr_GetSingleVote
(
    @VoteID int
)
AS
SELECT Votes.*
FROM Votes
WHERE VoteID = @VoteID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE Pr_GetVotes

AS

SELECT 
    *
    
FROM
    Votes
    
ORDER BY VoteID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE Pr_UpdateVote
(
    @VoteID int
)
AS

UPDATE 
    Votes

SET
    VoteCount = VoteCount + 1

WHERE
    VoteID = @VoteID
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

