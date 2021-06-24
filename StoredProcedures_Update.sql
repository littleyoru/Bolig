USE Bolig;


-- stored procedures for updating Logins table
-- 1. change password by giving a user id
GO
CREATE OR ALTER PROCEDURE Change_Password @NewPass NVARCHAR(50), @UserId INT
AS
	UPDATE Logins SET Password = @NewPass WHERE UserId = @UserId;


-- call
GO
--EXEC Change_Password 'Password2', 1;



-- 2. change password by giving user email
GO
CREATE OR ALTER PROCEDURE Change_Password_ByEmail @NewPass NVARCHAR(50), @UserEmail NVARCHAR(50)
AS
	
	UPDATE Logins SET Password = @NewPass WHERE UserId = (SELECT Id FROM Users WHERE Email = @UserEmail);


-- call
GO
--EXEC Change_Password_ByEmail 'Password3', 'elena@gmail.com';





-- stored procedures for editing information on users
-- change user email
GO
CREATE OR ALTER PROCEDURE Change_Email @UserId INT, @NewEmail NVARCHAR(50)
AS
	UPDATE Users SET Email = @NewEmail WHERE Id = @UserId;


-- call
GO
--EXEC Change_Email 1, 'elena10@gmail.com';



-- change username
GO
CREATE OR ALTER PROCEDURE Change_Username @UserId INT, @Name NVARCHAR(50)
AS
	UPDATE Users SET UserName = @Name WHERE Id = @UserId;


-- call
GO
--EXEC Change_Username 1, 'ElenaElena';





-- stored procedures for editing residence information
-- change residence title
GO
CREATE OR ALTER PROCEDURE Change_Title @Id INT, @title NVARCHAR(255)
AS
	UPDATE Residences SET Title = @title WHERE Id = @Id;


-- call
GO
--EXEC Change_Title 2, 'Newly added cozy apartment';




-- change rent amount of a residence
GO
CREATE OR ALTER PROCEDURE Change_Rent @Id INT, @rent INT
AS
	UPDATE Residences SET Rent = @rent WHERE Id = @Id;


-- call
GO
--EXEC Change_Rent 1, 10000;




-- change rent amount of apartments with a specific number of rooms, listed by a specific user
GO
CREATE OR ALTER PROCEDURE Change_Rent_ByRooms @NewRent INT, @RoomNo TINYINT, @UserId INT
AS
	UPDATE Residences SET Rent = @NewRent WHERE UserId = @UserId AND ResidenceType = 1 AND Rooms = @RoomNo;


-- call
GO
--EXEC Change_Rent_ByRooms 13500, 4, 1;
--EXEC Change_Rent_ByRooms 12000, 3, 1;




-- allow pets on all houses in a specific city listed by a specific user
GO
CREATE OR ALTER PROCEDURE Allow_Pets @UserId INT, @City NVARCHAR(50)
AS
	UPDATE Residences SET AllowPets = 1 WHERE ResidenceType = 3 AND PostCodeId = (SELECT Id FROM PostCodes WHERE City = @City);


-- call
GO
--EXEC Allow_Pets 1, 'Roskilde';




-- change utilities cost for a residence
GO
CREATE OR ALTER PROCEDURE Change_Utilities @Id INT, @NewCost INT
AS
	UPDATE Residences SET UtilitiesCost = @NewCost WHERE Id = @Id;


-- call
GO
--EXEC Change_Utilities 300, 2;

