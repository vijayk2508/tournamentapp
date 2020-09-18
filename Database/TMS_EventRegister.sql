USE [TMS]
GO

/****** Object:  Table [dbo].[TMS_EventRegister]    Script Date: 3/7/2019 10:55:37 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TMS_EventRegister](
	[EventRegister_ID] [int] IDENTITY(1,1) NOT NULL,
	[EventRegister_EventID] [int] NULL,
	[EventRegister_PlayerID] [int] NULL,
	[EventRegister_PlayerUsername] [nvarchar](max) NULL,
	[EventRegister_AddedDateTime] [numeric](18, 0) NULL,
 CONSTRAINT [PK_TMS_EventRegister] PRIMARY KEY CLUSTERED 
(
	[EventRegister_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


