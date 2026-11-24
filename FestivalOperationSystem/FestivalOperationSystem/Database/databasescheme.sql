USE master
GO

IF DB_ID('Comp1551Coursework') IS NOT NULL
BEGIN
	ALTER DATABASE Comp1551Coursework SET SINGLE_USER WITH ROLLBACK IMMEDIATE
	DROP DATABASE Comp1551Coursework
END
GO

CREATE DATABASE Comp1551Coursework
GO

USE Comp1551Coursework
GO

CREATE TABLE People (	
	PersonID int PRIMARY KEY IDENTITY(1,1),
	[Name] nvarchar(100) NOT NULL,
	Telephone varchar(20) NOT NULL,
	Email varchar(255) NOT NULL UNIQUE,
	[Role] varchar(10) NOT NULL,
	IsDeleted bit NOT NULL DEFAULT 0,
	DeletedAt datetime2 NULL,
	CONSTRAINT CK_People_Role
	CHECK ([Role] IN ('Performer', 'Crew', 'Vendor')),
	CONSTRAINT CK_People_DeletedAt
	CHECK ((IsDeleted = 0 AND DeletedAt IS NULL)
		OR (IsDeleted = 1 AND DeletedAt IS NOT NULL))
);

CREATE TABLE Performers (
	PersonID int PRIMARY KEY,
	Fee decimal(10,2) NOT NULL,
	CONSTRAINT FK_Performers_People
	FOREIGN KEY (PersonID)
	REFERENCES People(PersonID),
	CONSTRAINT CK_Performers_Fee
	CHECK (Fee >= 0)
);

CREATE TABLE Crew (
	PersonID int PRIMARY KEY,
	HourlyRate decimal(8,2) NOT NULL,
	EmploymentType varchar(10) NOT NULL,
	WeeklyHours int NOT NULL,
	CONSTRAINT FK_Crew_People
	FOREIGN KEY (PersonID)
	REFERENCES People(PersonID),
	CONSTRAINT CK_Crew_HourlyRate
	CHECK (HourlyRate > 0),
	CONSTRAINT CK_Crew_EmploymentType
	CHECK (EmploymentType IN ('FullTime', 'PartTime')),
	CONSTRAINT CK_Crew_WeeklyHours
	CHECK ((EmploymentType = 'FullTime' AND WeeklyHours BETWEEN 25 AND 40)
		OR (EmploymentType = 'PartTime' AND WeeklyHours BETWEEN 1 AND 24))
);

CREATE TABLE Vendors (
	PersonID int PRIMARY KEY,
	StallName nvarchar(100) NOT NULL,
	CONSTRAINT FK_Vendors_People
	FOREIGN KEY (PersonID)
	REFERENCES People(PersonID)
);

CREATE TABLE Genres (
	GenreID int PRIMARY KEY IDENTITY(1,1),
	GenreName nvarchar(50) NOT NULL UNIQUE
);

CREATE TABLE Categories (
	CategoryID int PRIMARY KEY IDENTITY(1,1),
	CategoryName nvarchar(50) NOT NULL UNIQUE
);

CREATE TABLE PerformerGenres (
	PersonID int NOT NULL,
	GenreID int NOT NULL,
	CONSTRAINT PK_PerformerGenres
	PRIMARY KEY (PersonID, GenreID),
	CONSTRAINT FK_PerformerGenres_Performers
	FOREIGN KEY (PersonID)
	REFERENCES Performers(PersonID),
	CONSTRAINT FK_PerformerGenres_Genres
	FOREIGN KEY (GenreID)
	REFERENCES Genres(GenreID)
);

CREATE TABLE VendorCategories (
	PersonID int NOT NULL,
	CategoryID int NOT NULL,
	CONSTRAINT PK_VendorCategories
	PRIMARY KEY (PersonID, CategoryID),
	CONSTRAINT FK_VendorCategories_Vendors
	FOREIGN KEY (PersonID)
	REFERENCES Vendors(PersonID),
	CONSTRAINT FK_VendorCategories_Categories
	FOREIGN KEY (CategoryID)
	REFERENCES Categories(CategoryID)
);
GO

CREATE VIEW ActivePeople
AS
SELECT PersonID, [Name], Telephone, Email, [Role]
FROM People
WHERE IsDeleted = 0
GO