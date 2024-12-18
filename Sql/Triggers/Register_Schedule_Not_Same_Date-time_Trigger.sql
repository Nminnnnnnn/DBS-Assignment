USE [EducationSystemDB]
GO
CREATE TRIGGER trg_PreventDuplicateSchedule
ON Timetable
INSTEAD OF INSERT
AS
BEGIN
    -- Kiểm tra trùng lịch
    IF EXISTS (
        SELECT 1
        FROM Timetable AS t
        INNER JOIN Schedule AS s1 ON t.ScheduleId = s1.Id
        INNER JOIN Inserted AS i ON t.StudentId = i.StudentId
        INNER JOIN Schedule AS s2 ON i.ScheduleId = s2.Id
        WHERE 
            (s1.StartTime < s2.EndTime AND s1.EndTime > s2.StartTime) -- Thời gian bị trùng
    )
    BEGIN
        -- Ghi nhận lỗi nếu phát hiện lịch trùng
		PRINT N'Sinh viên đã đăng ký môn học trùng thời gian trong thời khóa biểu!';
        ROLLBACK TRANSACTION;
    END
    ELSE
    BEGIN
        -- Thêm bản ghi nếu không trùng
		PRINT N'Thêm lịch học thành công.';
        INSERT INTO Timetable (StudentId, ScheduleId)
        SELECT StudentId, ScheduleId
        FROM Inserted;
    END
END;
