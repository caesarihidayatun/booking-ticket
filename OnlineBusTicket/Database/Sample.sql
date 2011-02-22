CREATE DATABASE OnlineBus
GO
USE OnlineBus
GO
--CREATE TABLE CATEGORY----------------------------------------------------------------------------------------------------
--Store type of travel--
CREATE TABLE Category(
	CategoryID int IDENTITY(1,1) PRIMARY KEY,
	CategoryName nvarchar(50),
	Status bit
)
GO
--CREATE TABLE BUSTYPE-----------------------------------------------------------------------------------------------------
--Store type of bus--
CREATE TABLE BusType(
	BusTypeID int IDENTITY(1,1) PRIMARY KEY,
	[Type] nvarchar(50) NOT NULL,
	Status bit
)
GO
--CREATE TABLE BUS---------------------------------------------------------------------------------------------------------
--Store information buses--
CREATE TABLE Bus(
	BusPlate nvarchar(50) PRIMARY KEY,
	BusTypeID int NOT NULL,
	CategoryID int NOT NULL,
	BusName nvarchar(50) NOT NULL,
	Seat int NOT NULL,
	Status bit
)
GO
ALTER TABLE Bus
ADD CONSTRAINT fk_Bus_BusType
FOREIGN KEY (BusTypeID) REFERENCES BusType(BusTypeID)
ON DELETE CASCADE
ON UPDATE CASCADE
GO
ALTER TABLE Bus
ADD CONSTRAINT fk_Bus_Category
FOREIGN KEY (CategoryID) REFERENCES Category(CategoryID)
ON DELETE CASCADE
ON UPDATE CASCADE
GO
--CREATE TABLE ROUTER------------------------------------------------------------------------------------------------------
--Store information Routes--
CREATE TABLE Router(
	RouterID int IDENTITY(1,1) PRIMARY KEY,
	RouterName nvarchar(50) NOT NULL,
	StartPlace nvarchar(50) NOT NULL,
	DestinationPlace nvarchar(50) NOT NULL,
	Distance int NOT NULL,
	Description ntext,
	Status bit
)
GO
--CREATE TABLE LIST BUS----------------------------------------------------------------------------------------------------
--Store list information of buses to customer search--
CREATE TABLE ListBus(
	ListBusID int IDENTITY(1,1) PRIMARY KEY,
	RouterID int NOT NULL,
	BusPlate nvarchar(50) NOT NULL,
	Departure datetime NOT NULL,
	Arrival datetime NOT NULL,
	Price float NOT NULL,
	Status bit
)
GO
ALTER TABLE ListBus
ADD CONSTRAINT fk_ListBus_Router
FOREIGN KEY (RouterID) REFERENCES Router(RouterID)
ON DELETE CASCADE
ON UPDATE CASCADE
GO
ALTER TABLE ListBus
ADD CONSTRAINT fk_ListBus_Bus
FOREIGN KEY (BusPlate) REFERENCES Bus(BusPlate)
ON DELETE CASCADE
ON UPDATE CASCADE
GO
--CREATE TABLE PROMOTE-----------------------------------------------------------------------------------------------------
--Store type of discount charges--
CREATE TABLE Promote(
	PromoteID int IDENTITY(1,1) PRIMARY KEY,
	PromoteName nvarchar(50) NOT NULL,
	Discount int NOT NULL,
	Status bit
)
GO
--CREATE TABLE ACCOUNT-----------------------------------------------------------------------------------------------------
--Store information Admins, Employees, and customers
CREATE TABLE Account(
	AccountID int IDENTITY(1,1) PRIMARY KEY,
	UserName nvarchar(50),
	Password nvarchar(50),
	[Role] nvarchar(50),
	Birthday datetime,
	Sex nvarchar(50),
	IdentifyCode nvarchar(50) NOT NULL,
	FullName nvarchar(50),
	Address nvarchar(MAX) NOT NULL,
	Phone varchar(50),
	Email nvarchar(50) NOT NULL,
	Status bit
)
GO
--CREATE TABLE TICKET------------------------------------------------------------------------------------------------------
--Store information booking detail--
CREATE TABLE Ticket(
	TicketNo int IDENTITY(1,1) PRIMARY KEY,
	DateBooking datetime NOT NULL,
	ListBusID int NOT NULL,
	AccountID int NOT NULL,
	NumberSeat int NOT NULL,
	PromoteID int NOT NULL,
	TotalFees int,
	Status int
)
GO
ALTER TABLE Ticket
ADD CONSTRAINT fk_Ticket_Account
FOREIGN KEY (AccountID) REFERENCES Account(AccountID)
ON DELETE CASCADE
ON UPDATE CASCADE
GO
ALTER TABLE Ticket
ADD CONSTRAINT fk_Ticket_Promote
FOREIGN KEY (PromoteID) REFERENCES Promote(PromoteID)
ON DELETE CASCADE
ON UPDATE CASCADE
GO
ALTER TABLE Ticket
ADD CONSTRAINT fk_Ticket_ListBus
FOREIGN KEY (ListBusID) REFERENCES ListBus(ListBusID)
ON DELETE CASCADE
ON UPDATE CASCADE
GO
---------------------------------------------------------------------------------------------------------------------------
CREATE TABLE CancelCharge(
	CancelChargeNo int IDENTITY(1,1) PRIMARY KEY,
	CancelChargeName nvarchar(50) NOT NULL,
	PercentPrice int NOT NULL,
	DateCancel int NOT NULL,
	Status bit
)
GO
--CREATE TABLE PLACE-------------------------------------------------------------------------------------------------------
--Store place--
CREATE TABLE Place (
	PlaceID int IDENTITY(1,1) PRIMARY KEY,
	PlaceName nvarchar(50) NOT NULL,
)
GO
--CREATE TABLE NEWS--------------------------------------------------------------------------------------------------------
--Store news--
CREATE TABLE News(
	NewsId int IDENTITY(1,1) PRIMARY KEY,
	Title nvarchar(MAX),
	Description ntext,
	NewsContent ntext,
	Author nvarchar(50),
	Images varchar(200),
	NewsType int,
	Status bit
)
--INSERT VALUES TO TABLE---------------------------------------------------------------------------------------------------
GO
--CATEGORY--
INSERT INTO Category(CategoryName,Status) VALUES ('Travel','True')
INSERT INTO Category(CategoryName,Status) VALUES ('Picnic','True')
INSERT INTO Category(CategoryName,Status) VALUES ('Family','True')
GO
--BUSTYPE--
INSERT INTO BusType([Type],Status) VALUES ('Volvo, AC, Video','True')
INSERT INTO BusType([Type],Status) VALUES ('Hitech, AC','True')
INSERT INTO BusType([Type],Status) VALUES ('Volvo Semi Sleeper, AC, Video','True')
INSERT INTO BusType([Type],Status) VALUES ('Luxury','True')
INSERT INTO BusType([Type],Status) VALUES ('Express','True')
GO
--BUS--
INSERT INTO Bus VALUES ('30B - 4557','1','1','01','42','True');
INSERT INTO Bus VALUES ('30H - 4444','5','1','02','39','True');
INSERT INTO Bus VALUES ('30L - 3144','3','2','03','40','True')
INSERT INTO Bus VALUES ('30L - 3145','2','2','04','24','True')
INSERT INTO Bus VALUES ('16H - 1102','4','3','05','16','True')
INSERT INTO Bus VALUES ('16M - 9999','3','3','06','34','True')
GO
--ROUTER--
INSERT INTO Router VALUES ('Ha Noi - Bac Giang','Ha Noi','Bac Giang','60','Interprovincial','True')
INSERT INTO Router VALUES ('Ha Noi - Hai Phong','Ha Noi','Hai Phong','130','Interprovincial','True')
INSERT INTO Router VALUES ('Ha Noi - Nam Dinh','Ha Noi','Nam Dinh','120','Interprovincial','True')
INSERT INTO Router VALUES ('Ha Noi - Hai Duong','Ha Noi','Hai Duong','70','Interprovincial','True')
INSERT INTO Router VALUES ('Hai Phong - Thai Nguyen','Hai Phong','Thai Nguyen','300','Interprovincial','True')
INSERT INTO Router VALUES ('Hai Phong - Nam Dinh','Hai Phong','Nam Dinh','75','Interprovincial','True')
GO
--LISTBUS--
INSERT INTO ListBus VALUES ('1','30B - 4557',getdate(),dateadd(hh,2,getdate()),'60','True')
INSERT INTO ListBus VALUES ('2','30H - 4444',getdate(),dateadd(hh,5,getdate()),'100','True')
INSERT INTO ListBus VALUES ('3','30L - 3144',getdate(),dateadd(hh,10,getdate()),'95','True')
INSERT INTO ListBus VALUES ('4','30L - 3145',getdate(),dateadd(hh,3,getdate()),'75','True')
INSERT INTO ListBus VALUES ('5','16H - 1102',getdate(),dateadd(hh,4,getdate()),'150','True')
INSERT INTO ListBus VALUES ('6','16M - 9999',getdate(),dateadd(hh,8,getdate()),'55','True')
GO
--PROMOTE--
INSERT INTO Promote VALUES ('Under five old','100','True')
INSERT INTO Promote VALUES ('Five to twelve years old','50','True')
INSERT INTO Promote VALUES ('Twelve to fifty years old','0','True')
INSERT INTO Promote VALUES ('More than 50 years old','30','True')
GO
--ACCOUNT--
INSERT INTO Account VALUES ('tuyendn','abc12345','Admin','12/29/1987','Male','121772846','Tuyen Dang','Hai Ba Trung, Ha Noi','0985943948','dangngoctuyen@gmail.com','True')
INSERT INTO Account VALUES ('hoannk','abc12345','Admin','07/30/1986','Male','121884566','Hoan Nguyen','Cau Giay, Ha Noi','0988888888','hoannk307@gmail.com','True')
GO
--PLACE--
INSERT INTO Place VALUES ('Bac Giang')
INSERT INTO Place VALUES ('Bac Ninh')
INSERT INTO Place VALUES ('Cao Bang')
INSERT INTO Place VALUES ('Da Nang')
INSERT INTO Place VALUES ('Ha Noi')
INSERT INTO Place VALUES ('Hai Duong')
INSERT INTO Place VALUES ('Hai Phong')
INSERT INTO Place VALUES ('Hoa Binh')
INSERT INTO Place VALUES ('Hung Yen')
INSERT INTO Place VALUES ('Lang Son')
INSERT INTO Place VALUES ('Nghe An')
INSERT INTO Place VALUES ('Ninh Binh')
INSERT INTO Place VALUES ('Nam Dinh')
INSERT INTO Place VALUES ('Thai Nguyen')
INSERT INTO Place VALUES ('Thanh Hoa')
INSERT INTO Place VALUES ('Vinh Phuc')
INSERT INTO Place VALUES ('Yen Bai')
GO
--CancelCharge--
INSERT INTO CancelCharge VALUES ('More than 2 day',0,2,'True')
INSERT INTO CancelCharge VALUES ('More than 1 day',15,1,'True')
INSERT INTO CancelCharge VALUES ('More than 2 day',30,0,'True')





