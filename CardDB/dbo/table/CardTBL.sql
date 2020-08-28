CREATE TABLE [dbo].[CardTBL]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [ElementType] VARCHAR(50) NOT NULL, 
    [ElementName] VARCHAR(50) NOT NULL, 
    [InSan] INT NULL, 
    [DeSan] INT NULL, 
    [IsForce] VARCHAR(50) NULL, 
    [IsInter] VARCHAR(50) NULL, 
    [ElementDes] VARCHAR(MAX) NULL
)
