IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = '[SportShoes_Backup]')
BEGIN
  CREATE DATABASE [SportShoes_Backup];
END;
GO

USE [SportShoes_Backup]
GO

/****** Object:  Table [dbo].[OrderDetail]   Script Date: 1/22/2024 06:06:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NULL,
	[ProductID] [int] NULL,
	[Quantity] [int] NULL,
	[Price] [decimal](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[OrderDetail]   Script Date: 1/22/2024 06:27:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OrderDate] [datetime] NULL,
	[DeliveryDate] [datetime] NULL,
	[PaymentStatus] [nvarchar](50) NULL,
	[CustomerID] [int] NULL,
	[Voucher] [int] NULL,
	[TransportFee] [decimal](18, 0),
	[DeliveryStatusID] [int] NULL,
	[Note] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[TrangThai]    Script Date: 1/22/2024 07:40:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeliveryStatus](
	[DeliveryStatusID] [int] IDENTITY(1,1) NOT NULL,
	[DeliveryStatusName] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[DeliveryStatusID] ASC
)
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Supplier]    Script Date: 1/22/2024 07:40:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[SupplierID] [int] IDENTITY(1,1) NOT NULL,
	[SupplierName] [nvarchar](150) NULL,
	[Address] [nvarchar](max) NULL,
	[Email] [nvarchar](250) NULL,
	[PhoneNumber] [varchar](20) NULL,
	[Fax] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[SupplierID] ASC
)) ON [PRIMARY]
GO 

/****** Object:  Table [dbo].[Producer]    Script Date: 1/22/2024 07:40:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producer](
	[ProducerID] [int] IDENTITY(1,1) NOT NULL,
	[ProducerName] [nvarchar](100) NULL,
	[Note] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[ProducerID] ASC
)
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[ImportCoupon]    Script Date: 1/22/2024 07:40:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImportCoupon](
	[CouponID] [int] IDENTITY(1,1) NOT NULL,
	[SupplierID] [int] NULL,
	[ImportDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[CouponID] ASC
)
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[ImportCouponDetail]    Script Date: 1/22/2024 07:40:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImportCouponDetail](
	[ImportCouponDetailID] [int] IDENTITY(1,1) NOT NULL,
	[CouponID] [int] NULL,
	[ProductID] [int] NULL,
	[Price] [decimal](18, 0) NULL,
	[Quantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ImportCouponDetailID] ASC
)
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[[Category]]    Script Date: 1/22/2024 07:40:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](150) NULL,
	[Icon] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Product]    Script Date: 1/22/2024 07:40:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](250) NULL,
	[Price] [decimal](18, 0) NULL,
	[UpdateDate] [datetime] NULL,
	[Decription] [nvarchar](max) NULL,
	[Image] [nvarchar](max) NULL,
	[Quantity] [int] NULL,
	[View] [int] NULL,
	[Discount] [decimal](18, 0) NULL,
	[Comment] [int] NULL,
	[SupplierID] [int] NULL,
	[ProducerID] [int] NULL,
	[CategoryID] [int] NULL,
	[Images1] [nvarchar](max) NULL,
	[Images2] [nvarchar](max) NULL,
	[Images3] [nvarchar](max) NULL,
	[Images4] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Comment]   Script Date: 6/14/2022 11:13:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[Content] [nvarchar](max) NULL,
	[Vote] int,
	[CustommerID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CustommerID] ASC,
	[ProductID] ASC
)
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Voucher]   Script Date: 6/14/2022 11:13:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Voucher](
    [VoucherID] [int] IDENTITY(1,1) NOT NULL,
    [VoucherCode] [nvarchar](50) NOT NULL,
    [Discount] [decimal](5, 2) NOT NULL,  -- Phần trăm giảm giá (ví dụ: 10000)
    [MinOrderAmount] [decimal](18, 0) NOT NULL,  -- Số tiền tối thiểu để áp dụng voucher (ví dụ: 100,000 đồng)
    [ExpirationDate] [datetime] NULL,  -- Ngày hết hạn (nếu có)
    PRIMARY KEY CLUSTERED ([VoucherID] ASC)
) ON [PRIMARY];
GO
------------- CONSTRAINT ----------------
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_Price]  DEFAULT ((0)) FOR [Price]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_Quantity]  DEFAULT ((1)) FOR [Quantity]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_Discount]  DEFAULT ((0)) FOR [Discount]
GO
ALTER TABLE [dbo].[Order] ADD  CONSTRAINT [DF_Order_OrderDate]  DEFAULT (getdate()) FOR [OrderDate]
GO
ALTER TABLE [dbo].[Order] ADD  CONSTRAINT [DF_Order_DeliveryDate]  DEFAULT (getdate()) FOR [DeliveryDate]
GO
ALTER TABLE [dbo].[Order] ADD  CONSTRAINT [DF_Order_PaymentStatus]  DEFAULT (N'COD') FOR [PaymentStatus]
GO
ALTER TABLE [dbo].[Order] ADD  CONSTRAINT [DF_Order_TransportFee]  DEFAULT ((0)) FOR [TransportFee]
GO
ALTER TABLE [dbo].[Order] ADD  CONSTRAINT [DF_Order_DeliveryStatusID]  DEFAULT ((0)) FOR [DeliveryStatusID]
GO