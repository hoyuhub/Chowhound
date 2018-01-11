USE [FoodDB]
GO

INSERT INTO [dbo].[XCitys]
           ([Id]
           ,[Administrative1]
           ,[Administrative2]
           ,[AdministrativeE1]
           ,[AdministrativeE2]
           ,[CityLevel]
           ,[EName]
           ,[Name]
           ,[TimeZone])
     VALUES
           (<Id, nvarchar(450),>
           ,<Administrative1, nvarchar(max),>
           ,<Administrative2, nvarchar(max),>
           ,<AdministrativeE1, nvarchar(max),>
           ,<AdministrativeE2, nvarchar(max),>
           ,<CityLevel, nvarchar(max),>
           ,<EName, nvarchar(max),>
           ,<Name, nvarchar(max),>
           ,<TimeZone, nvarchar(max),>)
GO

