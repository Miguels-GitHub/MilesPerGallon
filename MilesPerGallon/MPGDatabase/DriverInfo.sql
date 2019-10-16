CREATE TABLE [dbo].[DriverInfo]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Fname] NVARCHAR(50) NOT NULL, 
    [Lname] NVARCHAR(50) NOT NULL, 
    [CarModel] NVARCHAR(50) NOT NULL, 
    [MilesDriven] FLOAT NOT NULL, 
    [GallonsFilled] INT NOT NULL, 
    [FillupDate] DATE NOT NULL
)
