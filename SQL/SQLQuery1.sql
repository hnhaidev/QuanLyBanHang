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
values (N'Hoàng Ngọc Hải','2000-10-09',N'Hà Tĩnh', '0987654456', 0) 
insert into Staff 
values (N'Trần Văn Hai Ngàn','2020-06-22',N'Bến Tre', '0377618046', 0) 
insert into Staff 
values (N'Trần Đình Trọng','1997-03-05',N'Thanh Hóa', '0876453221', 0) 
insert into Staff 
values (N'Đặng Tuấn Anh','1999-12-23',N'TP. Hồ Chí Minh', '0923453334', 0) 
insert into Staff 
values (N'Nguyễn Thị Bưởi','2000-05-24',N'Bến Tre', '0367453445', 1) 
insert into Staff 
values (N'Trần Nguyễn Tri Thức','2000-11-22',N'Bến Tre', '0343456765', 0) 
insert into Staff 
values (N'Trần Thanh Huyền','2000-07-11',N'Quảng Bình', '0377654332', 1)
insert into Staff 
values (N'Trần Thị Huỳnh Trâm','2000-03-30',N'Tiền Giang', '0945234321', 1)
insert into Staff 
values (N'Trần Thị Phương Dung','2000-04-22',N'Đồng Nai', '0233466865', 1)
insert into Staff 
values (N'Nguyễn Thị Phương Thảo','1998-03-12',N'Khánh Hòa', '0983456873', 1)
insert into Staff 
values (N'Nguyễn Ngọc Như Linh','2000-03-11',N'Khánh Hòa', '0365425632', 1)
insert into Staff 
values (N'Nguyễn Anh Dũng','1994-08-12',N'Ninh Thuận', '0913456987', 0)
insert into Staff 
values (N'Hoàng Tuấn Minh','1995-09-22',N'Đồng Nai', '0323333765', 0)
insert into Staff 
values (N'Trần Thiện An','1995-07-23',N'Long An', '0353232156', 0)
insert into Staff 
values (N'Phan Trung Kiên','2001-03-30',N'Cà Mau', '0333425674', 0)
insert into Staff 
values (N'Huỳnh Thị Hương','2000-07-12',N'Quãng Ngãi', '0343556785', 1)
insert into Staff 
values (N'Lê Huy','1992-08-10',N'Bình Dương', '0934081335', 0)
insert into Staff 
values (N'Nguyễn Huỳnh Thiên Lý','1999-09-15',N'Bình Dương', '0934081335', 0)

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
insert into ProductType
values (N'Tủ Lạnh') 
insert into ProductType
values (N'Máy Giặt') 
insert into ProductType
values (N'Máy Lạnh') 
insert into ProductType
values (N'Máy Ảnh') 
insert into ProductType
values (N'Công Cụ - Dụng Cụ') 
go

-- Bảng Product 
insert into Product 
values (1,N'Laptop Asus','12000',40) 
insert into Product 
values (1,N'Laptop HP','9000',45) 
insert into Product 
values (1,N'Laptop Dell','15000',50) 
insert into Product 
values (1,N'Laptop HP','9000',50) 
insert into Product 
values (1,N'Laptop Apple','20000',70) 
insert into Product 
values (1,N'Laptop Lenovo','16000',60) 
insert into Product 
values (1,N'Laptop Acer','9000',50) 
insert into Product 
values (1,N'Laptop MSI','10000',50) 
insert into Product 
values (1,N'Laptop LG','11000',40) 

insert into Product 
values (2,N'Điện Thoại Samsung','4000',40) 
insert into Product 
values (2,N'Điện Thoại iPhone','5000',50) 
insert into Product 
values (2,N'Điện Thoại OPPO','4000',50) 
insert into Product 
values (2,N'Điện Thoại Vsmart','3000',50) 
insert into Product 
values (2,N'Điện Thoại Vivo','4000',50) 
insert into Product 
values (2,N'Điện Thoại Realme','3000',50) 
insert into Product 
values (2,N'Điện Thoại Nokia','3500',50) 
insert into Product 
values (2,N'Điện Thoại Xiaomi','3500',50)

insert into Product 
values (3,N'TiVi Samsung','6000',25) 
insert into Product 
values (3,N'TiVi Sony','8000',40) 
insert into Product 
values (3,N'TiVi LG','6000',30) 
insert into Product 
values (3,N'TiVi TCL','6000',35) 
insert into Product 
values (3,N'TiVi Sharp','7000',25) 
insert into Product 
values (3,N'TiVi Casper','7000',40) 
insert into Product 
values (3,N'TiVi Panasonic','7000',35)


insert into Product 
values (4,N'Tủ Lạnh Samsung','9000',25) 
insert into Product 
values (4,N'Tủ Lạnh Panasonic','9000',40) 
insert into Product 
values (4,N'Tủ Lạnh Sharp','7000',30) 
insert into Product 
values (4,N'Tủ Lạnh AQUA','7000',35) 
insert into Product 
values (4,N'Tủ Lạnh Toshiba','8000',25) 
insert into Product 
values (4,N'Tủ Lạnh LG','7000',40) 
insert into Product 
values (4,N'Tủ Lạnh Hitachi','7000',35)
insert into Product 
values (4,N'Tủ Lạnh Electrolux','9000',40)

insert into Product 
values (5,N'Máy Giặt LG','9000',30)
insert into Product 
values (5,N'Máy Giặt Electrolux','9000',40)
insert into Product 
values (5,N'Máy Giặt Samsung','8000',30)
insert into Product 
values (5,N'Máy Giặt Toshiba','9000',45)
insert into Product 
values (5,N'Máy Giặt Panasonic','9000',50)
insert into Product 
values (5,N'Máy Giặt AQUA','9000',40)
insert into Product 
values (5,N'Máy Giặt Whirlpool','7000',40)
insert into Product 
values (5,N'Máy Giặt Sharp','7000',45)

insert into Product 
values (6,N'Máy Lạnh Panasonic','7000',45)
insert into Product 
values (6,N'Máy Lạnh Daikin','7000',50)
insert into Product 
values (6,N'Máy Lạnh Toshiba','5000',45)
insert into Product 
values (6,N'Máy Lạnh Casper','6000',45)
insert into Product 
values (6,N'Máy Lạnh LG','7000',60)
insert into Product 
values (6,N'Máy Lạnh Samsung','7000',45)
insert into Product 
values (6,N'Máy Lạnh Sharp','7000',45)

insert into Product 
values (7,N'Máy Ảnh Sony','3500',45)
insert into Product 
values (7,N'Máy Ảnh Canon','4000',45)
insert into Product 
values (7,N'Máy Ảnh Fujifim','3500',45)
insert into Product 
values (7,N'Máy Ảnh Nikon','3500',45)

insert into Product 
values (8,N'Máy khoan','500',45)
insert into Product 
values (8,N'Máy mài','400',45)
insert into Product 
values (8,N'Máy bơm nước','500',45)
insert into Product 
values (8,N'Máy phun xịt rửa','350',45)
insert into Product 
values (8,N'Thang nhôm','350',45)
insert into Product 
values (8,N'Máy may','1000',45)
insert into Product 
values (8,N'Két sắt','100',45)
go

-- Bảng Client
insert into Client 
values ('01',N'Ông Thọ',N'Nghệ An') 
insert into Client 
values ('02',N'Ông Phúc',N'Nghệ An') 
insert into Client 
values ('03',N'Ông Lộc',N'Nghệ An') 
insert into Client 
values ('04',N'Ông Bảo',N'Nghệ An') 
go

-- Bảng Bill
insert into Bill
values (1,'01',GETDATE())
insert into Bill
values (1,'02',GETDATE())
insert into Bill
values (1,'03',GETDATE())
insert into Bill
values (1,'04',GETDATE())
go

-- Bảng BillÌno
insert into BillInfo
values (1,1,2)
insert into BillInfo
values (1,2,1)
insert into BillInfo
values (2,5,1)
insert into BillInfo
values (3,10,2)
insert into BillInfo
values (3,15,1)
insert into BillInfo
values (4,1,1)
insert into BillInfo
values (4,15,1)
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
@clientPhone nvarchar(100), @staffId int
as
begin
	insert Bill (staffId , phoneNumber ,billDate)
	values (@staffId, @clientPhone , GETDATE())
end
go

-- Thêm BillInfo
create proc USP_InsertBillInfo
@billId int, @productId int, @amount int
as
begin
	insert BillInfo(billId, productId, amount)
	values(@billId, @productId, @amount)
end
go

-- hiển thị List sản phẩm
create proc USP_GetListProduct
@productTypeId int
as
begin
	select * from Product
	where productTypeId = @productTypeId and productAmount > 0;
end
go

-- xuất thông tin billInfo
alter proc USP_ExportBillInfo
as
begin
	declare @maxBillId int;
	select @maxBillId = MAX(Bill.billId) from Bill;

	select P.productName as N'Tên Sản Phẩm', BI.amount as N'Số Lượng',(p.productPrice * BI.amount) as N'Thành Tiền'
	from BillInfo as BI, Product as P, Bill as B
	where BI.billId = @maxBillId and BI.productId = P.productId and B.billId = @maxBillId
end
go
exec USP_ExportBillInfo

-- Hien thi thong tin Staff
create proc USP_ListStaff
as
begin
	select staffId as N'Mã Nhân Viên', staffName as N'Tên Nhân Viên', dateOfBirth as N'Ngày Sinh', address as N'Quê Quán', phoneNumber as N'Số ĐT', gender as N'Giới Tính'
	from Staff
end
go

-- Thêm nhân viên
create proc USP_InsertStaff
@staffName nvarchar(100), @dateOfBirth Date, @address nvarchar(100), @phoneNumber nvarchar(100), @gender bit
as
begin
	Insert into Staff
	Values (@staffName, @dateOfBirth, @address, @phoneNumber, @gender);
end
go

-- Sửa nhân viên
create proc USP_UpdateStaff
@id int, @staffName nvarchar(100), @dateOfBirth Date, @address nvarchar(100), @phoneNumber nvarchar(100), @gender bit
as
begin
	Update Staff
	set staffName = @staffName, dateOfBirth = @dateOfBirth, address = @address , phoneNumber = @phoneNumber, gender = @gender
	where staffId = @id;
end 
go

-- Tìm kiếm theo tên của nhân viên
create proc USP_SearchStaffByName
@staffName nvarchar(100)
as
begin
	select staffId as N'Mã Nhân Viên', staffName as N'Tên Nhân Viên', dateOfBirth as N'Ngày Sinh', address as N'Quê Quán', phoneNumber as N'Số ĐT', gender as N'Giới Tính'
	from Staff 
	where dbo.fuConvertToUnsign1(staffName) LIKE N'%' + dbo.fuConvertToUnsign1(@staffName) + '%'
end
go

-- Tìm kiếm theo tên của san phẩm
create proc USP_SearchProductByName
@productName nvarchar(100)
as
begin
	select productId as N'Mã Sản Phẩm', productName as N'Tên Sản Phẩm', productPrice as N'Giá', productAmount as 'Số lượng', productTypeId as N'Mã Loại Sản Phẩm' from Product where dbo.fuConvertToUnsign1(productName) LIKE N'%' + dbo.fuConvertToUnsign1(@productName) + '%'
end
go

-------------------------------- Bảng View Tính tổng tiền-------------------------
create View SumMoneyProduct as

	select BI.billId,P.productName as N'productName', BI.amount as N'amount', S.staffName as N'staffName', C.clientName as N'clientName', P.productPrice * BI.amount as N'SUMMoney'
	from BillInfo as BI, Product as P, Bill as B, Staff as S, Client as C
	where BI.productId = P.productId and B.staffId = S.staffId and B.phoneNumber = C.phoneNumber  and B.billId = BI.billId
go

alter View UV_SumMoney as
select CAST(B.billDate AS DATE) as dayPay,
	(select SUM(SUMMoney) from SumMoneyProduct  Where SumMoneyProduct.billId = B.billId) as moneyPay
	from Bill as B
go
alter proc USP_SumMoneyInDay
@dayPay nvarchar(10)
as
begin
	select CAST(dayPay AS DATE) as Ngay, sum(moneyPay) AS tien
	from UV_SumMoney
	where MONTH(dayPay) = @dayPay
	group by CAST(dayPay AS DATE) ORDER by CAST(dayPay AS DATE)
end
go


-- Hiển Thị Bill
create proc USP_GetListBill
as
begin
	select B.billId as N'Mã Bill', C.clientName as N'Tên Khách Hàng', S.staffName as N'Tên Nhân Viên',
	(select SUM(SUMMoney) from SumMoneyProduct  Where SumMoneyProduct.billId = B.billId) as N'Tổng Tiền'
	from Bill as B, Staff as S, Client as C
	where B.staffId = S.staffId and B.phoneNumber = C.phoneNumber
end
go