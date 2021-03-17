/****** Object:  Table [dbo].[tx]    Script Date: 3/12/2021 9:28:43 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tx](
	[wallet] [nvarchar](255) NOT NULL,
	[txid] [nvarchar](255) NULL,
	[date] [timestamp] NULL,
	[incoming] [bit] NULL,
	[value] [float] NULL,
	[coin] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[wallet] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tx]  WITH CHECK ADD  CONSTRAINT [coingrp2] FOREIGN KEY([coin])
REFERENCES [dbo].[coins] ([id])
GO

ALTER TABLE [dbo].[tx] CHECK CONSTRAINT [coingrp2]
GO

