
create table Affiliation
(
	Id int identity(1,1) primary key,
	InsertedIn datetime not null,
	UpdatedIn datetime,
	DeletedIn datetime,
	Name varchar(255) not null
)

create table Artist
(
	Id int identity(1,1) primary key,
	InsertedIn datetime not null,
	UpdatedIn datetime,
	DeletedIn datetime,
	Name varchar(255) not null
)

create table BalanceForce
(
	Id int identity(1,1) primary key,
	InsertedIn datetime not null,
	UpdatedIn datetime,
	DeletedIn datetime,
	CardId int not null,
	LegalityId int not null,
	Points int not null,
	ElitePoints int null,
	Health int not null
)

create table Card
(
	Id int identity(1,1) primary key,
	InsertedIn datetime not null,
	UpdatedIn datetime,
	DeletedIn datetime,
	Name varchar(255) not null,
	Text varchar(max),
	Number int not null,
	ArtistId int not null,
	AffiliationId int not null,
	FactionId int not null,
	ColorId int not null,
	RarityId int not null,
	DieId int,
	SetStarWarsId int not null,
	Url varchar(500) not null,
	DataCode varchar(255) not null,
	Cost int null,
	Points int null,
	ElitePoints int null,
	Health int null,
	IsCharacter bit not null
)

create table CardType
(
	Id int identity(1,1) primary key,
	InsertedIn datetime not null,
	UpdatedIn datetime,
	DeletedIn datetime,
	CardId int not null,
	TypeId int not null
)

create table Color
(
	Id int identity(1,1) primary key,
	InsertedIn datetime not null,
	UpdatedIn datetime,
	DeletedIn datetime,
	Name varchar(255) not null
)

create table DiceAction
(
	Id int identity(1,1) primary key,
	InsertedIn datetime not null,
	UpdatedIn datetime,
	DeletedIn datetime,
	Name varchar(255) not null
)

create table DiceFace
(
	Id int identity(1,1) primary key,
	InsertedIn datetime not null,
	UpdatedIn datetime,
	DeletedIn datetime,
	Value int not null,
	IsModifier bit not null,
	DiceActionId int not null,
	Cost int not null,
	DieId int not null
)

create table Die
(
	Id int identity(1,1) primary key,
	InsertedIn datetime not null,
	UpdatedIn datetime,
	DeletedIn datetime,
	CardId int not null
)

create table Faction
(
	Id int identity(1,1) primary key,
	InsertedIn datetime not null,
	UpdatedIn datetime,
	DeletedIn datetime,
	Name varchar(255) not null
)

create table Keyword
(
	Id int identity(1,1) primary key,
	InsertedIn datetime not null,
	UpdatedIn datetime,
	DeletedIn datetime,
	Name varchar(255) not null,
	Text varchar(max) not null
)

create table Legality
(
	Id int identity(1,1) primary key,
	InsertedIn datetime not null,
	UpdatedIn datetime,
	DeletedIn datetime,
	Name varchar(255) not null
)

create table Rarity
(
	Id int identity(1,1) primary key,
	InsertedIn datetime not null,
	UpdatedIn datetime,
	DeletedIn datetime,
	Name varchar(255) not null
)

create table SetStarWars
(
	Id int identity(1,1) primary key,
	InsertedIn datetime not null,
	UpdatedIn datetime,
	DeletedIn datetime,
	Name varchar(255) not null
)

create table Type
(
	Id int identity(1,1) primary key,
	InsertedIn datetime not null,
	UpdatedIn datetime,
	DeletedIn datetime,
	Name varchar(255) not null
)

alter table BalanceForce
add foreign key (CardId) references Card(id)

alter table BalanceForce
add foreign key (LegalityId) references Legality(id)

alter table Card
add foreign key (ArtistId) references Artist(id)

alter table Card
add foreign key (AffiliationId) references Affiliation(id)

alter table Card
add foreign key (FactionId) references Faction(id)

alter table Card
add foreign key (ColorId) references Color(id)

alter table Card
add foreign key (RarityId) references Rarity(id)

alter table Card
add foreign key (DieId) references Die(id)

alter table Card
add foreign key (SetStarWarsId) references SetStarWars(id)

alter table CharacterCard
add foreign key (CardId) references Card(id)

alter table NonCharacterCard
add foreign key (CardId) references Card(id)

alter table DiceFace
add foreign key (DiceActionId) references DiceAction(id)

alter table DiceFace
add foreign key (DieId) references Die(id)

alter table Die
add foreign key (CardId) references Card(id)

alter table CardType
add foreign key (CardId) references Card(id)

alter table CardType
add foreign key (TypeId) references Type(id)