create database QuanLyBanHang
go

use QuanLyBanHang
go

-- Staff
-- Account
-- Product
-- Client
-- Bill
-- BillInfo

--------------------------------Tạo bảng Staff--------------------------
create table Staff
(
	staffId int identity primary key, -- khóa chính
	staffName nvarchar(100),
	dateOfBirth date,
	address nvarchar(100),
	phoneNumber nvarchar(100),
	gender bit,
)
go

--------------------------------Tạo bảng Account--------------------------
create table Account
(
	staffId int,
	userName nvarchar(100) primary key,
	passWord nvarchar(100),
	accountType bit

	foreign key (staffId) references Staff(staffId) -- khóa ngoại
)
go

--------------------------------Tạo bảng Products--------------------------
create table Product
(
	productId int identity primary key, -- khóa chính
	productName nvarchar(100),
	productPrice float,
	productType nvarchar(100)
)
go

--------------------------------Tạo bảng Client--------------------------
create table Client
(
	clientId int identity primary key, -- khóa chính
	clientName nvarchar(100),
	address nvarchar(100),
	phoneNumber nvarchar(100)
)
go

--------------------------------Tạo bảng Bill--------------------------
create table Bill
(
	billId int identity primary key, -- khóa chính
	clientId int,
	staffId int,
	billDate date,
	sumMoney float

	
	foreign key (clientId) references Client(clientId), -- khóa ngoại
	foreign key (staffId) references Staff(staffId) -- khóa ngoại
)
go

--------------------------------Tạo bảng BillIfo--------------------------
create table BillInfo
(
	billInfoId int identity primary key,
	billId int,
	productId int,
	amount int,

	foreign key (billId) references Bill(billId), -- khóa ngoại
	foreign key (productId) references Product(productId) -- khóa ngoại
)
go

--------------------------------Thêm dữ liệu vào từng bảng--------------------------
-- Bảng Staff
insert into Staff 
values (N'Hoàng Ngọc Hải','2020-10-09',N'Hà Tĩnh', '1101001', 0) 
insert into Staff 
values (N'Hoàng Ngọc Hải','2020-10-09',N'Hà Tĩnh', '1101001', 0) 
insert into Staff 
values (N'Hoàng Ngọc Hải','2020-10-09',N'Hà Tĩnh', '1101001', 0) 
insert into Staff 
values (N'Hoàng Ngọc Hải','2020-10-09',N'Hà Tĩnh', '1101001', 0) 
insert into Staff 
values (N'Hoàng Ngọc Hải','2020-10-09',N'Hà Tĩnh', '1101001', 0) 
insert into Staff 
values (N'Hoàng Ngọc Hải','2020-10-09',N'Hà Tĩnh', '1101001', 0) 
go

-- Bảng Account
insert into Account 
values (1,'hai001','1', 0) 
go

-- Bảng Product
insert into Product 
values (N'Laptop Asus','15000', 'Laptop') 
insert into Product 
values (N'Laptop HP','15000', 'Laptop') 
insert into Product 
values (N'Laptop Lenovo','15000', 'Laptop') 
insert into Product 
values (N'Laptop SSI','15000', 'Laptop') 
go

-- Bảng Client
insert into Client 
values (N'Ông Phúc',N'Nghệ An', '1101010') 
insert into Client 
values (N'Ông Phúc',N'Nghệ An', '1101010') 
insert into Client 
values (N'Ông Phúc',N'Nghệ An', '1101010') 
go

-- Bảng Bill
insert into Bill 
values (1,1,'2020-10-10',15000) 
insert into Bill 
values (2,1,'2020-10-10',15000)
insert into Bill 
values (3,2,'2020-10-10',15000)
go

-- Bảng BillInfo
insert into BillInfo
values (1,1,1)
go

SELECT * FROM Account WHERE userName = N'hai001' AND passWord = N'1' 
go