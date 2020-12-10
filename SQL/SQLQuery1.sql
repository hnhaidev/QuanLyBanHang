create database QuanLyBanHang
go

use QuanLyBanHang
go

-- Staff
-- Account
-- Product
-- ProductType
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
create table ProductType
(
	productTypeId int identity primary key, -- khóa chính
	productTypeName nvarchar(100)
)
go

--------------------------------Tạo bảng Products--------------------------
create table Product
(
	productId int identity primary key, -- khóa chính
	productTypeId int,
	productName nvarchar(100),
	productPrice float,
	
	foreign key (productTypeId) references ProductType(productTypeId) -- khóa ngoại
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
-- Bảng ProductType
insert into ProductType
values (N'Laptop') 
insert into ProductType
values (N'Điện Thoại') 
insert into ProductType
values (N'TiVi') 
go

-- Bảng Product
insert into Product 
values (1,N'Laptop Asus','15000') 
insert into Product 
values (1,N'Laptop HP','15000') 
insert into Product 
values (2,N'Điện Thoại Lenovo','15000') 
insert into Product 
values (3,N'TiVi SSI','15000') 
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


--------------------------------Tạo PROC để truy suất--------------------------
-- Truy suất Login
create proc USP_Login
@userName nvarchar(100),@passWord  nvarchar(100)
as
begin
	Select * from Account where userName = @userName and passWord = @passWord
end
go

-- Truy suất Account
create proc USP_Account
as
begin
	select userName as N'Tên Tài Khoản', passWord as N'Mật Khẩu', staffName as N'Tên Nhân Viên', dateOfBirth as N'Ngày Sinh'
	,address as N'Địa Chỉ', accountType as N'Chức Vụ'
	from Account, Staff
	where Account.staffId = Staff.staffId
end
go

-- Truy suất Products
create proc USP_Product
as
begin
	select productName as N'Tên Sản Phẩm', productPrice as N'Giá', productTypeName as N'Loại Sản Phẩm'
	from Product, ProductType
	where Product.productTypeId = ProductType.productTypeId
end
go