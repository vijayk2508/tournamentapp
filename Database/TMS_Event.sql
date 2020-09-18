USE [TMS]
GO

/****** Object:  Table [dbo].[TMS_Event]    Script Date: 3/7/2019 10:53:41 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TMS_Event](
	[Event_ID] [int] IDENTITY(1,1) NOT NULL,
	[Event_Image] [nvarchar](max) NULL,
	[Event_Title] [nvarchar](max) NULL,
	[Event_Description] [nvarchar](max) NULL,
	[Event_AddedDateTime] [numeric](18, 0) NULL,
 CONSTRAINT [PK_TMS_Event] PRIMARY KEY CLUSTERED 
(
	[Event_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


