/****** Object:  Table [dbo].[priorities]    Script Date: 3/12/2021 9:28:06 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[priorities](
	[id] [tinyint] IDENTITY(1,1) NOT NULL,
	[priorityname] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

