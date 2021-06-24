-- database creation
DROP DATABASE IF EXISTS Bolig;
CREATE DATABASE Bolig;
GO
USE Bolig;
GO

-- create tables

CREATE TABLE Residences
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	ResidenceType INT,  -- enum: Apartment = 1, TerraceHouse = 2, House = 3, Room = 4
	Title NVARCHAR(255),
	Rent INT NOT NULL,
	Size SMALLINT NOT NULL,
	Rooms TINYINT NOT NULL,
	AllowPets BIT,
	Street NVARCHAR(50) NOT NULL,
	PostCodeId INT NOT NULL,
	AvailableFrom DATETIME,
	RentDuration INT,
	PublishDate DATETIME NOT NULL,
	Deposit INT,
	UtilitiesCost INT,
	UserId INT NOT NULL
);

CREATE TABLE PostCodes
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Code INT UNIQUE NOT NULL,
	City NVARCHAR(50) NOT NULL
);

CREATE TABLE Users
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	UserName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50),
	Email NVARCHAR(50) UNIQUE NOT NULL
);

CREATE TABLE Logins
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Password NVARCHAR(50) NOT NULL,
	UserId INT NOT NULL
);