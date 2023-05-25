create database DB_SIMS
use DB_SIMS
go
create table TBL_account(
	id int identity(1,1) not null , 
	username varchar(20) primary key not null , 
	password varchar(20) default '123456++' not null , 
	userstatus varchar(2) default '1' not null check(userstatus = '1' or userstatus ='0') ,
	usertype varchar(20) check (usertype = 'Student' or usertype = 'Staff') not null , 
	createdate date default current_timestamp , 
	createtime time default current_timestamp , 
	lastmodifieddate time default current_timestamp ,
	lastmodifiedtime time default current_timestamp ,
	createdby varchar(20)  , 
	lastmodifiedby varchar(20)  , 
	loginstatus varchar(2) default '1' check(loginstatus = '1' or loginstatus ='0')
)

go
create table TBL_role(
	id int identity(1,1) not null,
	roleid varchar(20) primary key ,
	rolename varchar(50) not null , 
	createdate date default current_timestamp , 
	createtime time default current_timestamp , 
	lastmodifieddate time default current_timestamp ,
	lastmodifiedtime time default current_timestamp ,
	createdby varchar(20)  , 
	lastmodifiedby varchar(20)  , 
	status varchar(2) default '1'
)
go
create table TBL_userrole(
	id int identity(1,1) not null ,
	userroleid varchar(20) primary key ,
	username varchar(20) foreign key references TBL_account(username) , 
	roleid varchar(20) foreign key references TBL_role(roleid) ,  
	assigneddate date default current_timestamp , 
	assignedtime time default current_timestamp , 
	lastassignedddate  date default current_timestamp , 
	lastassignedtime  time default current_timestamp , 
	assignedby varchar(20)  , 
	lastassignedby varchar(20)  , 
	status varchar(2) default '1'
)
go
create table TBL_menu(
	id int identity(1,1) not null , 
	menuid int primary key not null , 
	parentid int  not null , 
	menuname varchar(100) not null, 
	menulink varchar(100) ,
	description varchar(100) ,
	createdate date default current_timestamp , 
	createtime time default current_timestamp , 
	lastmodifieddate date default current_timestamp ,
	lastmodifiedtime time default current_timestamp ,
	createdby varchar(20)  , 
	lastmodifiedby varchar(20)  , 
	status varchar(2) default '1'
) 
go
create table TBL_usermenu(
	id int identity(1,1) primary key not null,
	username varchar(20) foreign key references TBL_account(username),
	menuId int  foreign key references TBL_menu(menuId), 
	status varchar(2) default '0' , 
	assigneddate date default current_timestamp , 
	lastassignedddate  date default current_timestamp , 
	assignedtime time default current_timestamp , 
	lastassignedtime  time default current_timestamp , 
	assignedby varchar(20)  , 
	lastassignedby varchar(20) , 
)
go
create table TBL_rolemenu(
	id int identity(1,1) primary key not null,
	roleid varchar(20) foreign key references TBL_role(roleid),
	menuId int  foreign key references TBL_menu(menuId), 
	status varchar(2) default '0' , 
	assigneddate date default current_timestamp , 
	lastassignedddate  date default current_timestamp , 
	assignedtime time default current_timestamp , 
	lastassignedtime  time default current_timestamp ,  
	assignedby varchar(20)  , 
	lastassignedby varchar(20)  , 
)

create table TBL_university(
	id int identity(1,1) not null , 
	univid varchar(20) primary key not null default 'MAU', 
	univname varchar(100) unique not null default 'Mekdela Amba university',
	createddate date default current_timestamp,
	createdtime time default current_timestamp,
	createdby varchar(20),
	modifieddate date default current_timestamp,
	modifiedtime time default current_timestamp,
	modifiedby varchar(20),
	status varchar(2) default '1' ,
	systid varchar(20),
	systname varchar(100)
)