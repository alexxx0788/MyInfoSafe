-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
IF OBJECT_ID ( 'ShepherdDb.InsertOrder', 'P' ) IS NOT NULL   
    DROP PROCEDURE Purchasing.InsertOrder;  
GO 
Create  PROCEDURE InsertOrder(@UserId INT,@StockId INT,@Amount INT)
AS
BEGIN
DECLARE @StockPrice INT;
DECLARE @StockAmount INT;
SELECT @StockPrice=Price,@StockAmount=Amount FROM [Stock] WHERE StockId=@StockId;

DECLARE @Balance INT;
SELECT @Balance=Balance FROM [User] WHERE UserId=@UserId;

UPDATE [User] SET Balance=(@Balance-@StockPrice) WHERE UserId=@UserId

UPDATE [Stock] SET Amount=(Amount-@Amount) WHERE StockId=@StockId;

INSERT INTO [Order] (UserId,StockId,Price,DateTime,Amount) VALUES (@UserId,@StockId,@StockPrice,GETDATE(),@Amount)

END
GO
