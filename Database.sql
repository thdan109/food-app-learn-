CREATE DATABASE QuanLyQuanCafe
GO

USE QuanLyQuanCafe
GO


CREATE TABLE TableFood
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Bàn chưa có tên',
	status NVARCHAR(100) NOT NULL DEFAULT N'Trống'	-- Trống || Có người
)
GO

CREATE TABLE Account
(
	UserName NVARCHAR(100) PRIMARY KEY,	
	DisplayName NVARCHAR(100) NOT NULL DEFAULT N'Ola la la',
	PassWord NVARCHAR(1000) NOT NULL DEFAULT 0,
	Type INT NOT NULL  DEFAULT 0, -- 1: admin && 0: staff,
	ID INT IDENTITY
)
GO

CREATE TABLE FoodCategory
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
	mota NVARCHAR(100) NOT NULL DEFAULT N'Mô tả danh mục',
)
GO

CREATE TABLE Food
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
	idCategory INT NOT NULL,
	price FLOAT NOT NULL DEFAULT 0
	
	FOREIGN KEY (idCategory) REFERENCES dbo.FoodCategory(id)
)
GO

CREATE TABLE Bill
(
	id INT IDENTITY PRIMARY KEY,
	DateCheckIn DATE NOT NULL DEFAULT GETDATE(),
	DateCheckOut DATE,
	idTable INT NOT NULL,
	status INT NOT NULL DEFAULT 0, -- 1: đã thanh toán && 0: chưa thanh toán
	totalPrice FLOAT ,
	discount INT NOT NULL DEFAULT 0
	FOREIGN KEY (idTable) REFERENCES dbo.TableFood(id)
)
GO

CREATE TABLE BillInfo
(
	id INT IDENTITY PRIMARY KEY,
	idBill INT NOT NULL,
	idFood INT NOT NULL,
	count INT NOT NULL DEFAULT 0
	
	FOREIGN KEY (idBill) REFERENCES dbo.Bill(id),
	FOREIGN KEY (idFood) REFERENCES dbo.Food(id)
)
GO


-- Thêm Account
INSERT INTO dbo.Account(UserName,DisplayName,PassWord ,Type) VALUES ( N'admin',N'admin',N'1', 1)
INSERT INTO dbo.Account(UserName,DisplayName,PassWord ,Type) VALUES ( N'K9',N'K9',N'1', 1)
INSERT INTO dbo.Account(UserName,DisplayName,PassWord ,Type) VALUES ( N'staff',N'staff',N'1', 0)
INSERT INTO dbo.Account(UserName,DisplayName,PassWord ,Type) VALUES ( N'123',N'123',N'1', 0)
INSERT INTO dbo.Account(UserName,DisplayName,PassWord ,Type) VALUES ( N'staff1',N'staff1',N'1', 0)
INSERT INTO dbo.Account(UserName,DisplayName,PassWord ,Type) VALUES ( N'1234',N'1234',N'1', 0)
GO

-- Thêm Category
INSERT dbo.FoodCategory(name) VALUES ( N'Cơm')
INSERT dbo.FoodCategory(name) VALUES ( N'Dạng sợi')
INSERT dbo.FoodCategory(name) VALUES ( N'Tráng miệng')
INSERT dbo.FoodCategory(name) VALUES ( N'Món cuốn')
INSERT dbo.FoodCategory(name) VALUES ( N'Nước')
INSERT dbo.FoodCategory(name) VALUES ( N'Xôi')
GO

-- Thêm Food
INSERT dbo.Food(name,idCategory,price ) VALUES ( N'Cơm đĩa', 1, 120000)
INSERT dbo.Food(name,idCategory,price ) VALUES ( N'Cơm hến', 1, 50000)
INSERT dbo.Food(name,idCategory,price ) VALUES ( N'Cơm lam', 1, 60000)
INSERT dbo.Food(name,idCategory,price ) VALUES ( N'Cơm tấm', 1, 60000)
INSERT dbo.Food(name,idCategory,price ) VALUES ( N'Cơm trắng', 1, 120000)
INSERT dbo.Food(name,idCategory,price ) VALUES ( N'Bánh canh', 2, 15000)
INSERT dbo.Food(name,idCategory,price ) VALUES ( N'Bún bò Huế', 2, 15000)
INSERT dbo.Food(name,idCategory,price ) VALUES ( N'Bún cá', 2, 15000)
INSERT dbo.Food(name,idCategory,price ) VALUES ( N'Bún chả', 2, 15000)
INSERT dbo.Food(name,idCategory,price ) VALUES ( N'Bún ốc', 2, 15000)
INSERT dbo.Food(name,idCategory,price ) VALUES ( N'Bún riêu cua', 2, 15000)
INSERT dbo.Food(name,idCategory,price ) VALUES ( N'Bún thịt nướng', 2, 15000)
INSERT dbo.Food(name,idCategory,price ) VALUES ( N'Chè đậu xanh', 3, 12000)
INSERT dbo.Food(name,idCategory,price ) VALUES ( N'Chè hạt sen', 3, 12000)
INSERT dbo.Food(name,idCategory,price ) VALUES ( N'Chè đậu trắng', 3, 12000)
INSERT dbo.Food(name,idCategory,price ) VALUES ( N'Sương sáo', 3, 12000)
INSERT dbo.Food(name,idCategory,price ) VALUES ( N'Sương sâm', 3, 12000)
INSERT dbo.Food(name,idCategory,price ) VALUES ( N'Sương sa', 3, 12000)
INSERT dbo.Food(name,idCategory,price ) VALUES ( N'Gỏi cá', 4, 12000)
INSERT dbo.Food(name,idCategory,price ) VALUES ( N'Gỏi cuốn', 4, 12000)
INSERT dbo.Food(name,idCategory,price ) VALUES ( N'Nem chua', 4, 12000)
INSERT dbo.Food(name,idCategory,price ) VALUES ( N'Chả giò', 4, 12000)
INSERT dbo.Food(name,idCategory,price ) VALUES ( N'Bò bía', 4, 12000)
INSERT dbo.Food(name,idCategory,price ) VALUES ( N'Bánh ướt', 4, 12000)
INSERT dbo.Food(name,idCategory,price ) VALUES ( N'Cafe', 5, 12000)
INSERT dbo.Food(name,idCategory,price ) VALUES ( N'Pepsi', 5, 12000)
INSERT dbo.Food(name,idCategory,price ) VALUES ( N'Sting', 5, 12000)
INSERT dbo.Food(name,idCategory,price ) VALUES ( N'7 Up', 5, 12000)
INSERT dbo.Food(name,idCategory,price ) VALUES ( N'Coca Cola lala', 5, 12000)
INSERT dbo.Food(name,idCategory,price ) VALUES ( N'Nước suối', 5, 12000)
INSERT dbo.Food(name,idCategory,price ) VALUES ( N'Xôi chiên', 6, 12000)
INSERT dbo.Food(name,idCategory,price ) VALUES ( N'Xôi đậu xanh', 6, 12000)
INSERT dbo.Food(name,idCategory,price ) VALUES ( N'Xôi gà', 6, 12000)
INSERT dbo.Food(name,idCategory,price ) VALUES ( N'Xôi gấc', 6, 12000)
INSERT dbo.Food(name,idCategory,price ) VALUES ( N'Xôi lá cẩm', 6, 12000)
INSERT dbo.Food(name,idCategory,price ) VALUES ( N'Xôi ngũ sắc', 6, 12000)
INSERT dbo.Food(name,idCategory,price ) VALUES ( N'Xôi vò', 6, 12000)
INSERT dbo.Food(name,idCategory,price ) VALUES ( N'Xôi đậu phộng', 6, 12000)


-- Thêm Table
INSERT dbo.TableFood(name, status) VALUES (N'Bàn 1', N'Trống')
INSERT dbo.TableFood(name, status) VALUES (N'Bàn 2', N'Trống')
INSERT dbo.TableFood(name, status) VALUES (N'Bàn 3', N'Trống')
INSERT dbo.TableFood(name, status) VALUES (N'Bàn 4', N'Trống')
INSERT dbo.TableFood(name, status) VALUES (N'Bàn 5', N'Trống')
INSERT dbo.TableFood(name, status) VALUES (N'Bàn 6', N'Trống')
INSERT dbo.TableFood(name, status) VALUES (N'Bàn 7', N'Trống')
INSERT dbo.TableFood(name, status) VALUES (N'Bàn 8', N'Trống')
INSERT dbo.TableFood(name, status) VALUES (N'Bàn 9', N'Trống')
INSERT dbo.TableFood(name, status) VALUES (N'Bàn 10', N'Trống')
INSERT dbo.TableFood(name, status) VALUES (N'Bàn 11', N'Trống')
INSERT dbo.TableFood(name, status) VALUES (N'Bàn 12', N'Trống')
INSERT dbo.TableFood(name, status) VALUES (N'Bàn 13', N'Trống')
INSERT dbo.TableFood(name, status) VALUES (N'Bàn 14', N'Trống')
INSERT dbo.TableFood(name, status) VALUES (N'Bàn 15', N'Trống')
INSERT dbo.TableFood(name, status) VALUES (N'Bàn 16', N'Trống')
INSERT dbo.TableFood(name, status) VALUES (N'Bàn 17', N'Trống')
INSERT dbo.TableFood(name, status) VALUES (N'Bàn 18', N'Trống')
INSERT dbo.TableFood(name, status) VALUES (N'Bàn 19', N'Trống')
INSERT dbo.TableFood(name, status) VALUES (N'Bàn 20', N'Trống')

-- PROC USP_GetTableList
CREATE PROC USP_GetTableList
AS SELECT * FROM dbo.TableFood
GO

-- PROC USP_GetListBillByDate
create PROC USP_GetListBillByDate
@checkIn date, @checkOut date
AS 
BEGIN
	SELECT t.name AS [Tên bàn], b.totalPrice AS [Tổng tiền], DateCheckIn AS [Ngày vào], DateCheckOut AS [Ngày ra], discount AS [Giảm giá]
	FROM dbo.Bill AS b,dbo.TableFood AS t
	WHERE DateCheckIn >= @checkIn AND DateCheckOut <= @checkOut AND b.status = 1
	AND t.id = b.idTable
END
GO

-- FUNC fuConvertToUnsign1
CREATE FUNCTION [dbo].[fuConvertToUnsign1] ( @strInput NVARCHAR(4000) ) RETURNS NVARCHAR(4000) AS BEGIN IF @strInput IS NULL RETURN @strInput IF @strInput = '' RETURN @strInput DECLARE @RT NVARCHAR(4000) DECLARE @SIGN_CHARS NCHAR(136) DECLARE @UNSIGN_CHARS NCHAR (136) SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' DECLARE @COUNTER int DECLARE @COUNTER1 int SET @COUNTER = 1 WHILE (@COUNTER <=LEN(@strInput)) BEGIN SET @COUNTER1 = 1 WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) BEGIN IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) BEGIN IF @COUNTER=1 SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) ELSE SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) BREAK END SET @COUNTER1 = @COUNTER1 +1 END SET @COUNTER = @COUNTER +1 END SET @strInput = replace(@strInput,' ','-') RETURN @strInput END
GO

-- PROC USP_InsertBill
CREATE PROC USP_InsertBill
@idTable INT
AS
BEGIN
	INSERT dbo.Bill 
	        ( DateCheckIn ,
	          DateCheckOut ,
	          idTable ,
	          status,
	          discount
	        )
	VALUES  ( GETDATE() , -- DateCheckIn - date
	          NULL , -- DateCheckOut - date
	          @idTable , -- idTable - int
	          0,  -- status - int
	          0
	        )
END
GO

-- PROC USP_InsertBillInfo
CREATE PROC USP_InsertBillInfo
@idBill INT, @idFood INT, @count INT
AS
BEGIN

	DECLARE @isExitsBillInfo INT
	DECLARE @foodCount INT = 1
	
	SELECT @isExitsBillInfo = id, @foodCount = b.count 
	FROM dbo.BillInfo AS b 
	WHERE idBill = @idBill AND idFood = @idFood

	IF (@isExitsBillInfo > 0)
	BEGIN
		DECLARE @newCount INT = @foodCount + @count
		IF (@newCount > 0)
			UPDATE dbo.BillInfo	SET count = @foodCount + @count WHERE idFood = @idFood
		ELSE
			DELETE dbo.BillInfo WHERE idBill = @idBill AND idFood = @idFood
	END
	ELSE
	BEGIN
		INSERT	dbo.BillInfo
        ( idBill, idFood, count )
		VALUES  ( @idBill, -- idBill - int
          @idFood, -- idFood - int
          @count  -- count - int
          )
	END
END
Go

-- PRO USP_SwitchTabel
CREATE PROC USP_SwitchTabel
@idTable1 INT, @idTable2 int
AS BEGIN

	DECLARE @idFirstBill int
	DECLARE @idSeconrdBill INT
	
	DECLARE @isFirstTablEmty INT = 1
	DECLARE @isSecondTablEmty INT = 1
	
	
	SELECT @idSeconrdBill = id FROM dbo.Bill WHERE idTable = @idTable2 AND status = 0
	SELECT @idFirstBill = id FROM dbo.Bill WHERE idTable = @idTable1 AND status = 0
	
	PRINT @idFirstBill
	PRINT @idSeconrdBill
	PRINT '-----------'
	
	IF (@idFirstBill IS NULL)
	BEGIN
		PRINT '0000001'
		INSERT dbo.Bill
		        ( DateCheckIn ,
		          DateCheckOut ,
		          idTable ,
		          status
		        )
		VALUES  ( GETDATE() , -- DateCheckIn - date
		          NULL , -- DateCheckOut - date
		          @idTable1 , -- idTable - int
		          0  -- status - int
		        )
		        
		SELECT @idFirstBill = MAX(id) FROM dbo.Bill WHERE idTable = @idTable1 AND status = 0
		
	END
	
	SELECT @isFirstTablEmty = COUNT(*) FROM dbo.BillInfo WHERE idBill = @idFirstBill
	
	PRINT @idFirstBill
	PRINT @idSeconrdBill
	PRINT '-----------'
	
	IF (@idSeconrdBill IS NULL)
	BEGIN
		PRINT '0000002'
		INSERT dbo.Bill
		        ( DateCheckIn ,
		          DateCheckOut ,
		          idTable ,
		          status
		        )
		VALUES  ( GETDATE() , -- DateCheckIn - date
		          NULL , -- DateCheckOut - date
		          @idTable2 , -- idTable - int
		          0  -- status - int
		        )
		SELECT @idSeconrdBill = MAX(id) FROM dbo.Bill WHERE idTable = @idTable2 AND status = 0
		
	END
	
	SELECT @isSecondTablEmty = COUNT(*) FROM dbo.BillInfo WHERE idBill = @idSeconrdBill
	
	PRINT @idFirstBill
	PRINT @idSeconrdBill
	PRINT '-----------'

	SELECT id INTO IDBillInfoTable FROM dbo.BillInfo WHERE idBill = @idSeconrdBill
	
	UPDATE dbo.BillInfo SET idBill = @idSeconrdBill WHERE idBill = @idFirstBill
	
	UPDATE dbo.BillInfo SET idBill = @idFirstBill WHERE id IN (SELECT * FROM IDBillInfoTable)
	
	DROP TABLE IDBillInfoTable
	
	IF (@isFirstTablEmty = 0)
		UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable2
		
	IF (@isSecondTablEmty= 0)
		UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable1
END
GO

-- TRIGGER UTG_UpdateBillInfo
CREATE TRIGGER UTG_UpdateBillInfo
ON dbo.BillInfo FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @idBill INT
	
	SELECT @idBill = idBill FROM Inserted
	
	DECLARE @idTable INT
	
	SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill AND status = 0	
	
	DECLARE @count INT
	SELECT @count = COUNT(*) FROM dbo.BillInfo WHERE idBill = @idBill
	
	IF (@count > 0)
	BEGIN
	
		PRINT @idTable
		PRINT @idBill
		PRINT @count
		
		UPDATE dbo.TableFood SET status = N'Có người' WHERE id = @idTable		
		
	END		
	ELSE
	BEGIN
	PRINT @idTable
		PRINT @idBill
		PRINT @count
	UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable	
	end
	
END
GO

-- TRIGGER UTG_UpdateBill
CREATE TRIGGER UTG_UpdateBill
ON dbo.Bill FOR UPDATE
AS
BEGIN
	DECLARE @idBill INT
	
	SELECT @idBill = id FROM Inserted	
	
	DECLARE @idTable INT
	
	SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill
	
	DECLARE @count int = 0
	
	SELECT @count = COUNT(*) FROM dbo.Bill WHERE idTable = @idTable AND status = 0
	
	IF (@count = 0)
		UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable
END
GO

-- PROC USP_Login
CREATE PROC USP_Login
@userName nvarchar(100), @passWord nvarchar(100)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE UserName = @userName AND PassWord = @passWord
END
GO

-- PROC USP_UpdateAccount
CREATE PROC USP_UpdateAccount
@userName NVARCHAR(100), @displayName NVARCHAR(100), @password NVARCHAR(100), @newPassword NVARCHAR(100)
AS
BEGIN
	DECLARE @isRightPass INT = 0
	
	SELECT @isRightPass = COUNT(*) FROM dbo.Account WHERE USERName = @userName AND PassWord = @password
	
	IF (@isRightPass = 1)
	BEGIN
		IF (@newPassword = NULL OR @newPassword = '')
		BEGIN
			UPDATE dbo.Account SET DisplayName = @displayName WHERE UserName = @userName
		END		
		ELSE
			UPDATE dbo.Account SET DisplayName = @displayName, PassWord = @newPassword WHERE UserName = @userName
	end
END
GO

--PROC USP_GetNumBillByDate
CREATE PROC USP_GetNumBillByDate
@checkIn date, @checkOut date
AS 
BEGIN
	SELECT COUNT(*)
	FROM dbo.Bill AS b,dbo.TableFood AS t
	WHERE DateCheckIn >= @checkIn AND DateCheckOut <= @checkOut AND b.status = 1
	AND t.id = b.idTable
END
GO

-- PROC USP_GetListBillByDateAndPage
CREATE PROC USP_GetListBillByDateAndPage
@checkIn date, @checkOut date, @page int
AS 
BEGIN
	DECLARE @pageRows INT = 10
	DECLARE @selectRows INT = @pageRows
	DECLARE @exceptRows INT = (@page - 1) * @pageRows
	
	;WITH BillShow AS( SELECT b.ID, t.name AS [Tên bàn], b.totalPrice AS [Tổng tiền], DateCheckIn AS [Ngày vào], DateCheckOut AS [Ngày ra], discount AS [Giảm giá]
	FROM dbo.Bill AS b,dbo.TableFood AS t
	WHERE DateCheckIn >= @checkIn AND DateCheckOut <= @checkOut AND b.status = 1
	AND t.id = b.idTable)
	
	SELECT TOP (@selectRows) * FROM BillShow WHERE id NOT IN (SELECT TOP (@exceptRows) id FROM BillShow)
END
GO

-- PROC USP_GetListBillByDateForReport
CREATE PROC USP_GetListBillByDateForReport
@checkIn date, @checkOut date
AS 
BEGIN
	SELECT t.name, b.totalPrice, DateCheckIn, DateCheckOut, discount
	FROM dbo.Bill AS b,dbo.TableFood AS t
	WHERE DateCheckIn >= @checkIn AND DateCheckOut <= @checkOut AND b.status = 1
	AND t.id = b.idTable
END
GO