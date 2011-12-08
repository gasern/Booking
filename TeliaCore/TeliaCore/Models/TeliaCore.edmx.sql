
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 12/06/2011 22:53:27
-- Generated from EDMX file: D:\Develope\Projects\TeliaCore\TeliaCore\TeliaCore\Models\TeliaCore.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TeliaCore];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_BookingContact_Booking]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BookingContact] DROP CONSTRAINT [FK_BookingContact_Booking];
GO
IF OBJECT_ID(N'[dbo].[FK_BookingContact_Contact]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BookingContact] DROP CONSTRAINT [FK_BookingContact_Contact];
GO
IF OBJECT_ID(N'[dbo].[FK_ContactMealOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MealOrders] DROP CONSTRAINT [FK_ContactMealOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_BookingMealOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MealOrders] DROP CONSTRAINT [FK_BookingMealOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_RoomBooking]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bookings] DROP CONSTRAINT [FK_RoomBooking];
GO
IF OBJECT_ID(N'[dbo].[FK_MealOrdersRefreshments]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RefreshmentItems] DROP CONSTRAINT [FK_MealOrdersRefreshments];
GO
IF OBJECT_ID(N'[dbo].[FK_RefreshmentItemProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RefreshmentItems] DROP CONSTRAINT [FK_RefreshmentItemProduct];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Bookings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bookings];
GO
IF OBJECT_ID(N'[dbo].[Contacts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Contacts];
GO
IF OBJECT_ID(N'[dbo].[MealOrders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MealOrders];
GO
IF OBJECT_ID(N'[dbo].[Rooms]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Rooms];
GO
IF OBJECT_ID(N'[dbo].[Products]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Products];
GO
IF OBJECT_ID(N'[dbo].[RefreshmentItems]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RefreshmentItems];
GO
IF OBJECT_ID(N'[dbo].[BookingContact]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BookingContact];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Bookings'
CREATE TABLE [dbo].[Bookings] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [StartDate] datetime  NOT NULL,
    [EndDate] datetime  NOT NULL,
    [StartTime] datetime  NOT NULL,
    [EndTime] datetime  NOT NULL,
    [Host] nvarchar(max)  NOT NULL,
    [RoomId] int  NOT NULL,
    [MealOrderWanted] bit  NOT NULL
);
GO

-- Creating table 'Contacts'
CREATE TABLE [dbo].[Contacts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [Initials] nvarchar(max)  NOT NULL,
    [PhoneNumber] int  NOT NULL,
    [MobileNumber] int  NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Department] nvarchar(max)  NOT NULL,
    [IsOnline] bit  NOT NULL,
    [LastOnline] datetime  NOT NULL,
    [CreateDate] datetime  NOT NULL,
    [UserName] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [RememberMe] bit  NULL
);
GO

-- Creating table 'MealOrders'
CREATE TABLE [dbo].[MealOrders] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CoffeeWanted] bit  NOT NULL,
    [TeaWanted] bit  NOT NULL,
    [NumberOfDiningGuests] smallint  NOT NULL,
    [DishWishServedAt] datetime  NOT NULL,
    [DepartmentCharged] nvarchar(max)  NOT NULL,
    [DepartmentCreditNumber] nvarchar(max)  NOT NULL,
    [TotalPrice] decimal(18,0)  NOT NULL,
    [ContactId] int  NOT NULL,
    [Booking_Id] int  NOT NULL
);
GO

-- Creating table 'Rooms'
CREATE TABLE [dbo].[Rooms] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Nr] smallint  NOT NULL,
    [Location] nvarchar(max)  NOT NULL,
    [NumberOfSeats] smallint  NOT NULL,
    [InternetAvailable] bit  NOT NULL,
    [ProjectorAvailable] bit  NOT NULL,
    [PhoneAvailable] bit  NOT NULL,
    [WhiteboardAvailable] bit  NOT NULL,
    [VideoconferenceAvailable] bit  NOT NULL
);
GO

-- Creating table 'Products'
CREATE TABLE [dbo].[Products] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Price] decimal(18,0)  NOT NULL,
    [Size] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'RefreshmentItems'
CREATE TABLE [dbo].[RefreshmentItems] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Quantity] int  NOT NULL,
    [MealOrdersId] int  NOT NULL,
    [Product_Id] int  NOT NULL
);
GO

-- Creating table 'BookingContact'
CREATE TABLE [dbo].[BookingContact] (
    [Booking_Id] int  NOT NULL,
    [Contact_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [PK_Bookings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Contacts'
ALTER TABLE [dbo].[Contacts]
ADD CONSTRAINT [PK_Contacts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MealOrders'
ALTER TABLE [dbo].[MealOrders]
ADD CONSTRAINT [PK_MealOrders]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Rooms'
ALTER TABLE [dbo].[Rooms]
ADD CONSTRAINT [PK_Rooms]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RefreshmentItems'
ALTER TABLE [dbo].[RefreshmentItems]
ADD CONSTRAINT [PK_RefreshmentItems]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Booking_Id], [Contact_Id] in table 'BookingContact'
ALTER TABLE [dbo].[BookingContact]
ADD CONSTRAINT [PK_BookingContact]
    PRIMARY KEY NONCLUSTERED ([Booking_Id], [Contact_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Booking_Id] in table 'BookingContact'
ALTER TABLE [dbo].[BookingContact]
ADD CONSTRAINT [FK_BookingContact_Booking]
    FOREIGN KEY ([Booking_Id])
    REFERENCES [dbo].[Bookings]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Contact_Id] in table 'BookingContact'
ALTER TABLE [dbo].[BookingContact]
ADD CONSTRAINT [FK_BookingContact_Contact]
    FOREIGN KEY ([Contact_Id])
    REFERENCES [dbo].[Contacts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BookingContact_Contact'
CREATE INDEX [IX_FK_BookingContact_Contact]
ON [dbo].[BookingContact]
    ([Contact_Id]);
GO

-- Creating foreign key on [ContactId] in table 'MealOrders'
ALTER TABLE [dbo].[MealOrders]
ADD CONSTRAINT [FK_ContactMealOrder]
    FOREIGN KEY ([ContactId])
    REFERENCES [dbo].[Contacts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ContactMealOrder'
CREATE INDEX [IX_FK_ContactMealOrder]
ON [dbo].[MealOrders]
    ([ContactId]);
GO

-- Creating foreign key on [Booking_Id] in table 'MealOrders'
ALTER TABLE [dbo].[MealOrders]
ADD CONSTRAINT [FK_BookingMealOrder]
    FOREIGN KEY ([Booking_Id])
    REFERENCES [dbo].[Bookings]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BookingMealOrder'
CREATE INDEX [IX_FK_BookingMealOrder]
ON [dbo].[MealOrders]
    ([Booking_Id]);
GO

-- Creating foreign key on [RoomId] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [FK_RoomBooking]
    FOREIGN KEY ([RoomId])
    REFERENCES [dbo].[Rooms]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RoomBooking'
CREATE INDEX [IX_FK_RoomBooking]
ON [dbo].[Bookings]
    ([RoomId]);
GO

-- Creating foreign key on [MealOrdersId] in table 'RefreshmentItems'
ALTER TABLE [dbo].[RefreshmentItems]
ADD CONSTRAINT [FK_MealOrdersRefreshments]
    FOREIGN KEY ([MealOrdersId])
    REFERENCES [dbo].[MealOrders]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_MealOrdersRefreshments'
CREATE INDEX [IX_FK_MealOrdersRefreshments]
ON [dbo].[RefreshmentItems]
    ([MealOrdersId]);
GO

-- Creating foreign key on [Product_Id] in table 'RefreshmentItems'
ALTER TABLE [dbo].[RefreshmentItems]
ADD CONSTRAINT [FK_RefreshmentItemProduct]
    FOREIGN KEY ([Product_Id])
    REFERENCES [dbo].[Products]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RefreshmentItemProduct'
CREATE INDEX [IX_FK_RefreshmentItemProduct]
ON [dbo].[RefreshmentItems]
    ([Product_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------