USE [ShepherdDb]
GO

/****** Object:  Table [dbo].[Order]    Script Date: 1/31/2017 4:58:41 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Order](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[StockId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[DateTime] [datetime] NOT NULL,
	[Price] [money] NOT NULL,
	[Amount] [int] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Stock] FOREIGN KEY([StockId])
REFERENCES [dbo].[Stock] ([StockId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Stock]
GO

ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO

ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_User]
GO

