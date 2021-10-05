CREATE TABLE reserve
(
	[ResId] INT NOT NULL PRIMARY KEY IDENTITY(1, 1), 
    [ClientName] VARCHAR(100) NULL, 
    [RoomNo] NUMERIC NULL, 
    [DateIn] date NULL, 
    [DateOut] date NULL
)
