# WebAPIDemo
Works with Sql Server db. The db name is Basket and contains 2 tables: 
- articles
- baskets

The Articles table creation script:
USE [Basket]
GO

/****** Object:  Table [dbo].[articles]    Script Date: 2022-11-25 2:28:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[articles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[price] [float] NOT NULL,
	[basketId] [int] NOT NULL,
 CONSTRAINT [PK_article] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[articles]  WITH CHECK ADD  CONSTRAINT [FK_article_basket] FOREIGN KEY([basketId])
REFERENCES [dbo].[baskets] ([id])
GO

ALTER TABLE [dbo].[articles] CHECK CONSTRAINT [FK_article_basket]
GO



The Baskets table creation script:
USE [Basket]
GO

/****** Object:  Table [dbo].[baskets]    Script Date: 2022-11-25 2:29:56 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[baskets](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[customer] [nvarchar](255) NOT NULL,
	[paysVAT] [bit] NOT NULL,
	[status] [int] NOT NULL,
 CONSTRAINT [PK_basket] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



