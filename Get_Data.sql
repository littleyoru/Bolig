USE Bolig;


-- stored procedure to Get user data
GO
CREATE OR ALTER PROCEDURE GET_User @Userid INT
AS
    SELECT * FROM dbo.Users WHERE Id = @Userid;
GO
--EXEC GET_User  1


-- stored procedure to Residences

GO
CREATE OR ALTER PROCEDURE GET_Residences @Res_Available Date, @Res_Rooms INT,@Res_id INT
AS 
    SELECT * FROM dbo.Residences WHERE AvailableFrom = @Res_Available OR Rooms = @Res_Rooms OR id = @Res_id 
GO
--EXEC GET_Residences '2020-05-31', 4, 1

-- stored procedure to Residences Rent

GO
CREATE OR ALTER PROCEDURE GET_ResRent @Res_Rent INT
AS 
    SELECT * FROM dbo.Residences WHERE Rent < @Res_Rent 
GO
--EXEC GET_Residences 10000

-- stored procedure to Postcodes 

GO
CREATE OR ALTER PROCEDURE GET_PostCodeCity @Post INT, @_city NVARCHAR(50)
AS 
    SELECT * FROM dbo.PostCodes WHERE Code = @Post OR City = @_city
GO
--EXEC GET_Residences 8800, ''


-- stored procedure to Login 

GO
CREATE OR ALTER PROCEDURE GET_Login @User NVARCHAR(50)
AS 
    SELECT * FROM dbo.Logins INNER JOIN dbo.Users ON Logins.UserId = Users.Id WHERE Users.UserName = @User
GO
--EXEC GET_Login 'Mladen'




