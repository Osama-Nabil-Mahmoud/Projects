create database Library
use  Library 
create table Member(
	ID varchar(20) primary key,
	F_Name varchar(15),
	L_Name varchar(15),
	Address varchar(50),
	phone varchar(12)
)

create table publisher(
	p_ID varchar(15) primary key,
	name varchar (50),
	p_Address varchar(50)
)

create table books(
	B_ID varchar(20) primary key ,
	Title varchar(50),
	Author varchar (50),
	price DECIMAL(5,2) ,
	Availability varchar(20),
	P_ID varchar(15) FOREIGN KEY (P_ID) REFERENCES publisher(P_ID)

)

create table Borrowed_By(
	B_ID varchar(20) FOREIGN KEY (B_ID) REFERENCES Books(B_ID) ,
	M_ID varchar(20) FOREIGN KEY (M_ID) REFERENCES Member(ID) ,
	Due_Date varchar(20),
	Return_Date varchar(20),
	PRIMARY KEY (B_ID , M_ID)
)

Create view memberBorrow
	as
	select m.F_Name , m.L_Name ,m.phone ,b.Title as 'Book Name' , bb.Due_Date , bb.Return_Date 
	from Member m , Borrowed_By bb , books b
	where m.ID = bb.M_ID and bb.B_ID = b.B_ID
