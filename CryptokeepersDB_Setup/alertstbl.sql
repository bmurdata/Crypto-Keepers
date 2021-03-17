/****** Object:  Table [dbo].[alerts]    Script Date: 3/12/2021 9:25:42 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[alerts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[type] [tinyint] NULL,
	[concern] [nvarchar](255) NOT NULL,
	[flag] [tinyint] NULL,
	[priority] [tinyint] NULL,
	[entity] [smallint] NULL,
	[notes] [nvarchar](max) NULL,
	[reported] [datetime] NOT NULL,
	[coin] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[alerts] ADD  DEFAULT (getdate()) FOR [reported]
GO

ALTER TABLE [dbo].[alerts]  WITH CHECK ADD  CONSTRAINT [coingrp] FOREIGN KEY([coin])
REFERENCES [dbo].[coins] ([id])
GO

ALTER TABLE [dbo].[alerts] CHECK CONSTRAINT [coingrp]
GO

ALTER TABLE [dbo].[alerts]  WITH CHECK ADD  CONSTRAINT [entitygrp] FOREIGN KEY([entity])
REFERENCES [dbo].[entities] ([id])
GO

ALTER TABLE [dbo].[alerts] CHECK CONSTRAINT [entitygrp]
GO

ALTER TABLE [dbo].[alerts]  WITH CHECK ADD  CONSTRAINT [flaggrp] FOREIGN KEY([flag])
REFERENCES [dbo].[flags] ([id])
GO

ALTER TABLE [dbo].[alerts] CHECK CONSTRAINT [flaggrp]
GO

ALTER TABLE [dbo].[alerts]  WITH CHECK ADD  CONSTRAINT [prioritygrp] FOREIGN KEY([priority])
REFERENCES [dbo].[priorities] ([id])
GO

ALTER TABLE [dbo].[alerts] CHECK CONSTRAINT [prioritygrp]
GO

ALTER TABLE [dbo].[alerts]  WITH CHECK ADD  CONSTRAINT [typegrp] FOREIGN KEY([type])
REFERENCES [dbo].[types] ([id])
GO

ALTER TABLE [dbo].[alerts] CHECK CONSTRAINT [typegrp]
GO


