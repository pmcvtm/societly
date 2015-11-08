create table GameUsers
(
	Id uniqueidentifier not null,

	UserName	nvarchar(500) not null,
	Email		nvarchar(500) not null,
	Password	nvarchar(500) not null,
	PasswordSalt nvarchar(500) not null,

	constraint [PK_GameUsers] primary key clustered ([Id] asc)
)
GO

create table Socialites
(
	Id uniqueidentifier not null,
	FirstName	nvarchar(250) not null,
	LastName	nvarchar(250) not null,
	Birthday	date	not null,

	UserId uniqueidentifier not null,
	
	constraint [PK_Socialites] primary key clustered ([Id] asc)
)
GO
alter table Socialites add constraint [FK_Socialites_GameUsers] foreign key(UserId)
references GameUsers (Id)
Go

create table Places
(
	Id uniqueidentifier not null,
	Name		nvarchar(250) null,
	Latitude	int not null,
	Longitude	int not null,

	constraint [PK_Places] primary key clustered ([Id] asc)
)
GO

create table RawMaterials
(
	Id uniqueidentifier not null,
	Name		nvarchar(250) null,
	Description nvarchar(500) not null,

	constraint [PK_RawMaterials] primary key clustered ([Id] asc)
)
GO

create table RawMaterialSources
(
	Id uniqueidentifier not null,
	Name		nvarchar(250) null,
	Description nvarchar(500) not null,
	Quantity	int not null,

	MaterialId	uniqueidentifier not null,
	PlaceId		uniqueidentifier not null,

	constraint [PK_RawMaterialSources] primary key clustered ([Id] asc)
)
GO
alter table RawMaterialSources add constraint [FK_RawMaterialSources_RawMaterials] foreign key(MaterialId)
references RawMaterials (Id)
Go
alter table RawMaterialSources add constraint [FK_RawMaterialSources_Places] foreign key(PlaceId)
references Places (Id)

