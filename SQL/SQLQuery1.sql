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
	staffName nvarchar(100) not null,
	dateOfBirth date,
	address nvarchar(100),
	phoneNumber nvarchar(100),
	gender bit,
)
go

--------------------------------Tạo bảng Account--------------------------
create table Account
(
	staffId int not null,
	userName nvarchar(100) primary key,
	passWord nvarchar(100) not null,
	accountType int

	foreign key (staffId) references Staff(staffId) -- khóa ngoại
)
go

--------------------------------Tạo bảng Products--------------------------
create table ProductType
(
	productTypeId int identity primary key, -- khóa chính
	productTypeName nvarchar(100) not null
)
go

--------------------------------Tạo bảng Products--------------------------
create table Product
(
	productId int identity primary key, -- khóa chính
	productTypeId int not null,
	productName nvarchar(100) not null,
	productPrice float not null,
	productAmount int,
	
	foreign key (productTypeId) references ProductType(productTypeId) -- khóa ngoại
)
go

--------------------------------Tạo bảng Client--------------------------
create table Client
(
	phoneNumber nvarchar(100) primary key,-- khóa chính
	clientName nvarchar(100),
	address nvarchar(100),
)
go

--------------------------------Tạo bảng Bill--------------------------
create table Bill
(
	billId int identity primary key, -- khóa chính
	staffId int not null,
	phoneNumber nvarchar(100) not null,
	billDate date,

	
	foreign key (phoneNumber) references Client(phoneNumber), -- khóa ngoại
	foreign key (staffId) references Staff(staffId) -- khóa ngoại
)
go

--------------------------------Tạo bảng BillIfo--------------------------
create table BillInfo
(
	billId int not null,
	productId int not null,
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
values (1,'hai001','1962026656160185351301320480154111117132155', 0) 
insert into Account
values (2,'admin','1962026656160185351301320480154111117132155',1)
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
values (1,N'Laptop Asus','15000',10) 
insert into Product 
values (1,N'Laptop HP','15000',15) 
insert into Product 
values (2,N'Điện Thoại Lenovo','15000',20) 
insert into Product 
values (3,N'TiVi SSI','15000',25) 
go

-- Bảng Client
insert into Client 
values ('03333333',N'Ông Phúc',N'Nghệ An') 
insert into Client 
values ('03333334',N'Ông Phúc',N'Nghệ An') 
insert into Client 
values ('03333335',N'Ông Phúc',N'Nghệ An') 
go

-- Bảng Bill
insert into Bill 
values (1,'03333333','2020-10-10') 
insert into Bill 
values (2,'03333334','2020-10-10')
insert into Bill 
values (3,'03333335','2020-10-10')
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
Create proc USP_Account
as
begin
	select Staff.staffId as N'Mã Nhân Viên', userName as N'Tên Tài Khoản', staffName as N'Tên Nhân Viên', dateOfBirth as N'Ngày Sinh'
	,address as N'Địa Chỉ', accountType as N'Quản Lý'
	from Account, Staff
	where Account.staffId = Staff.staffId
end
go

-- Truy suất Products
create proc USP_Product
as
begin
	select productId as N'Mã Sản Phẩm', productName as N'Tên Sản Phẩm', productPrice as N'Giá', productAmount as 'Số lượng', productTypeId as N'Mã Loại Sản Phẩm'
	from Product
end
go

-- Tìm kiếm Product theo tên sản phẩm không dấu
CREATE FUNCTION [dbo].[fuConvertToUnsign1] 
( @strInput NVARCHAR(4000) ) 
RETURNS NVARCHAR(4000) 
AS 
BEGIN 
	IF @strInput IS NULL 
		RETURN @strInput 
	IF @strInput = '' 
		RETURN @strInput 
	DECLARE @RT NVARCHAR(4000) 
	DECLARE @SIGN_CHARS NCHAR(136) 
	DECLARE @UNSIGN_CHARS NCHAR (136) 
	SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' 
	DECLARE @COUNTER int 
	DECLARE @COUNTER1 int 
	SET @COUNTER = 1 WHILE (@COUNTER <=LEN(@strInput)) 
		BEGIN 
			SET @COUNTER1 = 1 WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) 
				BEGIN 
					IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) 
						BEGIN 
							IF @COUNTER=1 
								SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) 
							ELSE SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) 
							BREAK 
						END 
							SET @COUNTER1 = @COUNTER1 +1 
				END SET @COUNTER = @COUNTER +1 
		END SET @strInput = replace(@strInput,' ','-') 
	RETURN @strInput 
END
go

-- Truy suất Account
Create proc USP_SearchAccount
@userName nvarchar(100)
as
begin
	select Staff.staffId as N'Mã Nhân Viên', userName as N'Tên Tài Khoản' , staffName as N'Tên Nhân Viên', dateOfBirth as N'Ngày Sinh'
	,address as N'Địa Chỉ', accountType as N'Quản Lý'
	from Account, Staff
	where Account.staffId = Staff.staffId and userName = @userName
end
go

-- Thêm Bill
create proc USP_InsertBill
@clientPhone nvarchar(100)
as
begin
	insert Bill (staffId , phoneNumber ,billDate)
	values (2, @clientPhone,GETDATE())
end
go

-- Thêm BillInfo
create proc USP_InsertBillInfo
@billId int, @productId int, @amount int
as
begin
	
	begin
		insert BillInfo(billId, productId, amount)
		values(@billId, @productId, @amount)
	end
end
go

