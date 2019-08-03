create table Request
(
	Id int identity(1,1) primary key,
	InsertedIn datetime not null,
	UpdatedIn datetime,
	DeletedIn datetime,
	StatusId int,
	RobotId int,
	RegisterDate datetime not null,
	StartDateExecution datetime,
	EndDateExecution datetime,
	Response varchar(max),
	AttemptQty int null
)

create table Robot
(
	Id int identity(1,1) primary key,
	InsertedIn datetime not null,
	UpdatedIn datetime,
	DeletedIn datetime,
	Name varchar(255) not null,
	RobotTypeId int not null,
	SiteId int not null
)

create table RobotType
(
	Id int identity(1,1) primary key,
	InsertedIn datetime not null,
	UpdatedIn datetime,
	DeletedIn datetime,
	Name varchar(255) not null
)

create table Site
(
	Id int identity(1,1) primary key,
	InsertedIn datetime not null,
	UpdatedIn datetime,
	DeletedIn datetime,
	Name varchar(255) not null,
	Url varchar(255) not null
)

create table Status
(
	Id int identity(1,1) primary key,
	InsertedIn datetime not null,
	UpdatedIn datetime,
	DeletedIn datetime,
	Name varchar(255) not null
)


alter table Request
add Foreign Key (RobotId) references Robot(id)

alter table Request
add Foreign Key (StatusId) references Status(id)

alter table Robot
add Foreign Key (SiteId) references Site(id)

alter table Robot
add Foreign Key (RobotTypeId) references RobotType(id)