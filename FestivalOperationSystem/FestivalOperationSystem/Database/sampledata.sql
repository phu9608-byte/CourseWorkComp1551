USE Comp1551Coursework
GO

-- Run this script right after databasescheme.sql.
-- IDs are fixed so the demo always starts from the same data.

SET IDENTITY_INSERT Genres ON
INSERT INTO Genres (GenreID, GenreName) VALUES
	(1, N'Pop'),
	(2, N'EDM'),
	(3, N'Rock'),
	(4, N'Jazz')
SET IDENTITY_INSERT Genres OFF
GO

SET IDENTITY_INSERT Categories ON
INSERT INTO Categories (CategoryID, CategoryName) VALUES
	(1, N'Food'),
	(2, N'Drinks'),
	(3, N'Snacks'),
	(4, N'T-Shirts'),
	(5, N'Posters'),
	(6, N'Accessories')
SET IDENTITY_INSERT Categories OFF
GO

SET IDENTITY_INSERT People ON
INSERT INTO People (PersonID, [Name], Telephone, Email, [Role], IsDeleted, DeletedAt) VALUES
	(1, N'Anna Lee', '0901234567', 'anna.lee@festival.com', 'Performer', 0, NULL),
	(2, N'Trương Vĩnh Ký', '0912345678', 'truong.vinhky@festival.com', 'Performer', 0, NULL),
	(3, N'Mark Davis', '+44 7700 900123', 'mark.davis@festival.com', 'Crew', 0, NULL),
	(4, N'Nguyễn Thị Linh', '0987654321', 'linh.nguyen@festival.com', 'Crew', 0, NULL),
	(5, N'Trần Văn Hòa', '0934567890', 'hoa.tran@festival.com', 'Vendor', 0, NULL),
	(6, N'Tom Baker', '+44 7700 900456', 'tom.baker@festival.com', 'Vendor', 0, NULL),
	-- Soft-deleted record, used to demonstrate the Restore feature
	(7, N'Joanna Smith', '0976543210', 'joanna.smith@festival.com', 'Crew', 1, '2026-11-20 10:00:00')
SET IDENTITY_INSERT People OFF
GO

INSERT INTO Performers (PersonID, Fee) VALUES
	(1, 5000.00),
	(2, 3500.00)

INSERT INTO PerformerGenres (PersonID, GenreID) VALUES
	(1, 1),
	(1, 2),
	(2, 3),
	(2, 4)
GO

INSERT INTO Crew (PersonID, HourlyRate, EmploymentType, WeeklyHours) VALUES
	(3, 18.50, 'FullTime', 40),
	(4, 15.00, 'PartTime', 16),
	(7, 14.00, 'PartTime', 10)
GO

INSERT INTO Vendors (PersonID, StallName) VALUES
	(5, N'Phở Hà Nội'),
	(6, N'Festival Merch')

INSERT INTO VendorCategories (PersonID, CategoryID) VALUES
	(5, 1),
	(5, 2),
	(5, 3),
	(6, 4),
	(6, 5),
	(6, 6)
GO
