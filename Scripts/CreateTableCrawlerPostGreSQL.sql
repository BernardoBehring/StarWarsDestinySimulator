create table "RobotType"
(
	"Id" serial NOT NULL,
	"InsertedIn" timestamp not null,
	"UpdatedIn" timestamp,
	"DeletedIn" timestamp,
	"Name" character varying(255) not null,
	CONSTRAINT "PK_RobotType" PRIMARY KEY ("Id")
	
);

create table "Site"
(
	"Id" serial NOT NULL,
	"InsertedIn" timestamp not null,
	"UpdatedIn" timestamp,
	"DeletedIn" timestamp,
	"Name" character varying(255) not null,
	"Url" character varying(255) not null,
	CONSTRAINT "PK_Site" PRIMARY KEY ("Id")
);


create table "Status"
(
	"Id" serial NOT NULL,
	"InsertedIn" timestamp not null,
	"UpdatedIn" timestamp,
	"DeletedIn" timestamp,
	"Name" character varying(255) not null,
	CONSTRAINT "PK_Status" PRIMARY KEY ("Id")
);

create table "Robot"
(
	"Id" serial NOT NULL,
	"InsertedIn" timestamp not null,
	"UpdatedIn" timestamp,
	"DeletedIn" timestamp,
	"Name" character varying(255) not null,
	"RobotTypeId" int not null,
	"SiteId" int not null,
	CONSTRAINT "PK_Robot" PRIMARY KEY ("Id"),
	CONSTRAINT "FK_Robot_Site_SiteId" FOREIGN KEY ("SiteId") REFERENCES "Site" ("Id"),
	CONSTRAINT "FK_Robot_RobotType_RobotTypeId" FOREIGN KEY ("RobotTypeId") REFERENCES "RobotType" ("Id")
);




create table "Request"
(
	"Id" serial NOT NULL,
	"InsertedIn" timestamp not null,
	"UpdatedIn" timestamp,
	"DeletedIn" timestamp,
	"StatusId" int,
	"RobotId" int,
	"RegisterDate" timestamp not null,
	"StartDateExecution" timestamp,
	"EndDateExecution" timestamp,
	"Response" character varying(8000),
	"AttemptQty" int null,
	CONSTRAINT "PK_Request" PRIMARY KEY ("Id"),
	CONSTRAINT "FK_Request_Robot_RobotId" FOREIGN KEY ("RobotId") REFERENCES "Robot" ("Id"),
	CONSTRAINT "FK_Request_Status_StatusId" FOREIGN KEY ("StatusId") REFERENCES "Status" ("Id")
);





