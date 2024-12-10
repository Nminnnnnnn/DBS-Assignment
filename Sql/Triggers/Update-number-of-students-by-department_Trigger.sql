USE [EducationSystemDB]
GO
CREATE TRIGGER TR_UpdateDepartmentStats_Student
ON [Student]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @AffectedDepts TABLE (Department NVARCHAR(50));
    
    -- Lấy tất cả department có xảy ra thêm hoặc xoá department không trùng thêm vào bảng tạm lưu để xử lý
    INSERT INTO @AffectedDepts
    SELECT DISTINCT u.Department
    FROM [User] u
    INNER JOIN inserted i ON u.Id = i.UserId
    WHERE u.Department IS NOT NULL
    UNION
    SELECT DISTINCT u.Department
    FROM [User] u
    INNER JOIN deleted d ON u.Id = d.UserId
    WHERE u.Department IS NOT NULL;

    -- Cập nhật thống kê cho các Department bị ảnh hưởng
    UPDATE ds
    SET ds.TotalUsers = (
        SELECT COUNT(*)
        FROM [User] u
        INNER JOIN Student s ON u.Id = s.UserId
        WHERE u.Department = ds.Department AND u.Status = 'Active' AND s.LearningStatus = 'Active'
    ),
    ds.LastUpdated = GETDATE()
    FROM DepartmentStats ds
    WHERE ds.Department IN (SELECT Department FROM @AffectedDepts);

    -- Thêm mới các Department chưa có trong DepartmentStats
    INSERT INTO DepartmentStats (Department, TotalUsers, LastUpdated)
    SELECT 
        dept.Department,
        (
            SELECT COUNT(*)
            FROM [User] u
            INNER JOIN Student s ON u.Id = s.UserId
            WHERE u.Department = dept.Department AND u.Status = 'Active' AND s.LearningStatus = 'Active'
        ),
        GETDATE()
    FROM @AffectedDepts dept
    WHERE NOT EXISTS (
        SELECT 1
        FROM DepartmentStats ds
        WHERE ds.Department = dept.Department
    );
END