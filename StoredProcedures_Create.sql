USE Bolig;


-- stored procedure to add a User
GO
CREATE OR ALTER PROCEDURE Add_User @UserName NVARCHAR(50), @LastName NVARCHAR(50), @Email NVARCHAR(50)
AS
	INSERT INTO Users VALUES (@UserName, @LastName, @Email);


-- add user call
GO
EXEC Add_User 'Elena', 'Ene', 'elena@gmail.com';


-- stored procedure to add a residence for rent
GO
CREATE OR ALTER PROCEDURE Add_Residence @UserId INT, @ResidenceType TINYINT, @Title NVARCHAR(255), @Rent INT, @Size SMALLINT, @Rooms TINYINT, @AllowPets BIT, @Street NVARCHAR(50), @PostCodeId INT, @AvailableFrom DATETIME, @RentDuration INT, @PublishDate DATETIME, @Deposit INT, @UtilitiesCost INT
AS
	INSERT INTO Residences 
	VALUES (@ResidenceType, @Title, @Rent, @Size, @Rooms, @AllowPets, @Street, @PostCodeId, @AvailableFrom, @RentDuration, @PublishDate, @Deposit, @UtilitiesCost, @UserId);



-- add residence call
GO
EXEC Add_Residence 1, 1, 'Lovely apartment in the center of the city', 12000, 110, 4, 0, 'Vesterbrogade 3, 1.th', 1, '2020/01/31', NULL, '2020/01/01', 36000, 800;
EXEC Add_Residence 1, 1, 'Lovely apartment in the shopping street', 11500, 100, 4, 1, 'Vesterbrogade 3, 1.tv', 1, '2020/01/31', NULL, '2020/01/01', 36000, 500;
EXEC Add_Residence 1, 3, 'Cozy house at the edge of city', 12700, 150, 4, 1, 'Randersvej 15', 1, '2020/01/31', NULL, '2020/01/01', 40000, 800;
EXEC Add_Residence 1, 1, 'Cozy apartment close to facilities', 10700, 100, 4, 1, 'Randersvej 7', 1, '2020/01/31', NULL, '2020/01/01', 20000, 700;




-- stored procedure to add city and post code
GO
CREATE OR ALTER PROCEDURE Add_City @PostCode INT, @City NVARCHAR(50)
AS
	INSERT INTO PostCodes VALUES (@PostCode, @City);



-- add cities with post codes
GO
EXEC Add_City 8800, 'Viborg';
EXEC Add_City 8830, 'Tjele';
EXEC Add_City 4000, 'Roskilde';
EXEC Add_City 4200, 'Slagelse';
EXEC Add_City 4400, 'Kalundborg';



-- stored procedure to create user login
GO
CREATE OR ALTER PROCEDURE Create_Login @UserId INT, @Pass NVARCHAR(50)
AS
	INSERT INTO Logins VALUES (@Pass, @UserId);


-- add login call
GO
EXEC Create_Login 1, 'Password1';



