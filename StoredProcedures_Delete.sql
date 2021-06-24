USE Bolig;


-- stored procedures for deleting a user
GO
CREATE OR ALTER PROCEDURE Delete_User @Id INT
AS
	DELETE FROM Users WHERE Id = @Id;


--call
GO
--EXEC Delete_User 1;



-- delete a residence
GO
CREATE OR ALTER PROCEDURE Delete_Residence @Id INT
AS
	DELETE FROM Residences WHERE Id = @Id;


--call
GO
--EXEC Delete_Residence 1;

