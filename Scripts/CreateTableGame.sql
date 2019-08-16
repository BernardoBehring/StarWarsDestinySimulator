create table Action
(
	Id int identity(1,1) primary key,
	InsertedIn datetime not null,
	UpdatedIn datetime,
	DeletedIn datetime,
	Name varchar(255) not null
)

create table ActionPhase
(
	Id int identity(1,1) primary key,
	InsertedIn datetime not null,
	UpdatedIn datetime,
	DeletedIn datetime,
	RoundId int not null
)


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
	CardLegalityId int not null,
	Points int null,
	ElitePoints int null,
	Health int null
)

create table BattleField
(
	Id int identity(1,1) primary key,
	InsertedIn datetime not null,
	UpdatedIn datetime,
	DeletedIn datetime,
	GameId int not null,
	BattlefieldCardId int not null
)

create table Card
(
	Id int identity(1,1) primary key,
	InsertedIn datetime not null,
	UpdatedIn datetime,
	DeletedIn datetime,
	Name varchar(255) not null,
	Subtitle varchar(255) null,
	Text varchar(max),
	Number int not null,
	ArtistId int null,
	AffiliationId int not null,
	FactionId int not null,
	ColorId int not null,
	RarityId int not null,
	DieId int,
	SetStarWarsId int not null,
	Url varchar(500) not null,
	UrlImage varchar(500) null,
	DataCode varchar(255) not null,
	Points int null,
	ElitePoints int null,
	Health int null,
	Cost int null,
	IsCharacter bit not null,
	IsSuport bit not null,
	IsUpgrade bit not null,
	IsUnique bit null,
	Flavor varchar(max) null,
	Image varchar(max) null	
)

create table CardDeck
(
	Id int identity(1,1) primary key,
	InsertedIn datetime not null,
	UpdatedIn datetime,
	DeletedIn datetime,
	CardId int not null,
	DeckId int not null
)

create table CardLegality
(
	Id int identity(1,1) primary key,
	InsertedIn datetime not null,
	UpdatedIn datetime,
	DeletedIn datetime,
	CardId int not null,
	LegalityId int not null,
	IsLegal bit not null
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

create table Deck
(
	Id int identity(1,1) primary key,
	InsertedIn datetime not null,
	UpdatedIn datetime,
	DeletedIn datetime,
	Name varchar(255) not null,
	Url varchar(500) not null
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
	Value varchar(5) not null,
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

create table Effect
(
	Id int identity(1,1) primary key,
	InsertedIn datetime not null,
	UpdatedIn datetime,
	DeletedIn datetime,
	Name varchar(255) not null
)

create table Faction
(
	Id int identity(1,1) primary key,
	InsertedIn datetime not null,
	UpdatedIn datetime,
	DeletedIn datetime,
	Name varchar(255) not null
)

create table Game
(
	Id int identity(1,1) primary key,
	InsertedIn datetime not null,
	UpdatedIn datetime,
	DeletedIn datetime,
	BattleFieldId int,
	SetUpId int
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

create table Player
(
	Id int identity(1,1) primary key,
	InsertedIn datetime not null,
	UpdatedIn datetime,
	DeletedIn datetime,
	Name varchar(255) not null
)

create table PlayerGame
(
	Id int identity(1,1) primary key,
	InsertedIn datetime not null,
	UpdatedIn datetime,
	DeletedIn datetime,
	GameId int not null,
	PlayerId int not null,
	DeckId int not null
)

create table PlayerGameCharacterShield
(
	Id int identity(1,1) primary key,
	InsertedIn datetime not null,
	UpdatedIn datetime,
	DeletedIn datetime,
	SetUpId int not null,
	PlayerGameId int not null,
	CharacterCardId int not null,
	QtyShield int not null
)

create table PlayerGameIniciative
(
	Id int identity(1,1) primary key,
	InsertedIn datetime not null,
	UpdatedIn datetime,
	DeletedIn datetime,
	SetUpId int not null,
	PlayerGameId int not null,
	Iniciative int not null
)

create table PlayerRound
(
	Id int identity(1,1) primary key,
	InsertedIn datetime not null,
	UpdatedIn datetime,
	DeletedIn datetime,
	PlayerGameId int not null,
	RoundGameId int not null,
	Resources int not null
)

create table PlayerRoundCardInDiscard
(
	Id int identity(1,1) primary key,
	InsertedIn datetime not null,
	UpdatedIn datetime,
	DeletedIn datetime,
	PlayerRoundId int not null,
	CardId int not null
)

create table PlayerRoundCardInHand
(
	Id int identity(1,1) primary key,
	InsertedIn datetime not null,
	UpdatedIn datetime,
	DeletedIn datetime,
	PlayerRoundId int not null,
	CardId int not null
)

create table PlayerRoundCardInLimbo
(
	Id int identity(1,1) primary key,
	InsertedIn datetime not null,
	UpdatedIn datetime,
	DeletedIn datetime,
	PlayerRoundId int not null,
	CardId int not null
)

create table PlayerRoundCardInPlay
(
	Id int identity(1,1) primary key,
	InsertedIn datetime not null,
	UpdatedIn datetime,
	DeletedIn datetime,
	PlayerRoundId int not null,
	CardId int not null
)

create table PlayerRoundCardInPlayUpgrade
(
	Id int identity(1,1) primary key,
	InsertedIn datetime not null,
	UpdatedIn datetime,
	DeletedIn datetime,
	PlayerRoundCardInPlayId int not null,
	Exausted bit not null,
	CanBeExausted bit not null
)

create table PlayerRoundRolledDice
(
	Id int identity(1,1) primary key,
	InsertedIn datetime not null,
	UpdatedIn datetime,
	DeletedIn datetime,
	PlayerRoundId int not null,
	DieId int not null,
	DiceFaceId int not null
)

create table Rarity
(
	Id int identity(1,1) primary key,
	InsertedIn datetime not null,
	UpdatedIn datetime,
	DeletedIn datetime,
	Name varchar(255) not null
)

create table Round
(
	Id int identity(1,1) primary key,
	InsertedIn datetime not null,
	UpdatedIn datetime,
	DeletedIn datetime,
	UpkeepPhaseId int,
	ActionPhaseId int,
	BattleFieldClaimed bit not null,
	PlayerGameIdClaimedBattlefield int
)

create table RoundGame
(
	Id int identity(1,1) primary key,
	InsertedIn datetime not null,
	UpdatedIn datetime,
	DeletedIn datetime,
	RoundId int not null,
	GameId int not null
)

create table SetStarWars
(
	Id int identity(1,1) primary key,
	InsertedIn datetime not null,
	UpdatedIn datetime,
	DeletedIn datetime,
	Name varchar(255) not null
)

create table SetUp
(
	Id int identity(1,1) primary key,
	InsertedIn datetime not null,
	UpdatedIn datetime,
	DeletedIn datetime,
	BattlefieldChoosedId int not null,
	GameId int not null
)

create table Turn
(
	Id int identity(1,1) primary key,
	InsertedIn datetime not null,
	UpdatedIn datetime,
	DeletedIn datetime,
	Number int not null,
	ActionPhaseId int not null
)

create table Type
(
	Id int identity(1,1) primary key,
	InsertedIn datetime not null,
	UpdatedIn datetime,
	DeletedIn datetime,
	Name varchar(255) not null
)

create table UpkeepPhase
(
	Id int identity(1,1) primary key,
	InsertedIn datetime not null,
	UpdatedIn datetime,
	DeletedIn datetime,
	RoundId int not null
)

alter table CardLegality
add foreign key (CardId) references Card(id)

alter table CardLegality
add foreign key (LegalityId) references Legality(id)

alter table BalanceForce
add foreign key (CardLegalityId) references CardLegality(id)

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

alter table ActionPhase
add foreign key(RoundId) references Round(id)

alter table BattleField
add foreign key(GameId) references Game(id)

alter table BattleField
add foreign key(BattlefieldCardId) references Card(id)

alter table CardDeck
add foreign key(CardId) references Card(id)

alter table CardDeck
add foreign key(DeckId) references Deck(id)

alter table Game
add foreign key(BattleFieldId) references BattleField(id)

alter table Game
add foreign key(SetUpId) references SetUp(id)

alter table PlayerGame
add foreign key(GameId) references Game(id)

alter table PlayerGame
add foreign key(PlayerId) references Player(id)

alter table PlayerGame
add foreign key(DeckId) references Deck(id)

alter table PlayerRound
add foreign key(RoundGameId) references RoundGame(id)

alter table PlayerRound
add foreign key(PlayerGameId) references PlayerGame(id)

alter table PlayerRoundCardInHand
add foreign key(PlayerRoundId) references PlayerRound(id)

alter table PlayerRoundCardInHand
add foreign key(CardId) references Card(id)

alter table PlayerRoundCardInLimbo
add foreign key(PlayerRoundId) references PlayerRound(id)

alter table PlayerRoundCardInLimbo
add foreign key(CardId) references Card(id)

alter table PlayerRoundCardInPlay
add foreign key(PlayerRoundId) references PlayerRound(id)

alter table PlayerRoundCardInPlay
add foreign key(CardId) references Card(id)

alter table PlayerRoundCardInDiscard
add foreign key(PlayerRoundId) references PlayerRound(id)

alter table PlayerRoundCardInDiscard
add foreign key(CardId) references Card(id)

alter table PlayerRoundRolledDice
add foreign key(PlayerRoundId) references PlayerRound(id)

alter table PlayerRoundRolledDice
add foreign key(DieId) references Die(id)

alter table PlayerRoundRolledDice
add foreign key(DiceFaceId) references DiceFace(id)

alter table PlayerRoundCardInPlayUpgrade
add foreign key(PlayerRoundCardInPlayId) references PlayerRoundCardInPlay(id)

alter table Round
add foreign key(UpkeepPhaseId) references UpkeepPhase(id)

alter table Round
add foreign key(ActionPhaseId) references ActionPhase(id)

alter table Round
add foreign key(PlayerGameIdClaimedBattlefield) references PlayerGame(id)

alter table RoundGame
add foreign key(RoundId) references Round(id)

alter table RoundGame
add foreign key(GameId) references Game(id)

alter table PlayerGameIniciative
add foreign key(PlayerGameId) references PlayerGame(id)

alter table PlayerGameIniciative
add foreign key(SetUpId) references SetUp(id)

alter table PlayerGameCharacterShield
add foreign key(SetUpId) references SetUp(id)

alter table PlayerGameCharacterShield
add foreign key(PlayerGameId) references PlayerGame(id)

alter table PlayerGameCharacterShield
add foreign key(CharacterCardId) references Card(id)

alter table Turn
add foreign key (ActionPhaseId) references ActionPhase(id)

alter table UpkeepPhase
add foreign key (RoundId) references Round(id)

alter table SetUp
add foreign key (GameId) references Game(id)

alter table SetUp
add foreign key (BattlefieldChoosedId) references Battlefield(id)
