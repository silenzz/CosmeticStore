 --Owner table
create table Owner (
ID int,
OwnerID varchar(255) primary key,
OwnerName varchar(255),
OwnerLoginID varchar(255),
OwnerPassword varchar(255),
OwnerEmail varchar(255),
OwnerAddress varchar(255),
OwnerPhone int,
OwnerGender int
);
--Manager table
create table Manager (
ID int,
ManagerID varchar(255) primary key,
ManagerName varchar(255),
ManagerLoginID varchar(255),
ManagerPassword varchar(255),
ManagerEmail varchar(255),
ManagerAddress varchar(255),
ManagerPhone int,
ManagerGender int,
);
--Staff table
create table Staff (
ID int,
StaffID varchar(255) primary key,
StaffName varchar(255),
StaffLoginID varchar(255),
StaffPassword varchar(255),
StaffEmail varchar(255),
StaffAddress varchar(255),
StaffPhone int,
StaffGender int,
);
--Customer Table
create table Customer (
ID int,
CustomerID varchar(255) primary key,
CustomerLoginID varchar(255),
CustomerPassword varchar(255),
CustomerName varchar(255),
CustomerGender int,
CustomerEmail varchar(255),
CustomerAddress varchar(255),
CustomerPhone int,
);
--Delivery Staff Table
create table DelStaff (
ID int,
DelID varchar(255) primary key,
DelName varchar(255),
DelLoginID varchar(255),
DelPassword varchar(255),
DelEmail varchar(255),
DelAddress varchar(255),
DelPhone int,
DelGender int,
VehicleNo int,
);
--Product Record Table
create table Product (
CosID int,
CosSKU varchar(255) primary key,
CosName varchar(255),
CosCom varchar(255),
CosPrice float,
CosExpiriedDate date,
CosQuantity int,
CosType varchar(32),
CosUnit varchar(16),
);
create table Caterogy (
ID int,
cateID varchar(255) primary key,
cateName varchar(255),
description varchar(255)
);
create table Bill (
BillID int primary key,
SellerName varchar(255),
BillAddress varchar(255),
BillDate varchar(255),
toAMT int
);
create table Income (
InID int primary key,
InAmount int,
InSeller varchar(255),
InDate varchar(255),
InNote varchar(255),
InUser varchar(255),
);
--drop table Manager
drop table Bill 
select * from bill
delete from Bill where BillID = 1
insert into Owner values(1, 'O01', 'Thach', 'admin', 'admin123', 'baothach722002@gmail.com', 'HCM', 0901196142, 0)
